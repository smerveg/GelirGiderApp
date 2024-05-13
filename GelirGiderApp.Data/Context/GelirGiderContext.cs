using GelirGiderApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Data.Context
{
    public class GelirGiderContext:DbContext
    {
        public GelirGiderContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<GelirGider> GelirGiders { get; set; }
        public DbSet<Urun> Uruns { get; set; }
        public DbSet<Kategori> Kategoris { get; set; }
        public DbSet<Tur> Turs { get; set; }
    }
}
