using System.Collections.Generic;
using SharpCMS.Service.Views;
using System.ComponentModel.DataAnnotations;

namespace SharpCMS.UI.Mvc.Models
{
    public class HomeModel
    {
        [Display(Name = "Идентификатор пользователя")]
        public string Id { get; set; }

        [Display(Name = "Волонтерство")]
        public ArticleView HomePageArticle { get; set; }

        [Display(Name = "Новости")]
        public IEnumerable<NewsView> LatestNews { get; set; }

        [Display(Name = "Акции")]
        public IEnumerable<ArticleView> AnnouncementGroups { get; set; }

        [Display(Name = "Организации")]
        public IEnumerable<CompanyView> Companies { get; set; }
    }
}