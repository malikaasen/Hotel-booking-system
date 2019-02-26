using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLConnectionApplication.DataProviders
{
   public class RomDataprovider
    {

        public Rom FinnRom(int romNummer)
        {
            Rom rom;
            using (var context = new DatabaseContext())
            {
                 rom = context.Rom.Where(r => r.RomID == romNummer).FirstOrDefault();
            }

            return rom;
        }

        public List<Rom> FinnAlleRom()
        {
            using (var context = new DatabaseContext())
            {
                return context.Rom.Include("Reservasjoner").ToList();
            }
        }

        public void LeggTilRom(Rom rom)
        {
            using (var context = new DatabaseContext())
            {
                context.Rom.Add(rom);
                context.SaveChanges();
            }
        }

        public void SlettRom(int romNummer) {
            using (var context = new DatabaseContext())
            {
                context.Rom.Remove(context.Rom.Where(r => r.RomID == romNummer).FirstOrDefault());
                context.SaveChanges();
            }
        }

        public void EditRom(Rom rom) {
			Rom rommet;
			using (var context = new DatabaseContext())
            {
                rommet = context.Rom.Where(r => r.RomID == rom.RomID).FirstOrDefault();
                rommet.AntallSenger = rom.AntallSenger;
                rommet.Storrelse = rom.Storrelse;
                rommet.Kvalitet = rom.Kvalitet;
                context.SaveChanges();
            }
        }



    }
}
