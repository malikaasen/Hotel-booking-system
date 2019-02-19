using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;

namespace Front_desk
{
	/// <summary>
	/// Interaction logic for ReservasjonVindu.xaml
	/// </summary>
	public partial class ReservasjonVindu : Window
	{

		ReservasjonDataprovider reservasjonProvider = new ReservasjonDataprovider();
        RomDataprovider romProvider = new RomDataprovider();
		KundeDataprovider kundeProvider = new KundeDataprovider();

		public ReservasjonVindu()
		{
			InitializeComponent();
		}

		private void SlettButton_Click(object sender, RoutedEventArgs e)
		{

            var selectedItems = ListView1.SelectedItems;
            foreach (Reservasjon selectedItem in selectedItems)
            {
                reservasjonProvider.slettReservajon(Convert.ToInt32(selectedItem.ReservasjonID));
            }

            ShowData();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			ShowData();
		}

		private void EditButton_Click(object sender, RoutedEventArgs e)
		{
            Reservasjon res = new Reservasjon();
            var selectedItem = (Reservasjon)ListView1.SelectedItem;
            res.ReservasjonID = Convert.ToInt32(selectedItem.ReservasjonID);
            res.RomId = Convert.ToInt32(this.RomIDBox.SelectedIndex);
            res.KundeId = Convert.ToInt32(this.KundeIDBox.SelectedIndex);
            res.ReservasjonStatus = (ReservasjonStatus)ReservasjonStatusBox.SelectedIndex;
            res.FraDato = (DateTime)this.FraDatoBox.SelectedDate;
            res.TilDato = (DateTime)this.TilDatoBox.SelectedDate;

            Kunde kunde = kundeProvider.FinnKunde(Convert.ToInt32(this.KundeIDBox.SelectedIndex + 1));
            res.Kunde = kunde;
            Rom rom = romProvider.FinnRom(Convert.ToInt32(this.RomIDBox.SelectedIndex + 1));
            res.Rom = rom;
            reservasjonProvider.EditReservasjon(res);

            ShowData();
        }

		private void AddButton_Click(object sender, RoutedEventArgs e)
		{
            Reservasjon res = new Reservasjon();
            res.ReservasjonID = Convert.ToInt32(this.ReservasjonsBox.Text);
            res.RomId = Convert.ToInt32(this.RomIDBox.SelectedIndex);
            res.KundeId = Convert.ToInt32(this.KundeIDBox.SelectedIndex);
			res.ReservasjonStatus = (ReservasjonStatus) ReservasjonStatusBox.SelectedIndex;
			res.FraDato = (DateTime)this.FraDatoBox.SelectedDate;
            res.TilDato = (DateTime)this.TilDatoBox.SelectedDate;

			Kunde kunde = kundeProvider.FinnKunde(Convert.ToInt32(this.KundeIDBox.SelectedIndex+1));
            res.Kunde = kunde;
			Rom rom = romProvider.FinnRom(Convert.ToInt32(this.RomIDBox.SelectedIndex+1));
			res.Rom = rom;
			reservasjonProvider.LeggTilReservasjon(res);

            ShowData();
        }
		private void ShowData()
		{
			ListView1.Items.Clear();
			foreach (var row in reservasjonProvider.FinnAlleReservasjoner())
			{
				ListView1.Items.Add(row);
			}
			foreach (var row in kundeProvider.FinnAlleKunder())
			{
                KundeIDBox.Items.Add(row.KundeID);
			}

            foreach (var row in romProvider.FinnAlleRom())
            {
                RomIDBox.Items.Add(row.RomID);
            }
			

		}

	}
}
