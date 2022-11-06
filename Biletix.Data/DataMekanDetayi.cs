using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Data
{
    public class DataMekanDetayi : _BaseData<MekanDetayi>
    {

        public  IQueryable<MekanDetayi> MekanaGoreDetayListesi(int id)
        {
            return TumunuGetir().Where(x => x.MekanId == id).AsQueryable();
        }
    }
}
