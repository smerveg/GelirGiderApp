using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GelirGiderApp.UI.Models
{
    public class GelirGiderVM
    {
        public int GelirGiderID { get; set; }
        [DisplayName("Başlık")]
        public string Baslik { get; set; }
        [DisplayName("Tarih")]
        public DateTime Tarih { get; set; }
        [DisplayName("Urun")]
        [Required(ErrorMessage ="Lütfen bir ürün seçiniz")]
        public int UrunID { get; set; }
        [DisplayName("Urun")]
        public string UrunAd { get; set; }
        [DisplayName("Kategori")]
        [Required(ErrorMessage = "Lütfen bir kategori seçiniz")]
        public int KategoriID { get; set; }
        [DisplayName("Kategori")]
        public string KategoriAd { get; set; }
        public int TurID { get; set; }
        public string TurAd { get; set; }
        [DisplayName("Miktar")]
        public float Miktar { get; set; }
        [DisplayName("Dönem")]
        [Required(ErrorMessage = "Lütfen bir dönem seçiniz")]
        public int DonemID { get; set; }
        public string DonemAd { get; set; }
        public double ToplamGelir { get; set; } = 0.0;
        public double ToplamGider { get; set; } = 0.0;
    }
}
