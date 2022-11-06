using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class MekanDetayi
    {
        public MekanDetayi()
        {
            Fotograflar = new List<Fotograf>();
            OturmaPlaniFotograflar = new List<Fotograf>();
        }

        [Key]
        public int MekanDetayId { get; set; }

        public virtual Mekan Mekan { get; set; }
        public int MekanId { get; set; }

        public string Salon { get; set; }
        public int Kapasite { get; set; }

        public string Aciklama { get; set; }

        public int OturmaPlaniId { get; set; }
        public virtual OturmaPlani OturmaPlani { get; set; }

        public virtual Fotograf Fotograf { get; set; }

        public virtual List<Fotograf> Fotograflar { get; set; }
        public virtual List<Fotograf> OturmaPlaniFotograflar { get; set; }


    }
}
