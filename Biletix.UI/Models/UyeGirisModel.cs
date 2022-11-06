using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Biletix.UI.Models
{
    public class UyeGirisModel
    {
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Ad { get; set; }

        public bool OnaylandiMi { get; set; }

    }
}