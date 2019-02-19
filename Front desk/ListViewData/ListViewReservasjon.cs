using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front_desk.ListViewData
{
	class ListViewReservasjon
	{
		public string ReservasjonID { get; set; }
		public string RomId { get; set; }
		public string KundeId { get; set; }
		public string ReservasjonStatus { get; set; }
		public string FraDato { get; set; }
		public string TilDato { get; set; }

		public ListViewReservasjon()
		{

		}
		public ListViewReservasjon(string reservasjonID, string romId, string kundeId, string reservasjonStatus, string fraDato, string tilDato)
		{
			ReservasjonID = reservasjonID;
			RomId = romId;
			KundeId = kundeId;
			ReservasjonStatus = reservasjonStatus;
			FraDato = fraDato;
			TilDato = tilDato;
		}
	}
}
