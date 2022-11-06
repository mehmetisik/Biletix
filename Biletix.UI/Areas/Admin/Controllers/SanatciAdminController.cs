using Biletix.Data;
using Biletix.Entity;
using Biletix.UI.Areas.Admin.Attributes;
using Biletix.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biletix.UI.Areas.Admin.Controllers
{
    public class SanatciAdminController : Controller
    {
        // GET: Admin/SanatciAdmin
        //public ActionResult Index()
        //{
        //    List<ModelSanatcı> mdlSanatçılar = _dataSAnatcı.TumunuGetir().Select(x => new ModelSanatcı
        //    {
        //        SanatciId = x.SanatciId,
        //        Ad = x.Ad,
        //        Soyad = x.Soyad
        //    }).ToList();
        //    return View(mdlSanatçılar);
        //}

        //private DataSanatci _dataSAnatcı;
        
        //public SanatciAdminController()
        //{
        //    _dataSAnatcı = new DataSanatci();
        //}

        //public ActionResult SanatciKaydetGüncelle(ModelSanatcı gelen)
        //{
        //    int gelenID = 0;
        //    if (gelen.SanatciId==0)
        //    {
        //        Sanatci sanatci = new Sanatci
        //        {
        //            Ad = gelen.Ad,
        //            Soyad = gelen.Soyad,
        //        };

        //        gelenID = _dataSAnatcı.Kaydet(sanatci).SanatciId;                
        //    }
        //    else
        //    {
        //        //Sanatci sanatcı = _dataSAnatcı.IDyeGoreGetir(gelen.SanatciId);
        //        //sanatcı.Ad = gelen.Ad;
        //        //sanatcı.Soyad = gelen.Soyad;
        //        //_dataSAnatcı.Guncelle(sanatcı);
        //    }
        //    return Json(new { success=true,ID=gelenID}, JsonRequestBehavior.AllowGet);
        //}

        //[MyErrorHandler]
        //public ActionResult SanatciSil(int osman)//buradaki "osman" ajaxtan geliyo isimler yani parametreler aynı olucak
        //{
        //    _dataSAnatcı.Sil(_dataSAnatcı.IDyeGoreGetir(osman));
        //    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult SanatcıDüzenle(int ID)
        //{
        //    Sanatci sanatci = _dataSAnatcı.IDyeGoreGetir(ID);
        //    ModelSanatcı mds = new ModelSanatcı
        //    {
        //        Ad = sanatci.Ad,
        //        Soyad = sanatci.Soyad
        //    };
        //    return Json(mds, JsonRequestBehavior.AllowGet);
        //}

    }
}