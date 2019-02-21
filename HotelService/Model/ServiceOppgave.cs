using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_service.Model
{
    public enum OppgaveType
    {
        Renhold, Service, Vedlikehold
    }

    public enum Status
    {
        Ny, Pågående, Ferdig
    }

    public class ServiceOppgave
    {
        public int RomID { get; set; }
        public OppgaveType OppgaveType { get; set; }
        public string Beskrivelse { get; set; }
        public string Notat { get; set; }
        public Status Status { get; set; }
    }
}
