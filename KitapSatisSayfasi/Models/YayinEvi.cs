using System.Collections.Generic;

namespace KitapSatisSayfasi.Models
{
    public class YayinEvi
    {
        public int YayinEviID { get; set; }
        public string YayinEviAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }


        public ICollection<Kitap> Kitaplar { get; set; }
    }
}
