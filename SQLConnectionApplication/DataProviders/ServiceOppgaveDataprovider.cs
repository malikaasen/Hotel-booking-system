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

        public void SlettServiceOppgave(int serviceNummer)
        {
            using (var context = new DatabaseContext())
            {
                context.ServiceOppgaver.Remove(context.ServiceOppgaver.Where(r => r.ServiceOppgaveId == serviceNummer).FirstOrDefault());
                context.SaveChanges();
            }
        }

        public void EditServiceOppgave(ServiceOppgave serviceOppgave)
        {
            ServiceOppgave  serviceoppg;
            using (var context = new DatabaseContext())
            {
                serviceoppg = context.ServiceOppgaver.Where(r => r.ServiceOppgaveId == serviceOppgave.RomID).FirstOrDefault();
                serviceoppg.OppgaveType = serviceOppgave.OppgaveType;
                serviceoppg.RomID = serviceOppgave.RomID;
                serviceoppg.Status = serviceOppgave.Status;
                serviceoppg.Beskrivelse = serviceOppgave.Beskrivelse;
                serviceoppg.Notat = serviceOppgave.Notat;
                context.SaveChanges();
            }
        }

    }
}
