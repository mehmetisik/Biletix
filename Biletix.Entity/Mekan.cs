using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class Mekan
    {
        public Mekan()
        {
            //MekanFotograflari = new List<Fotograf>();
            OturmaPlaniFotograflari = new List<Fotograf>();
        }

        public int MekanId { get; set; }
        public string MekanAdi { get; set; }
        public string Adres { get; set; }

        public int SehirId { get; set; }
        public virtual Sehir Sehir { get; set; }

        //public virtual List<Fotograf> MekanFotograflari { get; set; }
        public virtual List<Fotograf> OturmaPlaniFotograflari { get; set; }



    }
}
