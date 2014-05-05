using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IEditCompanyPagePresenter
    {
        void Display();
        string SaveCompanyItem(string companyId, string companyTitle, string companyAbstract, string companyText, string companyKeywords,
            string companyDescription, string companyEditor, bool companyIsActive, string companyAddress, string companyEmail,
            string companyHyperlink, string companyLogo, string companyPhoneNumber, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu);
    }
}
