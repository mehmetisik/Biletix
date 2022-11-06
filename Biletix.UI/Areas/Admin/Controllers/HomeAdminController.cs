using Biletix.Data;
using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biletix.UI.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            new DataMekan().TumunuGetir().ToList();
            
            return View();
        }
    }
}