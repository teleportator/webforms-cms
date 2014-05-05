using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public interface IHomePageView : IPageBaseView, IMainMenuNodesContainer
    {
        string Id { get; set; }
        ArticleView HomePageArticle { set; }
        IEnumerable<NewsView> LatestNews { set; }
        IEnumerable<ArticleView> AnnouncementGroups { set; }
        IEnumerable<CompanyView> Companies { set; }
    }
}
