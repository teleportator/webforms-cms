using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using SharpCMS.UI.Mvc.Models.Services;

namespace SharpCMS.UI.Mvc.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult RequestVolunteerBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RequestVolunteerBook(ServiceRequestVolunteerBookModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            SendRequest(model.LastName, model.FirstName, model.Patronymic, model.DateOfBirth.ToShortDateString(),
                        model.School, model.Profession, model.Help, model.Phone);

            return View("Success");
        }

        private void SendRequest(string lastName, string firstName, string patronymic, string dateOfBirth, string school,
                                 string profession, string help, string phone)
        {
            var smtpClient = new SmtpClient();
            var mailMessage = new MailMessage(new MailAddress("no-reply@xn--80aeam3amfbublh.xn--p1ai"),
                                              new MailAddress("specialist@xn--80aeam3amfbublh.xn--p1ai"))
                                  {
                                      Subject = "Поступила новая заявка на получение личной книжки волонтера",
                                      Body =
                                          GenerateBodyText(lastName, firstName, patronymic, dateOfBirth, school,
                                                           profession, help, phone)
                                  };
            smtpClient.Send(mailMessage);
        }

        private string GenerateBodyText(string lastName, string firstName, string patronymic, string dateOfBirth,
                                        string school, string profession, string help, string phone)
        {
            var bodyText = new StringBuilder();
            bodyText.Append(string.Format("Фамилия: {0}\n", lastName));
            bodyText.Append(string.Format("Имя: {0}\n", firstName));
            bodyText.Append(string.Format("Отчество: {0}\n", patronymic));
            bodyText.Append(string.Format("Дата рождения: {0}\n", dateOfBirth));
            bodyText.Append(string.Format("Учебное заведение: {0}\n", school));
            bodyText.Append(string.Format("Спеиальность: {0}\n", profession));
            bodyText.Append(string.Format("Чем хочу помогать: {0}\n", help));
            bodyText.Append(string.Format("Контактный телефон: {0}\n", phone));
            return bodyText.ToString();
        }
    }
}