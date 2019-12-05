using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrestaLabDICIS.Web.Helpers
{

    using Microsoft.AspNetCore.Mvc;
    using System.Net;

    public class NotFoundViewResult : ViewResult
    {
        public NotFoundViewResult(string viewName)
        {
            ViewName = viewName;
            StatusCode = (int)HttpStatusCode.NotFound;
        }
    }

}
