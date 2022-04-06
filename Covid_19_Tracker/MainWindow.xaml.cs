using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Covid_19_Tracker
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }


        private void clickOnBouttonRecupererData(object sender, RoutedEventArgs e)
        {
            API api = new API();

            string json = api.GetCovidData().GetAwaiter().GetResult();
            var listDataCovid = JsonConvert.DeserializeObject<List<Covid_Modele>>(json);

            textBlockDate.Text = listDataCovid[0].Date;

        }
    }
}
