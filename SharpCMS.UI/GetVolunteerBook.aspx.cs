using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SharpCMS.Presentation;
using SharpCMS.Presentation.IoC;
using SharpCMS.UI.Shared.Master;

namespace SharpCMS.UI
{
    public partial class GetVolunteerBookPage : StaticPage, IGetVolunteerBookPageView
    {
        #region Fields
        private IGetVolunteerBookPagePresenter _presenter;
        #endregion

        #region Methods
        protected void Page_Init(object sender, EventArgs e)
        {
            _presenter = new GetVolunteerBookPagePresenter(this, ServiceFactory.CreateContentService());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((IEditorMenuContainer)Page.Master).ShowEditorMenu = this.AllowFullAccess;
            _presenter.Display();
        }

        protected void btnSendRequest_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                _presenter.SendRequest(HttpUtility.HtmlEncode(txtLastName.Text), HttpUtility.HtmlEncode(txtFirstName.Text),
                    HttpUtility.HtmlEncode(txtPatronymic.Text), HttpUtility.HtmlEncode(txtDateOfBirth.Text),
                    HttpUtility.HtmlEncode(txtSchool.Text), HttpUtility.HtmlEncode(txtProfession.Text),
                    HttpUtility.HtmlEncode(txtHelp.Text), HttpUtility.HtmlEncode(txtPhone.Text));
                mvwVolunteerBookRequest.ActiveViewIndex = 1;
            }
        }
        #endregion
    }
}