using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Entity
{
    public class OturmaPlani
    {
        //public OturmaPlani()
        //{
        //    Fotograflar = new List<Fotograf>();
        //}
        [Key]
        public int OturmaPlanId { get; set; }
        public string OturmaPlan { get; set; }

        //public virtual List<Fotograf> Fotograflar { get; set; }


    }
}
