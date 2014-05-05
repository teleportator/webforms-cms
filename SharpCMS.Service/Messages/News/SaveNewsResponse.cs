using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCMS.Service.Messages
{
    public class SaveNewsResponse : ResponseBase
    {
        public string NewsUrl { get; set; }
    }
}
