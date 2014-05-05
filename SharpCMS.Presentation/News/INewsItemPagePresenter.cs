using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Presentation
{
    public interface INewsItemPagePresenter
    {
        void Display();
        void DeleteNewsItem();
        void AddComment(string commentText, string commentCreatedBy);
        void DeleteComment(string commentId);
    }
}
