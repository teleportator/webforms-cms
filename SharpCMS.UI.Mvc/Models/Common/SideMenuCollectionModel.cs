using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SharpCMS.UI.Mvc.Models.Common
{
	public class SideMenuCollectionModel : ICollection<SideMenuLinkModel>
	{
		private readonly ICollection<SideMenuLinkModel> _collection;

		public SideMenuCollectionModel() : this(new List<SideMenuLinkModel>())
		{
		}

		public SideMenuCollectionModel(IList<SideMenuLinkModel> collection)
		{
			_collection = new Collection<SideMenuLinkModel>(collection);
		}

		public bool HasCurrent { get; set; }

		public IEnumerator<SideMenuLinkModel> GetEnumerator()
		{
			return _collection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _collection.GetEnumerator();
		}

		public void Add(SideMenuLinkModel item)
		{
			_collection.Add(item);
		}

		public void Clear()
		{
			_collection.Clear();
		}

		public bool Contains(SideMenuLinkModel item)
		{
			return _collection.Contains(item);
		}

		public void CopyTo(SideMenuLinkModel[] array, int arrayIndex)
		{
			_collection.CopyTo(array, arrayIndex);
		}

		public bool Remove(SideMenuLinkModel item)
		{
			return _collection.Remove(item);
		}

		public int Count
		{
			get { return _collection.Count; }
		}

		bool ICollection<SideMenuLinkModel>.IsReadOnly
		{
			get { return _collection.IsReadOnly; }
		}
	}
}