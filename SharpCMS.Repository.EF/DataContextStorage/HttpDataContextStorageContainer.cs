using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SharpCMS.Repository.EF.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private string _dataContextKey = "DataContext";

        public SharpCMSDataContext GetDataContext()
        {
            SharpCMSDataContext objectContext = null;
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                objectContext = (SharpCMSDataContext)HttpContext.Current.Items[_dataContextKey];
            return objectContext;
        }

        public void Store(SharpCMSDataContext sharpCMSDataContext)
        {
            if (HttpContext.Current.Items.Contains(_dataContextKey))
                HttpContext.Current.Items[_dataContextKey] = sharpCMSDataContext;
            else
                HttpContext.Current.Items.Add(_dataContextKey, sharpCMSDataContext);
        }
    }
}
