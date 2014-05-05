using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.Service.Views;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI.Admin
{
    public partial class AddAnnouncementItemPage : StaticPage, IAddAnnouncementItemPageView
    {
        #region Fields
        private IAddAnnouncementItemPagePresenter _presenter;
        private SiteNodeView _parentSiteNode;
        #endregion

        #region Members
        public string ParentId
        {
            get { return Request.QueryString["ParentId"]; }
        }

        public SiteNodeView ParentSiteNode
        {
            set
            {
                _parentSiteNode = value;
                if (!IsPostBack)
                {
                    Page.Title += " / " + "Новый элемент";
                    txtParentAnnouncementGroupTitle.Text = HttpUtility.HtmlDecode(value.Title);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new AddAnnouncementItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCreateAnnouncementItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string announcementUrl = _presenter.CreateAnnouncementItem(
                    HttpUtility.HtmlEncode(txtAnnouncementItemTitle.Text),
                    HttpUtility.HtmlEncode(txtAnnouncementItemAbstract.Text), txtAnnouncementItemText.Value,
                    txtAnnouncementItemKeywords.Text, txtAnnouncementItemDescription.Text, User.Identity.Name,
                    chkAnnouncementItemIsActive.Checked, txtAnnouncementItemStartingDate.Text,
                    txtAnnouncementItemExpiryDate.Text, HttpUtility.HtmlEncode(txtAnnouncementItemVenue.Text),
                    txtAnnouncementItemStartingTime.Text,
                    HttpUtility.HtmlEncode(txtAnnouncementItemOrganizer.Text),
                    HttpUtility.HtmlEncode(txtAnnouncementItemContact.Text),
                    txtAnnouncementItemSortOrder.Text, chkAnnouncementItemDisplayOnMainMenu.Checked, _parentSiteNode.Id,
                    chkAnnouncementItemDisplayOnSideMenu.Checked);
                Response.Redirect(announcementUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_parentSiteNode.Url);
        }
        #endregion
    }
}