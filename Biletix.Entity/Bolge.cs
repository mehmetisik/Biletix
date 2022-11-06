using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    
    public class Bolge
    {
        public Bolge()
        {
            Sehirler = new List<Sehir>();
        }

        public int BolgeId { get; set; }
        public string BolgeAdi { get; set; }

        public virtual List<Sehir> Sehirler { get; set; }

    }
}
