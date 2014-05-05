using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Model
{
    public class ItemBase
    {
        #region Members
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public bool IsActive { get; set; }
        #endregion
    }
}
