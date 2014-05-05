using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharpCMS.UI
{
    public enum StatusCode : int
    {
        OK = 200,
        BadRequest = 400,
        Forbidden = 403,
        FileNotFound = 404,
        InternalError = 500,
        NotImplemented = 501
    }
}