using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class Kategori
    {
        public Kategori()
        {
            AltKategoriler = new List<AltKategori>();
        }
        public int KategoriId { get; set; }
        public string KategoriAdi { get; set; }

        public virtual List<AltKategori> AltKategoriler { get; set; }

    }
}
