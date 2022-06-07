namespace KitapSatisSayfasi.Models
{
    public class KitapKategori
    {
        public int KitapKategoriID { get; set; }
        public int KitapID { get; set; }
        public int KategoriID { get; set; }

        public Kitap Kitap { get; set; }
        public Kategori Kategori { get; set; }
    }
}
