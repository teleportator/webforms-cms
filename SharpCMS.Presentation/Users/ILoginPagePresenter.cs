using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface ILoginPagePresenter
    {
        void Display();
        void ValidateUser(string login, string password);
    }
}
