using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapSatisSayfasi.Models.Configuration
{
    public class YazarCFG : IEntityTypeConfiguration<Yazar>
    {
        public void Configure(EntityTypeBuilder<Yazar> builder)
        {
            builder.HasData(new Yazar() {YazarID=1, YazarAdi = "Ahmet Ümit" ,Biyografi=""});
            builder.HasData(new Yazar() {YazarID=2, YazarAdi = "Tolstoy",Biyografi="" });
            builder.HasData(new Yazar() {YazarID=3, YazarAdi = "Dostoyevski",  Biyografi = "" });
            builder.HasData(new Yazar() {YazarID=4, YazarAdi = "Cengiz Aymetov",Biyografi="" });
            builder.HasData(new Yazar() {YazarID=5, YazarAdi = "İskender Pala",Biyografi="" });
            builder.HasData(new Yazar() {YazarID=6, YazarAdi = "Jack London" ,Biyografi=""});
        }
    }
}
