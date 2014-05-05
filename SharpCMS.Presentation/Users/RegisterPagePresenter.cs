using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace SharpCMS.Presentation
{
    public class RegisterPagePresenter : StaticPagePresenter, IRegisterPagePresenter
    {
        #region .Ctor
        public RegisterPagePresenter(IRegisterPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IRegisterPageView View
        {
            get { return (IRegisterPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.MainMenuNodes = GetMainMenuNodes();
        }

        public bool CreateUser(string userEmail, string userLogin, string userPassword)
        {
            List<string> errors = new List<string>();
            
            if (Membership.GetUserNameByEmail(userEmail) != null)
            {
                errors.Add("Пользователь с введенным e-mail уже существует.");
            }
            if (Membership.GetUser(userLogin) != null)
            {
                errors.Add("Введенное Имя пользователя занято.");
            }
            if (userLogin == userPassword)
            {
                errors.Add("Пароль и Имя пользователя не должны совпадать.");
            }
            if (!CheckPassword(userPassword))
            {
                errors.Add("Пароль должен быть не короче шести символов и может состоять из латинских букв, цифр. " +
                    "Обязательно наличие хотя бы одиного цифрового и буквенного символа.");
            }
            if (errors.Count > 0)
            {
                View.Errors = errors.ToArray();
                return false;
            }
            else
            {
                Membership.CreateUser(userLogin, userPassword, userEmail);
                Roles.AddUserToRole(userLogin, "Users");
                return true;
            }
        }

        private bool CheckPassword(string userPassword)
        {
            Regex strengthExpression = new Regex(Membership.PasswordStrengthRegularExpression);
            return strengthExpression.IsMatch(userPassword);
        }
        #endregion
    }
}
