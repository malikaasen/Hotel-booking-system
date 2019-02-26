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
		ReservasjonDataprovider reservasjonProvider = new ReservasjonDataprovider();
		KundeDataprovider kundeDataprovider = new KundeDataprovider();
		List<Rom> roms = new List<Rom>();



		// GET: RomReservasjon
		[HttpGet]
		public ActionResult Index(String KundeID)
		{
			var kundeid = Convert.ToInt32(KundeID);
			this.Session["kundeID"] = kundeid;
			System.Diagnostics.Debug.WriteLine(kundeid);
			return View(roms);
		}

		[HttpPost]
		public ActionResult Index(DateTime fdato, DateTime tdato, int storrelse, int kvalitet, int antallsenger)
		{
			var kunde = this.Session["kundeID"];
			this.Session["kundeID"] = kunde;
			this.Session["fraDato"] = fdato;
			this.Session["tilDato"] = tdato;



			var rommene = romProvider.FinnAlleRom();
			//	var reservasjonene = reservasjonProvider.FinnAlleReservasjoner();
			var muligrom = (from rom in rommene
							where gyldigRom(rom.Reservasjoner, fdato, tdato) && gyldigValg(rom, storrelse, kvalitet, antallsenger)
							select rom).ToList();



			roms = (List<Rom>)muligrom;
			return View(muligrom);
		}
		[HttpPost]
		public ActionResult VelgRom(String RomID)
		{
			int romID = Convert.ToInt32(RomID);
			int kundeID = Convert.ToInt32(this.Session["kundeID"]);
			Reservasjon reservasjon = new Reservasjon();
			reservasjon.RomId = romID;
			reservasjon.KundeId = Convert.ToInt32(this.Session["kundeID"]);
			reservasjon.TilDato = Convert.ToDateTime(this.Session["fraDato"]);
			reservasjon.FraDato = Convert.ToDateTime(this.Session["tilDato"]);
			reservasjon.ReservasjonStatus = 0;

			System.Diagnostics.Debug.WriteLine(romID);
			System.Diagnostics.Debug.WriteLine(Convert.ToDateTime(this.Session["fraDato"]));
			System.Diagnostics.Debug.WriteLine(Convert.ToDateTime(this.Session["tilDato"]));

			reservasjonProvider.LeggTilReservasjon(reservasjon);
			return RedirectToAction("Index", "KundeSide", new { userName = kundeDataprovider.FinnKunde(kundeID).Navn });
		}
		public Boolean gyldigValg(Rom rom, int storrelse, int kvalitet, int antallsenger)
		{
			//if (((int) rom.Storrelse > storrelse) && ((int) rom.Kvalitet > kvalitet) && (rom.AntallSenger > antallsenger))
			if (rom.AntallSenger < antallsenger)
			{
				return false;
			}
			if ((int)rom.Storrelse < storrelse)
			{
				return false;
			}
			if ((int)rom.Kvalitet < kvalitet)
			{
				return false;
			}
			return true;

		}
		public Boolean gyldigRom(ICollection<Reservasjon> reservasjons, DateTime fdato, DateTime tdato)
		{
			foreach (Reservasjon reservasjon in reservasjons)
			{
				if ((reservasjon.FraDato >= fdato && reservasjon.FraDato <= tdato) || (reservasjon.TilDato >= fdato && reservasjon.TilDato <= tdato))
				{
					return false;
				}
			}
			return true;
		}
	}

}