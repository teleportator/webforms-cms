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

namespace SharpCMS.UI
{
    public partial class AddIdeaItemPublicPage : StaticPage, IAddIdeaItemPublicPageView
    {
        #region Fields
        private IAddIdeaItemPublicPagePresenter _presenter;
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
                Page.Title += " / " + "Добавление идеи";
                lnkParentSiteNode.NavigateUrl = value.Url;
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
            _presenter = new AddIdeaItemPublicPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();

            if (!User.Identity.IsAuthenticated)
            {
                mvwAddIdeaItem.ActiveViewIndex = 0;
            }
            else
            {
                mvwAddIdeaItem.ActiveViewIndex = 2;
            }
        }

        protected void btnCreateIdeaItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && User.Identity.IsAuthenticated)
            {
                string ideaUrl = _presenter.CreateIdeaItem(HttpUtility.HtmlEncode(txtIdeaItemTitle.Text),
                    HttpUtility.HtmlEncode(txtIdeaItemAbstract.Text), txtIdeaItemText.Text,
                    User.Identity.Name, ddlIdeaItemCategory.SelectedItem.Text, _parentSiteNode.Id);
                mvwAddIdeaItem.ActiveViewIndex = 1;
            }
        }
        #endregion
    }
}