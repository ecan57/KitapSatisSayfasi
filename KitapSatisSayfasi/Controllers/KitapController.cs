using Microsoft.AspNetCore.Mvc;
using KitapSatisSayfasi.Data;
using KitapSatisSayfasi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KitapSatisSayfasi.Controllers
{
    public class KitapController : Controller
    {
        ApplicationDbContext _db;
        public KitapController(ApplicationDbContext db)
        {
            _db=db;
           //db.Database.EnsureDeleted();//Önce database varsa sil
           //db.Database.EnsureCreated();//sonra ekle
           ///Register da kişi eklemek için bu kodların açık olması gerek!!!
        }
        public IActionResult Index()
        {
            return View(_db.Kitaplar.Include("Yazar").ToList());
        }
        public IActionResult Detay(int id)
        {
            return View(_db.Kitaplar.Include("Yazar").Include("YayinEvi").Where(k=>k.KitapID == id).Single());
        }
    }
}
