using System;
using System.Web.UI;
using SharpCMS.Presentation;
using SharpCMS.Service.Views;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;
using System.Web;

namespace SharpCMS.UI.Admin
{
    public partial class EditNewsItemPage : StaticPage, IEditNewsItemPageView
    {
        #region Fields
        private EditNewsItemPagePresenter _presenter;
        private NewsView _currentNews;
        private SiteNodeView _currentSiteNode;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public NewsView CurrentNews
        {
            set
            {
                _currentNews = value;
                if (!IsPostBack)
                {
                    txtNewsItemTitle.Text = HttpUtility.HtmlDecode(value.Title);
                    txtNewsItemText.Value = value.Text;
                    txtNewsItemAbstract.Text = HttpUtility.HtmlDecode(value.Abstract);
                    chkNewsItemIsActive.Checked = value.IsActive;
                    txtNewsItemKeywords.Text = value.Keywords;
                    txtNewsItemDescription.Text = value.Description;
                    txtNewsItemPublishedDate.Text = value.PublishedDate;
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
                    txtParentNewsGroupTitle.Text = HttpUtility.HtmlDecode(value.ParentNode.Title);
                    txtNewsItemSortOrder.Text = value.SortOrder;
                    chkNewsItemDisplayOnMainMenu.Checked = value.DisplayOnMainMenu;
                    chkNewsItemDisplayOnSideMenu.Checked = value.DisplayOnSideMenu;
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new EditNewsItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSaveNewsItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string newsUrl = _presenter.SaveNewsItem(this.Id, HttpUtility.HtmlEncode(txtNewsItemTitle.Text),
                    HttpUtility.HtmlEncode(txtNewsItemAbstract.Text), txtNewsItemText.Value, txtNewsItemKeywords.Text,
                    txtNewsItemDescription.Text, User.Identity.Name, chkNewsItemIsActive.Checked,
                    txtNewsItemPublishedDate.Text, txtNewsItemSortOrder.Text, chkNewsItemDisplayOnMainMenu.Checked,
                    chkNewsItemDisplayOnSideMenu.Checked);
                Response.Redirect(newsUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_currentSiteNode.Url);
        }
        #endregion
    }
}