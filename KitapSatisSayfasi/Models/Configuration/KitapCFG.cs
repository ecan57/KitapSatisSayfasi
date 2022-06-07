using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace KitapSatisSayfasi.Models.Configuration
{
    public class KitapCFG : IEntityTypeConfiguration<Kitap>
    {


        public void Configure(EntityTypeBuilder<Kitap> builder)
        {
            builder.HasData(new Kitap() {KitapID=1, KitapAdi = "Beyoğlunun En Güzel Abisi", YazarID = 1, YayinEviID = 1, TavsiyeSayisi = 0, KapakResmi = "Beyoğlunun En Güzel Abisi", Fiyat = 45, Ozet = "....", StokAdeti = 10, BasimTarihi = DateTime.Parse("12/12/2012") });
            builder.HasData(new Kitap() {KitapID=2, KitapAdi = "Savaş ve Barış", YazarID = 2, YayinEviID = 1, TavsiyeSayisi = 0, KapakResmi = "Savaş Ve BARIŞ", Fiyat = 55, Ozet = "....", StokAdeti = 10, BasimTarihi = DateTime.Parse("12/12/2015") });
        }
    }
}
