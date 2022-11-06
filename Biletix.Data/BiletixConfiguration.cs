using Biletix.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biletix.Data
{
    public class BiletixConfiguration : DbMigrationsConfiguration<BiletixContext>
    {
        public BiletixConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BiletixContext context)
        {
            if (context.Kategori.Count() < 5)
            {
                #region Kategoriler ve Alt Kategoriler

                Kategori ktg1 = new Kategori();
                ktg1.KategoriAdi = "Müzik";

                Kategori ktg2 = new Kategori();
                ktg2.KategoriAdi = "Spor";

                Kategori ktg3 = new Kategori();
                ktg3.KategoriAdi = "Sahne Sanatları";

                Kategori ktg4 = new Kategori();
                ktg4.KategoriAdi = "Aile Eğlencesi";

                Kategori ktg5 = new Kategori();
                ktg5.KategoriAdi = "Eğitim&Diğer";

                AltKategori altK11 = new AltKategori();
                altK11.AltKategoriAdi = "Pop";
                altK11.Kategori = ktg1;

                AltKategori altK12 = new AltKategori();
                altK12.AltKategoriAdi = "Rock";
                altK12.Kategori = ktg1;

                AltKategori altK13 = new AltKategori();
                altK13.AltKategoriAdi = "Caz";
                altK13.Kategori = ktg1;

                AltKategori altK14 = new AltKategori();
                altK14.AltKategoriAdi = "Klasik";
                altK14.Kategori = ktg1;

                AltKategori altK15 = new AltKategori();
                altK15.AltKategoriAdi = "Alternatif";
                altK15.Kategori = ktg1;

                AltKategori altK21 = new AltKategori
                {
                    AltKategoriAdi = "Futbool",
                    Kategori = ktg2
                };
                AltKategori altK22 = new AltKategori
                {
                    AltKategoriAdi = "Basketboll",
                    Kategori = ktg2
                };
                AltKategori altK23 = new AltKategori
                {
                    AltKategoriAdi = "Tenis",
                    Kategori = ktg2
                };
                AltKategori altK24 = new AltKategori
                {
                    AltKategoriAdi = "Motor Sporları",
                    Kategori = ktg2
                };
                AltKategori altK25 = new AltKategori
                {
                    AltKategoriAdi = "Voleybol",
                    Kategori = ktg2
                };


                AltKategori altK31 = new AltKategori
                {
                    AltKategoriAdi = "Tiyatro",
                    Kategori = ktg3
                };
                AltKategori altK32 = new AltKategori
                {
                    AltKategoriAdi = "Gösteri",
                    Kategori = ktg3
                };
                AltKategori altK33 = new AltKategori
                {
                    AltKategoriAdi = "Bale-Dans",
                    Kategori = ktg3
                };
                AltKategori altK34 = new AltKategori
                {
                    AltKategoriAdi = "Stand-Up",
                    Kategori = ktg3
                };
                AltKategori altK35 = new AltKategori
                {
                    AltKategoriAdi = "Müzikli Gösteri",
                    Kategori = ktg3
                };
                AltKategori altK36 = new AltKategori
                {
                    AltKategoriAdi = "Opera",
                    Kategori = ktg3
                };

                AltKategori altK41 = new AltKategori();
                altK41.AltKategoriAdi = "Gösteri";
                altK41.Kategori = ktg4;

                AltKategori altK42 = new AltKategori();
                altK42.AltKategoriAdi = "Sirk";
                altK42.Kategori = ktg4;

                AltKategori altK43 = new AltKategori();
                altK43.AltKategoriAdi = "Tiyatro";
                altK43.Kategori = ktg4;

                AltKategori altK44 = new AltKategori();
                altK44.AltKategoriAdi = "Müzikli Gösteri";
                altK44.Kategori = ktg4;

                AltKategori altK51 = new AltKategori();
                altK51.AltKategoriAdi = "Müze";
                altK51.Kategori = ktg5;

                AltKategori altK52 = new AltKategori();
                altK52.AltKategoriAdi = "Atölye";
                altK52.Kategori = ktg5;

                AltKategori altK53 = new AltKategori();
                altK53.AltKategoriAdi = "Eğitim";
                altK53.Kategori = ktg5;

                AltKategori altK54 = new AltKategori();
                altK54.AltKategoriAdi = "Sergi";
                altK54.Kategori = ktg5;

                AltKategori altK55 = new AltKategori();
                altK55.AltKategoriAdi = "Sosyal Sorumluluk";
                altK55.Kategori = ktg5;

                AltKategori altK56 = new AltKategori();
                altK56.AltKategoriAdi = "MEB Onaylı Eğitim";
                altK56.Kategori = ktg5;

                AltKategori altK57 = new AltKategori();
                altK57.AltKategoriAdi = "Konferans";
                altK57.Kategori = ktg5;

                AltKategori altK58 = new AltKategori();
                altK58.AltKategoriAdi = "Fuar";
                altK58.Kategori = ktg5;

                AltKategori altK59 = new AltKategori();
                altK59.AltKategoriAdi = "Ürün Satışı";
                altK59.Kategori = ktg5;



                #endregion


                #region Bolgeler ve Sehirler
                Bolge b1 = new Bolge
                {
                    BolgeAdi = "Marmara"
                };
                Bolge b2 = new Bolge
                {
                    BolgeAdi = "Ege"
                };
                Bolge b3 = new Bolge
                {
                    BolgeAdi = "Akdeniz"
                };

                Sehir s1 = new Sehir
                {
                    SehirAd = "İstanbul",
                    Bolge = b1
                };

                Sehir s2 = new Sehir
                {
                    SehirAd = "Tekirdağ",
                    Bolge = b1
                };

                Sehir s3 = new Sehir
                {
                    SehirAd = "Yalova",
                    Bolge = b1
                };

                Sehir s4 = new Sehir
                {
                    SehirAd = "İzmir",
                    Bolge = b2
                };
                Sehir s5 = new Sehir
                {
                    SehirAd = "Muğla",
                    Bolge = b2
                };
                Sehir s6 = new Sehir
                {
                    SehirAd = "Balıkesir",
                    Bolge = b2
                };

                Sehir s7 = new Sehir
                {
                    SehirAd = "Antalya",
                    Bolge = b3
                };
                Sehir s8 = new Sehir
                {
                    SehirAd = "Burdur",
                    Bolge = b3
                };

                Sehir s9 = new Sehir
                {

                    SehirAd = "Isparta",
                    Bolge = b3
                };

                Sehir s10 = new Sehir
                {
                    SehirAd = "Denizli",
                    Bolge = b2
                };

                #endregion

                #region Calisanlar Uyeler
                Calisan cls = new Calisan
                {
                    Ad = "mehmet",
                    Soyad = "IŞIK",
                    Adres = "Bağcılar",
                    Email = "mehmet@mehmet.com",
                    Sifre = "1",
                    Sehir = s1,
                    Telefon = "123456",
                    Unvan = "Admin",

                };

                Calisan cls2 = new Calisan
                {
                    Ad = "Kemal",
                    Soyad = "deliaci",
                    Adres = "Esenler",
                    Email = "Kemal@Kemal.com",
                    Sifre = "1",
                    Sehir = s1,
                    Telefon = "123456",
                    Unvan = "admin",

                };
                Calisan cls3 = new Calisan
                {
                    Ad = "Harun",
                    Soyad = "Kökten",
                    Adres = "Şirinevler",
                    Email = "harun@harun.com",
                    Sifre = "1",
                    Sehir = s1,
                    Telefon = "123456",
                    Unvan = "Admin",

                };

                Uye uye1 = new Uye
                {
                    Ad = "Murat",
                    Soyad = "Kara",
                    Email = "murat@murat.com",
                    Sifre = "1",
                    Adres = "Ayvalık",
                    Telefon = "324534534",
                    Sehir = s1
                };
                Uye uye2 = new Uye
                {
                    Ad = "Ali",
                    Soyad = "CAN",
                    Email = "ali@ali.com",
                    Sifre = "1",
                    Adres = "Gölhisar",
                    Telefon = "324534534",
                    Sehir = s8

                };
                Uye uye3 = new Uye
                {
                    Ad = "Fatma",
                    Soyad = "Yılmaz",
                    Email = "fatma@fatma.com",
                    Sifre = "1",
                    Adres = "Ayvalık",
                    Telefon = "324534534",
                    Sehir = s6
                };
                Uye uye4 = new Uye
                {
                    Ad = "Mesut",
                    Soyad = "Soylu",
                    Email = "mesut@mesut.com",
                    Sifre = "1",
                    Adres = "Bornova",
                    Telefon = "324534534",
                    Sehir = s4

                }; 
                #endregion

                Mekan mk1 = new Mekan
                {
                    MekanAdi = "Harbiye Cemil Topuzlu Açıkhava Sahnesi",
                    Adres = "Beşiktaş",
                    Sehir = s1
                };
                Mekan mk2 = new Mekan
                {
                    MekanAdi = "EGS Kongre Kültür Merkezi",
                    Adres = "Denizli Meydan",
                    Sehir = s10
                };
                Mekan mk3 = new Mekan
                {
                    MekanAdi = "Expo 2016 Antalya Turkcell Büyük Amfitiyatro",
                    Adres = "Aksu",
                    Sehir = s7
                };

                OturmaPlani otrP1 = new OturmaPlani
                {
                    OturmaPlan = "Ayakta"
                };
                OturmaPlani otrP2 = new OturmaPlani
                {
                    OturmaPlan = "Koltuklu"
                };
                OturmaPlani otrP3 = new OturmaPlani
                {
                    OturmaPlan = "Karışık"
                };

                context.Kategori.AddOrUpdate(ktg1, ktg2, ktg3,ktg4,ktg5);
                context.AltKategori.AddOrUpdate(altK11,altK12,altK13,altK21,altK22,altK23,altK31,altK32,altK33,altK41,altK42,altK43,altK44,altK51,altK52,altK53,altK54,altK55,altK56,altK57,altK58,altK59);
                context.Bolge.AddOrUpdate(b1,b2,b3);
                context.Sehir.AddOrUpdate(s1,s2,s3,s4,s5,s6,s7,s8,s9);
                context.Calisan.AddOrUpdate(cls,cls2,cls3);
                context.Uye.AddOrUpdate(uye1,uye2,uye3,uye4);
                //context.Mekan.AddOrUpdate(mk1,mk2,mk3);
                context.OturmaPlani.AddOrUpdate(otrP1,otrP2,otrP3);

            }

            base.Seed(context);
        }
    }
}
