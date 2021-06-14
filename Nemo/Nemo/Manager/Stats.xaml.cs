using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
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

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for Stats.xaml
    /// </summary>
    public partial class Stats : Window
    {
        Database.AppLayer appLayer;
        string currentMonth, currentYear;
        public Stats()
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            currentMonth = DateTime.Now.Month.ToString();
            currentYear = DateTime.Now.Year.ToString();
            LoadData();
        }
        public void LoadData()
        {
            LoadMaleFemale();
            LoadNumEmps();
            LoadToalCost();
            LoadTotalSal();
            LoadDiffProdSal();
            LoadCountEmpsOverYears();
            LoadAvgSalaries();
            LoadProductionOverYears();
            LoadTargetVsActual();
            LoadOldestMachines();
            LoadMachinesOverYears();
            LoadReligions();
            LoadPlacesResideIn();
            LoadTopProdLines();

            /*
            LoadReligions();
            
            */

        }
        public SeriesCollection SeriesCollection { get; set; }
        public void LoadMaleFemale()
        {

            DataTable dt = appLayer.GetMaleFemale();
            string maleCount = dt.Rows[0]["maleCount"].ToString();
            string femaleCount = dt.Rows[0]["FemaleCount"].ToString();
            double malesPercentage = Math.Round(((double.Parse(maleCount)) / (double.Parse(maleCount) + double.Parse(femaleCount))) * 100);
            double femalesPercentage = Math.Round(((double.Parse(femaleCount)) / (double.Parse(maleCount) + double.Parse(femaleCount))) * 100);
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
        public void LoadNumEmps()
        {
            DataTable dt = appLayer.GetNumEmps();
            mangersCount.Text = "Managers: " + dt.Rows[0]["mangerCount"].ToString();
            SupervisorsCount.Text = "Supervisors: " + dt.Rows[0]["superVisorsCount"].ToString();
            workersCount.Text = "Workers: " + dt.Rows[0]["workersCount"].ToString();
        }
        public void LoadToalCost()
        {

            double sumCost = appLayer.GetTotalCost();
            int pwr10 = 0;
            while (sumCost / 10 > 100)
            {
                pwr10 = pwr10 + 1;
                sumCost = sumCost /10;
            }
            totalCostIn.Text = "Total cost in 10^" + (pwr10+1);
            totalCost.Value = sumCost/10;
        }
        public void LoadTotalSal()
        {
            double sumCost = appLayer.GetTotalSal();
            int pwr10 = 0;
            while (sumCost / 10 > 100)
            {
                pwr10 = pwr10 + 1;
                sumCost = sumCost / 10;
            }
            totalSalIn.Text = "Total Salaries in 10^" +( pwr10 + 1);
            totalSal.Value = sumCost / 10;
        }

        public void LoadDiffProdSal()
        {
            double diff = appLayer.GetTotalCost() - appLayer.GetTotalSal();
            diffProdSal.Text = "Total produced-total salaries = " + diff;

        }
        public void LoadCountEmpsOverYears()
        {
            DataTable dt = appLayer.GetTotalEmpsOverYears();
            double[] vals = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals[i] = double.Parse(dt.Rows[i]["EmpsCount"].ToString());

            SeriesCollectionNumEmps = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> (vals)
                },
            };
            string[] years = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                years[i] = dt.Rows[i]["year"].ToString();
            year = years;
            count = count => count.ToString("C");

            
            DataContext = this;

        }
        public SeriesCollection SeriesCollectionNumEmps { get; set; }
        public string[] year { get; set; }
        public Func<double, string> count { get; set; }


        public void LoadAvgSalaries()
        {
            //avgSal.ItemsSource = null;
           DataTable dt = appLayer.GetAvgSalaries();
           avgSal.ItemsSource = dt.DefaultView;
        }

        public void LoadProductionOverYears()
        {
            DataTable dt = appLayer.GetProductionoOverYears();
            double[] vals = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals[i] = double.Parse(dt.Rows[i]["amt"].ToString());

            SeriesCollectionProdAmt = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> (vals)
                },
            };
            string[] years = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                years[i] = dt.Rows[i]["year"].ToString();
            yearPA = years;
            count = count => count.ToString("C");


            DataContext = this;
        }

        public SeriesCollection SeriesCollectionProdAmt { get; set; }
        public string[] yearPA { get; set; }
        public Func<double, string> amt { get; set; }

        private void seeMore(object sender, RoutedEventArgs e)
        {
            new StatsProdSeeMore().Show();
        }


        private void LoadTargetVsActual()
        {
            DataTable dt = appLayer.GetTargedVsActual();
            double[] vals1 = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals1[i] = double.Parse(dt.Rows[i]["target"].ToString());
            double[] vals2 = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals2[i] = double.Parse(dt.Rows[i]["actual"].ToString());

            SeriesCollectionTargetAtucal = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Target",
                    Values = new ChartValues<double> (vals1)
                },
                new LineSeries
                {
                    Title = "Actual produced",
                    Values = new ChartValues<double> (vals2)
                },
            };
            string[] months = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                months[i] = dt.Rows[i]["month"].ToString();
            monthTA = months;
            countTA = count => count.ToString("C");


            DataContext = this;
        }

        public SeriesCollection SeriesCollectionTargetAtucal { get; set; }
        public string[] monthTA { get; set; }
        public Func<double, string> countTA { get; set; }

        public void LoadOldestMachines()
        {
            DataTable dt = appLayer.GetOldestMachines();
            oldMachines.ItemsSource = dt.DefaultView;
        }

        public void LoadMachinesOverYears()
        {

            DataTable dt = appLayer.GetMachinesOverYearsAcu();
            double[] vals1 = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals1[i] = double.Parse(dt.Rows[i]["sumMachines"].ToString());

            SeriesCollectionCountMachines = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Target",
                    Values = new ChartValues<double> (vals1)
                },
              
            };
            string[] years = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                years[i] = dt.Rows[i]["years"].ToString();
            yearMa = years;
            countMa = count => count.ToString("C");


            DataContext = this;
        }

        public SeriesCollection SeriesCollectionCountMachines { get; set; }
        public string[] yearMa { get; set; }
        public Func<double, string> countMa { get; set; }
        public void LoadReligions()
        {
            DataTable dt = appLayer.GetReligions();

            double[] vals = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals[i] = double.Parse(dt.Rows[i]["Countr"].ToString());

            SeriesCollectionRel = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> (vals)
                }
            };



            //also adding values updates and animates the chart automatically
            SeriesCollectionRel[0].Values.Add(48d);

            string[] adds = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                adds[i] = dt.Rows[i]["Religion"].ToString();
            Religion = adds;
            Countr = value => value.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollectionRel { get; set; }
        public string[] Religion { get; set; }
        public Func<double, string> Countr { get; set; }

        public void LoadPlacesResideIn()
        {
            DataTable dt = appLayer.SelectHighestPeopleReside();

            double[] vals = new double[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                vals[i] = double.Parse(dt.Rows[i]["Count"].ToString());

            SeriesCollectionPlaces = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Count",
                    Values = new ChartValues<double> (vals)
                }
            };



            //also adding values updates and animates the chart automatically
            SeriesCollectionPlaces[0].Values.Add(48d);

            string[] adds = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                adds[i] = dt.Rows[i]["Address"].ToString();
            Address = adds;
            countPlaces = countPlaces => countPlaces.ToString("N");

            DataContext = this;
        }

        public SeriesCollection SeriesCollectionPlaces { get; set; }
        public string[] Address { get; set; }
        public Func<double, string> countPlaces { get; set; }
        public void LoadTopProdLines()
        {
            DataTable dt = appLayer.GetTopProductionLines();
            topProdLines.ItemsSource = dt.DefaultView;
        }
    }


}
