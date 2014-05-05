using System.ComponentModel.DataAnnotations;

namespace SharpCMS.UI.Mvc.Models.Accounts
{
	public class LogOnModel
	{
		[Required(ErrorMessage = "¬ведите адрес электронной почты")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "јдрес электронной почты")]
		public string Email { get; set; }

		[Required(ErrorMessage = "¬ведите пароль")]
		[DataType(DataType.Password)]
		[Display(Name = "ѕароль")]
		public string Password { get; set; }
	}
}