using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace SQLConnectionApplication.Model
{
	[Table(Name = "Service")]
	class Service
	{
		private int _Service_ID;
		[Column(IsPrimaryKey = true, Storage = "_Service_ID")]
		public int Service_ID
		{
			get
			{
				return this._Service_ID;
			}
			set
			{
				this._Service_ID = value;
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
		private string _Beskrivelse;
		[Column(Storage = "_Beskrivelse")]
		public string Beskrivelse
		{
			get
			{
				return this._Beskrivelse;
			}
			set
			{
				this._Beskrivelse = value;
			}
		}
		private string _Status;
		[Column(Storage = "_Status")]
		public string Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				this._Status = value;
			}
		}

        private string _Servicetype;
        [Column(Storage = "_Servicetype")]
        public string Servicetype
        {
            get
            {
                return this._Servicetype;
            }
            set
            {
                this._Servicetype = value;
            }
        }
    }
}
