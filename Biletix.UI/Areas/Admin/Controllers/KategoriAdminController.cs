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
    public class KategoriAdminController : Controller
    {
        private DataKategori _dataKategori;

        public KategoriAdminController()
        {
            _dataKategori = new DataKategori();
        }


        // GET: Admin/Kategori
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            IPagedList<ModelKategori> mKtg = _dataKategori.TumunuGetir().Select(x => new ModelKategori
            {
                KategoriId = x.KategoriId,
                KategoriAdi = x.KategoriAdi

            }).OrderBy(x => x.KategoriId).ToPagedList(_sayfaNo,5);

            return View(mKtg);
        }

        [MyErrorHandler]
        public ActionResult KategoriKaydetGuncelle(ModelKategori gelen)
        {

            int gelenID = 0;
            if (gelen.KategoriId == 0)
            {
                Kategori ktg = new Kategori
                {

                    KategoriAdi = gelen.KategoriAdi

                };
                gelenID = _dataKategori.Kaydet(ktg).KategoriId;
            }
            else
            {
                Kategori ktg = _dataKategori.IDyeGoreGetir(gelen.KategoriId);
                ktg.KategoriAdi = gelen.KategoriAdi;

                _dataKategori.Guncelle(ktg);

            }
            return Json(new { success = true, ID = gelenID }, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult KategoriDuzenle(int ID)
        {
            Kategori ktg = _dataKategori.IDyeGoreGetir(ID);
            ModelKategori mdlK = new ModelKategori
            {
                KategoriId = ktg.KategoriId,
                KategoriAdi = ktg.KategoriAdi
            };

            return Json(mdlK, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult KategoriSil(int ID)
        {
            _dataKategori.Sil(_dataKategori.IDyeGoreGetir(ID));

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }



    }
}