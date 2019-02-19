using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
        }

        private void Button_Ren_Click(object sender, RoutedEventArgs e)
        {
            type = "rengjører";
            FinnOppgaver(type);
        }

        private void Button_Room_Click(object sender, RoutedEventArgs e)
        {
            type = "roomservice";
            FinnOppgaver(type);

        }

        private void Button_Main_Click(object sender, RoutedEventArgs e)
        {
            type = "maintanace";
            FinnOppgaver(type);
        }
        //test
        private List<String> FinnOppgaver(String type)
        {
            List<String> test = new List<String>();
            switch(type){
                case "rengjører":
                    break;
                case "roomservice":
                    break;
                case "maintanace":
                    break;

            }
            return test;
        }
         
    }
}
