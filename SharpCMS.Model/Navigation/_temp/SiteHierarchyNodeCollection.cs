using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SharpCMS.Model.Navigation
{
    public class SiteHierarchyNodeCollection : IList<SiteHierarchyNode>
    {
        #region Fields
        List<SiteHierarchyNode> _nodes = null;
        #endregion

        public SiteHierarchyNodeCollection()
        {
            _nodes = new List<SiteHierarchyNode>();
        }

        public int IndexOf(SiteHierarchyNode item)
        {
            return _nodes.IndexOf(item);
        }

        public void Insert(int index, SiteHierarchyNode item)
        {
            _nodes.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _nodes.RemoveAt(index);
        }

        public SiteHierarchyNode this[int index]
        {
            get
            {
                return _nodes[index];
            }
            set
            {
                _nodes[index] = value;
            }
        }

        public void Add(SiteHierarchyNode item)
        {
            _nodes.Add(item);
        }

        public void Clear()
        {
            _nodes.Clear();
        }

        public bool Contains(SiteHierarchyNode item)
        {
            return _nodes.Contains(item);
        }

        public void CopyTo(SiteHierarchyNode[] array, int arrayIndex)
        {
            _nodes.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return _nodes.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(SiteHierarchyNode item)
        {
            return _nodes.Remove(item);
        }

        public IEnumerator<SiteHierarchyNode> GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nodes.GetEnumerator();
        }
    }
}
