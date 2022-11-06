using Biletix.Data;
using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biletix.UI.Controllers
{
    public class GosteriDetayController : Controller
    {
        DataKategori _dataKategori = new DataKategori();
        DataAltKategori _dataAltKategori = new DataAltKategori();
        DataSehir _dataSehir = new DataSehir();
        DataUye _uyeData = new DataUye();
        DataGosteri _gosteriData = new DataGosteri();
        
        public GosteriDetayController()
        {
            ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList(); ;
            ViewBag.AltKategoriler = _dataAltKategori.TumunuGetir().ToList();
            ViewBag.Sehirler = _dataSehir.TumunuGetir();
        }


        // GET: GosteriDetay
        public ActionResult Index(int id)
        {
            Gosteri gstr = _gosteriData.IDyeGoreGetir(id);


            //aynı gösteri altkategoride olanları aldım. sayfanın altında listeliycem 4 adet.

            ViewBag.BenzerKategoriGosteriler = _gosteriData.TumunuGetir().Where(x => x.AltKategori.AltKategoriAdi == gstr.AltKategori.AltKategoriAdi).Take(4).ToList();



            return View(gstr);
        }

        public ActionResult SatinAlmaOncesi(int id)
        {
            Gosteri gstr = _gosteriData.IDyeGoreGetir(id);
            return View(gstr);
        }



    }
}