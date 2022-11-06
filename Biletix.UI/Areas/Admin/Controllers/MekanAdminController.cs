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
using System.IO;

namespace Biletix.UI.Areas.Admin.Controllers
{
    public class MekanAdminController : Controller
    {
        private DataMekan _dataMekan;
        private DataSehir _dataSehir;
        private DataMekanDetayi _dataMekanDetay;
        private DataOturmaPlani _dataOturmaPlani;

        public MekanAdminController()
        {
            _dataOturmaPlani = new DataOturmaPlani();
            _dataMekanDetay = new DataMekanDetayi();
            _dataSehir = new DataSehir();
            _dataMekan = new DataMekan();
        }

        // GET: Admin/MekanAdmin
        public ActionResult Index(int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            IPagedList<ModelMekan> mdlMekanlar = _dataMekan.TumunuGetir().Select(x => new ModelMekan
            {
                MekanId = x.MekanId,
                MekanAdi = x.MekanAdi,
                Adres = x.Adres,
                SehirId = x.SehirId,
                Sehir = x.Sehir


            }).OrderBy(x => x.MekanId).ToPagedList(_sayfaNo, 5);

            ViewBag.sehirler = _dataSehir.TumunuGetir().ToList().Select(x => new ModelSehir
            {
                SehirId = x.SehirId,
                SehirAd = x.SehirAd,
                BolgeId = x.BolgeId,
                Bolge = x.Bolge
            }).ToList();

            return View(mdlMekanlar);
        }

        [MyErrorHandler]
        public ActionResult Duzenle(int id)
        {

            Mekan mk = _dataMekan.IDyeGoreGetir(id);
            ModelMekan mdlMekan = new ModelMekan
            {
                MekanId = mk.MekanId,
                MekanAdi = mk.MekanAdi,
                Adres = mk.Adres,
                SehirId = mk.SehirId,
                SehirAD = mk.Sehir.SehirAd

            };

            return Json(mdlMekan, JsonRequestBehavior.AllowGet);
        }

        [MyErrorHandler]
        public ActionResult KaydetOrGuncelle(ModelMekan gelen)
        {
            int eklenanID = 0;
            if (gelen.MekanId == 0)
            {
                Mekan mk = new Mekan();
                mk.MekanAdi = gelen.MekanAdi;
                mk.Adres = gelen.Adres;
                mk.SehirId = gelen.SehirId;
        
                foreach (var item in gelen.OturmaPlaniFotograflari)
                {
                    mk.OturmaPlaniFotograflari.Add(new Fotograf
                    {
                        FotoAdi = item
                    });
                }

                eklenanID = _dataMekan.Kaydet(mk).MekanId;
            }
            else
            {
                Mekan gMk = _dataMekan.IDyeGoreGetir(gelen.MekanId);
                gMk.MekanAdi = gelen.MekanAdi;
                gMk.Adres = gelen.Adres;
                gMk.Sehir = _dataSehir.IDyeGoreGetir(gelen.SehirId);

                _dataMekan.Guncelle(gMk);
            }


            return Json(new { success = true, ID = eklenanID }, JsonRequestBehavior.AllowGet);
        }
        [MyErrorHandler]
        public ActionResult Sil(int id)
        {
            Mekan silMk = _dataMekan.IDyeGoreGetir(id);

            _dataMekan.Sil(silMk);

            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detay(int id, int? sayfaNo)
        {
            int _sayfaNo = sayfaNo ?? 1;
            IPagedList<ModelMekanDetay> mkDt = _dataMekanDetay.MekanaGoreDetayListesi(id).Select(x => new ModelMekanDetay
            {
                MekanDetayId = x.MekanDetayId,
                MekanId = x.MekanId,
                Mekan = x.Mekan,
                Kapasite = x.Kapasite,
                OturmaPlani = x.OturmaPlani,
                OturmaPlaniId = x.OturmaPlaniId,
                Fotograflar = x.Fotograflar,
                Salon = x.Salon,
                Fotograf = x.Fotograf,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.MekanDetayId).ToPagedList(_sayfaNo, 5);


            Mekan mk = _dataMekan.IDyeGoreGetir(id);

            ModelMekan mekan = new ModelMekan
            {
                MekanId = mk.MekanId,
                MekanAdi = mk.MekanAdi,
                Adres = mk.Adres,
                Sehir = mk.Sehir,
                SehirAD = mk.Sehir.SehirAd,
                SehirId = mk.SehirId,
            };
            ViewBag.mekan = mekan;

            ViewBag.oturmaPlani = _dataOturmaPlani.TumunuGetir().Select(x => new ModelOturmaPlani
            {
                OturmaPlanId = x.OturmaPlanId,
                OturmaPlan = x.OturmaPlan

            }).ToList();

            return View(mkDt);
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

        public ActionResult MekanDetaytKaydetOrGuncelle(ModelMekanDetay gelen)
        {
            MekanDetayi mkDty = new MekanDetayi();
            mkDty.MekanId = gelen.MekanId;
            mkDty.Salon = gelen.Salon;
            mkDty.Kapasite = gelen.Kapasite;
            mkDty.Aciklama = gelen.Aciklama;
            mkDty.OturmaPlaniId = gelen.OturmaPlaniId;
            foreach (string item in gelen.StrFotoListesi)
            {
                mkDty.Fotograflar.Add(new Fotograf
                {
                    FotoAdi = item

                });
            }
            foreach (string item in gelen.StrOturmaPlaniFoto)
            {
                mkDty.OturmaPlaniFotograflar.Add(new Fotograf
                {
                    FotoAdi = item
                });
            }

            _dataMekanDetay.Kaydet(mkDty);

            return Json("s");
        }
    }
}