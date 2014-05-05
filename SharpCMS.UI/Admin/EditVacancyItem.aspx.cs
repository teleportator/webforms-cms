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
    public partial class EditVacancyItemPage : StaticPage, IEditVacancyItemPageView
    {
        #region Fields
        private IEditVacancyItemPagePresenter _presenter;
        private VacancyView _currentVacancy;
        private SiteNodeView _currentSiteNode;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public VacancyView CurrentVacancy
        {
            set
            {
                _currentVacancy = value;
                if (!IsPostBack)
                {
                    txtVacancyItemTitle.Text = HttpUtility.HtmlDecode(_currentVacancy.Title);
                    txtVacancyItemText.Value = _currentVacancy.Text;
                    txtVacancyItemAbstract.Text = HttpUtility.HtmlDecode(_currentVacancy.Abstract);
                    chkVacancyItemIsActive.Checked = _currentVacancy.IsActive;
                    txtVacancyItemKeywords.Text = _currentVacancy.Keywords;
                    txtVacancyItemDescription.Text = _currentVacancy.Description;
                    txtVacancyItemEmployer.Text = HttpUtility.HtmlDecode(_currentVacancy.Employer);
                    txtVacancyItemContact.Text = HttpUtility.HtmlDecode(_currentVacancy.Contact);
                    txtVacancyItemResponsibilities.Text = HttpUtility.HtmlDecode(_currentVacancy.Responsibilities);
                    txtVacancyItemDemands.Text = HttpUtility.HtmlDecode(_currentVacancy.Demands);
                    txtVacancyItemConditions.Text = HttpUtility.HtmlDecode(_currentVacancy.Conditions);
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
                    Page.Title += " / " + _currentSiteNode.Title;
                    txtParentVacancyGroupTitle.Text = HttpUtility.HtmlDecode(_currentSiteNode.ParentNode.Title);
                    txtVacancyItemSortOrder.Text = _currentSiteNode.SortOrder;
                    chkVacancyItemDisplayOnMainMenu.Checked = _currentSiteNode.DisplayOnMainMenu;
                    chkVacancyItemDisplayOnSideMenu.Checked = _currentSiteNode.DisplayOnSideMenu;
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new EditVacancyItemPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSaveVacancyItem_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string vacancyUrl = _presenter.SaveVacancyItem(this.Id, HttpUtility.HtmlEncode(txtVacancyItemTitle.Text),
                    HttpUtility.HtmlEncode(txtVacancyItemAbstract.Text), txtVacancyItemText.Value, txtVacancyItemKeywords.Text,
                    txtVacancyItemDescription.Text, User.Identity.Name, chkVacancyItemIsActive.Checked,
                    HttpUtility.HtmlEncode(txtVacancyItemEmployer.Text), HttpUtility.HtmlEncode(txtVacancyItemContact.Text),
                    HttpUtility.HtmlEncode(txtVacancyItemResponsibilities.Text),
                    HttpUtility.HtmlEncode(txtVacancyItemDemands.Text), HttpUtility.HtmlEncode(txtVacancyItemConditions.Text),
                    txtVacancyItemSortOrder.Text, chkVacancyItemDisplayOnMainMenu.Checked,
                    chkVacancyItemDisplayOnSideMenu.Checked);
                Response.Redirect(vacancyUrl);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(_currentSiteNode.Url);
        }
        #endregion
    }
}