using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitapSatisSayfasi.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")] //sadece admin olan admin paneline ulaşabilir. üye girmeye çalışırsa uyarı verecek. 
    //Authorize: url elle girilince girilmesini önlüyor. güvenlik için. yetkisi olankişiye özel olan sayfadır çünkü.
    [Area("Admin")]
    public class PanelController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
