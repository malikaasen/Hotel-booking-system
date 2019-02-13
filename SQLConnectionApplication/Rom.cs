using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using SQLConnectionApplication;

namespace SQLConnectionApplication
{
	[Table(Name = "Rom")]
	class Rom
	{
		private int _Rom_ID;
		[Column(IsPrimaryKey = true, Storage = "_Rom_ID")]
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
		private string _Quality;
		[Column(Storage = "_Quality")]
		public string Quality
		{
			get
			{
				return this._Quality;
			}
			set
			{
				this._Quality = value;
			}
		}

		private EntitySet<Service> _Service;
		[Association(Storage = "_Service", OtherKey = "Service_ID")]
		public EntitySet<Service> Services
		{
			get { return this._Service; }
			set { this._Service.Assign(value); }
		}
	}
}
