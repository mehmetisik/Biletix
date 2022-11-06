using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelAltKategori
    {
        public int AltKategoriId { get; set; }
        public string AltKategoriAdi { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
