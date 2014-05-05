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
    public partial class VacancyGroupPage : DynamicPage, IVacancyGroupPageView
    {
        #region Fields
        private IVacancyGroupPagePresenter _presenter;
        private ArticleView _currentArticle;
        #endregion

        #region Members
        public string Id
        {
            get { return Request.QueryString["Id"]; }
        }

        public IEnumerable<VacancyView> Vacancies
        {
            set
            {
                if (value.Count() > 0)
                {
                    rptVacancies.DataSource = value;
                    rptVacancies.DataBind();
                    lblEmptyVacancies.Visible = false;
                    rptVacancies.Visible = true;
                }
                else
                {
                    lblEmptyVacancies.Visible = true;
                    rptVacancies.Visible = false;
                }
            }
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
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new VacancyGroupPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnDeleteVacancyGroup_Click(object sender, EventArgs e)
        {
            _presenter.DeleteVacancyGroup();
            Response.Redirect(_currentSiteNode.ParentNode.Url);
        }
        #endregion
    }
}