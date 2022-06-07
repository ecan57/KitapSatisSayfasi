using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace KitapSatisSayfasi.Models
{
    public class Uye : IdentityUser<int> //varsayılan olarak gelen string değeri int'e çevirecek fakat arkaplanda çoğu ayarı değiştirmek gerekicek
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Adres { get; set; }

        public ICollection<Satis> Satislar { get; set; }
        public ICollection<Sepet> Sepetler { get; set; }

    }
}
