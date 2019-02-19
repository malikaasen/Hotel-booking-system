using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front_desk.ListViewData
{
	class ListViewRom
	{
		public string RomCol { get; set; }
		public string StorrelseCol { get; set; }
		public string KvalitetCol { get; set; }
		public string AntallSengerCol { get; set; }


		public ListViewRom()
		{

		}
		public ListViewRom(string romCol, string storrelseCol, string kvalitetCol, string antallSengerCol)
		{
			RomCol = romCol;
			StorrelseCol = storrelseCol;
			KvalitetCol = kvalitetCol;
			AntallSengerCol = antallSengerCol;
		}
	}
}
