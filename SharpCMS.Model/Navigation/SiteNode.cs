using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Infrastructure;

namespace SharpCMS.Model
{
    public class SiteNode : ItemBase, IAggregateRoot
    {
        #region Members
        public string Title { get; set; }
        public string Url { get; set; }
        public Guid ContentItemId { get; set; }
        public bool DisplayOnMainMenu { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public int SortOrder { get; set; }
        #endregion
    }
}
