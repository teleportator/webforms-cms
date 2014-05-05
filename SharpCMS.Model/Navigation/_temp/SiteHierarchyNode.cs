using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model.Navigation
{
    public class SiteHierarchyNode
    {
        #region Fields
        private SiteHierarchyNodeCollection _childNodes = null;
        #endregion

        #region Members
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public Guid ItemId { get; set; }
        public SiteHierarchyNode ParentNode { get; set; }
        public bool DisplayOnMainMenu { get; set; }
        public bool DisplayOnSideMenu { get; set; }
        public int SortOrder { get; set; }
        public SiteHierarchyNodeCollection ChildNodes
        {
            get
            {
                if (_childNodes == null)
                {
                    _childNodes = new SiteHierarchyNodeCollection();
                }
                return _childNodes;
            }
            set
            {
                _childNodes = value;
            }
        }
        public int LayerNumber
        {
            get
            {
                if (ParentNode != null)
                    return ParentNode.LayerNumber + 1;
                else
                    return 0;
            }
        }
        #endregion
    }
}
