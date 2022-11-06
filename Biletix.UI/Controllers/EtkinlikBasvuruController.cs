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
    public class EtkinlikBasvuruController : Controller
    {
        // GET: EtkinlikBasvuru
        DataKategori _dataKategori;
        DataAltKategori _dataAltKategori;
        DataSehir _dataSehir;
        DataMekanBasvuru _dataMekanBasvuru;
        DataEtkinlikBasvuru _dataEtkinlikBasvuru;
        DataMekan _dataMekan;


        public EtkinlikBasvuruController()
        {
            _dataKategori = new DataKategori();
            _dataAltKategori = new DataAltKategori();
            _dataSehir = new DataSehir();
            _dataEtkinlikBasvuru = new DataEtkinlikBasvuru();
            _dataMekanBasvuru = new DataMekanBasvuru();
            _dataMekan = new DataMekan();
            

        }

        // GET: EtkinlikBasvuru
        public ActionResult Index()
        {
            //List<SehirModel> mdlSehir = _dataSehir.TumunuGetir().ToList().Select(x => new SehirModel
            //{
            //    SehirId = x.SehirId,
            //    SehirAd = x.SehirAd,
            //    BolgeId = x.BolgeId,
            //    Bolge = x.Bolge

            //}).ToList();

            //ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList();
            //ViewBag.AltKategoriler = _dataAltKategori.TumunuGetir().ToList();
            ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList(); ;
            ViewBag.AltKategoriler = _dataAltKategori.TumunuGetir().ToList();
            ViewBag.Sehirler = _dataSehir.TumunuGetir();
            return View();
        }

        public ActionResult Kaydet(EtkinlikMekanBasvuruModel gelen)
        {

            MekanBasvuru mekanBasvuru = new MekanBasvuru
            {
                FirmaAdi = gelen.FirmaAdi,
                Ad = gelen.Ad,
                Soyad = gelen.Soyad,
                Email = gelen.Email,
                Telefon = gelen.Telefon,
                EtkinlikTanimi = gelen.EtkinlikTanimi
            };

            EtkinlikBasvuru etkinlikBasvuru = new EtkinlikBasvuru
            {
                Adres = gelen.Adres,
                MekanKapasite = gelen.MekanKapasite,
                EtkinlikTarihi = gelen.EtkinlikTarihi,
                BiletSayisi = gelen.BiletSayisi,
                BiletFiyati = gelen.BiletFiyati,
                Not = gelen.Not,
                Sehir = _dataSehir.IDyeGoreGetir(gelen.SehirId),
                //Mekan = _dataMekan.IDyeGoreGetir(gelen.MekanId) == DBNull.Value ? null : (int?)Convert.ToInt32(_dataMekan.IDyeGoreGetir(gelen.MekanId))



            };

            _dataEtkinlikBasvuru.Kaydet(etkinlikBasvuru);
            _dataMekanBasvuru.Kaydet(mekanBasvuru);

            return RedirectToAction("Index", "EtkinlikBasvuru");

        }




        //public ActionResult MekanBasvuruListesi()
        //{
        //    List<MekanBasvuruModel> mbListesi = _dataMekanBasvuru.TumunuGetir().Select(x => new MekanBasvuruModel
        //    {
        //        FirmaAdi=x.FirmaAdi,
        //        Ad=x.Ad,
        //        Soyad=x.Soyad,
        //        Email=x.Email,
        //        Telefon=x.Telefon,
        //        MekanTanimi=x.MekanTanimi

        //    }).ToList();

        //    return View(mbListesi);
        //}


        //public ActionResult EtkinlikBasvuruListesi()
        //{
        //    List<EtkinlikBasvuruModel> ebListesi = _dataEtkinlikBasvuru.TumunuGetir().Select(x => new EtkinlikBasvuruModel
        //    {
        //        Adres=x.Adres,
        //        MekanKapasite=x.MekanKapasite,
        //        EtkinlikTarihi=x.EtkinlikTarihi,
        //        BiletFiyati=x.BiletFiyati,
        //        BiletSayisi=x.BiletSayisi,
        //        Not=x.Not,
        //        SehirId=x.SehirId,
        //        MekanId=x.MekanId

        //    }).ToList();

        //    return View(ebListesi);
        //}
    }
}