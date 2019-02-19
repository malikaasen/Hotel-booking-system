using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLConnectionApplication.Model;

namespace HotelServiceAPI.Models
{
    public class ServiceOppgaveDTO
    {
        public int RomID { get; set; }
        public string OppgaveType { get; set; }
        public string Beskrivelse { get; set; }
        public string Notat { get; set; }
        public string Status { get; set; }

        public ServiceOppgaveDTO CreateFromEntity(ServiceOppgave serviceOppgave)
        {
            
            return new ServiceOppgaveDTO() { RomID = serviceOppgave.RomID, Beskrivelse = serviceOppgave.Beskrivelse, OppgaveType = serviceOppgave.Status.ToString()};
        }
    }

   
}