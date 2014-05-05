using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;
using SharpCMS.Model;

namespace SharpCMS.Service.Mappers
{
    public static class CommentExtensions
    {
        public static CommentView ConvertToCommentView(this Comment comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException();
            }
            return new CommentView()
            {
                Id = comment.Id.ToString(),
                ParentId = comment.ParentId.ToString(),
                Created = comment.Created.ToString("dd MMMM yyyy, HH:mm"),
                CreatedBy = comment.CreatedBy,
                Updated = comment.Updated.ToString(),
                UpdatedBy = comment.UpdatedBy,
                IsActive = comment.IsActive,
                Text = comment.Text
            };
        }

        public static IEnumerable<CommentView> ConvertToCommentViewCollection(this IEnumerable<Comment> comments)
        {
            List<CommentView> commentViewCollection = new List<CommentView>();
            foreach (Comment comment in comments)
            {
                commentViewCollection.Add(comment.ConvertToCommentView());
            }
            return commentViewCollection;
        }
    }
}
