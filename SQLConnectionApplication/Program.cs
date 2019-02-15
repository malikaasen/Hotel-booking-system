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
	class Program
	{
		static void Main(string[] args)
		{
			DataContext dc = new DataContext(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);


			Table<Rom> Romene = dc.GetTable<Rom>();

			dc.Log = Console.Out;

			IQueryable<Rom> romQuery =
				from rom in Romene
					//			where true
				select rom;

			foreach (Rom rom in romQuery)
			{
				Console.WriteLine("Rom_ID={0}, Senger={1}, Storrelse={2}, Quality={3}", rom.Rom_ID, rom.Senger, rom.Storrelse, rom.Quality);
			}

			//          Rom rommet = new Rom
			//          {
			//              Quality = "God",
			//          Senger = 6,
			//          Rom_ID = 8,
			//          Storrelse = "L"
			//      };
			////	rommet.Services = new EntitySet<Service>();

				Data data = new Data();
			//	data.leggTilRom(rommet);
			Rom rommet = data.finnRom(7);
			Console.WriteLine("Rommet er funnet med ID:" + rommet.Rom_ID);

			Table<Service> Servicene = dc.GetTable<Service>();

			dc.Log = Console.Out;

			IQueryable<Service> serviceQuery =
				from service in Servicene
				select service;

			foreach (Service service in serviceQuery)
			{
				Console.WriteLine("Service_ID={0}, Rom_ID={1}, Beskrivelse={2}, Status={3}", service.Service_ID, service.Rom_ID, service.Beskrivelse, service.Status);
			}

			Console.ReadLine();


		}
	}
}
