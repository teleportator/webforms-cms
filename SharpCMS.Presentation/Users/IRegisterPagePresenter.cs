using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IRegisterPagePresenter
    {
        void Display();
        bool CreateUser(string userEmail, string userLogin, string userPassword);
    }
}
