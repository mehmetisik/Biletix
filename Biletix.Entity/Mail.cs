﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
   public class Mail
    {
        public int MailId { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
        public string GonderilecekMailAdresi { get; set; }

    }
}
