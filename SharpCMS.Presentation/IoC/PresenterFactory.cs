using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation.IoC
{
    public static class PresenterFactory
    {
        public static IAddArticlePagePresenter CreateAddArticlePagePresenter(IAddArticlePageView view)
        {
            switch (view.PageType)
            {
                case "Article":
                    return new AddArticlePagePresenter(view, ServiceFactory.CreateContentService());
                case "News":
                    return new AddNewsGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Company":
                    return new AddCompanyGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Idea":
                    return new AddIdeaGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Vacancy":
                    return new AddVacancyGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Announcement":
                    return new AddAnnouncementGroupPagePresenter(view, ServiceFactory.CreateContentService());
                default:
                    return new AddArticlePagePresenter(view, ServiceFactory.CreateContentService());
            }
        }

        public static IEditArticlePagePresenter CreateEditArticlePagePresenter(IEditArticlePageView view)
        {
            switch (view.PageType)
            {
                case "Article":
                    return new EditArticlePagePresenter(view, ServiceFactory.CreateContentService());
                case "News":
                    return new EditNewsGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Company":
                    return new EditCompanyGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Idea":
                    return new EditIdeaGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Vacancy":
                    return new EditVacancyGroupPagePresenter(view, ServiceFactory.CreateContentService());
                case "Announcement":
                    return new EditAnnouncementGroupPagePresenter(view, ServiceFactory.CreateContentService());
                default:
                    return new EditArticlePagePresenter(view, ServiceFactory.CreateContentService());
            }
        }
    }
}
