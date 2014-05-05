using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Messages;
using SharpCMS.Service.Views;

namespace SharpCMS.Presentation
{
    public class IdeaItemPagePresenter : StaticPagePresenter, IIdeaItemPagePresenter
    {
        #region .Ctor
        public IdeaItemPagePresenter(IIdeaItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private IIdeaItemPageView View
        {
            get { return (IIdeaItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void DeleteComment(string commentId)
        {
            DeleteCommentRequest request = new DeleteCommentRequest() { Id = commentId };
            _contentService.DeleteComment(request);
        }

        public void DeleteIdeaItem()
        {
            DeleteIdeaRequest deleteIdeaRequest = new DeleteIdeaRequest() { Id = View.Id };
            _contentService.DeleteIdea(deleteIdeaRequest);
        }

        public void Display()
        {
            View.CurrentIdea = GetCurrentIdea();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.CurrentComments = GetCurrentComments();
        }

        private IEnumerable<CommentView> GetCurrentComments()
        {
            FindCommentsRequest request = new FindCommentsRequest()
            {
                ParentId = View.Id,
                ShowInactive = _view.AllowFullAccess
            };
            return _contentService.FindComments(request).CommentsFound;
        }

        private IdeaView GetCurrentIdea()
        {
            FindIdeaRequest request = new FindIdeaRequest() { Id = View.Id };
            return _contentService.FindIdea(request).IdeaFound;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        public void AddComment(string commentText, string commentCreatedBy)
        {
            AddCommentRequest request = new AddCommentRequest()
            {
                ParentId = View.Id,
                Text = InputDataUtilities.TextAreaHtmlEncode(commentText),
                CreatedBy = commentCreatedBy,
                IsActive = true
            };
            _contentService.AddComment(request);
        }
        #endregion
    }
}
