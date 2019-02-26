using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookingWeb.Controllers
{
    public class RegistrerController : Controller
    {
        KundeDataprovider kundeDataprovider;
        // GET: Registrer
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(string userName, string password)
        {
            kundeDataprovider = new KundeDataprovider();
            if (!(String.IsNullOrWhiteSpace(userName) && String.IsNullOrWhiteSpace(password))){
                Kunde kunde = new Kunde();
                kunde.KundeID = 1;
                kunde.Navn = userName;
                kunde.Passord = password;
                kundeDataprovider.LeggTilKunde(kunde);

                return RedirectToAction("index", "Login");
            }
            else return RedirectToAction("index", "Registrer");
        }
    }
}