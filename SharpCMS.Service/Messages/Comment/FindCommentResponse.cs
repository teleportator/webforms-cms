﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpCMS.Service.Views;

namespace SharpCMS.Service.Messages
{
    public class FindCommentResponse : ResponseBase
    {
        public CommentView CommentFound { get; set; }
    }
}
