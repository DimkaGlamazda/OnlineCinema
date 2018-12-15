using Microsoft.Owin.Security.Cookies;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
namespace OnlineCinema.API.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager _userManager;

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        
        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut(CookieAuthenticationDefaults.AuthenticationType);

            return RedirectToAction("index");
        }
    }
}
