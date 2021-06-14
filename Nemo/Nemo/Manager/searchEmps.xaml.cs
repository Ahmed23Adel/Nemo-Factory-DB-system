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
    /// Interaction logic for searchEmps.xaml
    /// </summary>
    public partial class searchEmps : Window
    {
        Database.AppLayer appLayer;
        //Here I get Instance of ManagerOptions, to enable to show it agagin after it's hidder if user clicks on to update some employee or somethig, 
        ManagerOptoins parentInstance;
        FiltersClasses.EmpFilter empFilter;
        public searchEmps(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            this.parentInstance = parentInstance;
            appLayer = Database.AppLayer.GetInstance();
            empFilter = new FiltersClasses.EmpFilter();
            loadData();
        }


        private void loadData()
        {
            DataTable dt = appLayer.SelectAllEmps();
            allEmps.ItemsSource = dt.DefaultView;
        }
        private void MenuItemMouseDownUpdate(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            new UpdateEmployee(result, parentInstance).Show();//showing updateEmployee to update Data
            parentInstance.Hide();

        } 
        /// <summary>
          /// This event is triggerd if user right clicked on any row of employese and check Delete
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
        private void MenuItemMouseDownDelete(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            //make sure that user is sure to update info
            if (MessageBox.Show("Are you sure you want to delete this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                MakeSound.MakeSent();
                DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
                String result = (drv["ID"]).ToString();//get the id to search by it.
                appLayer.DeleteAtId(result);
                Refresh();

            }
        }

        /// <summary>
        /// This event is triggerd if user right clicked on any row of employese and check Make manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemMouseDownMakeManger(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            DataRowView drv1 = (DataRowView)allEmps.SelectedItem;//get selected row
            String result1 = (drv1["Name"]).ToString();//get the id to search by it.
            if (MessageBox.Show("Are you sure you want to Make " + result1 + " Manager?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();

                DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
                String result = (drv["ID"]).ToString();//get the id to search by it.
                appLayer.MakeEmpManager(result);
                Refresh();
            }
        }

        /// <summary>
        /// This event is triggerd if user right clicked on any row of employese and check make worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemMouseDownMakeWorker(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            DataRowView drv1 = (DataRowView)allEmps.SelectedItem;//get selected row
            String result1 = (drv1["Name"]).ToString();//get the id to search by it.
            if (MessageBox.Show("Are you sure you want to Make " + result1 + " Worker?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
                String result = (drv["ID"]).ToString();//get the id to search by it.
                appLayer.MakeEmpWorker(result);
                Refresh();
            }
        }
        /// <summary>
        /// This event is triggerd if user right clicked on any row of employese and check make supervisor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemMouseDownMakeSupervisor(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            DataRowView drv1 = (DataRowView)allEmps.SelectedItem;//get selected row
            String result1 = (drv1["Name"]).ToString();//get the id to search by it.
            if (MessageBox.Show("Are you sure you want to Make " + result1 + " Supervisor?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
                String result = (drv["ID"]).ToString();//get the id to search by it.
                appLayer.MakeEmpSupervisor(result);
                Refresh();
            }
        }
        public void Refresh()
        {
            allEmps.ItemsSource = null;
            loadData();
        }
       
        private void Filters(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            new FilterEmpsSearch(empFilter,this).Show();
        }

   

        public void searchAndFilter()
        {
            empFilter.name = searchable.Text.Trim();
            DataTable dt = appLayer.searchAndFilter(empFilter);
            allEmps.ItemsSource = null;
            allEmps.ItemsSource = dt.DefaultView;
        }

        private void searchable_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchAndFilter();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
        }
   
    }
}
