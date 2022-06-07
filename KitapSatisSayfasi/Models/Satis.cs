using System;
using System.Collections.Generic;

namespace KitapSatisSayfasi.Models
{
    public class Satis
    {
        public int SatisID { get; set; }
        public int UyeID { get; set; }
        public DateTime SatisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }


        public Uye Uye { get; set; }
        public ICollection<SatisDetay> SatisDetaylar { get; set; }

    }
}
