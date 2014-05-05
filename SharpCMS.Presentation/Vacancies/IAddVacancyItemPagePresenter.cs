using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IAddVacancyItemPagePresenter
    {
        void Display();
        string CreateVacancyItem(string vacancyTitle, string vacancyAbstract, string vacancyText, string vacancyKeywords,
            string vacancyDescription, string vacancyEditor, bool vacancyIsActive, string vacancyEmployer,
            string vacancyResponsibilities, string vacancyContact, string vacancyDemands, string vacancyConditions,
            string nodeSortOrder, bool nodeDisplayOnMainMenu, string nodeParentId, bool nodeDisplayOnSideMenu);
    }
}
