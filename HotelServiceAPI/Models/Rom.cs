using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelServiceAPI.Models
{
    public class RomDTO
    {
        public int RomID { get; set; }
        public Storrelse Storrelse { get; set; }
        public Kvalitet Kvalitet { get; set; }
        public int AntallSenger { get; set; }

        internal static RomDTO CreateFrom(Rom rom)
        {
            return new RomDTO
            {
                RomID = rom.RomID,
                Storrelse = rom.Storrelse,
                Kvalitet = rom.Kvalitet,
                AntallSenger = rom.AntallSenger
            };
        }
    }
}