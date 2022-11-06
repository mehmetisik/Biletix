using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class BiletDetayı
    {

       [Key]
        public int BiletDetayId { get; set; }

        public int BiletSiparisId { get; set; }
        public virtual BiletSiparisi BiletSiparisi { get; set; }

        public int Adet { get; set; }
        public decimal ToplamTutar { get; set; }

    }
}
