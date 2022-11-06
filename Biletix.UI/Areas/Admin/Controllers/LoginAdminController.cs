using Biletix.Data;
using Biletix.Entity;
using Biletix.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biletix.UI.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
        DataCalisan _dataCalisan;

        public LoginAdminController()
        {
            _dataCalisan = new DataCalisan();
        }


        // GET: Admin/LoginAdmin
        public ActionResult Index()
        {
            return View();
        }

       //[HttpPost]
        public ActionResult GirisYap(ModelCalisan mdlcal)
        {
            Calisan calisan = _dataCalisan.TumunuGetir().FirstOrDefault(x => x.Email == mdlcal.Email && x.Sifre == mdlcal.Sifre);
            Session["CalId"] = calisan;
            
            return RedirectToAction("Index", "HomeAdmin");
        }

        public ActionResult CikisYap()
        {
            Session["CalId"] = null;
            return View("Index");

        }

    }
}