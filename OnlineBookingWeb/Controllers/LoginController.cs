using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineBookingWeb.Services;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineBookingWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogonUser(string userName, string password)
        {
            var authenticationService = new AuthenticationService();

            if (authenticationService.ValidateUser(userName, password))
            {
                return RedirectToAction("index", "ReservasjonStatus", new { userName = userName });
            }
            else return RedirectToAction("index", "Login");
        }
    }
}