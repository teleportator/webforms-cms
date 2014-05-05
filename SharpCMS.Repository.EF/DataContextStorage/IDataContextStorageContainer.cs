using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Repository.EF.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        SharpCMSDataContext GetDataContext();
        void Store(SharpCMSDataContext sharpCMSDataContext);
    }
}
