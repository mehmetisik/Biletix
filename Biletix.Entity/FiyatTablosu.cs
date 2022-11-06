using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class FiyatTablosu
    {
        public int FiyatTablosuId { get; set; }
        public decimal Fiyat { get; set; }
        public string Aciklama { get; set; }
        public int Adet { get; set; }

        //public int GösteriId { get; set; }
        //public virtual Gosteri Gosteri { get; set; }

    }
}
