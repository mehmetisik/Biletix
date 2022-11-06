using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class EtkinlikBasvuru
    {
        public int EtkinlikBasvuruId { get; set; }
        public string Adres { get; set; }
        public int MekanKapasite { get; set; }
        public DateTime EtkinlikTarihi { get; set; }
        public int BiletSayisi { get; set; }
        public decimal BiletFiyati { get; set; }
        public string Not { get; set; }

        public int SehirId { get; set; }
        public virtual Sehir Sehir { get; set; }

        public int? MekanId { get; set; }
        public virtual Mekan Mekan { get; set; }

    }
}
