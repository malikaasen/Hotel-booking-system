using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
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
		List<Rom> roms = new List<Rom>();
        // GET: RomReservasjon
		[HttpGet]
        public ActionResult Index()
        {
			return View(roms);
        }

		[HttpPost]
		public ActionResult Index(DateTime fdato, DateTime tdato, String storrelse, String kvalitet, String antallsenger)
		{
			roms = romProvider.FinnAlleRom();
			return View(roms);
		}
	}

}