using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
