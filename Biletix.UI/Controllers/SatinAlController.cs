using Biletix.Data;
using Biletix.Entity;
using Biletix.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biletix.UI.Controllers
{
    public class SatinAlController : Controller
    {
        DataGosteri _gosteriData;

        public SatinAlController()
        {
            _gosteriData = new DataGosteri();
        }

        // GET: SatinAl
        public ActionResult Index(int id)
        {
            Gosteri gstr = _gosteriData.IDyeGoreGetir(id);

            return View(gstr);
        }

        public ActionResult Bilet(int id)
        {
            Gosteri gstr = _gosteriData.IDyeGoreGetir(id);

            return View(gstr);
        }
    }
}