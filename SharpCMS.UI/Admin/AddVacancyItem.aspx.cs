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
    public partial class AddVacancyItemPage : StaticPage, IAddVacancyItemPageView
    {
        #region Fields
        private AddVacancyItemPagePresenter _presenter;
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
                    txtParentVacancyGroupTitle.Text = HttpUtility.HtmlDecode(value.Title);
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new AddVacancyItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnCreateVacancyItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string vacancyUrl = _presenter.CreateVacancyItem(HttpUtility.HtmlEncode(txtVacancyItemTitle.Text),
                    HttpUtility.HtmlEncode(txtVacancyItemAbstract.Text), txtVacancyItemText.Value,
                    txtVacancyItemKeywords.Text, txtVacancyItemDescription.Text, User.Identity.Name,
                    chkVacancyItemIsActive.Checked, HttpUtility.HtmlEncode(txtVacancyItemEmployer.Text),
                    HttpUtility.HtmlEncode(txtVacancyItemResponsibilities.Text),
                    HttpUtility.HtmlEncode(txtVacancyItemContact.Text), HttpUtility.HtmlEncode(txtVacancyItemDemands.Text),
                    HttpUtility.HtmlEncode(txtVacancyItemConditions.Text),
                    txtVacancyItemSortOrder.Text, chkVacancyItemDisplayOnMainMenu.Checked, _parentSiteNode.Id,
                    chkVacancyItemDisplayOnSideMenu.Checked);
                Response.Redirect(vacancyUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_parentSiteNode.Url);
        }
        #endregion
    }
}