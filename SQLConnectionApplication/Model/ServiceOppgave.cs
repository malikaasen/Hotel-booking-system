using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionApplication.Model
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
        public int ServiceOppgaveId { get; set; }
        public int RomID { get; set; }
        public OppgaveType OppgaveType { get; set; }
        public string Beskrivelse { get; set; }
        public string Notat { get; set; }
        public Status Status { get; set; }

        public virtual Rom Rom { get; set; }


        public override string ToString()
        {
            return $"Oppgave type: {OppgaveType}, Romnummer: {RomID}, Beskrivelse {Beskrivelse}, Status: {Status}";
        }

    }
}
