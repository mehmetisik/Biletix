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
    public class UyeAdminController : Controller
    {
        private DataUye _dataUye;
        private DataSehir _dataSehir;

        public UyeAdminController()
        {
            _dataSehir = new DataSehir();
            _dataUye = new DataUye();
        }

        // GET: Admin/UyeAdmin
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            IPagedList<ModelUye> uyeler = _dataUye.TumunuGetir().Select(x => new ModelUye
            {
                UyeId = x.UyeId,
                Ad = x.Ad,
                Soyad = x.Soyad,
                Adres = x.Adres,
                Email = x.Email,
                Telefon = x.Telefon,
                Sehir = x.Sehir

            }).OrderBy(x => x.UyeId).ToPagedList(_sayfaNo,5);

            List<ModelSehir> sehirler = _dataSehir.TumunuGetir().Select(x => new ModelSehir {
                SehirId = x.SehirId,
                SehirAd = x.SehirAd
                
            }).ToList();

            ViewData["Sehirler"] = sehirler;

            return View(uyeler);
        }

        [MyErrorHandlerAttribute]
        public ActionResult UyeKaydetGuncelle(ModelUye gelen)
        {
            
            int gelenID = 0;
            if (gelen.UyeId == 0)
            {
                Uye uye = new Uye
                {

                    Ad = gelen.Ad,
                    Soyad = gelen.Soyad,
                    Email = gelen.Email,
                    Sifre = gelen.Sifre,
                    Telefon = gelen.Telefon,
                    Adres = gelen.Adres,
                    Sehir = _dataSehir.IDyeGoreGetir(gelen.SehirId),
                    

                };

                gelenID = _dataUye.Kaydet(uye).UyeId;
            }
            else
            {
                Uye uye = _dataUye.IDyeGoreGetir(gelen.UyeId);

                uye.Ad = gelen.Ad;
                uye.Soyad = gelen.Soyad;
                uye.Email = gelen.Email;
                uye.Sifre = gelen.Sifre;
                uye.Telefon = gelen.Telefon;
                uye.Adres = gelen.Adres;
                uye.Sehir = _dataSehir.IDyeGoreGetir(gelen.SehirId);

                _dataUye.Guncelle(uye);

            }



            return Json(new { success = true, ID = gelenID }, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult UyeDuzenle(int ID)
        {
            Uye uye = _dataUye.IDyeGoreGetir(ID);

            ModelUye mdu = new ModelUye
            {
                UyeId = uye.UyeId,
                Ad = uye.Ad,
                Soyad = uye.Soyad,
                Adres = uye.Adres,
                Telefon = uye.Telefon,
                Sifre = uye.Sifre,
                SehirId= uye.Sehir.SehirId,
                Email = uye.Email
                
            };

            return Json(mdu, JsonRequestBehavior.AllowGet);
        }


        [MyErrorHandler]
        public ActionResult UyeSil(int ID)
        {

            _dataUye.Sil(_dataUye.IDyeGoreGetir(ID));

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);

        }
    }
}