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
    }
}
