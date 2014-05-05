using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;
using SharpCMS.Presentation.IoC;

namespace SharpCMS.UI
{
    public partial class AnnouncementItemPage : DynamicPage, IAnnouncementItemPageView
    {
        #region Fields
        private IAnnouncementItemPagePresenter _presenter;
        private AnnouncementView _currentAnnouncement;
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
                if (value != null)
                {
                    _currentAnnouncement = value;

                    lblAnnouncementTitle.Text = _currentAnnouncement.Title;
                    lblAnnouncementText.Text = _currentAnnouncement.Text;
                    lblAnnouncementDate.Text = _currentAnnouncement.StartingDate;
                    if (_currentAnnouncement.StartingDate != _currentAnnouncement.ExpiryDate)
                    {
                        lblAnnouncementDate.Text += " - " + _currentAnnouncement.ExpiryDate;
                    }
                    lblAnnouncementVenue.Text = _currentAnnouncement.Venue;
                    lblAnnouncementStartingTime.Text = _currentAnnouncement.StartingTime;
                    lblAnnouncementOrganizer.Text = _currentAnnouncement.Organizer;
                    lblAnnouncementContact.Text = _currentAnnouncement.Contact;
                }
                else
                {
                    TransferToErrorPage(StatusCode.FileNotFound);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new AnnouncementItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteAnnouncementItem_Click(object sender, EventArgs e)
        {
            _presenter.DeleteAnnouncementItem();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}