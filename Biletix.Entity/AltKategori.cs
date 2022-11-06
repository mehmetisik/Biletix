using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class AltKategori
    {
        public int AltKategoriId { get; set; }
        public string AltKategoriAdi { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori  { get; set; }



    }
}
