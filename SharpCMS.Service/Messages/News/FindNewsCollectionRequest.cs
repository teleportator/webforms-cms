using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class FindNewsCollectionRequest
    {
        public bool ShowUnpublished { get; set; }
        public string ParentId { get; set; }
    }
}
