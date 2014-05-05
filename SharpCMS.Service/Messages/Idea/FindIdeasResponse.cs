﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Service.Messages
{
    public class FindIdeasResponse : ResponseBase
    {
        public IEnumerable<IdeaView> IdeasFound { get; set; }
    }
}
