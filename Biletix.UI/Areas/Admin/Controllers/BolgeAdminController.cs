using Biletix.Data;
using Biletix.Entity;
using Biletix.UI.Areas.Admin.Attributes;
using Biletix.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace Biletix.UI.Areas.Admin.Controllers
{
    public class BolgeAdminController : Controller
    {
        private DataBolge _dataBolge;

        public BolgeAdminController()
        {
            _dataBolge = new DataBolge();
        }

        // GET: Admin/BolgeAdmin
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            IPagedList<ModelBolge> bolgeler = _dataBolge.TumunuGetir().Select(x => new ModelBolge
            {
                BolgeId = x.BolgeId,
                BolgeAdi = x.BolgeAdi

            }).OrderBy(x => x.BolgeId).ToPagedList(_sayfaNo,5);

            return View(bolgeler);
        }

        [MyErrorHandler]
        public ActionResult BolgeDuzenle(int ID)
        {
            Bolge bolge = _dataBolge.IDyeGoreGetir(ID);
            ModelBolge mdl = new ModelBolge
            {
                BolgeId = bolge.BolgeId,
                BolgeAdi = bolge.BolgeAdi
               
            };

            return Json(mdl, JsonRequestBehavior.AllowGet);
        } 

        [MyErrorHandlerAttribute]
        public ActionResult BolgeKaydetGuncelle(ModelBolge gelen)
        {
            
            int gelenID = 0;
            if (gelen.BolgeId == 0)
            {
                Bolge bolge = new Bolge
                {
                    BolgeAdi = gelen.BolgeAdi

                };


                gelenID = _dataBolge.Kaydet(bolge).BolgeId;
               
            }

            else
            {
                Bolge bolge = _dataBolge.IDyeGoreGetir(gelen.BolgeId);

                bolge.BolgeAdi = gelen.BolgeAdi;

                _dataBolge.Guncelle(bolge);
            }

            return Json(new { success = true, ID = gelenID }, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult BolgeSil(int ID)
        {
            //Bolge silincek = ;

            _dataBolge.Sil(_dataBolge.IDyeGoreGetir(ID));
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}