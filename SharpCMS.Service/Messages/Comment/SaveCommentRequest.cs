using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class SaveCommentRequest
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Editor { get; set; }
        public bool IsActive { get; set; }
    }
}
