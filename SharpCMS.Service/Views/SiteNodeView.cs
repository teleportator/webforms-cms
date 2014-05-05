using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Views
{
    public class SiteNodeView
    {
        #region Fields
        private SiteNodeViewCollection _childNodes = null;
        #endregion

        #region Members
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ContentItemId { get; set; }
        public SiteNodeView ParentNode { get; set; }
        public bool DisplayOnMainMenu { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public bool IsActive { get; set; }
        public string SortOrder { get; set; }
        public SiteNodeViewCollection ChildNodes
        {
            get
            {
                if (_childNodes == null)
                {
                    _childNodes = new SiteNodeViewCollection();
                }
                return _childNodes;
            }
            set
            {
                _childNodes = value;
            }
        }
        public int Layer 
        {
            get
            {
                return (ParentNode == null) ? 0 : ParentNode.Layer + 1;
            }
        }
        #endregion

        #region Members
        public static bool IsParentsActive(SiteNodeView siteNode)
        {
            if (siteNode != null)
            {
                return siteNode.IsActive && IsParentsActive(siteNode.ParentNode);
            }
            return true;
        }
        #endregion
    }
}
