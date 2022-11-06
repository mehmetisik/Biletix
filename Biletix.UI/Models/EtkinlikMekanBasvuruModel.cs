using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biletix.UI.Models
{
    public class EtkinlikMekanBasvuruModel
    {
        public int EtkinlikMekanBasvuruId { get; set; }

        public string FirmaAdi { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string EtkinlikTanimi { get; set; }

        public string MekanAdi { get; set; }
        public string Adres { get; set; }
        public int MekanKapasite { get; set; }
        public DateTime EtkinlikTarihi { get; set; }
        public int BiletSayisi { get; set; }
        public decimal BiletFiyati { get; set; }
        public string Not { get; set; }

        public int SehirId { get; set; }
        //public Sehir Sehir { get; set; }
        
        public int? MekanId { get; set; }

    }
}