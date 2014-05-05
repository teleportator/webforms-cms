using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SharpCMS.UI.Mvc.Models.Ideas
{
    public class IdeaProposeModel
    {
        public Dictionary<int, string> Categories { get; set; }

        [Required]
        [DisplayName("Категория:")]
        public int CategoryId { get; set; }

        [StringLength(200, ErrorMessage = "Максимум 200 символов")]
        [Required(ErrorMessage = "Введите заголовок")]
        [DisplayName("Заголовок:")]
        public string Title { get; set; }

        [StringLength(200, ErrorMessage = "Максимум 200 символов")]
        [Required(ErrorMessage = "Введите краткое содержание")]
        [DisplayName("Краткое содержание:")]
        public string Abstract { get; set; }

		[AllowHtml]
        [StringLength(4000, ErrorMessage = "Максимум 4000 символов")]
        [Required(ErrorMessage = "Введите основной текст")]
        [DisplayName("Основной текст:")]
        public string Text { get; set; }
    }
}