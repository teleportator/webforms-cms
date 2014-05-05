using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.Service.Views;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI
{
    public partial class CompanyGroup : DynamicPage, ICompanyGroupPageView
    {
        #region Fields
        private ICompanyGroupPagePresenter _presenter;
        private ArticleView _currentArticle;
        public const string _path = @"/Shared/Images/no-image.jpg";
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public ArticleView CurrentArticle
        {
            set
            {
                if (value != null)
                {
                    _currentArticle = value;

                    lblArticleTitle.Text = _currentArticle.Title;
                    lblArticleText.Text = _currentArticle.Text;
                }
                else
                {
                    TransferToErrorPage(StatusCode.FileNotFound);
                }
            }
        }

        public IEnumerable<CompanyView> Companies
        {
            set
            {
                if (value.Count() > 0)
                {
                    rptCompanies.DataSource = value;
                    rptCompanies.DataBind();
                    lblEmptyCompanies.Visible = false;
                    rptCompanies.Visible = true;
                }
                else
                {
                    lblEmptyCompanies.Visible = true;
                    rptCompanies.Visible = false;
                }
            }
        }
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new CompanyGroupPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteCompanyGroup_Click(object sender, EventArgs e)
        {
            _presenter.DeleteCompanyGroup();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}