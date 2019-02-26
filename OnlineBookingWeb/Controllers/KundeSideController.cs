using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookingWeb.Controllers
{
    public class KundeSideController : Controller
    {
        KundeDataprovider kundeDataprovider;
        // GET: KundeSide
        public ActionResult Index(string userName)
        {
            Kunde kunden;
            if (userName != null)
            {
                kundeDataprovider = new KundeDataprovider();
                kunden = kundeDataprovider.FinnKunde(userName);
            }
            else kunden = new Kunde();
            return View(kunden);
        }


    }
}