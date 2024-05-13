using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GelirGiderApp.Data.DTO
{
    public class GelirGiderDTO
    {
        public int GelirGiderID { get; set; }
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
        public float Miktar { get; set; }
        public int UrunID { get; set; }
 
        public string UrunAd { get; set; }
 
        public int KategoriID { get; set; }
      
        public string KategoriAd { get; set; }
        public int TurID { get; set; }
        public string TurAd { get; set; }
        public double ToplamGelir { get; set; }
        public double ToplamGider { get; set; }
    }
}
