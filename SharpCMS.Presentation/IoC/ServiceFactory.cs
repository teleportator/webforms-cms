using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpCMS.Infrastructure;
using SharpCMS.Service;
using SharpCMS.Model;
using SharpCMS.Repository.EF;
using SharpCMS.Repository.EF.Repositories;

namespace SharpCMS.Presentation.IoC
{
    public static class ServiceFactory
    {
        public static ContentService CreateContentService()
        {
            IUnitOfWork uow;
            IArticleRepository articleRepository;
            ISiteNodeRepository siteNodeRepository;
            INewsRepository newsRepository;
            ICompanyRepository companyRepository;
            IIdeaRepository ideaRepository;
            ICommentRepository commentRepository;
            IVacancyRepository vacancyRepository;
            IAnnouncementRepository announcementRepository;

            uow = new EFUnitOfWork();
            articleRepository = new ArticleRepository(uow);
            siteNodeRepository = new SiteNodeRepository(uow);
            newsRepository = new NewsRepository(uow);
            companyRepository = new CompanyRepository(uow);
            ideaRepository = new IdeaRepository(uow);
            commentRepository = new CommentRepository(uow);
            vacancyRepository = new VacancyRepository(uow);
            announcementRepository = new AnnouncementRepository(uow);
            
            return new ContentService(articleRepository, siteNodeRepository, newsRepository, companyRepository, ideaRepository,
                 commentRepository, vacancyRepository, announcementRepository, uow, HttpContext.Current);
        }
    }
}