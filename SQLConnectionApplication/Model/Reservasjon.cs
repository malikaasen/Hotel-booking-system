using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionApplication.Model
{
    public enum ReservasjonStatus
    {
        Avslått = 0, Pågående = 1, Godkjent = 2
    }
    public class Reservasjon
    {
        public int ReservasjonID { get; set; }
        public int RomId { get; set; } 
        public int KundeId { get; set; }
        public ReservasjonStatus ReservasjonStatus { get; set; }
        public DateTime FraDato { get; set; }
        public DateTime TilDato { get; set; }

        //Navigational properties
        public virtual Rom Rom { get; set; }
        public virtual Kunde Kunde { get; set; }

        public override string ToString()
        {
            return $"RomNummer: {RomId}, Fra dato: {FraDato.Date}, Til dato: {TilDato.Date}, Kunde: {Kunde.Navn}, ReservasjonStatus: {ReservasjonStatus}";
        }
    }
}