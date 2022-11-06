using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Data
{
    public class BiletixContext :DbContext
    {
        public BiletixContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BiletixContext, BiletixConfiguration>());
            //Database.Connection.ConnectionString = "Server=.;Database=BiletixDB;Integrated security=true";
            Database.Connection.ConnectionString = "Server=mssql07.turhost.com;Database=BiletixDB;uid=saBilet;pwd=Biletx123";

        }


        private static BiletixContext _context;

        public static BiletixContext ContextOlustur()
        {
            return _context ?? (_context = new BiletixContext());
        }

        public DbSet<AltKategori> AltKategori { get; set; }
        public DbSet<BiletDetayı> BiletDetayi { get; set; }
        public DbSet<BiletSiparisi> BiletSiparisi { get; set; }
        public DbSet<Bolge> Bolge { get; set; }
        public DbSet<Calisan> Calisan { get; set; }
        public DbSet<EtkinlikBasvuru> EtkinlikBasvur { get; set; }
        public DbSet<FiyatTablosu> FiyatTablosu { get; set; }
        public DbSet<Fotograf> Fotograf { get; set; }
        public DbSet<Gosteri> Gosteri { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Mekan> Mekan { get; set; }
        public DbSet<MekanBasvuru> MekanBasvuru { get; set; }
        public DbSet<MekanDetayi> MekanDetayi { get; set; }
        public DbSet<OturmaPlani> OturmaPlani { get; set; }
        public DbSet<Sanatci> Sanatci { get; set; }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Uye> Uye { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
