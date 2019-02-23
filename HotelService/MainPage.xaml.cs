using Hotel_service.DataAccess;
using Hotel_service.Model;
using Hotel_service.Services;
using System;
using System.Collections.Generic;
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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hotel_service
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private String type;
        public MainPage()
        {
            this.InitializeComponent();
            ApiHelper.InitializeClient();
        }



        private async void Button_Ren_Click(object sender, RoutedEventArgs e)
        {
            type = "rengjører";
            await FinnOppgaver(type);
            this.Frame.Navigate(typeof(NewPage), type);
        }

        private async void Button_Room_Click(object sender, RoutedEventArgs e)
        {
            type = "roomservice";
            await FinnOppgaver(type);
            this.Frame.Navigate(typeof(NewPage), type);

        }

        private async void Button_Main_Click(object sender, RoutedEventArgs e)
        {
            type = "maintanace";
            await FinnOppgaver(type);
            this.Frame.Navigate(typeof(NewPage), type);
        }
        //test
        private async Task FinnOppgaver(String type)
        {
            var serviceOppgaver = await ServiceOppgaveAPIClient.HentServiceOppgaver();
            List<ServiceOppgave> oppgaver;
            switch(type){
                case "rengjører":
                    oppgaver = serviceOppgaver.FindAll(so => so.OppgaveType == OppgaveType.Renhold);
                    break;
                case "roomservice":
                    oppgaver = serviceOppgaver.FindAll(so => so.OppgaveType == OppgaveType.Service);

                    break;
                case "maintanace":
                    oppgaver = serviceOppgaver.FindAll(so => so.OppgaveType == OppgaveType.Vedlikehold);
                    break;
            }
            
        }
         
    }
}
