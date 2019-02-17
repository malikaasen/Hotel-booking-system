using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using SQLConnectionApplication.Model;
using SQLConnectionApplication.DataProviders;


namespace SQLConnectionApplication
{
   public class Program
    {

        private static RomDataprovider _romDataProvider = new RomDataprovider();
        private static KundeDataprovider _kundeDataprovider = new KundeDataprovider();
        private static ReservasjonDataprovider _reservasjonDataprovider = new ReservasjonDataprovider();
        private static ServiceOppgaveDataprovider _serviceOppgaveDataprovider = new ServiceOppgaveDataprovider();

        static void Main(String [] args)
        {
            Console.WriteLine("Alle rom");
            List<Rom> alleRom = _romDataProvider.FinnAlleRom();
            foreach (Rom rom in alleRom)
            {
                Console.WriteLine(rom);
            }


            Console.ReadKey();

            Console.WriteLine("Alle kunder");
            List<Kunde> alleKunder = _kundeDataprovider.FinnAlleKunder();
            foreach (Kunde kunde in alleKunder)
            {
                Console.WriteLine(kunde);
            }

            Console.ReadKey();

            Reservasjon reservasjon = new Reservasjon
            {
                Kunde = alleKunder[0],
                Rom = alleRom[0],
                FraDato = new DateTime(2019, 2, 17),
                TilDato = new DateTime(2019, 2, 23)

            };

            Console.WriteLine("Legger til reservasjon");
            _reservasjonDataprovider.LeggTilReservasjon(reservasjon);

            Console.WriteLine("Alle reservasjoner nå");
            List<Reservasjon> alleReservasjoner = _reservasjonDataprovider.FinnAlleReservasjoner();
            foreach (Reservasjon res in alleReservasjoner)
            {
                Console.WriteLine(res);
            }

            Console.ReadKey();

            Console.WriteLine("Legger til oppgaver");
            ServiceOppgave renhold = new ServiceOppgave
            {
                OppgaveType = OppgaveType.Renhold,
                Beskrivelse = "Renhold av rom",
                Rom = alleRom[0],
                Status = Status.Ny
            };

            ServiceOppgave vedlikehold = new ServiceOppgave
            {
                OppgaveType = OppgaveType.Vedlikehold,
                Beskrivelse = "Ødelagt vask",
                Rom = alleRom[1],
                Status = Status.Pågående
            };

            _serviceOppgaveDataprovider.LeggTilOppgave(renhold);
            _serviceOppgaveDataprovider.LeggTilOppgave(vedlikehold);


            Console.WriteLine("Alle oppgaver");
            List<ServiceOppgave> oppgaver = _serviceOppgaveDataprovider.FinnAlleOppgaver();

            foreach(var oppg in oppgaver)
            {
                Console.WriteLine(oppg);
            }



            Console.ReadKey();



        }
        
    }
}
