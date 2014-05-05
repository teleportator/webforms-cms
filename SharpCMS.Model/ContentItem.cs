using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public class ContentItem : ItemBase
    {
        #region Members
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Text { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public string UpdatedBy { get; set; }
        #endregion
    }
}
