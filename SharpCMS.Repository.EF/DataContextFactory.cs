using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Repository.EF.DataContextStorage;

namespace SharpCMS.Repository.EF
{
    public class DataContextFactory
    {
        public static SharpCMSDataContext GetDataContext()
        {
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();
            SharpCMSDataContext sharpCMSDataContext = _dataContextStorageContainer.GetDataContext();
            if (sharpCMSDataContext == null)
            {
                sharpCMSDataContext = new SharpCMSDataContext();
                _dataContextStorageContainer.Store(sharpCMSDataContext);
            }
            return sharpCMSDataContext;
        }
    }
}
