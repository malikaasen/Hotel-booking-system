using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLConnectionApplication.Model;

namespace SQLConnectionApplication.DataProviders
{
    public class ServiceOppgaveDataprovider
    {
        public void LeggTilOppgave(ServiceOppgave serviceOppgave)
        {
            using (var context = new DatabaseContext())
            {
                context.ServiceOppgaver.Add(serviceOppgave);
                context.SaveChanges();
            }
        }

        public List<ServiceOppgave> FinnAlleOppgaver()
        {
            using (var context = new DatabaseContext())
            {
                return context.ServiceOppgaver.ToList();
            }
        }


    }
}
