using KitapSatisSayfasi.Data;
using KitapSatisSayfasi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSatisSayfasi.Areas.Uyeler.Controllers
{
    [Authorize]
    [Area("Uyeler")]
    public class PanelController : Controller
    {
        UserManager<Uye> _userManager;
        ApplicationDbContext _db;
        //private int uyeID;
        public PanelController(ApplicationDbContext db, UserManager<Uye> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        
        public IActionResult Index()
        {
            int uyeID = int.Parse(_userManager.GetUserId(User));
            var result = _db.Sepetler.Include("Kitap").Where(s => s.UyeID == uyeID).ToList();
            return View(result);
        }
        public IActionResult SepeteEkle(int id)
        {//yoksa insert, varsa update

            int uyeID = int.Parse(_userManager.GetUserId(User));
            if (_db.Sepetler.Where(s=>s.Kitap.KitapID==id && s.UyeID == uyeID).Count() > 0)
            {
                //update
                Sepet sepet = _db.Sepetler.Where(s => s.Kitap.KitapID == id && s.UyeID == uyeID).Single();
                sepet.Adet += 1;
                _db.Entry<Sepet>(sepet).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                //insert
                Sepet sepet = new Sepet { KitapID = id, UyeID = uyeID, Adet = 1 };
                _db.Sepetler.Add(sepet);
            }
            _db.SaveChanges();
            return Redirect("~/Kitap/Index");
        }
        public IActionResult SepettenCikar(int id)
        {
            int uyeID = int.Parse(_userManager.GetUserId(User));
            Sepet sepet = _db.Sepetler.Find(id);
            if (sepet.Adet > 1)
            {
                //update
                sepet.Adet -= 1;
                _db.Entry(sepet).State = EntityState.Modified;
            }
            else if (sepet.Adet == 1)
            {
                //delete
                _db.Sepetler.Remove(sepet);
            }
            _db.SaveChanges();
            return Redirect("~/Uyeler/Panel/Index");
        }
        public IActionResult SepetiBosalt()
        {
            int uyeID = int.Parse(_userManager.GetUserId(User));
            SepetinTumunuTemizle(uyeID);
            return Redirect("~/Uyeler/Panel/Index");
        }
        private void SepetinTumunuTemizle(int uyeID)
        {
            var sonuc = _db.Sepetler.Where(s => s.UyeID == uyeID).ToList();
            _db.Sepetler.RemoveRange(sonuc);
            _db.SaveChanges();
        }
        private bool StokKontrolu(int uyeID, out string detay, out decimal toplamTutar)
        {//true ise stokta var, false ise stokta yok
            bool kontrol = true;
            detay = "";
            var sonuc = _db.Sepetler.Include("Kitap").Where(s => s.UyeID == uyeID).ToList();
            toplamTutar = 0;
            foreach (Sepet sepet in sonuc)
            {
                if (sepet.Adet > sepet.Kitap.StokAdeti)
                {
                    kontrol = false;
                    detay += sepet.Kitap.KitapAdi + " " + sepet.Kitap.StokAdeti + " ";
                }
                toplamTutar += sepet.Adet * sepet.Kitap.Fiyat;
            }
            return kontrol;
        }
        public IActionResult SatinAl()
        {
            //1-Stok Kontrolü
            //2-Satışa Kaydet
            //3-Detaya Kaydet
            //4-Stoktan Düş
            //5-Sepeti Boşalt
            int uyeID = int.Parse(_userManager.GetUserId(User));
            if (StokKontrolu(uyeID, out string Mesaj, out decimal toplamTutar))
            {//2.aşama
                Satis satis = new Satis()
                {
                    UyeID = uyeID,
                    SatisTarihi = DateTime.Now,
                    ToplamTutar = toplamTutar
                };
                _db.Satislar.Add(satis);
                _db.SaveChanges();

                int satisID = satis.SatisID;
                //3.aşama
                var sepet = _db.Sepetler.Include("Kitap").Where(s => s.UyeID == uyeID).ToList();
                foreach (Sepet s in sepet)
                {
                    //Satiş detay yaz
                    SatisDetay detay = new SatisDetay
                    {
                        KitapID = s.KitapID,
                        SatisID = satisID,
                        Adet = s.Adet,
                        Fiyat = s.Kitap.Fiyat
                    };
                    _db.SatisDetaylar.Add(detay);
                    //stoktan düş
                    s.Kitap.StokAdeti -= s.Adet;
                    _db.Entry(s.Kitap).State = EntityState.Modified;
                }
                _db.SaveChanges();
                SepetinTumunuTemizle(uyeID);
            }
            else
            {
                TempData["Mesaj"] = Mesaj;
            }
            return Redirect("~/Uyeler/Panel/Index");
        }
    }
}
