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
    public class HomeController : Controller
    {
        DataKategori _dataKategori = new DataKategori();
        DataAltKategori _dataAltKategori = new DataAltKategori();
        DataSehir _dataSehir = new DataSehir();
        DataUye _uyeData = new DataUye();
        DataGosteri _dataGosteri = new DataGosteri();

        public HomeController()
        {
            //ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList(); ;
            //ViewBag.AltKategoriler = _dataAltKategori.TumunuGetir().ToList();
            //ViewBag.Sehirler = _dataSehir.TumunuGetir();
            
        }

        // GET: Home
        public ActionResult Index(UyeGirisModel mdl)
        {
            //List<Gosteri> gstr = new List<Gosteri>();
            ViewBag.GosteriOneCikanResimler = _dataGosteri.TumunuGetir().Take(5).OrderByDescending(x => x.GosteriBaslangıcZamani).ToList();
            //gstr = _dataGosteri.TumunuGetir().ToList();

            //var gosteriler = _dataGosteri.TumunuGetir().Take(5).ToList();
            //var haberGosteri = from gosteri in gosteriler
            //                   orderby gosteri.GosteriBaslangıcZamani descending
            //                   select new { gosteri.GösteriAdi, gosteri.GosteriBaslangıcZamani, gosteri.Aciklama };               
            //ViewBag.GosteriHaber = haberGosteri.ToList();


            return View();
        }


        

        public ActionResult KayitOl( UyeKayitModel mdl )
        {
            Uye yeniUye = new Uye
            {
                Ad = mdl.Ad,
                Soyad = mdl.Telefon,
                Email = mdl.Email,
                Sifre = mdl.Sifre,
                Telefon=mdl.Telefon,
                Adres=mdl.Adres,
                Sehir = _dataSehir.IDyeGoreGetir(mdl.SehirId)
            };
         
            _uyeData.Kaydet(yeniUye);

            return View("Index");
        }

        public ActionResult UyeGiris(UyeGirisModel mdl)
        {
            Uye uy = _uyeData.TumunuGetir().Where(x => x.Email == mdl.Email && x.Sifre == mdl.Sifre).FirstOrDefault();
            Session["UyeGiris"] = uy;

            //ViewBag.Uye = _uyeData.TumunuGetir().Where(x => x.Email == mdl.Email && x.Sifre == mdl.Sifre && x.Ad == mdl.Ad).FirstOrDefault();

            return RedirectToAction("Index");
           
        }

        public ActionResult UyeGirisBiletOncesi(UyeGirisModel mdl)
        {
            Uye uy = _uyeData.TumunuGetir().Where(x => x.Email == mdl.Email && x.Sifre == mdl.Sifre).FirstOrDefault();
            Session["UyeGiris"] = uy;

            //ViewBag.Uye = _uyeData.TumunuGetir().Where(x => x.Email == mdl.Email && x.Sifre == mdl.Sifre && x.Ad == mdl.Ad).FirstOrDefault();

            return RedirectToAction("SatinAlmaOncesi", "GosteriDetay");

        }

        public ActionResult CikisYap()
        {
            Session["UyeGiris"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Hesabim()
        {
            //ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList();

            //Session["UyeGiris"] = null;
            return RedirectToAction("Index","Uye");
        }

        public ActionResult GosteriDetay()
        {
            return View();
        }


    




    }
}