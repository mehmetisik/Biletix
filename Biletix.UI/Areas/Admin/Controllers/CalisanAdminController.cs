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
    public class CalisanAdminController : Controller
    {
        private DataCalisan _dataCalisan;
        private DataSehir _dataSehir;

        public CalisanAdminController()
        {
            _dataSehir = new DataSehir();
            _dataCalisan = new DataCalisan();
        }

        // GET: Admin/CalisanAdmin
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            IPagedList<ModelCalisan> calisanlar = _dataCalisan.TumunuGetir().Select(x => new ModelCalisan
            {
                CalisanId = x.CalisanId,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Unvan = x.Unvan,
                Email = x.Email,
                Sifre = x.Sifre,
                Telefon = x.Telefon,
                Adres = x.Adres,
                Sehir = x.Sehir



            }).OrderBy(x => x.CalisanId).ToPagedList(_sayfaNo, 5);

            List<ModelSehir> mdlSehirler = _dataSehir.TumunuGetir().Select(x => new ModelSehir
            {
                SehirId = x.SehirId,
                SehirAd = x.SehirAd
            }).ToList();

            ViewBag.Sehirler = mdlSehirler;

            return View(calisanlar);
        }

        [MyErrorHandlerAttribute]
        public ActionResult CalisanKaydetGuncelle(ModelCalisan gelen)
        {

            int gelenID = 0;
            if (gelen.CalisanId == 0)
            {
                Calisan calisan = new Calisan
                {

                    Ad = gelen.Ad,
                    Soyad = gelen.Soyad,
                    Unvan = gelen.Unvan,
                    Email = gelen.Email,
                    Sifre = gelen.Sifre,
                    Telefon = gelen.Telefon,
                    Adres = gelen.Adres,
                    Sehir = _dataSehir.IDyeGoreGetir(gelen.SehirId)

                };

                gelenID = _dataCalisan.Kaydet(calisan).CalisanId;
            }
            else
            {
                Calisan calisan = _dataCalisan.IDyeGoreGetir(gelen.CalisanId);

                calisan.Ad = gelen.Ad;
                calisan.Soyad = gelen.Soyad;
                calisan.Unvan = gelen.Unvan;
                calisan.Email = gelen.Email;
                calisan.Sifre = gelen.Sifre;
                calisan.Telefon = gelen.Telefon;
                calisan.Adres = gelen.Adres;

                calisan.Sehir = _dataSehir.IDyeGoreGetir(gelen.SehirId);

                _dataCalisan.Guncelle(calisan);

            }


            return Json(new { success = true, ID = gelenID }, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult CalisanDuzenle(int ID)
        {
            Calisan calisan = _dataCalisan.IDyeGoreGetir(ID);

            ModelCalisan mdcls = new ModelCalisan
            {

                CalisanId = calisan.CalisanId,
                Ad = calisan.Ad,
                Soyad = calisan.Soyad,
                Unvan = calisan.Unvan,
                Email = calisan.Email,
                Sifre = calisan.Sifre,
                Telefon = calisan.Telefon,
                Adres = calisan.Adres,
                SehirId = calisan.Sehir.SehirId


            };

            return Json(mdcls, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult CalisanSil(int ID)
        {

            _dataCalisan.Sil(_dataCalisan.IDyeGoreGetir(ID));

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }

    }
}