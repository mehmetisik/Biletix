using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class BiletSiparisi
    {
        [Key]
        public int BiletSiparisId { get; set; }
        public DateTime BiletAlisTarihi { get; set; }

        public int UyeId { get; set; }
        public virtual Uye Uye { get; set; }

        public int GosteriId { get; set; }
        public virtual Gosteri Gosteri { get; set; }
      


    }
}
