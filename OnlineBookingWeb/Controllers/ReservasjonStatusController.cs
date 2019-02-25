using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineBookingWeb.Controllers
{
    public class ReservasjonStatusController : Controller
    {
        // GET: ReservasjonStatus
        public ActionResult Index()

        {
            KundeDataprovider kundeDataprovder = new KundeDataprovider();
            ReservasjonDataprovider reservasjonDataprovider = new ReservasjonDataprovider();

            var reservasjoner = reservasjonDataprovider.FinnAlleReservasjoner();
            return View(reservasjoner);
        }


    }
}