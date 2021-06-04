using System;
using System.Collections.Generic;
using System.Data;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        Database.AppLayer appLayer;
        public Statistics()
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            LoadData();

        }

        private void maleToFemale_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {

        }

        public void LoadData()
        {
            LoadMaleFemale();
            LoadAvgSalaries();
            LoadReligions();
            LoadTopProdLines();
            LoadOldestMachines();
            LoadPlacesResideIn();
            LoadNumEmps();

        }
        public void LoadMaleFemale()
        {

           DataTable dt = appLayer.GetMaleFemale();
            string maleCount = dt.Rows[0]["maleCount"].ToString();
            string femaleCount = dt.Rows[0]["FemaleCount"].ToString();
            double malesPercentage = Math.Round(((double.Parse(maleCount)) / (double.Parse(maleCount) + double.Parse(femaleCount))) * 100);
            double femalesPercentage =Math.Round( ((double.Parse(femaleCount)) / (double.Parse(maleCount) + double.Parse(femaleCount))) * 100);
            SeriesCollection = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Males%",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(malesPercentage) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Females%",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(femalesPercentage) },
                    DataLabels = true
                },
             
            };
           
            DataContext = this;
        }
        public SeriesCollection SeriesCollection { get; set; }

        public void LoadAvgSalaries()
        {
            DataTable dt = appLayer.GetAvgSalaries();
            avgSal.ItemsSource = dt.DefaultView;
        }

        public void LoadReligions()
        {
            DataTable dt = appLayer.GetReligions();

            double[] vals = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals[i] = double.Parse(dt.Rows[i]["Countr"].ToString());

            SeriesCollection4 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> (vals)
                }
            };



            //also adding values updates and animates the chart automatically
            SeriesCollection4[0].Values.Add(48d);

            string[] adds = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                adds[i] = dt.Rows[i]["Religion"].ToString();
            Religion = adds;
            Countr = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection4 { get; set; }
        public string[] Religion { get; set; }
        public Func<double, string> Countr { get; set; }
    

        public SeriesCollection SeriesCollection2 { get; set; }


        public void LoadTopProdLines()
        {
            DataTable dt = appLayer.GetTopProductionLines();
            topProdLines.ItemsSource = dt.DefaultView;
        }
        public void LoadOldestMachines()
        {
            DataTable dt = appLayer.GetOldestMachines();
            oldMachines.ItemsSource = dt.DefaultView;
        }
        public void LoadPlacesResideIn()
        {
            DataTable dt = appLayer.SelectHighestPeopleReside();

            double [] vals=new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals[i] = double.Parse(dt.Rows[i]["Count"].ToString());

            SeriesCollection3 = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> (vals)
                }
            };

           

            //also adding values updates and animates the chart automatically
            SeriesCollection3[0].Values.Add(48d);

            string[] adds = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                adds[i] = dt.Rows[i]["Address"].ToString();
            Address = adds;
            count = value => value.ToString("N");

            DataContext = this;
        }
        
        public SeriesCollection SeriesCollection3 { get; set; }
        public string[] Address { get; set; }
        public Func<double, string> count { get; set; }

        public void LoadNumEmps()
        {
            DataTable dt = appLayer.GetNumEmps();
            numEmps.Text = "You have " + dt.Rows[0]["workersCount"].ToString() + " Worker,  " + dt.Rows[0]["superVisorsCount"].ToString() + " Supervisors" + ", " + dt.Rows[0]["mangerCount"].ToString() + " Managers";
        }
    }
}
