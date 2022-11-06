using Biletix.Data;
using Biletix.Entity;
using Biletix.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace Biletix.UI.Controllers
{
    public class UyeController : Controller
    {
        DataKategori _dataKategori;
        DataAltKategori _dataAltKategori;
        DataUye _dataUye;
        DataSehir _dataSehir;
        public UyeController()
        {
            _dataAltKategori = new DataAltKategori();
            _dataKategori = new DataKategori();
            _dataUye = new DataUye();
            _dataSehir = new DataSehir();
            
        }


        // GET: Uye
        public ActionResult Index()
        {

            ViewBag.Kategoriler = _dataKategori.TumunuGetir().ToList();
            ViewBag.AltKategoriler = _dataAltKategori.TumunuGetir().ToList();
            ViewBag.Sehirler = _dataSehir.TumunuGetir();
            Uye uye = _dataUye.IDyeGoreGetir((Session["UyeGiris"] as Uye).UyeId);

            

            return View(uye);

        }

        public ActionResult SifreGuncelle(UyeGirisModel mdl)
        {
            Uye uye = _dataUye.IDyeGoreGetir((Session["UyeGiris"] as Uye).UyeId);
        
                uye.Sifre = mdl.Sifre;
                _dataUye.Guncelle(uye);
                return RedirectToAction("Hesabim", "Home");
        }

        public ActionResult SifremiUnuttum(string EMail)
        {
            
            return View();
        }


        //public ActionResult Dogrula(string Id)
        //{
        //    //MembershipUser kullanici = Membership.GetUser(new Guid(Id));
        //    //kullanici.IsApproved = true;
        //    //Membership.UpdateUser(kullanici);

        //    //return RedirectToAction("");
        //}



        //public ActionResult UyeKaydet(UyeKayitModel gelen)
        //{
        //    var kullaniciVarMi = _dataUye.TumunuGetir().Where(x => x.Email == gelen.Email).FirstOrDefault(y => y.Sifre == gelen.Sifre);

        //    if (kullaniciVarMi == null)
        //    {
        //        Uye uye = new Uye
        //        {
                    
        //            Ad=gelen.Ad,
        //            Soyad=gelen.Soyad,
        //            Adres=gelen.Adres,
        //            Sifre=gelen.Sifre,
        //            Email=gelen.Email,
        //            Telefon=gelen.Telefon,
        //            Sehir =_dataSehir.IDyeGoreGetir(gelen.SehirId)
                    
        //        };

        //         _dataUye.Kaydet(uye);
        //         return RedirectToAction("Index", "Home");
        //    }

        //    else
        //    {
        //        ViewBag.mesaj = "Bu mail sisteme daha önceden kayıt olmuştur";
        //    }

        //    return View();

            




        //}


        
        public ActionResult MailGonder(UyeGirisModel mdl)
        {
            Uye uye = _dataUye.TumunuGetir().Where(x => x.Email == mdl.Email).FirstOrDefault(); // üye var mı yok mu kontorolü için yaptım

            // Emailden şifre aldım
            var kullanici = _dataUye.TumunuGetir().Where(x => x.Email == mdl.Email).ToList();
            var kullaniciSifresi = from Uye in kullanici
                     where Uye.Email == mdl.Email
                     select Uye.Sifre;

            if (uye == null)
            {
                ViewBag.Durum = "Sistemde Kayıtlı E-Posta Adresiniz Bulunmamaktadır.";
            }
            else
            {
                ViewBag.Durum = "Mail Adresinize Şifreniz Gönderilmiştir.";

                WebMail.SmtpServer = "srvm01.turhost.com"; //Smtp sunucu adresi
                WebMail.EnableSsl = true; //Ssl kullanılıyorsa true yapmalısınız.
                WebMail.UserName = "biletx@mehmetisik.com.tr"; //Maili gönderecek hesap adı
                WebMail.Password = "Biletx123"; //Hesabın şifresi
                WebMail.SmtpPort = 587; //Mail gönderilecek port
                WebMail.From = "biletx@mehmetisik.com.tr"; //Maili gönderen
                
                WebMail.Send(mdl.Email, "Biletix - Şifre Talebi", "Sisteme Giriş Yapabilmek İçin Bilgileriniz Şu Şekildedir." + Environment.NewLine + " E-Posta : " + mdl.Email + " " +Environment.NewLine+ "   Şifreniz : " + kullaniciSifresi.FirstOrDefault());
            }

            return View("SifremiUnuttum");
        }
       
    }
}