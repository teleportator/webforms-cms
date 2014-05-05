using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Infrastructure;

namespace SharpCMS.Model
{
    public class Idea : ContentItem, IAggregateRoot
    {
        public string Category { get; set; }
        public int Rating { get; set; }
    }
}
