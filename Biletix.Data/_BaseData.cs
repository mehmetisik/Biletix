using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Data
{
    public class _BaseData<TEntity> where TEntity : class
    {
        private BiletixContext _context = BiletixContext.ContextOlustur();


        public TEntity Kaydet(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);

            _context.SaveChanges();

          return  _context.Set<TEntity>().ToList().Last();
        }

        public void Guncelle(TEntity obj)
        {
            _context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Sil(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public TEntity IDyeGoreGetir(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> TumunuGetir()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

    }
}
