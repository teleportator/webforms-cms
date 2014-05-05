using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace SharpCMS.Repository.EF.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable _shapCMSDataContexts = new Hashtable();

        public SharpCMSDataContext GetDataContext()
        {
            SharpCMSDataContext sharpCMSDataContext = null;
            if (_shapCMSDataContexts.Contains(GetThreadName()))
                sharpCMSDataContext =
                (SharpCMSDataContext)_shapCMSDataContexts[GetThreadName()];
            return sharpCMSDataContext;
        }

        public void Store(SharpCMSDataContext sharpCMSDataContext)
        {
            if (_shapCMSDataContexts.Contains(GetThreadName()))
                _shapCMSDataContexts[GetThreadName()] = sharpCMSDataContext;
            else
                _shapCMSDataContexts.Add(GetThreadName(), sharpCMSDataContext);
        }

        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}
