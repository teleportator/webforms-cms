using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using System.Net.Mail;

namespace SharpCMS.Presentation
{
    public class GetVolunteerBookPagePresenter : StaticPagePresenter, IGetVolunteerBookPagePresenter
    {
        #region .Ctor
        public GetVolunteerBookPagePresenter(IGetVolunteerBookPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IGetVolunteerBookPageView View
        {
            get { return (IGetVolunteerBookPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public bool SendRequest(string lastName, string firstName, string patronymic, string dateOfBirth, string school,
            string profession, string help, string phone)
        {
            System.Net.Mail.SmtpClient smtpClient = new SmtpClient();
            MailMessage mailMessage = new MailMessage(new MailAddress("no-reply@xn--80aeam3amfbublh.xn--p1ai"),
                new MailAddress("specialist@xn--80aeam3amfbublh.xn--p1ai"));
            mailMessage.Subject = "Поступила новая заявка на получение личной книжки волонтера";
            mailMessage.Body = GenerateBodyText(lastName, firstName, patronymic, dateOfBirth, school, profession, help, phone);
            smtpClient.Send(mailMessage);
            return true;
        }

        private string GenerateBodyText(string lastName, string firstName, string patronymic, string dateOfBirth,
            string school, string profession, string help, string phone)
        {
            StringBuilder bodyText = new StringBuilder();
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
        #endregion
    }
}
