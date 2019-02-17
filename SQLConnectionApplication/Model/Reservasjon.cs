using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SQLConnectionApplication.Model
{
    public enum ReservasjonStatus
    {
        Avslått, Pågående, Godkjent
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
            return $"RomNummer: {RomId}, Fra dato: {FraDato.Date}, Til dato: {TilDato.Date}, Kunde: {Kunde.Navn}";
        }
    }
}