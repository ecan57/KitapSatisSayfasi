using KitapSatisSayfasi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KitapSatisSayfasi.Models.Configuration;
namespace KitapSatisSayfasi.Data
{
    public class ApplicationDbContext : IdentityDbContext<Uye, Rol, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Kitap> Kitaplar { get; set; }//Sql serverda tablolara karşılık gelicek sınıflarımız
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<KitapKategori> KitapKategoriler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Rol> Roller { get; set; }
        public DbSet<Satis> Satislar { get; set; }
        public DbSet<SatisDetay> SatisDetaylar { get; set; }
        public DbSet<YayinEvi> YayinEvleri { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Rol>().HasData(new Rol() { Name = "Admin", NormalizedName = "ADMİN" }); DATA EKLEME YÖNTEMİ
            builder.ApplyConfiguration(new RolCFG());
            builder.ApplyConfiguration(new UyeCFG());
            builder.ApplyConfiguration(new KitapCFG());
            builder.ApplyConfiguration(new KategoriCFG());
            builder.ApplyConfiguration(new YazarCFG());
            builder.ApplyConfiguration(new KitapKategoriCFG());
            builder.ApplyConfiguration(new YayinEviCFG());

            base.OnModelCreating(builder);
        }


    }
}
