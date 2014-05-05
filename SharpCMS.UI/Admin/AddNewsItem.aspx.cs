using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Service.Views;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI.Admin
{
    public partial class AddNewsItemPage : StaticPage, IAddNewsItemPageView
    {
        #region Fields
        private AddNewsItemPagePresenter _presenter;
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
                    txtParentNewsGroupTitle.Text = HttpUtility.HtmlDecode(value.Title);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new AddNewsItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCreateNewsItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string newsUrl = _presenter.CreateNewsItem(HttpUtility.HtmlEncode(txtNewsItemTitle.Text),
                    HttpUtility.HtmlEncode(txtNewsItemAbstract.Text), txtNewsItemText.Value,
                    txtNewsItemKeywords.Text, txtNewsItemDescription.Text, User.Identity.Name, chkNewsItemIsActive.Checked,
                    txtNewsItemPublishedDate.Text, txtNewsItemSortOrder.Text, chkNewsItemDisplayOnMainMenu.Checked,
                    _parentSiteNode.Id, chkNewsItemDisplayOnSideMenu.Checked);
                Response.Redirect(newsUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_parentSiteNode.Url);
        }
        #endregion
    }
}