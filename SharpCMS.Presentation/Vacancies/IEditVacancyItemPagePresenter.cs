using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IEditVacancyItemPagePresenter
    {
        void Display();
        string SaveVacancyItem(string vacancyId, string vacancyTitle, string vacancyAbstract, string vacancyText,
            string vacancyKeywords, string vacancyDescription, string vacancyEditor, bool vacancyIsActive,
            string vacancyEmployer, string vacancyContact, string vacancyResponsibilities, string vacancyDemands,
            string vacancyConditions, string nodeSortOrder, bool nodeDisplayOnMainMenu, bool nodeDisplayOnSideMenu);
    }
}
