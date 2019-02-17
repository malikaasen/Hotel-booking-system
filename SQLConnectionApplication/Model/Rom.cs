using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using SQLConnectionApplication;
using System.ComponentModel.DataAnnotations;

namespace SQLConnectionApplication.Model
{
    public enum Storrelse
    {
        Lite, Middels, Stort
    }

    public enum Kvalitet
    {
        Dårlig, Middels, Bra
    }

    public class Rom
    {
        [Key]
        public int RomID { get; set; }
        public Storrelse Storrelse { get; set; }
        public Kvalitet Kvalitet { get; set; }
        public int AntallSenger { get; set; }

        public virtual ICollection<Reservasjon> Reservasjoner { get; set; }


    }
}
