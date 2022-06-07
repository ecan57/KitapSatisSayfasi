using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapSatisSayfasi.Models.Configuration
{
    public class KategoriCFG : IEntityTypeConfiguration<Kategori>
    {
        public void Configure(EntityTypeBuilder<Kategori> builder)
        {
            builder.HasData(new Kategori() {KategoriID=1, KategoriAdi = "Macera" });
            builder.HasData(new Kategori() {KategoriID=2, KategoriAdi = "Tarih" });
            builder.HasData(new Kategori() {KategoriID=3, KategoriAdi = "Polisiye" });
            builder.HasData(new Kategori() {KategoriID=4, KategoriAdi = "Spor" });
        }
    }
}
