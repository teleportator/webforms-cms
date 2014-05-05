using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SharpCMS.UI.Mvc.Models.Accounts
{
	public class RegisterModel
    {
		[Required(ErrorMessage = "Введите подтверждение пароля")]
		[DataType(DataType.Password)]
		[Display(Name = "Подтверждение пароля")]
		[Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Введите адрес электронной почты")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

		[Required(ErrorMessage = "Введите пароль")]
        [StringLength(15, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

		[Required(ErrorMessage="Введите имя пользователя")]
		[Display(Name = "Имя пользователя")]
		public string UserName { get; set; }
    }
}
