using System.Collections.Generic;

namespace KitapSatisSayfasi.Models
{
    public class Kategori
    {
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }


        public ICollection<KitapKategori> KitapKategoriler { get; set; }//Bir kitabın çok kategorisi olabilir bir kategorinin çok kitabı olabilir o yüzden bu şekilde tanımlıyoruz

    }
}
