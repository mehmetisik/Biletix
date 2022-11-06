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
    public class AltKategoriAdminController : Controller
    {
        private DataAltKategori _dataAltKategori;
        private DataKategori _dataKategori;

        public AltKategoriAdminController()
        {
            _dataKategori = new DataKategori();
            _dataAltKategori = new DataAltKategori();
        }
        // GET: Admin/AltKategoriAdmin
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            IPagedList<ModelAltKategori> altKategori = _dataAltKategori.TumunuGetir().Select(x => new ModelAltKategori
            {
                AltKategoriId = x.AltKategoriId,
                AltKategoriAdi = x.AltKategoriAdi,
                Kategori = x.Kategori
            }).OrderBy(x => x.AltKategoriId).ToPagedList(_sayfaNo,5);


            List<ModelKategori> ktg = _dataKategori.TumunuGetir().Select(x => new ModelKategori {
                KategoriId = x.KategoriId,
                KategoriAdi =x.KategoriAdi
            }).ToList();

            ViewData["Kategoriler"] = ktg;
            return View(altKategori);
        }


       [MyErrorHandlerAttribute]
        public ActionResult AltKategoriDuzenle(int ID)
        {
            AltKategori altKategori = _dataAltKategori.IDyeGoreGetir(ID);

            ModelAltKategori maltk = new ModelAltKategori
            {
                AltKategoriId=altKategori.AltKategoriId,
                AltKategoriAdi=altKategori.AltKategoriAdi,
               
            };
            
            return Json(maltk, JsonRequestBehavior.AllowGet);

        }

        [MyErrorHandlerAttribute]
        public ActionResult KaydetOrGuncelle(ModelAltKategori gelen)
        {
            int gelenID = 0;

            if (gelen.AltKategoriId == 0)
            {
                AltKategori altKategori = new AltKategori
                {
                    AltKategoriAdi=gelen.AltKategoriAdi,
                    KategoriId = gelen.KategoriId
                    
                };

                gelenID = _dataAltKategori.Kaydet(altKategori).AltKategoriId;
            }

            else
            {
                AltKategori altKategori = _dataAltKategori.IDyeGoreGetir(gelen.AltKategoriId);

                altKategori.AltKategoriAdi = gelen.AltKategoriAdi;
                altKategori.KategoriId = gelen.KategoriId;

                _dataAltKategori.Guncelle(altKategori);
            }

            return Json(new { success = true, ID = gelenID },JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult AltKategoriSil(int ID)
        {
            _dataAltKategori.Sil(_dataAltKategori.IDyeGoreGetir(ID));

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}