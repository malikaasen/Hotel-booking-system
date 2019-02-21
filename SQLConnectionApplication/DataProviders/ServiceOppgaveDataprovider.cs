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
            using (var DBContext = new DatabaseContext())
            {
                DBContext.ServiceOppgaver.Add(serviceOppgave);
                DBContext.SaveChanges();
            }
        }

        public List<ServiceOppgave> FinnAlleOppgaver()
        {
            using (var DBContext = new DatabaseContext())
            {
                return DBContext.ServiceOppgaver.ToList();
            }
        }

        public List<ServiceOppgave> FinnOppgaver(OppgaveType oppgaveType)
        {
            using (var DBContext = new DatabaseContext())
            {
                return DBContext.ServiceOppgaver.Where(o => o.OppgaveType == oppgaveType).ToList();
            }
        }


    }
}
