using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class SaveArticleResponse : ResponseBase
    {
        public string ArticleUrl { get; set; }
    }
}
