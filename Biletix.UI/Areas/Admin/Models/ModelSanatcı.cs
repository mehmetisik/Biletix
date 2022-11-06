using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biletix.UI.Areas.Admin.Models
{
    public class ModelSanatcı
    {
        public ModelSanatcı()
        {
            Fotograflar = new List<Fotograf>();
        }

        public int SanatciId { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public virtual List<Fotograf> Fotograflar { get; set; }
    }

}