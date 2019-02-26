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
        // GET: RomReservasjon
		[HttpGet]
        public ActionResult Index()
        {
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

			var rommene = romProvider.FinnAlleRom();
            //	var reservasjonene = reservasjonProvider.FinnAlleReservasjoner();
            var muligrom = (from rom in rommene
                            where gyldigRom(rom.Reservasjoner, fdato, tdato) && gyldigValg(rom, storrelse, kvalitet, antallsenger)
						   select rom).ToList();
						   


			roms = (List<Rom>) muligrom;
			return View(muligrom);
		}
		public  Boolean gyldigValg(Rom rom, int storrelse, int kvalitet, int antallsenger)
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