using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Views
{
    public class CommentView
    {
        #region Members
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Text { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public string Updated { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
