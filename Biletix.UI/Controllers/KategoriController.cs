using Biletix.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Biletix.UI.Controllers
{
    public class KategoriController : Controller
    {

        DataKategori _dataKategori;
        DataAltKategori _dataAltKategori;
        DataSehir _dataSehir;

        public KategoriController()
        {
            _dataAltKategori = new DataAltKategori();
            _dataKategori = new DataKategori();
            _dataSehir = new DataSehir();
            ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList();
            ViewBag.AltKategoriler = _dataAltKategori.TumunuGetir();
            ViewBag.Sehirler = _dataSehir.TumunuGetir();
            

            
        }


        // GET: Kategori
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _AnaKategori()
        {
          ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList();
            //ViewBag.AltKategoriler = _dataAltKategori.TumunuGetir().ToList();

            return View();
        }

    }
}