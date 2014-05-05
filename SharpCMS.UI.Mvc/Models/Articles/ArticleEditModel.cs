using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SharpCMS.UI.Mvc.Models.Articles
{
	public class ArticleEditModel
	{
		public string CurrentUrl { get; set; }

		[StringLength(200, ErrorMessage = "Превышен допустимый лимит длины")]
		[Required(ErrorMessage = "Введите заголовок")]
		[DisplayName("Заголовок")]
		public string Title { get; set; }

		[AllowHtml]
		[DisplayName("Основной текст")]
		public string Text { get; set; }

		[StringLength(200, ErrorMessage = "Превышен допустимый лимит длины")]
		[Required(ErrorMessage = "Введите краткое содержание")]
		[DisplayName("Краткое содержание")]
		public string Abstract { get; set; }

		[DisplayName("Показывать на сайте")]
		public bool IsActive { get; set; }

		[StringLength(200, ErrorMessage = "Превышен допустимый лимит длины")]
		[DisplayName("Тег Keywords")]
		public string Keywords { get; set; }

		[StringLength(200, ErrorMessage = "Превышен допустимый лимит длины")]
		[DisplayName("Тег Description")]
		public string Description { get; set; }

		[Range(1, 1000, ErrorMessage = "Введите целое число от 1 до 1000")]
		[Required(ErrorMessage = "Введите порядок сортировки")]
		[DisplayName("Порядок сортировки")]
		public int SortOrder { get; set; }

		[DisplayName("Показывать в главном меню")]
		public bool DisplayOnMainMenu { get; set; }

		[DisplayName("Показывать в боковом меню")]
		public bool DisplayOnSideMenu { get; set; } 
	}
}