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
    public partial class EditAnnouncementItemPage : StaticPage, IEditAnnouncementItemPageView
    {
        #region Fields
        private IEditAnnouncementItemPagePresenter _presenter;
        private AnnouncementView _currentAnnouncement;
        private SiteNodeView _currentSiteNode;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public AnnouncementView CurrentAnnouncement
        {
            set
            {
                _currentAnnouncement = value;
                if (!IsPostBack)
                {
                    txtAnnouncementItemTitle.Text = HttpUtility.HtmlDecode(_currentAnnouncement.Title);
                    txtAnnouncementItemText.Value = _currentAnnouncement.Text;
                    txtAnnouncementItemAbstract.Text = HttpUtility.HtmlDecode(_currentAnnouncement.Abstract);
                    chkAnnouncementItemIsActive.Checked = _currentAnnouncement.IsActive;
                    txtAnnouncementItemKeywords.Text = _currentAnnouncement.Keywords;
                    txtAnnouncementItemDescription.Text = _currentAnnouncement.Description;
                    txtAnnouncementItemStartingDate.Text =
                        Convert.ToDateTime(_currentAnnouncement.StartingDate).ToShortDateString();
                    txtAnnouncementItemExpiryDate.Text =
                        Convert.ToDateTime(_currentAnnouncement.ExpiryDate).ToShortDateString();
                    txtAnnouncementItemVenue.Text = HttpUtility.HtmlDecode(_currentAnnouncement.Venue);
                    txtAnnouncementItemStartingTime.Text = _currentAnnouncement.StartingTime;
                    txtAnnouncementItemOrganizer.Text = HttpUtility.HtmlDecode(_currentAnnouncement.Organizer);
                    txtAnnouncementItemContact.Text = HttpUtility.HtmlDecode(_currentAnnouncement.Contact);
                }
            }
        }

        public SiteNodeView CurrentSiteNode
        {
            set
            {
                _currentSiteNode = value;
                if (!IsPostBack)
                {
                    Page.Title += " / " + value.Title;
                    txtParentAnnouncementGroupTitle.Text = HttpUtility.HtmlDecode(value.ParentNode.Title);
                    txtAnnouncementItemSortOrder.Text = value.SortOrder;
                    chkAnnouncementItemDisplayOnMainMenu.Checked = value.DisplayOnMainMenu;
                    chkAnnouncementItemDisplayOnSideMenu.Checked = value.DisplayOnSideMenu;
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new EditAnnouncementItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSaveAnnouncementItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string announcementUrl = _presenter.SaveAnnouncementItem(
                    this.Id, HttpUtility.HtmlEncode(txtAnnouncementItemTitle.Text),
                    HttpUtility.HtmlEncode(txtAnnouncementItemAbstract.Text), txtAnnouncementItemText.Value,
                    txtAnnouncementItemKeywords.Text, txtAnnouncementItemDescription.Text, User.Identity.Name,
                    chkAnnouncementItemIsActive.Checked, txtAnnouncementItemStartingDate.Text,
                    txtAnnouncementItemExpiryDate.Text,
                    HttpUtility.HtmlEncode(txtAnnouncementItemVenue.Text),
                    txtAnnouncementItemStartingTime.Text,
                    HttpUtility.HtmlEncode(txtAnnouncementItemOrganizer.Text),
                    HttpUtility.HtmlEncode(txtAnnouncementItemContact.Text), txtAnnouncementItemSortOrder.Text,
                    chkAnnouncementItemDisplayOnMainMenu.Checked, chkAnnouncementItemDisplayOnSideMenu.Checked);
                Response.Redirect(announcementUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_currentSiteNode.Url);
        }
        #endregion
    }
}