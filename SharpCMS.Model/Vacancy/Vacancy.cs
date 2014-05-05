using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Infrastructure;

namespace SharpCMS.Model
{
    public class Vacancy : ContentItem, IAggregateRoot
    {
        public string Employer { get; set; }
        public string Contact { get; set; }
        public string Responsibilities { get; set; }
        public string Demands { get; set; }
        public string Conditions { get; set; }
    }
}
