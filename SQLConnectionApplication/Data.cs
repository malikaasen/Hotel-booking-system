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
			db = new DataBase(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

		}

		public void leggTilBooking(Booking booking)
		{
			Table<Booking> bookingene = db.GetTable<Booking>();
			db.bookings.InsertOnSubmit(booking);
			db.SubmitChanges();
		}

		public void leggTilRom(Rom rommet)
		{
			Table<Rom> Romene = db.GetTable<Rom>();
			db.roms.InsertOnSubmit(rommet);
			db.SubmitChanges();
		}
		public void leggTilReservasjon(Reservasjon reservasjon)
		{
			Table<Reservasjon> reservasjoner = db.GetTable<Reservasjon>();
			db.reservasjons.InsertOnSubmit(reservasjon);
			db.SubmitChanges();
		}

		public void leggTilService(Service service)
		{
			Table<Service> servicer = db.GetTable<Service>();
			db.services.InsertOnSubmit(service);
			db.SubmitChanges();
		}

		public Rom finnRom(int RomID)
		{
			Table<Rom> Romene = db.GetTable<Rom>();

			IQueryable<Rom> romQuery =
				from rom in Romene
				where RomID == rom.Rom_ID
				select rom;
			return romQuery.FirstOrDefault<Rom>();
		}

		public Service finnService(int ServiceID)
		{
			Table<Service> Servicene = db.GetTable<Service>();

			IQueryable<Service> serviceQuery =
				from service in Servicene
				where ServiceID == service.Service_ID
				select service;
			return serviceQuery.FirstOrDefault<Service>();
		}


	}
}
