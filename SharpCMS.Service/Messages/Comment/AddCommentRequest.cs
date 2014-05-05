using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class AddCommentRequest
    {
        public string ParentId { get; set; }
        public string Text { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
