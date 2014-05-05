using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IAddCompanyItemPagePresenter
    {
        void Display();
        string CreateCompanyItem(string companyTitle, string companyAbstract, string companyText, string companyKeywords,
            string companyDescription, string companyEditor, bool companyIsActive, string companyAddress, string companyEmail,
            string companyHyperlink, string companyLogo, string companyPhoneNumber, string nodeSortOrder,
            bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu);
    }
}
