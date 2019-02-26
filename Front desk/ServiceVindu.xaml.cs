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
    /// Interaction logic for ServiceVindu.xaml
    /// </summary>
    public partial class ServiceVindu : Window
    {
        ServiceOppgaveDataprovider serviceProvider = new ServiceOppgaveDataprovider();
        RomDataprovider romProvider = new RomDataprovider();
        public ServiceVindu()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SlettKnapp_Click(object sender, RoutedEventArgs e)
        {
            var selectedItems = ListView1.SelectedItems;
            foreach (ServiceOppgave selectedItem in selectedItems)
            {
                serviceProvider.SlettServiceOppgave(Convert.ToInt32(selectedItem.ServiceOppgaveId));
            }

            ShowData();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceOppgave service = new ServiceOppgave();
            var selectedItem = (ServiceOppgave) ListView1.SelectedItem;
            service.ServiceOppgaveId = (int)selectedItem.ServiceOppgaveId;
            service.RomID = Convert.ToInt32(this.romIDBox.SelectedValue);
            service.OppgaveType = (OppgaveType) serviceTypeBox.SelectedIndex;
            service.Beskrivelse = this.beskrivelseBox.Text;
            service.Notat = this.notatBox.Text;
            service.Status = (Status)statusBox.SelectedIndex;
            serviceProvider.EditServiceOppgave(service);
            ShowData();
        }

        private void LeggTilButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceOppgave service = new ServiceOppgave();
            service.RomID = Convert.ToInt32(this.romIDBox.SelectedValue);
            service.OppgaveType = (OppgaveType)serviceTypeBox.SelectedIndex;
            service.Beskrivelse = this.beskrivelseBox.Text;
            service.Notat = this.notatBox.Text;
            service.Status = (Status)statusBox.SelectedIndex;
            serviceProvider.LeggTilOppgave(service);
            ShowData();
           
        }

        private void ShowData()
        {
            ListView1.Items.Clear();
			romIDBox.Items.Clear();
            foreach (var row in serviceProvider.FinnAlleOppgaver())
            {
                ListView1.Items.Add(row);
            }

            foreach (var row in romProvider.FinnAlleRom())
            {
                romIDBox.Items.Add(row.RomID);
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowData();
        }
    }
}
