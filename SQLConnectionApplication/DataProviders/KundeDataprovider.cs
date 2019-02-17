using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLConnectionApplication.Model;

namespace SQLConnectionApplication.DataProviders
{
    public class KundeDataprovider
    {
        public Kunde FinnKunde(int kundeId)
        {
            using (var context = new DatabaseContext())
            {
                return context.Kunder.Where(k => k.KundeID == kundeId).FirstOrDefault();
            }
        }

        public Kunde FinnKunde(string kundeNavn)
        {
            using (var context = new DatabaseContext())
            {
                return context.Kunder.Where(k => k.Navn == kundeNavn).FirstOrDefault();
            }
        }

        public List<Kunde> FinnAlleKunder()
        {
            using (var context = new DatabaseContext())
            {
                return context.Kunder.ToList();
            }
        }

        public void LeggTilKunde(Kunde kunde)
        {
            using (var context = new DatabaseContext())
            {
                context.Kunder.Add(kunde);
            }
        }


    }
}
