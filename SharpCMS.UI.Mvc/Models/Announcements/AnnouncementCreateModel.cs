using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SharpCMS.UI.Mvc.Models.Announcements
{
	public class AnnouncementCreateModel
	{
		public string ParentUrl { get; set; }

		[DisplayName("Родительский раздел")]
		public string ParentTitle { get; set; }

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

		[Required(ErrorMessage = "Введите дату начала")]
		[DataType(DataType.Date, ErrorMessage = "Не верный формат даты")]
		[DisplayName("Дата начала")]
		public DateTime StartingDate { get; set; }

		[Required(ErrorMessage = "Введите дату окончания")]
		[DataType(DataType.Date, ErrorMessage = "Не верный формат даты")]
		[DisplayName("Дата окончания")]
		public DateTime ExpiryDate { get; set; }

		[Required(ErrorMessage = "Введите место проведения")]
		[DisplayName("Место проведения")]
		public string Venue { get; set; }

		[Required(ErrorMessage = "Введите время проведения")]
		[DisplayName("Время проведения")]
		public string StartingTime { get; set; }

		[Required(ErrorMessage = "Введите организатора")]
		[DisplayName("Организатор")]
		public string Organizer { get; set; }

		[Required(ErrorMessage = "Введите контакты")]
		[DisplayName("Контакты")]
		public string Contact { get; set; }
	}
}