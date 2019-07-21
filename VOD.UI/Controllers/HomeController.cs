using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VOD.UI.Models;
using Microsoft.AspNetCore.Identity;
using VOD.Common.Entities;
using VOD.Database.Services;
using System.Threading.Tasks;

namespace VOD.UI.Controllers
{
    public class HomeController : Controller
    {
        private SignInManager<VODUser> _signInManager;
        //private IDbReadService _db;

        public HomeController(SignInManager<VODUser> signInMgr/*, IDbReadService db*/)
        {
            _signInManager = signInMgr;
            //_db = db;
        }

        public async Task<IActionResult> Index()
        {
            if (!_signInManager.IsSignedIn(User))
                return RedirectToPage("/Account/Login", new { Area = "Identity" });
            /*_db.Include<Download>();
            _db.Include<Module, Course>();
            var result1 = await _db.SingleAsync<Download>(d => d.Id.Equals(3));
            var result2 = await _db.GetAsync<Download>();
            var result3 = await _db.GetAsync<Download>(d=>d.ModuleId.Equals(1));
            var result4 = await _db.AnyAsync<Download>(d=>d.ModuleId.Equals(1));*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
