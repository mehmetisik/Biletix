using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class Uye
    {
        [Key]
        public int UyeId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }


        //public int SehirId { get; set; }  //bu böyle kalsın acılması felaketlere yol acabilir
        public virtual Sehir Sehir { get; set; }

    }
}
