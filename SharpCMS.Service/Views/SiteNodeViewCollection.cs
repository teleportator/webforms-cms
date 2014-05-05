using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SharpCMS.Service.Views
{
    public class SiteNodeViewCollection : IList<SiteNodeView>
    {
        #region Fields
        List<SiteNodeView> _nodes = null;
        #endregion

        #region .Ctor
        public SiteNodeViewCollection() { _nodes = new List<SiteNodeView>(); }
        #endregion

        #region Methods
        public int IndexOf(SiteNodeView item) { return _nodes.IndexOf(item); }
        public void Insert(int index, SiteNodeView item) { _nodes.Insert(index, item); }
        public void RemoveAt(int index) { _nodes.RemoveAt(index); }
        public SiteNodeView this[int index]
        {
            get { return _nodes[index]; }
            set { _nodes[index] = value; }
        }
        public void Add(SiteNodeView item) { _nodes.Add(item); }
        public void Clear() { _nodes.Clear(); }
        public bool Contains(SiteNodeView item) { return _nodes.Contains(item); }
        public void CopyTo(SiteNodeView[] array, int arrayIndex) { _nodes.CopyTo(array, arrayIndex); }
        public int Count
        {
            get { return _nodes.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(SiteNodeView item) { return _nodes.Remove(item); }
        public IEnumerator<SiteNodeView> GetEnumerator() { return _nodes.GetEnumerator(); }
        IEnumerator IEnumerable.GetEnumerator() { return _nodes.GetEnumerator(); }
        #endregion
    }
}
