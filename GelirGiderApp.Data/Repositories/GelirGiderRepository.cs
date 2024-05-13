using GelirGiderApp.Data.Context;
using GelirGiderApp.Data.DataSeed;
using GelirGiderApp.Data.DTO;
using GelirGiderApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Data.Repositories
{
    public class GelirGiderRepository : IGelirGiderRepository
    {
        private readonly GelirGiderContext _context;

        public GelirGiderRepository(GelirGiderContext context)
        {
            _context = context;
            ////MockData data = new MockData(_context);
            ////data.Seed();

        }
        public async Task<int> Add(GelirGider entity)
        {
             _context.GelirGiders.Add(entity);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(int id)
        {
            var gelirGider = _context.GelirGiders.Find(id);
            _context.GelirGiders.Remove(gelirGider);
            return await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<GelirGider>> GetAll()
        {

            var r= await _context.GelirGiders.ToListAsync();
            return r;
        }

        public async Task<GelirGider> GetById(int id)
        {
            return await _context.GelirGiders.FirstOrDefaultAsync(g => g.GelirGiderID == id);
        }

        public async Task<GelirGider> Sum(int donem, int urun, int kategori)
        {
            List<GelirGider> list = new List<GelirGider>();
            if (donem==0 && urun ==0 && kategori==0)
            {
                list = await _context.GelirGiders.ToListAsync();
            }
            else if(urun==0 && kategori!=0)
            {
                list = await _context.GelirGiders.Where(k => k.KategoriID == kategori).ToListAsync();
            }
            else if (kategori == 0 && urun != 0)
            {
                list = await _context.GelirGiders.Where(u => u.UrunID == urun).ToListAsync();
            }
            else
            {
                list = await _context.GelirGiders.Where(u => u.UrunID == urun).Where(k => k.KategoriID == kategori).ToListAsync();
            }            

            var toplamGelir=list.Where(w=>w.TurID==1).OrderByDescending(o => o.Tarih).Take(donem).Sum(s => s.Miktar);
            var toplamGider = list.Where(w => w.TurID == 2).OrderByDescending(o => o.Tarih).Take(donem).Sum(s => s.Miktar);

            GelirGider gelirGider = new GelirGider();
            gelirGider.ToplamGelir = toplamGelir;
            gelirGider.ToplamGider = toplamGider;
            return gelirGider;
        }

        public async Task<int> Update(GelirGider entity)
        {
              _context.Update(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
