using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class FindCompaniesRequest
    {
        public string ParentId { get; set; }
        public bool ShowInactive { get; set; }
    }
}
