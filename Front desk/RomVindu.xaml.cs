using Front_desk.ListViewData;
using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
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


namespace Front_desk
{
	/// <summary>
	/// Interaction logic for RomVindu.xaml
	/// </summary>
	public partial class RomVindu : Window
	{
		private bool stopRefreshControls = false;
		private bool dataChanged = false;
		RomDataprovider romProvider = new RomDataprovider();

		public RomVindu()
		{
			InitializeComponent();
		}
		public void RefreshListView(string value1, string value2, string value3, string value4)
		{
			ListViewRom lvr = (ListViewRom)ListView1.SelectedItem;
			if (lvr != null && !stopRefreshControls)
			{
				setDataChanged(true);
				lvr.RomCol = value1;
				lvr.StorrelseCol = value2;
				lvr.KvalitetCol = value3;
				lvr.AntallSengerCol = value4;
			}
		}
		private void setDataChanged(bool value)
		{
			dataChanged = value;
			//saveButton.IsEnabled = value;
		}
		private void ListView1_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
		{
            //var selectedItem = (Rom)ListView1.SelectedItem;
            //this.RomIDBox.Text = selectedItem.RomID.ToString();
            //this.KvalitetBox.Text = selectedItem.Kvalitet.ToString();
            //this.StorrelseBox.Text = selectedItem.Storrelse.ToString();
            //this.AntallSenger.Text = selectedItem.AntallSenger.ToString();
		}

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			ShowData();
		}
		private void ShowData()
		{
			ListView1.Items.Clear();
			foreach (var row in romProvider.FinnAlleRom())
			{
				ListView1.Items.Add(row);
			}
		}


		private void SlettButtonClick(object sender, RoutedEventArgs e)
		{

			var selectedItems = ListView1.SelectedItems;
			foreach (Rom selectedItem in selectedItems)
			{
				romProvider.SlettRom(Convert.ToInt32(selectedItem.RomID));
			}

			ShowData();

		}

		private void AddKnapp_Click(object sender, RoutedEventArgs e)
		{
			Rom rom = new Rom();
			rom.RomID = Convert.ToInt32(this.RomIDBox.Text);
			rom.Storrelse = (Storrelse)StorrelseBox.SelectedIndex;
			rom.Kvalitet = (Kvalitet)KvalitetBox.SelectedIndex;
			rom.AntallSenger = Convert.ToInt32(this.AntallSenger.Text);

			romProvider.LeggTilRom(rom);


			ShowData();
		}

		private void EditButton_Click(object sender, RoutedEventArgs e)
		{
			Rom rom = new Rom();
			var selectedItem = (Rom)ListView1.SelectedItem;
			rom.RomID = Convert.ToInt32(selectedItem.RomID);
			rom.Storrelse = (Storrelse)StorrelseBox.SelectedIndex;
			rom.Kvalitet = (Kvalitet)KvalitetBox.SelectedIndex;
			rom.AntallSenger = Convert.ToInt32(this.AntallSenger.Text);
            romProvider.EditRom(rom);

            ShowData();
		}
	}


}
