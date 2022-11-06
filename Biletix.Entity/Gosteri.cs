using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class Gosteri
    {
        public Gosteri()
        {
            Sanatcilar = new List<Sanatci>();
            Fiyatlar = new List<FiyatTablosu>();
            GosteriFotograflari = new List<Fotograf>();
        }
        [Key]
        public int GosteriId { get; set; }
        public string GösteriAdi { get; set; }
        public DateTime GosteriBaslangıcZamani { get; set; }
        //public DateTime GosteriBitisZamani { get; set; }
        //public DateTime GosteriBaslangıcSaati { get; set; }
        //public DateTime GosteriBitisSaati { get; set; }
        public string Aciklama { get; set; }
        public string Not { get; set; }


        public virtual List<FiyatTablosu> Fiyatlar { get; set; }

        public int AltKategoriId { get; set; }
        public virtual AltKategori AltKategori { get; set; }

        public int MekanId { get; set; }
        public virtual Mekan Mekan { get; set; }


        public virtual List<Sanatci> Sanatcilar { get; set; }
        public virtual List<Fotograf> GosteriFotograflari { get; set; }


    }
}
