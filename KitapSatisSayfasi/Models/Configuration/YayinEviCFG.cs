using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitapSatisSayfasi.Models.Configuration
{
    public class YayinEviCFG : IEntityTypeConfiguration<YayinEvi>
    {
        public void Configure(EntityTypeBuilder<YayinEvi> builder)
        {
            builder.HasData(new YayinEvi() {YayinEviID=1, YayinEviAdi = "ABC", Adres="Avcılar" });
            builder.HasData(new YayinEvi() {YayinEviID=2, YayinEviAdi = "CBA", Adres="Beylikdüzü" });
        }
    }
}
