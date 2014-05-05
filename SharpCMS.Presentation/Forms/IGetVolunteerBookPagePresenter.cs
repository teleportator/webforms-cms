using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IGetVolunteerBookPagePresenter
    {
        void Display();
        bool SendRequest(string lastName, string firstName, string patronymic, string dateOfBirth, string school,
            string profession, string help, string phone);
    }
}
