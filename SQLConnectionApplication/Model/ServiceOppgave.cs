using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionApplication.Model
{
    public enum OppgaveType
    {
        Renhold = 0, Service = 1, Vedlikehold = 2
    }

    public enum Status
    {
        Ny = 0, Pågående = 1, Ferdig = 2
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
