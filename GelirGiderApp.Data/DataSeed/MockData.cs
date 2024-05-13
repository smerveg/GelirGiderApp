using GelirGiderApp.Data.Context;
using GelirGiderApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Data.DataSeed
{
    public class MockData
    {
        private readonly GelirGiderContext _context;

        public MockData(GelirGiderContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _context.GelirGiders.AddRange(
                new GelirGider()
                {
                    GelirGiderID = 1,
                    Baslik = "gelir1",
                    Tarih = DateTime.Now,
                    UrunID = 1,
                    UrunAd = null,
                    KategoriID = 2,
                    KategoriAd = null,
                    Miktar = 100,
                    TurID=1,
                    TurAd=null

                },
                new GelirGider()
                {
                    GelirGiderID = 2,
                    Baslik = "gelir2",
                    Tarih = DateTime.Now,
                    UrunID = 2,
                    UrunAd = null,
                    KategoriID = 2,
                    KategoriAd = null,
                    Miktar = 300,
                    TurID = 1,
                    TurAd = null
                },
                new GelirGider()
                {
                    GelirGiderID = 3,
                    Baslik = "gider3",
                    Tarih = DateTime.Now,
                    UrunID = 1,
                    UrunAd = null,
                    KategoriID = 5,
                    KategoriAd = null,
                    Miktar = 195,
                    TurID = 2,
                    TurAd = null
                },
                new GelirGider()
                {
                    GelirGiderID = 4,
                    Baslik = "gider4",
                    Tarih = DateTime.Now,
                    UrunID = 2,
                    UrunAd = null,
                    KategoriID = 3,
                    KategoriAd = null,
                    Miktar = 10,
                    TurID = 2,
                    TurAd = null

                },
                new GelirGider()
                {
                    GelirGiderID = 5,
                    Baslik = "gelir5",
                    Tarih = DateTime.Now,
                    UrunID = 2,
                    UrunAd = null,
                    KategoriID = 5,
                    KategoriAd = null,
                    Miktar = 10,
                    TurID = 1,
                    TurAd = null

                }



                );

            _context.Uruns.AddRange(
                new Urun() { UrunID=1,UrunAd="Hesap"},
                new Urun() { UrunID=2,UrunAd="Kart"}
                                          
                );
            _context.Kategoris.AddRange(
                new Kategori() { KategoriID = 1, KategoriAd = "Kira" },
                new Kategori() { KategoriID = 2, KategoriAd = "Bağış" },
                new Kategori() { KategoriID = 3, KategoriAd = "Vergi" },
                new Kategori() { KategoriID = 4, KategoriAd = "Aidat" },
                new Kategori() { KategoriID = 5, KategoriAd = "Diğer" }

                );
            _context.Turs.AddRange(
                new Tur() { TurID = 1, TurAd = "Gelir" },
                new Tur() { TurID = 2, TurAd = "Gider" }

                );

            _context.SaveChanges();

        }

    }
}
