using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLConnectionApplication.Model;

namespace SQLConnectionApplication.DataProviders
{
    public class ReservasjonDataprovider
    {
        public List<Reservasjon> FinnAlleReservasjoner()
        {
            using (var context = new DatabaseContext())
            {
                return context.Reservasjoner.Include("Kunde").ToList();
            }
        }

        public void LeggTilReservasjon(Reservasjon reservasjon)
        {
            using (var context = new DatabaseContext())
            {
                context.Reservasjoner.Add(reservasjon);
                context.SaveChanges();
            }
        }

        public void SlettReservasjon(int reservasjonsID)
        {
            using (var context = new DatabaseContext())
            {
                context.Reservasjoner.Remove(context.Reservasjoner.Where(r => r.ReservasjonID == reservasjonsID).FirstOrDefault());
                context.SaveChanges();
            }
        }

        public void EditReservasjon(Reservasjon reservasjon) 
        {
            Reservasjon res;
            using (var context = new DatabaseContext())
            {
                res = context.Reservasjoner.Where(r => r.ReservasjonID == reservasjon.ReservasjonID).FirstOrDefault();
                res.RomId = reservasjon.RomId;
                res.ReservasjonStatus = reservasjon.ReservasjonStatus;
                res.FraDato = reservasjon.FraDato;
                res.TilDato = reservasjon.TilDato;
                context.SaveChanges();


            }
        }
    }
}
