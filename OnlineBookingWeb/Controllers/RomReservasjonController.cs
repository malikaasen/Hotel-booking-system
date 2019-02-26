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
		List<Rom> roms = new List<Rom>();

		DateTime fraDato;
		DateTime tilDato;
		int kundeID;
		int romID;

        // GET: RomReservasjon
		[HttpGet]
        public ActionResult Index(int kuneID)
        {
			kundeID = kuneID;
			return View(roms);
        }

		[HttpPost]
		public ActionResult Index(DateTime fdato, DateTime tdato, int storrelse, int kvalitet, int antallsenger)
		{
			System.Diagnostics.Debug.WriteLine(fdato);
			System.Diagnostics.Debug.WriteLine(tdato);
			System.Diagnostics.Debug.WriteLine(storrelse);
			System.Diagnostics.Debug.WriteLine(kvalitet);
			System.Diagnostics.Debug.WriteLine(antallsenger);

			fraDato = fdato;
			tilDato = tdato;


			var rommene = romProvider.FinnAlleRom();
            //	var reservasjonene = reservasjonProvider.FinnAlleReservasjoner();
            var muligrom = (from rom in rommene
                            where gyldigRom(rom.Reservasjoner, fdato, tdato) && gyldigValg(rom, storrelse, kvalitet, antallsenger)
						   select rom).ToList();
						   


			roms = (List<Rom>) muligrom;
			return View(muligrom);
		}
		[HttpPost]
		public ActionResult VelgRom(int RomID)
		{
			romID = RomID;
			Reservasjon reservasjon = new Reservasjon();
            reservasjon.RomId = romID;
            reservasjon.KundeId = kundeID;
            reservasjon.TilDato = tilDato;
            reservasjon.FraDato = fraDato;
            reservasjon.ReservasjonStatus = 0;
			reservasjonProvider.LeggTilReservasjon(reservasjon);

			return RedirectToAction("index", "KundeSide", kundeID);
		}
		public Boolean gyldigValg(Rom rom, int storrelse, int kvalitet, int antallsenger)
		{
			//if (((int) rom.Storrelse > storrelse) && ((int) rom.Kvalitet > kvalitet) && (rom.AntallSenger > antallsenger))
			if(rom.AntallSenger < antallsenger)
			{
				return false;
			}
			if((int)rom.Storrelse < storrelse)
			{
				return false;
			}
			if((int)rom.Kvalitet < kvalitet){
				return false;
			}
			return true;
		
		}
		public Boolean gyldigRom(ICollection<Reservasjon> reservasjons, DateTime fdato, DateTime tdato)
		{
			foreach(Reservasjon reservasjon in reservasjons)
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