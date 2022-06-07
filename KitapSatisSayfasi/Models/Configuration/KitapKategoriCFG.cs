using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapSatisSayfasi.Models.Configuration
{
    public class KitapKategoriCFG : IEntityTypeConfiguration<KitapKategori>
    {
        public void Configure(EntityTypeBuilder<KitapKategori> builder)
        {
            builder.HasData(new KitapKategori() {KitapKategoriID=1, KitapID = 1, KategoriID = 3 });
            builder.HasData(new KitapKategori() {KitapKategoriID=2, KitapID = 2, KategoriID = 2 });
        }
    }
}
