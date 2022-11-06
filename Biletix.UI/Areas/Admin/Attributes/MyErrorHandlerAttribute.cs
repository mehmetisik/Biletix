using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Biletix.UI.Areas.Admin.Attributes
{
    public class MyErrorHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            filterContext.Result = new JsonResult
            {
                Data = new { success = false, error = filterContext.Exception.ToString() },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

    }
}
