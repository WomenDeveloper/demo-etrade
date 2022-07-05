using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebApplication1.Models;
using WebApplication1.Data;

namespace WebApplication1.Areas.Uyeler.Controllers
{
    [Authorize(Roles ="Uye")]
    [Area("Uyeler")]
    public class PanelController : Controller
    {
        private readonly UserManager<Uye> _userManager;
        private readonly ApplicationDbContext _db;

        public PanelController(UserManager<Uye> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db; 
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SepeteEkle(int id)
        {
            _db.Sepetler.Add(new Sepet() { UrunID=id, UyeID=GetUserID(), Adet=1 });
            _db.SaveChanges();
            return Redirect("~/Urun");
           // return Content(id+ " UyeID " + GetUserID());
        }

        private int GetUserID()
        {
            return Convert.ToInt32(_userManager.GetUserId(User));
        }
    }
}
