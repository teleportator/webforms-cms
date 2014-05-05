using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SharpCMS.UI.Mvc.Models.Services
{
	public class ServiceRequestVolunteerBookModel
	{
		[DisplayName("Фамилия")]
		[Required(ErrorMessage = "Укажите свою фамилию")]
		public string LastName { get; set; }

		[DisplayName("Имя")]
		[Required(ErrorMessage = "Укажите своё имя")]
		public string FirstName { get; set; }

		[DisplayName("Отчество")]
		[Required(ErrorMessage = "Укажите своё отчество")]
		public string Patronymic { get; set; }

		[DisplayName("Дата рождения")]
		[DataType(DataType.Date, ErrorMessage = "Не верный формат даты")]
		[Required(ErrorMessage = "Укажите дату своего рождения")]
		public DateTime DateOfBirth { get; set; }

		[DisplayName("Учебное заведение")]
		[Required(ErrorMessage = "Укажите свое учебное заведение")]
		public string School { get; set; }

		[DisplayName("Специальность")]
		[Required(ErrorMessage = "Укажите свою специальность")]
		public string Profession { get; set; }

		[DisplayName("Контактный телефон")]
		[Required(ErrorMessage = "Укажите свой контактный телефон")]
		public string Phone { get; set; }

		[DisplayName("Чем хочу помогать")]
		[Required(ErrorMessage = "Укажите то, чем хотите помогать")]
		public string Help { get; set; }
	}
}