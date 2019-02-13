using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace SQLConnectionApplication
{
	[Table(Name = "Reservasjon_ID")]
	class Reservasjon
	{
		private int _Reservasjon_ID;
		[Column(IsPrimaryKey = true, Storage = "_Reservasjon_ID")]
		public int Reservasjon_ID
		{

			get
			{
				return this._Reservasjon_ID;
			}
			set
			{
				this._Reservasjon_ID = value;
			}

		}

		private int _Senger;
		[Column(Storage = "_Senger")]
		public int Senger
		{
			get
			{
				return this._Senger;
			}
			set
			{
				this._Senger = value;
			}
		}

		private string _Storrelse;
		[Column(Storage = "_Storrelse")]
		public string Storrelse
		{
			get
			{
				return this._Storrelse;
			}
			set
			{
				this._Storrelse = value;
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

	}
}