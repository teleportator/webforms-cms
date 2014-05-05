using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class FindMainMenuNodesRequest
    {
        public string NodeId { get; set; }
        public bool Recursive { get; set; }
        public bool ShowInactive { get; set; }
    }
}
