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
    public partial class AddIdeaItemPage : StaticPage, IAddIdeaItemPageView
    {
        #region Fields
        private IAddIdeaItemPagePresenter _presenter;
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
                    txtParentIdeaGroupTitle.Text = HttpUtility.HtmlDecode(value.Title);
                }
            }
        }

        public IDictionary<int, string> CategoryList
        {
            set
            {
                ddlIdeaItemCategory.DataSource = value;
                ddlIdeaItemCategory.DataTextField = "Value";
                ddlIdeaItemCategory.DataValueField = "Key";
                ddlIdeaItemCategory.DataBind();
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new AddIdeaItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCreateIdeaItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ideaUrl = _presenter.CreateIdeaItem(HttpUtility.HtmlEncode(txtIdeaItemTitle.Text),
                    HttpUtility.HtmlEncode(txtIdeaItemAbstract.Text), txtIdeaItemText.Value,
                    txtIdeaItemKeywords.Text, txtIdeaItemDescription.Text, User.Identity.Name,
                    chkIdeaItemIsActive.Checked, ddlIdeaItemCategory.SelectedItem.Text, new int().ToString(),
                    txtIdeaItemSortOrder.Text, chkIdeaItemDisplayOnMainMenu.Checked, _parentSiteNode.Id,
                    chkIdeaItemDisplayOnSideMenu.Checked);
                Response.Redirect(ideaUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_parentSiteNode.Url);
        }
        #endregion
    }
}