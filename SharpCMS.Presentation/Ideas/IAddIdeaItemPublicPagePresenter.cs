using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface IAddIdeaItemPublicPagePresenter
    {
        void Display();
        string CreateIdeaItem(string ideaTitle, string ideaAbstract, string ideaText, string ideaEditor, string ideaCategory,
            string nodeParentId);
    }
}
