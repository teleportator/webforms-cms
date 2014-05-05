using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SharpCMS.UI.Mvc.Models.Accounts
{
	public class RegisterModel
    {
		[Required(ErrorMessage = "������� ������������� ������")]
		[DataType(DataType.Password)]
		[Display(Name = "������������� ������")]
		[Compare("Password", ErrorMessage = "������ � ��� ������������� �� ���������.")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "������� ����� ����������� �����")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "����� ����������� �����")]
        public string Email { get; set; }

		[Required(ErrorMessage = "������� ������")]
        [StringLength(15, ErrorMessage = "�������� {0} ������ ��������� �� ����� {2} ��������.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

		[Required(ErrorMessage="������� ��� ������������")]
		[Display(Name = "��� ������������")]
		public string UserName { get; set; }
    }
}
