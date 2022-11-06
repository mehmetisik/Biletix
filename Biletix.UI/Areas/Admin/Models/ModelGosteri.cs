using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelGosteri
    {
       

        public int GosteriId { get; set; }
        public string GosteriAdi { get; set; }
        public DateTime GosteriBaslangıcZamani { get; set; }
        public DateTime GosteriBitisZamani { get; set; }
        //public DateTime GosteriBaslangıcSaati { get; set; }
        //public DateTime GosteriBitisSaati { get; set; }
        public string StrGosteriBaslangicZamani { get; set; }
        public string GosteriBaslangicSaat { get; set; }

        public string Aciklama { get; set; }
        public string Not { get; set; }

        public int AltKategoriId { get; set; }
        public virtual AltKategori AltKategori { get; set; }

        public int MekanId { get; set; }
        public virtual Mekan Mekan { get; set; }


        public virtual List<Sanatci> Sanatcilar { get; set; }
        public List<Fotograf> GosteriFotograflari { get; set; }



        //fiyat Tablosu
        //public int FiyatTablosuId { get; set; }
        //public decimal Fiyat { get; set; }
        //public string FiyatAciklama { get; set; }

        public string[] FotograflarModel { get; set; }
        public string[] SanatciListesiModel { get; set; }
        public object[] FiyatListesiModel { get; set; }


      

    }
}
