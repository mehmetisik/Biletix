using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelSehir
    {
        public int SehirId { get; set; }
        public string SehirAd { get; set; }

        public int BolgeId { get; set; }
        public virtual Bolge Bolge { get; set; }


    }
}
