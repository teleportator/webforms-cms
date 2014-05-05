using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.UI.Shared.Master;
using SharpCMS.Service.Views;
using SharpCMS.Presentation.IoC;

namespace SharpCMS.UI.Admin
{
    public partial class EditIdeaItem : StaticPage, IEditIdeaItemPageView
    {
        #region Fields
        private IEditIdeaItemPagePresenter _presenter;
        private IdeaView _currentIdea;
        private SiteNodeView _currentSiteNode;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public IdeaView CurrentIdea
        {
            set
            {
                _currentIdea = value;
                if (!IsPostBack)
                {
                    txtIdeaItemTitle.Text = HttpUtility.HtmlDecode(value.Title);
                    txtIdeaItemText.Value = value.Text;
                    txtIdeaItemAbstract.Text = HttpUtility.HtmlDecode(value.Abstract);
                    chkIdeaItemIsActive.Checked = value.IsActive;
                    txtIdeaItemKeywords.Text = value.Keywords;
                    txtIdeaItemDescription.Text = value.Description;
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
                    txtParentIdeaGroupTitle.Text = HttpUtility.HtmlDecode(value.ParentNode.Title);
                    txtIdeaItemSortOrder.Text = value.SortOrder;
                    chkIdeaItemDisplayOnMainMenu.Checked = value.DisplayOnMainMenu;
                    chkIdeaItemDisplayOnSideMenu.Checked = value.DisplayOnSideMenu;
                }
            }
        }

        public IDictionary<int, string> CategoryList
        {
            set
            {
                if (!IsPostBack)
                {
                    ddlIdeaItemCategory.DataSource = value;
                    ddlIdeaItemCategory.DataTextField = "Value";
                    ddlIdeaItemCategory.DataValueField = "Key";
                    ddlIdeaItemCategory.DataBind();
                    ddlIdeaItemCategory.SelectedIndex = value.Where(pair => pair.Value == _currentIdea.Category)
                        .Select(pair => pair.Key).FirstOrDefault();
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new EditIdeaItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSaveIdeaItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string ideaUrl = _presenter.SaveIdeaItem(this.Id, HttpUtility.HtmlEncode(txtIdeaItemTitle.Text),
                    HttpUtility.HtmlEncode(txtIdeaItemAbstract.Text), txtIdeaItemText.Value, txtIdeaItemKeywords.Text,
                    txtIdeaItemDescription.Text, User.Identity.Name, chkIdeaItemIsActive.Checked,
                    ddlIdeaItemCategory.SelectedItem.Text, txtIdeaItemSortOrder.Text, chkIdeaItemDisplayOnMainMenu.Checked,
                    chkIdeaItemDisplayOnSideMenu.Checked);
                Response.Redirect(ideaUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_currentSiteNode.Url);
        }
        #endregion
    }
}