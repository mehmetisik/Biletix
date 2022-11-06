using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelUye
    {

        public int UyeId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public int SehirId { get; set; }
        public virtual Sehir Sehir { get; set; }
    }
}
