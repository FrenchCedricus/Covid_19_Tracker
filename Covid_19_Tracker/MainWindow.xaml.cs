using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        string departement = null;
        public MainWindow()
        {
            InitializeComponent();

        }


        private void clickOnBouttonRecupererData(object sender, RoutedEventArgs e)
        {
            int valeur_departement = comboBoxDepartement.SelectedIndex + 1;  //+1 cause it start at 0.
            switch (valeur_departement)
            {
                case 1:
                    departement = "Ain";
                    break;
                case 2:
                    departement = "Aisne";
                    break;
                case 3:
                    departement = "Allier";
                    break;
                case 4:
                    departement = "Alpes-de-Haute-Provence";
                    break;
                case 5:
                    departement = "Hautes-Alpes";
                    break;
                case 6:
                    departement = "Alpes-Maritimes";
                    break;
                case 7:
                    departement = "Ardèche";
                    break;


                    //LET'S CONTINUUUUE !!
            }

            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (s, ex) =>
            {
                // Part of other function calls here omitted that don't need to run on the UI thread
                API api = new API();

                string json = api.GetCovidData(departement).GetAwaiter().GetResult();
                var listDataCovid = JsonConvert.DeserializeObject<List<Covid_Modele>>(json);

                Dispatcher.Invoke(() =>
                {

                    // Part of other function calls here omitted that must run on the UI thread
                    textBlockDate.Text = listDataCovid[0].date?.ToString(); //The ToString() is for the "?" who ignore in case of null
                    textBlockDate.Cursor = Cursors.Cross;


                    textBlockHosp.Text = listDataCovid[0].hosp.ToString();
                    textBlocRanimation.Text = listDataCovid[0].rea.ToString();
                    textBlocPositif.Text = listDataCovid[0].pos?.ToString();

                    textBlockHosp24.Text = listDataCovid[0].incid_hosp.ToString();
                    textBlocRanimation24.Text = listDataCovid[0].incid_rad.ToString();
                    textBlocPositif24.Text = listDataCovid[0].pos_7j?.ToString();


                });
            };

            worker.RunWorkerAsync();

        }
    }
}
