using Biletix.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Biletix.UI.Controllers
{
    public class HakkimizdaController : Controller
    {
        // GET: Hakkimizda
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IletisimMail(IletisimFormu mdl)
        {

            try
            {
                WebMail.SmtpServer = "srvm01.turhost.com"; //Smtp sunucu adresi
                WebMail.EnableSsl = true; //Ssl kullanılıyorsa true yapmalısınız.
                WebMail.UserName = "biletx@mehmetisik.com.tr"; //Maili gönderecek hesap adı
                WebMail.Password = "Biletx123"; //Hesabın şifresi
                WebMail.SmtpPort = 587; //Mail gönderilecek port
                WebMail.From = "biletx@mehmetisik.com.tr"; //Maili gönderen
                WebMail.Send("biletx@mehmetisik.com.tr", mdl.Konu, mdl.Mesaj);


                ViewBag.Posta = "Mesajınız İletilmiştir. İlginiz İçin Teşekkür Ederiz.";

            }
            catch (Exception)
            {
                ViewBag.Posta = "Mesaj Gönderirken Bir Hata Oluştu. Tekrar Deneyiniz..";

            }

            






            return View("Index");

        }


    }
}