using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelMekanDetay
    {

        public int MekanDetayId { get; set; }

        public virtual Mekan Mekan { get; set; }
        public int MekanId { get; set; }

        public string Salon { get; set; }
        public int Kapasite { get; set; }

        public string Aciklama { get; set; }

        public List<string> StrFotoListesi { get; set; }
        public List<string> StrOturmaPlaniFoto { get; set; }


        public int OturmaPlaniId { get; set; }
        public virtual OturmaPlani OturmaPlani { get; set; }

        public virtual Fotograf Fotograf { get; set; }

        public virtual List<Fotograf> Fotograflar { get; set; }
    }
}
