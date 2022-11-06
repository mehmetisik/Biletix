using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelMekan
    {
        public int MekanId { get; set; }
        public string MekanAdi { get; set; }
        public string Adres { get; set; }
        public string SehirAD { get; set; }

        public int SehirId { get; set; }
        public virtual Sehir Sehir { get; set; }

        public string[] MekanFotograflari { get; set; }
        public string[] OturmaPlaniFotograflari { get; set; }
    }
}
