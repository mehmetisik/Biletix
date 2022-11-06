using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biletix.UI.HelperClasses
{
    public class UserHelper
    {
        public static string IPAdress
        {
            get { return HttpContext.Current.Request.UserHostAddress; }
        }

        public static int? Id
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["Id"]); }
            set { HttpContext.Current.Session["Id"] = value; }
        }

        public static string UserName
        {
            get { return HttpContext.Current.Session["Username"].ToString(); }
            set { HttpContext.Current.Session["Username"] = value; }
        }
    }
}