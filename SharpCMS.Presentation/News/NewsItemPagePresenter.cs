using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service;
using SharpCMS.Service.Views;
using SharpCMS.Service.Messages;

namespace SharpCMS.Presentation
{
    public class NewsItemPagePresenter : StaticPagePresenter, INewsItemPagePresenter
    {
        #region .Ctor
        public NewsItemPagePresenter(INewsItemPageView view, ContentService contentService)
            : base(contentService, view) { }
        #endregion

        #region Members
        private INewsItemPageView View
        {
            get { return (INewsItemPageView)_view; }
        }
        #endregion

        #region Methods
        public void Display()
        {
            View.CurrentNews = GetCurrentNews();
            View.CurrentSiteNode = GetCurrentSiteNode();
            View.MainMenuNodes = GetMainMenuNodes();
            View.CurrentComments = GetCurrentComments();
        }

        public void DeleteNewsItem()
        {
            DeleteNewsRequest deleteNewsRequest = new DeleteNewsRequest() { Id = View.Id };
            _contentService.DeleteNews(deleteNewsRequest);
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

        public void DeleteComment(string commentId)
        {
            DeleteCommentRequest request = new DeleteCommentRequest() { Id = commentId };
            _contentService.DeleteComment(request);
        }

        private NewsView GetCurrentNews()
        {
            FindNewsRequest request = new FindNewsRequest() { Id = View.Id };
            return _contentService.FindNews(request).NewsFound;
        }

        private SiteNodeView GetCurrentSiteNode()
        {
            FindNodesRequest request = new FindNodesRequest() { ContentItemId = View.Id, All = false };
            return _contentService.FindNode(request).NodeFound;
        }

        private IEnumerable<CommentView> GetCurrentComments()
        {
            FindCommentsRequest request = new FindCommentsRequest()
            {
                ParentId = View.Id,
                ShowInactive = View.AllowFullAccess
            };
            return _contentService.FindComments(request).CommentsFound;
        }
        #endregion
    }
}
