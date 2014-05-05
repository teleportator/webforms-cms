using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class FindNodesRequest
    {
        public string ContentItemId { get; set; }
        public bool All { get; set; }
    }
}
