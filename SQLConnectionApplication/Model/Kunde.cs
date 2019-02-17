using System.Collections.Generic;

namespace SQLConnectionApplication.Model
{
    public class Kunde
    {
        public int KundeID { get; set; }
        public string Navn { get; set; }
        public string Passord { get; set; }

        //Navigational properties
        public virtual ICollection <Reservasjon> Reservasjoner { get; set; }


        public override string ToString()
        {
            return $"KundeID: {KundeID}, Navn {Navn}, Passord: {Passord}";
        }
    }
}