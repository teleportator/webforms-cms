using System;
using System.Linq;
using System.Web;
using SharpCMS.Infrastructure;
using SharpCMS.Model;
using SharpCMS.Service.Mappers;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Service
{
    public class ContentService
    {
        #region Fields

        private const string Key = "SharpCMS_SiteNodeHierarchy";
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly HttpContext _currentContext;
        private readonly IIdeaRepository _ideaRepository;
        private readonly INewsRepository _newsRepository;
        private readonly ISiteNodeRepository _siteNodeRepository;
        private readonly IUnitOfWork _uow;
        private readonly IVacancyRepository _vacancyRepository;

        #endregion

        #region .Ctor

        public ContentService(IArticleRepository articleRepository, ISiteNodeRepository siteNodeRepository,
                              INewsRepository newsRepository, ICompanyRepository companyRepository,
                              IIdeaRepository ideaRepository,
                              ICommentRepository commentRepository, IVacancyRepository vacancyRepository,
                              IAnnouncementRepository announcementRepository,
                              IUnitOfWork uow, HttpContext currentContext)
        {
            _articleRepository = articleRepository;
            _siteNodeRepository = siteNodeRepository;
            _currentContext = currentContext;
            _newsRepository = newsRepository;
            _companyRepository = companyRepository;
            _ideaRepository = ideaRepository;
            _commentRepository = commentRepository;
            _vacancyRepository = vacancyRepository;
            _announcementRepository = announcementRepository;
            _uow = uow;
        }

        #endregion

        #region Members

        private SiteNodeView SiteMap
        {
            get
            {
                SiteNodeView siteNodes;
                if (_currentContext.Cache[Key] != null)
                {
                    siteNodes = (SiteNodeView) _currentContext.Cache[Key];
                }
                else
                {
                    siteNodes = _siteNodeRepository.FindAll().ConvertToSiteNodeViews();
                    _currentContext.Cache.Insert(Key, siteNodes, null, DateTime.Now.AddMinutes(30), TimeSpan.Zero);
                }
                return siteNodes;
            }
        }

        #endregion

        #region Methods

        public AddArticleResponse AddArticle(AddArticleRequest request)
        {
            var response = new AddArticleResponse();
            var article = new Article
                              {
                                  Abstract = request.Abstract,
                                  Created = DateTime.Now,
                                  CreatedBy = request.CreatedBy,
                                  Description = request.Description,
                                  Id = Guid.NewGuid(),
                                  IsActive = request.IsActive,
                                  Keywords = request.Keywords,
                                  ParentId = new Guid(request.ParentId),
                                  Text = request.Text,
                                  Title = request.Title,
                                  Updated = DateTime.Now,
                                  UpdatedBy = request.CreatedBy
                              };
            _articleRepository.Add(article);

            var siteNode = new SiteNode
                               {
                                   ContentItemId = article.Id,
                                   DisplayOnMainMenu = request.DisplayOnMainMenu,
                                   DisplayOnSideMenu = request.DisplayOnSideMenu,
                                   Id = Guid.NewGuid(),
                                   IsActive = request.IsActive,
                                   ParentId = new Guid(request.ParentNodeId),
                                   SortOrder = Int32.Parse(request.SortOrder),
                                   Title = request.Title,
                                   Url = String.Format(request.UrlPattern, article.Id)
                               };
            _siteNodeRepository.Add(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.ArticleUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public DeleteArticleResponse DeleteArticle(DeleteArticleRequest request)
        {
            var response = new DeleteArticleResponse();
            Article article = _articleRepository.FindBy(new Guid(request.Id));
            _articleRepository.Remove(article);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            _siteNodeRepository.Remove(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.Success = true;

            return response;
        }

        public SaveArticleResponse SaveArticle(SaveArticleRequest request)
        {
            var response = new SaveArticleResponse();
            Article article = _articleRepository.FindBy(new Guid(request.Id));
            article.Abstract = request.Abstract;
            article.Description = request.Description;
            article.IsActive = request.IsActive;
            article.Keywords = request.Keywords;
            article.Text = request.Text;
            article.Title = request.Title;
            article.Updated = DateTime.Now;
            article.UpdatedBy = request.Editor;
            _articleRepository.Save(article);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            siteNode.Title = request.Title;
            siteNode.DisplayOnMainMenu = request.DisplayOnMainMenu;
            siteNode.DisplayOnSideMenu = request.DisplayOnSideMenu;
            siteNode.SortOrder = Int32.Parse(request.SortOrder);
            siteNode.IsActive = request.IsActive;
            _siteNodeRepository.Save(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.ArticleUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public FindArticleResponse FindArticle(FindArticleRequest request)
        {
            var response = new FindArticleResponse();
            Article article = _articleRepository.FindBy(new Guid(request.Id));
            if (article != null)
            {
                response.ArticleFound = article.ConvertToArticleView();
            }
            response.Success = true;

            return response;
        }

        public FindChildArticlesResponse FindArticles(FindChildArticlesRequest request)
        {
            var response = new FindChildArticlesResponse
                               {
                                   ArticlesFound = request.ShowInactive
                                                       ? _articleRepository.FindAll(new Guid(request.ParentId))
                                                             .OrderBy(n => n.Title)
                                                             .ConvertToArticleViewCollection()
                                                       : _articleRepository.FindAllPublished(new Guid(request.ParentId))
                                                             .OrderBy(n => n.Title)
                                                             .ConvertToArticleViewCollection(),
                                   Success = true
                               };

            return response;
        }

        public FindMainMenuNodesResponse FindMainMenuNodes(FindMainMenuNodesRequest request)
        {
            var response = new FindMainMenuNodesResponse
                               {
                                   NodesFound =
                                       FindMainMenuNodes(request.Recursive ? SiteMap : FindNodeBy(request.NodeId),
                                                         request.ShowInactive, request.Recursive),
                                   Success = true
                               };

            return response;
        }

        public FindNodesResponse FindNode(FindNodesRequest request)
        {
            var response = new FindNodesResponse
                               {
                                   NodeFound = request.All
                                                   ? SiteMap
                                                   : FindNodeByItemIdRecursively(SiteMap, request.ContentItemId),
                                   Success = true
                               };

            return response;
        }

        public AddNewsResponse AddNews(AddNewsRequest request)
        {
            var response = new AddNewsResponse();
            var news = new News
                           {
                               Abstract = request.Abstract,
                               Created = DateTime.Now,
                               CreatedBy = request.CreatedBy,
                               Description = request.Description,
                               Id = Guid.NewGuid(),
                               IsActive = request.IsActive,
                               Keywords = request.Keywords,
                               ParentId = new Guid(request.ParentId),
                               Text = request.Text,
                               Title = request.Title,
                               Updated = DateTime.Now,
                               UpdatedBy = request.CreatedBy,
                               PublishedDate = DateTime.Parse(request.PublishedDate)
                           };
            _newsRepository.Add(news);

            var siteNode = new SiteNode
                               {
                                   ContentItemId = news.Id,
                                   DisplayOnMainMenu = request.DisplayOnMainMenu,
                                   DisplayOnSideMenu = request.DisplayOnSideMenu,
                                   Id = Guid.NewGuid(),
                                   IsActive = request.IsActive,
                                   ParentId = new Guid(request.ParentNodeId),
                                   SortOrder = Int32.Parse(request.SortOrder),
                                   Title = request.Title,
                                   Url = String.Format(request.UrlPattern, news.Id)
                               };
            _siteNodeRepository.Add(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.NewsUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public DeleteNewsResponse DeleteNews(DeleteNewsRequest request)
        {
            var response = new DeleteNewsResponse();
            News news = _newsRepository.FindBy(new Guid(request.Id));
            _newsRepository.Remove(news);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            _siteNodeRepository.Remove(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.Success = true;

            return response;
        }

        public SaveNewsResponse SaveNews(SaveNewsRequest request)
        {
            var response = new SaveNewsResponse();
            News news = _newsRepository.FindBy(new Guid(request.Id));
            news.Abstract = request.Abstract;
            news.Description = request.Description;
            news.IsActive = request.IsActive;
            news.Keywords = request.Keywords;
            news.Text = request.Text;
            news.Title = request.Title;
            news.Updated = DateTime.Now;
            news.UpdatedBy = request.Editor;
            news.PublishedDate = DateTime.Parse(request.PublishedDate);
            _newsRepository.Save(news);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            siteNode.Title = request.Title;
            siteNode.DisplayOnMainMenu = request.DisplayOnMainMenu;
            siteNode.DisplayOnSideMenu = request.DisplayOnSideMenu;
            siteNode.SortOrder = Int32.Parse(request.SortOrder);
            siteNode.IsActive = request.IsActive;
            _siteNodeRepository.Save(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.NewsUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public FindNewsResponse FindNews(FindNewsRequest request)
        {
            var response = new FindNewsResponse();
            News news = _newsRepository.FindBy(new Guid(request.Id));
            if (news != null)
            {
                response.NewsFound = news.ConvertToNewsView();
            }
            response.Success = true;

            return response;
        }

        public FindNewsCollectionResponse FindNewsCollection(FindNewsCollectionRequest request)
        {
            var response = new FindNewsCollectionResponse();
            if (request.ShowUnpublished)
            {
                response.NewsFound =
                    _newsRepository.FindAll(new Guid(request.ParentId)).OrderByDescending(n => n.PublishedDate)
                        .ConvertToNewsViewCollection();
            }
            else
            {
                response.NewsFound = _newsRepository.FindAllPublished(new Guid(request.ParentId))
                    .OrderByDescending(n => n.PublishedDate).ConvertToNewsViewCollection();
            }
            response.Success = true;

            return response;
        }

        public AddCompanyResponse AddCompany(AddCompanyRequest request)
        {
            var response = new AddCompanyResponse();
            var company = new Company
                              {
                                  Abstract = request.Abstract,
                                  Created = DateTime.Now,
                                  CreatedBy = request.CreatedBy,
                                  Description = request.Description,
                                  Id = Guid.NewGuid(),
                                  IsActive = request.IsActive,
                                  Keywords = request.Keywords,
                                  ParentId = new Guid(request.ParentId),
                                  Text = request.Text,
                                  Title = request.Title,
                                  Updated = DateTime.Now,
                                  UpdatedBy = request.CreatedBy,
                                  Logo = request.Logo,
                                  PhoneNumber = request.PhoneNumber,
                                  Address = request.Address,
                                  Email = request.Email,
                                  Hyperlink = request.Hyperlink
                              };
            _companyRepository.Add(company);

            var siteNode = new SiteNode
                               {
                                   ContentItemId = company.Id,
                                   DisplayOnMainMenu = request.DisplayOnMainMenu,
                                   DisplayOnSideMenu = request.DisplayOnSideMenu,
                                   Id = Guid.NewGuid(),
                                   IsActive = request.IsActive,
                                   ParentId = new Guid(request.ParentNodeId),
                                   SortOrder = Int32.Parse(request.SortOrder),
                                   Title = request.Title,
                                   Url = String.Format(request.UrlPattern, company.Id)
                               };
            _siteNodeRepository.Add(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.CompanyUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public DeleteCompanyResponse DeleteCompany(DeleteCompanyRequest request)
        {
            var response = new DeleteCompanyResponse();
            Company company = _companyRepository.FindBy(new Guid(request.Id));
            _companyRepository.Remove(company);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            _siteNodeRepository.Remove(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.Success = true;

            return response;
        }

        public SaveCompanyResponse SaveCompany(SaveCompanyRequest request)
        {
            var response = new SaveCompanyResponse();
            Company company = _companyRepository.FindBy(new Guid(request.Id));
            company.Abstract = request.Abstract;
            company.Description = request.Description;
            company.IsActive = request.IsActive;
            company.Keywords = request.Keywords;
            company.Text = request.Text;
            company.Title = request.Title;
            company.Updated = DateTime.Now;
            company.UpdatedBy = request.Editor;
            company.Logo = request.Logo;
            company.PhoneNumber = request.PhoneNumber;
            company.Address = request.Address;
            company.Email = request.Email;
            company.Hyperlink = request.Hyperlink;
            _companyRepository.Save(company);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            siteNode.Title = request.Title;
            siteNode.DisplayOnMainMenu = request.DisplayOnMainMenu;
            siteNode.DisplayOnSideMenu = request.DisplayOnSideMenu;
            siteNode.SortOrder = Int32.Parse(request.SortOrder);
            siteNode.IsActive = request.IsActive;
            _siteNodeRepository.Save(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.CompanyUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public FindCompanyResponse FindCompany(FindCompanyRequest request)
        {
            var response = new FindCompanyResponse();
            Company company = _companyRepository.FindBy(new Guid(request.Id));
            if (company != null)
            {
                response.CompanyFound = _companyRepository.FindBy(new Guid(request.Id)).ConvertToCompanyView();
            }
            response.Success = true;

            return response;
        }

        public FindCompaniesResponse FindCompanies(FindCompaniesRequest request)
        {
            var response = new FindCompaniesResponse
                               {
                                   CompaniesFound = request.ShowInactive
                                                        ? _companyRepository.FindAll(new Guid(request.ParentId))
                                                              .OrderBy(n => n.Title)
                                                              .ConvertToCompanyViewCollection()
                                                        : _companyRepository.FindAllPublished(new Guid(request.ParentId))
                                                              .OrderBy(n => n.Title)
                                                              .ConvertToCompanyViewCollection(),
                                   Success = true
                               };

            return response;
        }

        public AddIdeaResponse AddIdea(AddIdeaRequest request)
        {
            var response = new AddIdeaResponse();
            var idea = new Idea
                           {
                               Abstract = request.Abstract,
                               Created = DateTime.Now,
                               CreatedBy = request.CreatedBy,
                               Description = request.Description,
                               Id = Guid.NewGuid(),
                               IsActive = request.IsActive,
                               Keywords = request.Keywords,
                               ParentId = new Guid(request.ParentId),
                               Text = request.Text,
                               Title = request.Title,
                               Updated = DateTime.Now,
                               UpdatedBy = request.CreatedBy,
                               Category = request.Category,
                               Rating = Int32.Parse(request.Rating)
                           };
            _ideaRepository.Add(idea);

            var siteNode = new SiteNode
                               {
                                   ContentItemId = idea.Id,
                                   DisplayOnMainMenu = request.DisplayOnMainMenu,
                                   DisplayOnSideMenu = request.DisplayOnSideMenu,
                                   Id = Guid.NewGuid(),
                                   IsActive = request.IsActive,
                                   ParentId = new Guid(request.ParentNodeId),
                                   SortOrder = Int32.Parse(request.SortOrder),
                                   Title = request.Title,
                                   Url = String.Format(request.UrlPattern, idea.Id)
                               };
            _siteNodeRepository.Add(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.IdeaUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public DeleteIdeaResponse DeleteIdea(DeleteIdeaRequest request)
        {
            var response = new DeleteIdeaResponse();
            Idea idea = _ideaRepository.FindBy(new Guid(request.Id));
            _ideaRepository.Remove(idea);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            _siteNodeRepository.Remove(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.Success = true;

            return response;
        }

        public SaveIdeaResponse SaveIdea(SaveIdeaRequest request)
        {
            var response = new SaveIdeaResponse();
            Idea idea = _ideaRepository.FindBy(new Guid(request.Id));
            idea.Abstract = request.Abstract;
            idea.Description = request.Description;
            idea.IsActive = request.IsActive;
            idea.Keywords = request.Keywords;
            idea.Text = request.Text;
            idea.Title = request.Title;
            idea.Updated = DateTime.Now;
            idea.UpdatedBy = request.Editor;
            idea.Category = request.Category;
            _ideaRepository.Save(idea);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            siteNode.Title = request.Title;
            siteNode.DisplayOnMainMenu = request.DisplayOnMainMenu;
            siteNode.DisplayOnSideMenu = request.DisplayOnSideMenu;
            siteNode.SortOrder = Int32.Parse(request.SortOrder);
            siteNode.IsActive = request.IsActive;
            _siteNodeRepository.Save(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.IdeaUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public FindIdeaResponse FindIdea(FindIdeaRequest request)
        {
            var response = new FindIdeaResponse();
            Idea idea = _ideaRepository.FindBy(new Guid(request.Id));
            if (idea != null)
            {
                response.IdeaFound = idea.ConvertToIdeaView();
            }
            response.Success = true;

            return response;
        }

        public FindIdeasResponse FindIdeas(FindIdeasRequest request)
        {
            var response = new FindIdeasResponse
                               {
                                   IdeasFound = request.ShowInactive
                                                    ? _ideaRepository.FindAll(new Guid(request.ParentId))
                                                          .OrderByDescending(n => n.Created)
                                                          .ConvertToIdeaViewCollection()
                                                    : _ideaRepository.FindAllPublished(new Guid(request.ParentId))
                                                          .OrderByDescending(n => n.Created)
                                                          .ConvertToIdeaViewCollection(),
                                   Success = true
                               };

            return response;
        }

        public AddCommentResponse AddComment(AddCommentRequest request)
        {
            var response = new AddCommentResponse();
            var comment = new Comment
                              {
                                  Created = DateTime.Now,
                                  CreatedBy = request.CreatedBy,
                                  Id = Guid.NewGuid(),
                                  IsActive = request.IsActive,
                                  ParentId = new Guid(request.ParentId),
                                  Text = request.Text,
                                  Updated = DateTime.Now,
                                  UpdatedBy = request.CreatedBy
                              };
            _commentRepository.Add(comment);

            _uow.Commit();

            response.Success = true;

            return response;
        }

        public DeleteCommentResponse DeleteComment(DeleteCommentRequest request)
        {
            var response = new DeleteCommentResponse();
            Comment comment = _commentRepository.FindBy(new Guid(request.Id));
            _commentRepository.Remove(comment);

            _uow.Commit();

            response.Success = true;

            return response;
        }

        public SaveCommentResponse SaveComment(SaveCommentRequest request)
        {
            var response = new SaveCommentResponse();
            Comment comment = _commentRepository.FindBy(new Guid(request.Id));
            comment.IsActive = request.IsActive;
            comment.Text = request.Text;
            comment.Updated = DateTime.Now;
            comment.UpdatedBy = request.Editor;
            _commentRepository.Save(comment);

            _uow.Commit();

            response.Success = true;

            return response;
        }

        public FindCommentResponse FindComment(FindCommentRequest request)
        {
            var response = new FindCommentResponse();
            Comment comment = _commentRepository.FindBy(new Guid(request.Id));
            if (comment != null)
            {
                response.CommentFound = comment.ConvertToCommentView();
            }
            response.Success = true;

            return response;
        }

        public FindCommentsResponse FindComments(FindCommentsRequest request)
        {
            var response = new FindCommentsResponse
                               {
                                   CommentsFound = request.ShowInactive
                                                       ? _commentRepository.FindAll(new Guid(request.ParentId))
                                                             .OrderBy(n => n.Created)
                                                             .ConvertToCommentViewCollection()
                                                       : _commentRepository.FindAllPublished(new Guid(request.ParentId))
                                                             .OrderBy(n => n.Created)
                                                             .ConvertToCommentViewCollection(),
                                   Success = true
                               };

            return response;
        }

        public AddVacancyResponse AddVacancy(AddVacancyRequest request)
        {
            var response = new AddVacancyResponse();
            var vacancy = new Vacancy
                              {
                                  Abstract = request.Abstract,
                                  Created = DateTime.Now,
                                  CreatedBy = request.CreatedBy,
                                  Description = request.Description,
                                  Id = Guid.NewGuid(),
                                  IsActive = request.IsActive,
                                  Keywords = request.Keywords,
                                  ParentId = new Guid(request.ParentId),
                                  Text = request.Text,
                                  Title = request.Title,
                                  Updated = DateTime.Now,
                                  UpdatedBy = request.CreatedBy,
                                  Employer = request.Employer,
                                  Contact = request.Contact,
                                  Responsibilities = request.Responsibilities,
                                  Conditions = request.Conditions,
                                  Demands = request.Demands
                              };
            _vacancyRepository.Add(vacancy);

            var siteNode = new SiteNode
                               {
                                   ContentItemId = vacancy.Id,
                                   DisplayOnMainMenu = request.DisplayOnMainMenu,
                                   DisplayOnSideMenu = request.DisplayOnSideMenu,
                                   Id = Guid.NewGuid(),
                                   IsActive = request.IsActive,
                                   ParentId = new Guid(request.ParentNodeId),
                                   SortOrder = Int32.Parse(request.SortOrder),
                                   Title = request.Title,
                                   Url = String.Format(request.UrlPattern, vacancy.Id)
                               };
            _siteNodeRepository.Add(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.VacancyUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public DeleteVacancyResponse DeleteVacancy(DeleteVacancyRequest request)
        {
            var response = new DeleteVacancyResponse();
            Vacancy vacancy = _vacancyRepository.FindBy(new Guid(request.Id));
            _vacancyRepository.Remove(vacancy);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            _siteNodeRepository.Remove(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.Success = true;

            return response;
        }

        public SaveVacancyResponse SaveVacancy(SaveVacancyRequest request)
        {
            var response = new SaveVacancyResponse();
            Vacancy vacancy = _vacancyRepository.FindBy(new Guid(request.Id));
            vacancy.Abstract = request.Abstract;
            vacancy.Description = request.Description;
            vacancy.IsActive = request.IsActive;
            vacancy.Keywords = request.Keywords;
            vacancy.Text = request.Text;
            vacancy.Title = request.Title;
            vacancy.Updated = DateTime.Now;
            vacancy.UpdatedBy = request.Editor;
            vacancy.Employer = request.Employer;
            vacancy.Contact = request.Contact;
            vacancy.Responsibilities = request.Responsibilities;
            vacancy.Demands = request.Demands;
            vacancy.Conditions = request.Conditions;
            _vacancyRepository.Save(vacancy);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            siteNode.Title = request.Title;
            siteNode.DisplayOnMainMenu = request.DisplayOnMainMenu;
            siteNode.DisplayOnSideMenu = request.DisplayOnSideMenu;
            siteNode.SortOrder = Int32.Parse(request.SortOrder);
            siteNode.IsActive = request.IsActive;
            _siteNodeRepository.Save(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.VacancyUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public FindVacancyResponse FindVacancy(FindVacancyRequest request)
        {
            var response = new FindVacancyResponse();
            Vacancy vacancy = _vacancyRepository.FindBy(new Guid(request.Id));
            if (vacancy != null)
            {
                response.VacancyFound = vacancy.ConvertToVacancyView();
            }
            response.Success = true;

            return response;
        }

        public FindVacanciesResponse FindVacancies(FindVacanciesRequest request)
        {
            var response = new FindVacanciesResponse
                               {
                                   VacanciesFound = request.ShowInactive
                                                        ? _vacancyRepository.FindAll(new Guid(request.ParentId))
                                                              .OrderByDescending(n => n.Created)
                                                              .ConvertToVacancyViewCollection()
                                                        : _vacancyRepository.FindAllPublished(new Guid(request.ParentId))
                                                              .OrderByDescending(n => n.Created)
                                                              .ConvertToVacancyViewCollection(),
                                   Success = true
                               };

            return response;
        }

        public AddAnnouncementResponse AddAnnouncement(AddAnnouncementRequest request)
        {
            var response = new AddAnnouncementResponse();
            var announcement = new Announcement
                                   {
                                       Abstract = request.Abstract,
                                       Created = DateTime.Now,
                                       CreatedBy = request.CreatedBy,
                                       Description = request.Description,
                                       Id = Guid.NewGuid(),
                                       IsActive = request.IsActive,
                                       Keywords = request.Keywords,
                                       ParentId = new Guid(request.ParentId),
                                       Text = request.Text,
                                       Title = request.Title,
                                       Updated = DateTime.Now,
                                       UpdatedBy = request.CreatedBy,
                                       StartingDate = DateTime.Parse(request.StartingDate),
                                       ExpiryDate = DateTime.Parse(request.ExpiryDate),
                                       Venue = request.Venue,
                                       StartingTime = request.StartingTime,
                                       Organizer = request.Organizer,
                                       Contact = request.Contact
                                   };
            _announcementRepository.Add(announcement);

            var siteNode = new SiteNode
                               {
                                   ContentItemId = announcement.Id,
                                   DisplayOnMainMenu = request.DisplayOnMainMenu,
                                   DisplayOnSideMenu = request.DisplayOnSideMenu,
                                   Id = Guid.NewGuid(),
                                   IsActive = request.IsActive,
                                   ParentId = new Guid(request.ParentNodeId),
                                   SortOrder = Int32.Parse(request.SortOrder),
                                   Title = request.Title,
                                   Url = String.Format(request.UrlPattern, announcement.Id)
                               };
            _siteNodeRepository.Add(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.AnnouncementUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public DeleteAnnouncementResponse DeleteAnnouncement(DeleteAnnouncementRequest request)
        {
            var response = new DeleteAnnouncementResponse();
            Announcement announcement = _announcementRepository.FindBy(new Guid(request.Id));
            _announcementRepository.Remove(announcement);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            _siteNodeRepository.Remove(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.Success = true;

            return response;
        }

        public SaveAnnouncementResponse SaveAnnouncement(SaveAnnouncementRequest request)
        {
            var response = new SaveAnnouncementResponse();
            Announcement announcement = _announcementRepository.FindBy(new Guid(request.Id));
            announcement.Abstract = request.Abstract;
            announcement.Description = request.Description;
            announcement.IsActive = request.IsActive;
            announcement.Keywords = request.Keywords;
            announcement.Text = request.Text;
            announcement.Title = request.Title;
            announcement.Updated = DateTime.Now;
            announcement.UpdatedBy = request.Editor;
            announcement.StartingDate = DateTime.Parse(request.StartingDate);
            announcement.ExpiryDate = DateTime.Parse(request.ExpiryDate);
            announcement.Venue = request.Venue;
            announcement.StartingTime = request.StartingTime;
            announcement.Organizer = request.Organizer;
            announcement.Contact = request.Contact;
            _announcementRepository.Save(announcement);

            string siteNodeId = FindNodeByItemIdRecursively(SiteMap, request.Id).Id;
            SiteNode siteNode = _siteNodeRepository.FindBy(new Guid(siteNodeId));
            siteNode.Title = request.Title;
            siteNode.DisplayOnMainMenu = request.DisplayOnMainMenu;
            siteNode.DisplayOnSideMenu = request.DisplayOnSideMenu;
            siteNode.SortOrder = Int32.Parse(request.SortOrder);
            siteNode.IsActive = request.IsActive;
            _siteNodeRepository.Save(siteNode);

            _uow.Commit();
            _currentContext.Cache.Remove(Key);

            response.AnnouncementUrl = siteNode.Url;
            response.Success = true;

            return response;
        }

        public FindAnnouncementResponse FindAnnouncement(FindAnnouncementRequest request)
        {
            var response = new FindAnnouncementResponse();
            Announcement announcement = _announcementRepository.FindBy(new Guid(request.Id));
            if (announcement != null)
            {
                response.AnnouncementFound = announcement.ConvertToAnnouncementView();
            }
            response.Success = true;

            return response;
        }

        public FindAnnouncementsResponse FindAnnouncements(FindAnnouncementsRequest request)
        {
            var response = new FindAnnouncementsResponse();
            if (request.ShowInactive)
            {
                response.AnnouncementsFound = _announcementRepository.FindAll(new Guid(request.ParentId))
                    .OrderByDescending(n => n.StartingDate).ConvertToAnnouncementViewCollection();
            }
            else
            {
                response.AnnouncementsFound = _announcementRepository.FindAllPublished(new Guid(request.ParentId))
                    .OrderByDescending(n => n.StartingDate).ConvertToAnnouncementViewCollection();
            }
            response.Success = true;

            return response;
        }

        private SiteNodeViewCollection FindMainMenuNodes(SiteNodeView node, bool showInactive, bool recursive)
        {
            var nodesFound = new SiteNodeViewCollection();
            if (node.DisplayOnMainMenu && (SiteNodeView.IsParentsActive(node) || showInactive))
                nodesFound.Add(node);
            foreach (SiteNodeView childNode in node.ChildNodes)
            {
                if (recursive)
                {
                    foreach (SiteNodeView n in FindMainMenuNodes(childNode, showInactive, true))
                    {
                        nodesFound.Add(n);
                    }
                }
                else
                {
                    if (childNode.DisplayOnMainMenu && (SiteNodeView.IsParentsActive(childNode) || showInactive))
                        nodesFound.Add(childNode);
                }
            }
            return nodesFound;
        }

        private SiteNodeView FindNodeBy(string nodeId)
        {
            return FindNodeBy(SiteMap, nodeId);
        }

        private SiteNodeView FindNodeBy(SiteNodeView layerRootNode, string nodeId)
        {
            if (layerRootNode.Id == nodeId)
            {
                return layerRootNode;
            }
            return layerRootNode.ChildNodes
                .Select(n => FindNodeBy(n, nodeId))
                .FirstOrDefault(n => n != null);
        }

        private SiteNodeView FindNodeByItemIdRecursively(SiteNodeView layerRootNode, string contentItemId)
        {
            if (layerRootNode.ContentItemId == contentItemId)
            {
                return layerRootNode;
            }
            return layerRootNode.ChildNodes
                .Select(n => FindNodeByItemIdRecursively(n, contentItemId))
                .FirstOrDefault(n => n != null);
        }

        #endregion
    }
}