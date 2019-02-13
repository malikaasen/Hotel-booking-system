using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SQLConnectionApplication
{
	[Table(Name = "Booking")]
	class Booking
	{
		private int _Booking_ID;
		[Column(IsPrimaryKey = true, Storage = "_Booking_ID")]
		public int Booking_ID
		{

			get
			{
				return this._Booking_ID;
			}
			set
			{
				this._Booking_ID = value;
			}

		}
		private string _Dato_Start;
		[Column(Storage = "_Dato_Start")]
		public string Dato_Start
		{
			get
			{
				return this._Dato_Start;
			}
			set
			{
				this._Dato_Start = value;
			}
		}
		private string _Dato_Slutt;
		[Column(Storage = "_Dato_Slutt")]
		public string Dato_Slutt
		{
			get
			{
				return this._Dato_Slutt;
			}
			set
			{
				this._Dato_Slutt = value;
			}
		}
		private int _Rom_ID;
		[Column(Storage = "_Rom_ID", DbType = "int")]
		public int Rom_ID
		{
			get
			{
				return this._Rom_ID;
			}
			set
			{
				this._Rom_ID = value;
			}
		}
		private Rom _Rom;
		[Association(Storage = "_Rom", ThisKey = "Rom_ID")]
		public Rom rom
		{
			get
			{
				return this._Rom;
			}
			set
			{
				this._Rom = value;
			}
		}


	}
}
