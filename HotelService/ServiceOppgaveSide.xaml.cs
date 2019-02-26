using Hotel_service.DataAccess;
using Hotel_service.Model;
using Hotel_service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Hotel_service
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ServiceOppgaveSide : Page, INotifyPropertyChanged
    {
        public ObservableCollection<ServiceOppgave> Oppgaver { get; set; }
        string type;
        public event PropertyChangedEventHandler PropertyChanged;

        

        public ServiceOppgaveSide()
        {
            
            this.InitializeComponent();
            Oppgaver = new ObservableCollection<ServiceOppgave>();
            ListView.ItemsSource = Oppgaver;
            
            
          
         
            ApiHelper.InitializeClient();
           
            
           


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private async void Oppgaver_Button_Click(object sender, RoutedEventArgs e)
        {
            var serviceOppgaves = await ServiceOppgaveAPIClient.HentServiceOppgaver();
            Oppgaver.Clear();
            foreach (var oppgave in serviceOppgaves)
            {

                if (oppgave.OppgaveType.ToString() == type)
                {
                    Oppgaver.Add(oppgave);

                    String b = oppgave.Beskrivelse;
                }
                
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            type = e.Parameter as string;
            if (type == "Renhold")
            {
                textBlock.Text = "Oppgaver for rengjører";


            }
            else if (type == "Service")
            {
                textBlock.Text = "Oppgaver for room service";
            }
            else
            {
                textBlock.Text = "Oppgaver for maintenance";
            }
        }

        private void MyTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            var newText = args.NewText;
            var oldText = sender.Text;
            // TODO: process text change
            OnPropertyChanged();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var comboBoxItem = (e.AddedItems[0] as ComboBoxItem).Content as String;
            //if (comboBoxItem == null) return;

            //if (comboBoxItem != null && comboBoxItem.Equals("some text"))
            //{
            //    return;
            //    //do what ever you want
            //}
         
        }

        public void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = null) =>
             PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        //public async Task UpdateNotatsAsync()
        //{
        //    foreach (var modifiedNotat in Oppgaver
        //        .Where(x => x.IsModified).Select(x => x.Model))
        //    {
        //        await App.Repository.Customers.UpsertAsync(modifiedCustomer);
        //    }
        //    await GetCustomerListAsync();
        //}

    }
}

