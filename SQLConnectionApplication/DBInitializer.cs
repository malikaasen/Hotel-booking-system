using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionApplication
{
    class DBInitializer<T> : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            IList<Rom> rom = new List<Rom>();
            IList<Kunde> kunder = new List<Kunde>();
            IList<Reservasjon> reservasjoner = new List<Reservasjon>();
            IList<ServiceOppgave> serviceOppgaver = new List<ServiceOppgave>();


            // Legger til rom 
            rom.Add(new Rom
            {
                Kvalitet = Kvalitet.Bra,
                AntallSenger  = 3,
                Storrelse = Storrelse.Stort,
            });

            rom.Add(new Rom
            {
                Kvalitet = Kvalitet.Middels,
                AntallSenger = 2,
                Storrelse = Storrelse.Middels,
            });

            rom.Add(new Rom
            {
                Kvalitet = Kvalitet.Dårlig,
                AntallSenger = 1,
                Storrelse = Storrelse.Lite
            });

            //Legger til kunder 
            kunder.Add(new Kunde
            {
                KundeID = 1,
                Navn = "Ola Nordmann",
                Passord = "katt",
            });

            serviceOppgaver.Add(new ServiceOppgave
            {
                OppgaveType = OppgaveType.Renhold,
                RomID = 1,
                Beskrivelse = "Renhold av om 1",
                Status = Status.Ny
            });

            foreach (Rom romObjekt in rom)
            {
                context.Rom.Add(romObjekt);
            }

            foreach (var kunde in kunder)
            {
                context.Kunder.Add(kunde);
            }

            context.Rom.AddRange(rom);
            context.Kunder.AddRange(kunder);
            base.Seed(context);

            

        }
    }
}
