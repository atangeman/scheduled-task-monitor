
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ScheduledTaskMonitor.Models;

namespace ScheduledTaskMonitor.Controllers
{
    public class UserController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /User/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /User/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            UserStore<IdentityUser> _userStore = new UserStore<IdentityUser>();
            UserManager<IdentityUser> _userManager = new UserManager<IdentityUser>(_userStore);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userManager.Find(model.Email, model.Password);

            if (user != null)
            {
                var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
        }
        //
        // POST: /User/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            var authenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction("Home", "Movies");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Home", "Movies");
        }
        //
        // GET: /User/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /User/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return View("Error");
            }
            else
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = new IdentityUser() { UserName = model.Email };
                IdentityResult result = userManager.Create(user, model.Password);
                return RedirectToAction("Home", "Movies");
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}
