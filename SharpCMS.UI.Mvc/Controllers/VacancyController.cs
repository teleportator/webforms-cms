using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;
using SharpCMS.UI.Mvc.Models.Vacancies;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class VacancyController : ControllerBase
    {
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id)
        {
            SiteNodeView parentNode = GetSiteNode(id);
            var model = new VacancyCreateModel
                            {
                                ParentUrl = parentNode.Url,
                                ParentTitle = parentNode.Title,
                                Title = "Вакансия",
                                IsActive = true,
                                SortOrder = 500
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Create(Guid id, VacancyCreateModel model)
        {
            SiteNodeView parentNode = GetSiteNode(id);
            if (!ModelState.IsValid)
            {
                model.ParentUrl = parentNode.Url;
                model.ParentTitle = parentNode.Title;
                return View(model);
            }

            string vacancyUrl = CreateVacancy(id, model.Title, model.Abstract, model.Text,
                                              model.Keywords ?? String.Empty,
                                              model.Description ?? String.Empty, User.Identity.Name, model.IsActive,
                                              model.Employer,
                                              model.Responsibilities, model.Contact, model.Demands, model.Conditions,
                                              model.SortOrder, model.DisplayOnMainMenu, parentNode.Id,
                                              model.DisplayOnSideMenu);
            return Redirect(vacancyUrl);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Delete(Guid id)
        {
            SiteNodeView parentNode = GetSiteNode(id).ParentNode;
            DeleteVacancy(id);
            return Redirect(parentNode.Url);
        }

        public ActionResult Display(Guid id)
        {
            VacancyView vacancy = GetVacancy(id);
            var model = new VacancyDisplayModel
                            {
                                Id = id,
                                Conditions = GetCollectionFromField(vacancy.Conditions),
                                Contact = vacancy.Contact,
                                Demands = GetCollectionFromField(vacancy.Demands),
                                Employer = vacancy.Employer,
                                Responsibilities = GetCollectionFromField(vacancy.Responsibilities),
                                Text = vacancy.Text,
                                Title = vacancy.Title
                            };
            return View(model);
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id)
        {
            var currentNode = GetSiteNode(id);
            VacancyView vacancy = GetVacancy(id);
            var model = new VacancyEditModel
                            {
                                Abstract = vacancy.Abstract, 
                                Conditions = vacancy.Conditions,
                                Contact = vacancy.Contact,
                                CurrentUrl = currentNode.Url,
                                Demands = vacancy.Demands,
                                Description = vacancy.Description,
                                DisplayOnMainMenu = currentNode.DisplayOnMainMenu,
                                DisplayOnSideMenu = currentNode.DisplayOnSideMenu,
                                Employer = vacancy.Employer,
                                IsActive = vacancy.IsActive,
                                Keywords = vacancy.Keywords,
                                Responsibilities = vacancy.Responsibilities,
                                SortOrder = Int32.Parse(currentNode.SortOrder),
                                Text = vacancy.Text,
                                Title = vacancy.Title
                            };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public ActionResult Edit(Guid id, VacancyEditModel model)
        {
            var currentNode = GetSiteNode(id);
            if (!ModelState.IsValid)
            {
                model.CurrentUrl = currentNode.Url;
                return View(model);
            }

            SaveVacancy(id, model.Title, model.Abstract, model.Text, model.Keywords ?? String.Empty,
                        model.Description ?? String.Empty, User.Identity.Name, model.IsActive, model.Employer,
                        model.Contact, model.Responsibilities, model.Demands, model.Conditions, model.SortOrder,
                        model.DisplayOnMainMenu, model.DisplayOnSideMenu);

            return Redirect(currentNode.Url);
        }

        public ActionResult List(Guid id)
        {
            var model = new VacancyListModel
                            {
                                Id = id,
                                Vacancies = GetVacancyList(id)
                            };
            return View(model);
        }

        private string CreateVacancy(Guid parentId, string title, string @abstract, string text, string keywords,
                                     string description, string editor, bool isActive, string employer,
                                     string responsibilities, string contact, string demands, string conditions,
                                     int sortOrder, bool displayOnMainMenu, string parentNodeId,
                                     bool displayOnSideMenu)
        {
            var request = new AddVacancyRequest
                              {
                                  Abstract = @abstract,
                                  CreatedBy = editor,
                                  Description = description,
                                  IsActive = isActive,
                                  Keywords = keywords,
                                  ParentId = parentId.ToString(),
                                  Text = text,
                                  Title = title,
                                  Employer = employer,
                                  Responsibilities = responsibilities,
                                  Contact = contact,
                                  Demands = demands,
                                  Conditions = conditions,
                                  DisplayOnMainMenu = displayOnMainMenu,
                                  DisplayOnSideMenu = displayOnSideMenu,
                                  ParentNodeId = parentNodeId,
                                  SortOrder = sortOrder.ToString(),
                                  UrlPattern = "/vacancy/display/{0}"
                              };
            AddVacancyResponse response = ContentService.AddVacancy(request);

            return response.VacancyUrl;
        }

        private void DeleteVacancy(Guid id)
        {
            var deleteVacancyRequest = new DeleteVacancyRequest {Id = id.ToString()};
            ContentService.DeleteVacancy(deleteVacancyRequest);
        }

        private IEnumerable<string> GetCollectionFromField(string field)
        {
            return field.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
        }

        private VacancyView GetVacancy(Guid id)
        {
            var request = new FindVacancyRequest {Id = id.ToString()};
            return ContentService.FindVacancy(request).VacancyFound;
        }

        private IEnumerable<VacancyView> GetVacancyList(Guid id)
        {
            var request = new FindVacanciesRequest
                              {
                                  ShowInactive = AllowFullAccess,
                                  ParentId = id.ToString()
                              };
            return ContentService.FindVacancies(request).VacanciesFound;
        }

        private void SaveVacancy(Guid id, string title, string @abstract, string text,
                                 string keywords, string description, string editor, bool isActive,
                                 string employer, string contact, string responsibilities, string demands,
                                 string conditions, int sortOrder, bool displayOnMainMenu, bool displayOnSideMenu)
        {
            var request = new SaveVacancyRequest
                              {
                                  Abstract = @abstract,
                                  Description = description,
                                  Editor = editor,
                                  Id = id.ToString(),
                                  IsActive = isActive,
                                  Keywords = keywords,
                                  Text = text,
                                  Title = title,
                                  Employer = employer,
                                  Contact = contact,
                                  Responsibilities = responsibilities,
                                  Demands = demands,
                                  Conditions = conditions,
                                  DisplayOnMainMenu = displayOnMainMenu,
                                  DisplayOnSideMenu = displayOnSideMenu,
                                  SortOrder = sortOrder.ToString()
                              };
            
            ContentService.SaveVacancy(request);
        }
    }
}