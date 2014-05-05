using System.ComponentModel.DataAnnotations;

namespace SharpCMS.UI.Mvc.Models.Accounts
{
	public class LogOnModel
	{
		[Required(ErrorMessage = "������� ����� ����������� �����")]
		[DataType(DataType.EmailAddress)]
		[Display(Name = "����� ����������� �����")]
		public string Email { get; set; }

		[Required(ErrorMessage = "������� ������")]
		[DataType(DataType.Password)]
		[Display(Name = "������")]
		public string Password { get; set; }
	}
}