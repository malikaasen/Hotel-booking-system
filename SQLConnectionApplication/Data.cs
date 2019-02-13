using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;

namespace SQLConnectionApplication
{
	class Data
	{
		

        public partial class DataBase : DataContext
        {
            public Table<Rom> roms;
            public Table<Booking> bookings;
            public Table<Reservasjon> reservasjons;
            public Table<Service> services;
            public DataBase(string connection) : base(connection) { }
        }
        private DataBase db;
		public Data()
		{
            //DataBase db =
         db = new DataBase(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        //db = new DataContext(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
    }

    public void leggTilBooking(Booking booking)
		{

		}

		public void leggTilRom(Rom rommet)
		{
			Table<Rom> Romene = db.GetTable<Rom>();
			//db.Romene.InsertOnSubmit(rom);
			db.roms.InsertOnSubmit(rommet);
            db.SubmitChanges();
		}
		public void leggTilReservasjon(Reservasjon reservasjon)
		{
           
		}

		public Rom finnRom(int RomID)
		{
            return null;
		}

		public void leggTilService(Service service)
		{

		}
	}
}
