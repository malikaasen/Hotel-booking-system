using SQLConnectionApplication.DataProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace OnlineBookingWeb.Controllers
{
    public class RomReservasjonController : Controller
    {
		RomDataprovider romProvider = new RomDataprovider();
        // GET: RomReservasjon
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult FinnLedigRom(DateTime fdato, DateTime tdato)
		{
			var model = romProvider.FinnAlleRom();
			return View(model);
		}
	}

}