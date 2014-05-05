using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Infrastructure;

namespace SharpCMS.Model
{
    public class News : ContentItem, IAggregateRoot
    {
        public DateTime PublishedDate { get; set; }
    }
}
