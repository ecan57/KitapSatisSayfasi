using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitapSatisSayfasi.Models
{
    public class Kitap
    {
        public int KitapID { get; set; }
        [Column(TypeName = "varchar"),Required(ErrorMessage ="Boş geçilemez."),StringLength(100)]
        [Display(Name ="Kitap Adı")]
        public string KitapAdi { get; set; }
        public int YazarID { get; set; }
        public int YayinEviID { get; set; }
        public string KapakResmi { get; set; }
        public string Ozet { get; set; }
        public decimal Fiyat { get; set; }
        public DateTime BasimTarihi { get; set; }
        public int TavsiyeSayisi { get; set; }
        public int StokAdeti { get; set; }

        
        public ICollection<KitapKategori> KitapKategoriler { get; set; }
        public ICollection<SatisDetay> SatisDetaylar { get; set; }
        public ICollection<Sepet> Sepetler { get; set; }

        public Yazar Yazar { get; set; }
        public YayinEvi YayinEvi { get; set; }

    }
}
