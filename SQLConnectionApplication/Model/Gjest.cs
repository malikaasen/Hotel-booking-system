using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnectionApplication.Model
{
    public enum InnsjekkingStatus
    {
        Innsjekket, Utsjekket
    }
    public class Gjest
    {

        public int GjestId { get; set; }
        public int RomId { get; set; }
        public InnsjekkingStatus InnsjekkingStatus { get; set; }

        //navigational properties
        public virtual Rom Rom { get; set; }


    }
}
