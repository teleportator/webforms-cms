using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;
using SharpCMS.Presentation.IoC;

namespace SharpCMS.UI
{
    public partial class VacancyItem : DynamicPage, IVacancyItemPageView
    {
        #region Fields
        private IVacancyItemPagePresenter _presenter;
        private VacancyView _currentVacancy;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public VacancyView CurrentVacancy
        {
            set
            {
                if (value != null)
                {
                    _currentVacancy = value;

                    lblVacancyTitle.Text = _currentVacancy.Title;
                    lblVacancyText.Text = _currentVacancy.Text;
                    lblVacancyEmployer.Text = _currentVacancy.Employer;
                    lblVacancyContact.Text = _currentVacancy.Contact;
                    rptResponsibilities.DataSource = GetCollectionFromField(value.Responsibilities);
                    rptResponsibilities.DataBind();
                    rptDemands.DataSource = GetCollectionFromField(value.Demands);
                    rptDemands.DataBind();
                    rptConditions.DataSource = GetCollectionFromField(value.Conditions);
                    rptConditions.DataBind();
                }
                else
                {
                    TransferToErrorPage(StatusCode.FileNotFound);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new VacancyItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteVacancyItem_Click(object sender, EventArgs e)
        {
            _presenter.DeleteVacancyItem();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }

        private Dictionary<int, string> GetCollectionFromField(string field)
        {
            Dictionary<int, string> list = new Dictionary<int, string>();

            string[] listItems = field.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < listItems.Count(); i++)
            {
                list.Add(i, listItems[i]);
            }
            return list;
        }
        #endregion
    }
}