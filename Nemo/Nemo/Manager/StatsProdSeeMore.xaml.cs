using LiveCharts;
using LiveCharts.Wpf;
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
using System.Windows.Shapes;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for StatsProdSeeMore.xaml
    /// </summary>
    public partial class StatsProdSeeMore : Window
    {
        Database.AppLayer appLayer;
        DataTable productionLinesdt ;
        public StatsProdSeeMore()
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            productionLinesdt = appLayer.GetAllProductionLine();
            LoadProductionLines();
        }

        private void seeProductResult(object sender, RoutedEventArgs e)
        {
            if(productionLines.SelectedValue != null && products.SelectedValue != null)
            {
                if (seeProductAllYears.IsChecked == true)
                {
                    if (accumulated.IsChecked == true)
                        SeeProductOverAllYearsAcu(productionLines.SelectedValue.ToString(), products.SelectedValue.ToString());

                    else if (notAccumulated.IsChecked == true)
                        SeeProductOverAllYears(productionLines.SelectedValue.ToString(), products.SelectedValue.ToString());

                }
                else if (seeProductThisYears.IsChecked == true)
                {
                    if (accumulated.IsChecked == true)
                        SeeProductOverThisYearsAcu(productionLines.SelectedValue.ToString(), products.SelectedValue.ToString());

                    else if (notAccumulated.IsChecked == true)
                        SeeProductOverThisYears(productionLines.SelectedValue.ToString(), products.SelectedValue.ToString());
                }
            }
        }
        
        private void productOverThisYear(object sender, RoutedEventArgs e)
        {
            seeProductThisYears.IsChecked = false;
        }
        private void productOverAllYears(object sender, RoutedEventArgs e)
        {
            seeProductAllYears.IsChecked = false;
        }

        private void LoadProductionLines()
        {
            
            productionLines.ItemsSource = productionLinesdt.DefaultView;

        }
        
        private void accumulatedMouseDown(object sender, RoutedEventArgs e)
        {
            notAccumulated.IsChecked = false;
        }
        
        private void notAccumulatedMouseDown(object sender, RoutedEventArgs e)
        {
            accumulated.IsChecked = false;
        }

        

        private void productionLinees_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (productionLines.SelectedValue != null)
            {
                products.ItemsSource = null;
                products.Items.Clear();
                string lineId = productionLines.SelectedValue.ToString();
                DataTable dt = appLayer.GetAllProductsAtProductionLine(lineId);
                products.ItemsSource = dt.DefaultView;
            }
           
        }

        private void SeeProductOverAllYearsAcu(string lineId, string prductId)
        {
            DataTable dt = appLayer.GetProductAmtOverAllYearsAccu(lineId, prductId);
            if(dt!= null)
            {
                if (dt.Rows.Count == 0)
                {
                    productGraph.Visibility = Visibility.Hidden;
                    return;
                }
                productGraph.Visibility = Visibility.Visible;

                double[] vals = new double[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    vals[i] = double.Parse(dt.Rows[i]["sumInYear"].ToString());

                SeriesCollectionProduct = new SeriesCollection
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
                sum = sum => sum.ToString("C");


                DataContext = null;
                DataContext = this;
            }



        }
        
        private void SeeProductOverAllYears(string lineId, string prductId)
        {

            DataTable dt = appLayer.GetProductAmtOverAllYears(lineId, prductId);
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    productGraph.Visibility = Visibility.Hidden;
                    return;
                }
                productGraph.Visibility = Visibility.Visible;

                double[] vals = new double[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    vals[i] = double.Parse(dt.Rows[i]["sumInYear"].ToString());

                SeriesCollectionProduct = new SeriesCollection
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
                sum = sum => sum.ToString("C");


                DataContext = null;
                DataContext = this;
            }
        }
        
        private void SeeProductOverThisYears(string lineId, string prductId)
        {
            DataTable dt = appLayer.GetProductionOverThisYear(lineId, prductId, DateTime.Now.Year.ToString());
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    productGraph.Visibility = Visibility.Hidden;
                    return;
                }
                productGraph.Visibility = Visibility.Visible;

                double[] vals = new double[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    vals[i] = double.Parse(dt.Rows[i]["monAmount"].ToString());

                SeriesCollectionProduct = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> (vals)
                },
            };
                string[] years = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    years[i] = dt.Rows[i]["month"].ToString();
                year = years;
                sum = sum => sum.ToString("C");


                DataContext = null;
                DataContext = this;
            }
        }
        
        private void SeeProductOverThisYearsAcu(string lineId, string prductId)
        {
            string curyear = DateTime.Now.Year.ToString();
            DataTable dt = appLayer.GetProductionOverThisYearAcu(lineId, prductId, curyear);
            if (dt != null)
            {
                if (dt.Rows.Count == 0)
                {
                    productGraph.Visibility = Visibility.Hidden;
                    return;
                }
                productGraph.Visibility = Visibility.Visible;

                double[] vals = new double[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    vals[i] = double.Parse(dt.Rows[i]["monAmount"].ToString());

                SeriesCollectionProduct = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> (vals)
                },
            };
                string[] years = new string[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                    years[i] = dt.Rows[i]["month"].ToString();
                year = years;
                sum = sum => sum.ToString("C");


                DataContext = null;
                DataContext = this;
            }

        }
        public SeriesCollection SeriesCollectionProduct { get; set; }
        public string[] year { get; set; }
        public Func<double, string> sum { get; set; }

        private void productionLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productionLines.SelectedValue != null)
            {
                products.ItemsSource = null;
                products.Items.Clear();
                string lineId = productionLines.SelectedValue.ToString();
                DataTable dt = appLayer.GetAllProductsAtProductionLine(lineId);
                products.ItemsSource = dt.DefaultView;
            }
        }
    }
}
