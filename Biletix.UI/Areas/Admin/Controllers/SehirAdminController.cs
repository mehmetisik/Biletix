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
    public class SehirAdminController : Controller
    {
        private DataSehir _dataSehir;
        private DataBolge _dataBolge;

        public SehirAdminController()
        {
            _dataBolge = new DataBolge();
            _dataSehir = new DataSehir();
        }



        // GET: Admin/SehirAdmin
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;

            IPagedList<ModelSehir> sehirler = _dataSehir.TumunuGetir().Select(x => new ModelSehir
            {
                SehirId = x.SehirId,
                SehirAd = x.SehirAd,
                Bolge = x.Bolge,
                BolgeId = x.BolgeId
                
            }).OrderBy(x => x.SehirId).ToPagedList(_sayfaNo,5);

            ViewBag.bolgeler = _dataBolge.TumunuGetir().Select(x => new ModelBolge
            {
                BolgeAdi = x.BolgeAdi,
                BolgeId = x.BolgeId
            }).ToList();
          

            return View(sehirler);
        }

        

        [MyErrorHandlerAttribute]
        public ActionResult SehirKaydetGuncelle(ModelSehir gelen)
        {
            int gelenID = 0;
            if (gelen.SehirId == 0)
            {
                Sehir sehir = new Sehir
                {
                    SehirAd = gelen.SehirAd,
                    Bolge = _dataBolge.IDyeGoreGetir(gelen.BolgeId)
                    
                };

                gelenID = _dataSehir.Kaydet(sehir).SehirId;

            }

            else
            {
                Sehir sehir = _dataSehir.IDyeGoreGetir(gelen.SehirId);
               
                sehir.SehirAd = gelen.SehirAd;
                sehir.Bolge = _dataBolge.IDyeGoreGetir(gelen.BolgeId);
                    
                 _dataSehir.Guncelle(sehir);
            }

            return Json(new { success = true, ID = gelenID }, JsonRequestBehavior.AllowGet);
        }


        [MyErrorHandler]
        public ActionResult SehirDuzenle(int ID)
        {
            Sehir sehir = _dataSehir.IDyeGoreGetir(ID);

            ModelSehir mds = new ModelSehir
            {
                SehirId = sehir.SehirId,
                SehirAd = sehir.SehirAd
            };

            return Json(mds, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult SehirSil(int ID)
        {
            _dataSehir.Sil(_dataSehir.IDyeGoreGetir(ID));
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

    }
}