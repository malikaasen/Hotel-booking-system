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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Front_desk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

		private void OpneRomVindu(object sender, RoutedEventArgs e)
		{
			RomVindu objRomWindow = new RomVindu();
			objRomWindow.Show();
		}

		private void ReservasjonButton_Click(object sender, RoutedEventArgs e)
		{
            ReservasjonVindu objReservasjonWindow = new ReservasjonVindu();
            objReservasjonWindow.Show();
		}

        private void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceVindu objServiceWindow = new ServiceVindu();
            objServiceWindow.Show();
        }
    }
}
