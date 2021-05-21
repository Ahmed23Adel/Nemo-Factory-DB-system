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

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for Manager_options.xaml
    /// </summary>
    public partial class Manager_options : Window
    {
        Statistics stats_page;
        production_lines prod_line_page;
        employees emp_page;
        machines machine_page;
        public Manager_options()
        {
            InitializeComponent();
            this.stats_clicked.Visibility = Visibility.Hidden;
            this.productionLines_clicked.Visibility = Visibility.Hidden;
            this.emps_clicked.Visibility = Visibility.Hidden;
            this.machines_clicked.Visibility = Visibility.Hidden;

            //create instances of pages instead of creating new instance of them every time user click on on different tap.
            stats_page = new Statistics();
            prod_line_page = new production_lines();
            emp_page = new employees();
            machine_page = new machines();
        }

        

        private void stats_click_event(object sender, MouseButtonEventArgs e)
        {
            visibleFirstHideRest(stats_clicked, productionLines_clicked, emps_clicked, machines_clicked);
            MoreInfo.Content = stats_page;
        }
        
        private void productionline_click_event(object sender, MouseButtonEventArgs e)
        {
            visibleFirstHideRest(productionLines_clicked,stats_clicked, emps_clicked, machines_clicked);
            MoreInfo.Content = prod_line_page;
        }
        
        private void emps_click_event(object sender, MouseButtonEventArgs e)
        {
            visibleFirstHideRest(emps_clicked, productionLines_clicked, stats_clicked, machines_clicked);
            MoreInfo.Content = emp_page;
        }
        
        private void machines_click_event(object sender, MouseButtonEventArgs e)
        {
            visibleFirstHideRest(machines_clicked,emps_clicked, productionLines_clicked, stats_clicked);
            MoreInfo.Content = machine_page;
        }
        
        
        private void Collapse_event(object sender, MouseButtonEventArgs e)
        {
            collapseAll();
        }
        
        private void expand_event(object sender, MouseButtonEventArgs e)
        {
            expandAll();
        }

        private void collapseAll()
        {
            leftPanel.Visibility = Visibility.Hidden;
            sep.Visibility = Visibility.Hidden;

            //Changing the ratios
            ColumnDefinition d1 = new ColumnDefinition();
            d1.Width = new GridLength(0, GridUnitType.Star);

            ColumnDefinition d2 = new ColumnDefinition();
            d2.Width = new GridLength(0, GridUnitType.Star);

            ColumnDefinition d3 = new ColumnDefinition();
            d3.Width = new GridLength(1, GridUnitType.Star);
            leftRightPanel.ColumnDefinitions.Clear();
            leftRightPanel.ColumnDefinitions.Add(d1);
            leftRightPanel.ColumnDefinitions.Add(d2);
            leftRightPanel.ColumnDefinitions.Add(d3);
        }
        
        private void expandAll()
        {
            leftPanel.Visibility = Visibility.Visible;
            sep.Visibility = Visibility.Visible;

            //Changing the ratios to original one in xaml
            ColumnDefinition d1 = new ColumnDefinition();
            d1.Width = new GridLength(2.1, GridUnitType.Star);

            ColumnDefinition d2 = new ColumnDefinition();
            d2.Width = new GridLength(0.1, GridUnitType.Star);

            ColumnDefinition d3 = new ColumnDefinition();
            d3.Width = new GridLength(9, GridUnitType.Star);
            leftRightPanel.ColumnDefinitions.Clear();
            leftRightPanel.ColumnDefinitions.Add(d1);
            leftRightPanel.ColumnDefinitions.Add(d2);
            leftRightPanel.ColumnDefinitions.Add(d3);

        }

        private void visibleFirstHideRest(Line l1, Line l2, Line l3, Line l4)
        {
            l1.Visibility = Visibility.Visible;
            l2.Visibility = Visibility.Hidden;
            l3.Visibility = Visibility.Hidden;
            l4.Visibility = Visibility.Hidden;
        }
    }
}
