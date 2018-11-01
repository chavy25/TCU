using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using prTCUv2.ViewModels;
//using prTCUv2.Services;
using System.Web.Security;
//using System.Runtime.Caching;

namespace prTCUv2.Controllers
{
    public class HomeController : Controller
    {
        #region Class Instances
        //private LoginService oLogin = new LoginService();
        #endregion

        // GET: Home
        public ActionResult Index(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost, ActionName("Index")]
        public ActionResult Login(vmLogin Usuario, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(Usuario.UserName, false);
            if (!string.IsNullOrEmpty(returnUrl) && (returnUrl.Contains("/Admin/")))
                return Redirect(returnUrl);
            else
                return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public void LogOut(string Module)
        {
            //oLogin.UserDisconnected(HttpContext.User.Identity.Name, Module);
            FormsAuthentication.SignOut();
        }

        [HttpPost]
        public bool checkTimeout()
        {
            return User.Identity.IsAuthenticated;
        }
    }
}