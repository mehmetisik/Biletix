using Biletix.Data;
using Biletix.UI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Biletix.Entity;
using System.Globalization;
using Biletix.UI.Areas.Admin.Attributes;

namespace Biletix.UI.Areas.Admin.Controllers
{
    public class GosteriAdminController : Controller
    {
        private DataGosteri _dataGosteri;
        private DataMekan _dataMekan;
        private DataAltKategori _dataAltKategori;

        public GosteriAdminController()
        {
            _dataGosteri = new DataGosteri();
            _dataMekan = new DataMekan();
            _dataAltKategori = new DataAltKategori();
        }

        // GET: Admin/GosteriAdmin
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;

            IPagedList<ModelGosteri> dmlGosteriler = _dataGosteri.TumunuGetir().Select(x => new ModelGosteri
            {
                GosteriId = x.GosteriId,
                GosteriBaslangıcZamani = x.GosteriBaslangıcZamani,
                //GosteriBitisZamani = x.GosteriBitisZamani,
                Aciklama = x.Aciklama,
                AltKategori = x.AltKategori,
                AltKategoriId = x.AltKategoriId,
                GosteriFotograflari = x.GosteriFotograflari,
                GosteriAdi = x.GösteriAdi,
                Mekan = x.Mekan,
                MekanId = x.MekanId,
                Not = x.Not,
                Sanatcilar = x.Sanatcilar

            }).OrderBy(x => x.GosteriId).ToPagedList(_sayfaNo, 5);

            ViewBag.mekanlar = _dataMekan.TumunuGetir().Select(x => new ModelMekan
            {
                Adres = x.Adres,
                MekanAdi = x.MekanAdi,
                MekanId = x.MekanId,
                Sehir = x.Sehir,
                SehirAD = x.Sehir.SehirAd,
                SehirId = x.SehirId

            }).ToList();

            ViewBag.kategoriler = _dataAltKategori.TumunuGetir().Select(x => new ModelAltKategori
            {
                AltKategoriAdi = x.AltKategoriAdi,
                AltKategoriId = x.AltKategoriId,
                Kategori = x.Kategori,
                KategoriId = x.KategoriId

            }).ToList();

            return View(dmlGosteriler);
        }

        public ActionResult KaydetOrGuncell()
        {

            return Json("");
        }

        public ActionResult Sil()
        {
            return Json("");
        }

        public ActionResult Duzenle()
        {

            return Json("");
        }

        public ActionResult ResimKaydet()
        {
            List<string> resimListesi = new List<string>();

            if (Request.Files.Count > 0)
            {
                try
                {

                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {

                        HttpPostedFileBase file = files[i];
                        string fname;

                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = Guid.NewGuid() + ".jpg";// +"-"+ file.FileName;
                        }

                        resimListesi.Add(fname);

                        fname = Path.Combine(Server.MapPath("~/Content/image/"), fname);
                        file.SaveAs(fname);
                    }

                    return Json(resimListesi);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        public ActionResult KaydetOrGuncelle(ModelGosteri gelen)
        {


            Gosteri gst = new Gosteri();
            gst.GösteriAdi = gelen.GosteriAdi;
            gst.Aciklama = gelen.Aciklama;
            gst.AltKategoriId =gelen.AltKategoriId;
            gst.MekanId= gelen.MekanId;
            gst.Not = gelen.Not;
            gst.GosteriBaslangıcZamani = DateTime.Parse(gelen.StrGosteriBaslangicZamani, new CultureInfo("tr-TR"));
            foreach (string item in gelen.SanatciListesiModel)
            {
                gst.Sanatcilar.Add(new Sanatci
                {
                    AdSoyad = item
                });
            }
            foreach (object[] item in gelen.FiyatListesiModel)
            {
                gst.Fiyatlar.Add(new FiyatTablosu
                {
                    Aciklama = item[0].ToString(),
                    Fiyat = Convert.ToDecimal(item[1]),
                    Adet = Convert.ToInt32(item[2])
                
                });

            }
            foreach (string item in gelen.FotograflarModel)
            {
                gst.GosteriFotograflari.Add(new Fotograf
                {
                    FotoAdi = item

                });

            }

            int ID= _dataGosteri.Kaydet(gst).GosteriId;


            return Json(ID);
        }
        [MyErrorHandler]
        public ActionResult Sil(int ID)
        {
            Gosteri silinecekGst = _dataGosteri.IDyeGoreGetir(ID);

            _dataGosteri.Sil(silinecekGst);

            return Json(new {success=true });

        }

    }
}