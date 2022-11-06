using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelCalisan
    {
        public int CalisanId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Unvan { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }

        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }

    }
}
