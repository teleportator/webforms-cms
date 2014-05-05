using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI
{
    public class DynamicPage : StaticPage
    {
        #region Fields
        protected SiteNodeView _currentSiteNode;
        #endregion

        #region Members
        public SiteNodeView CurrentSiteNode
        {
            set
            {
                if (SiteNodeView.IsParentsActive(value) || this.AllowFullAccess)
                {
                    _currentSiteNode = value;

                    PageMasterPage pageMasterPage = (PageMasterPage)Master;
                    pageMasterPage.SideMenu.ShowAllNodes = this.AllowFullAccess;
                    pageMasterPage.SideMenu.SetCurrentNodeToDisplay(value);

                    Page.Title += " / " + _currentSiteNode.Title;
                }
                else
                {
                    TransferToErrorPage(StatusCode.FileNotFound);
                }
            }
        }
        #endregion
    }
}