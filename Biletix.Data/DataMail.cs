using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;


namespace Biletix.Data
{
   public class DataMail
    {
        public void MailGonder(string kullaniciAdi)
        {
            //MembershipUser user = Membership.GetUser(kullaniciAdi);
            //string confirmationGuid = user.ProviderUserKey.ToString();
            //string verifyUrl = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) +
            //                 "/account/verify?ID=" + confirmationGuid;
            //var message = new MailMessage("biletx@mehmetisik.com.tr", user.Email)
            //{
            //    Subject = "Üyeliğinizin aktif olması için lütfen linki tıklayınız",
            //    Body = verifyUrl
            //};
            //var alici = new SmtpClient();
            //alici.Send(message);
          


        }
    }
}
