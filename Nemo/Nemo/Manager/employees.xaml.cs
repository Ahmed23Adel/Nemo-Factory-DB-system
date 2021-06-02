using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for employees.xaml
    /// </summary>
    public partial class Employees : Page
    {
        Database.AppLayer appLayer;
        //Here I get Instance of ManagerOptions, to enable to show it agagin after it's hidder if user clicks on to update some employee or somethig, 
        ManagerOptoins parentInstance;

        public Employees(ManagerOptoins parentInstance)
        {

            InitializeComponent();
            this.parentInstance = parentInstance;
            appLayer = Database.AppLayer.GetInstance();

            loadData();
        }
        
        /// <summary>
        /// This will load all employees and will show them into DataGrid
        /// </summary>
        /// 


        private void loadData()
        {
            DataTable dt = appLayer.SelectAllEmps();
            allEmps.ItemsSource = dt.DefaultView;       
        }

       /// <summary>
       /// This event is triggerd if user right clicked on any row of employese and check update
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void MenuItemMouseDownUpdate(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            new UpdateEmployee(result,parentInstance).Show();//showing updateEmployee to update Data
            parentInstance.Hide();

        } /// <summary>
          /// This event is triggerd if user right clicked on any row of employese and check Delete
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
        private void MenuItemMouseDownDelete(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            appLayer.DeleteAtId(result);
            Refresh();

        }

        /// <summary>
        /// This event is triggerd if user right clicked on any row of employese and check Make manager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemMouseDownMakeManger(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            appLayer.MakeEmpManager(result);
            Refresh();
        }

        /// <summary>
        /// This event is triggerd if user right clicked on any row of employese and check make worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemMouseDownMakeWorker(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            appLayer.MakeEmpWorker(result);
            Refresh();
        }
        /// <summary>
        /// This event is triggerd if user right clicked on any row of employese and check make supervisor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemMouseDownMakeSupervisor(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)allEmps.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            appLayer.MakeEmpSupervisor(result);
            Refresh();
        }
        /// <summary>
        /// This event is triggerd if user right clicked on any row of employese and check give bonus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void give_bonus(object sender, RoutedEventArgs e)
        {
           
        }
        /// <summary>
        /// triggered at click on add button to add new employee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddEmp(object sender, RoutedEventArgs e)
        {
            new AddEmployee(parentInstance).Show();
            parentInstance.Hide();
        }
        /*
         * private void AddLine(object sender, RoutedEventArgs e)
        {
            new AddEmployee(parentInstance).Show();
            parentInstance.Hide();
        }
         */
        /// <summary>
        /// It loads again the dat in dataGrid by removing last values and select them again.
        /// </summary>
        public void Refresh()
        {
            allEmps.ItemsSource = null;
            loadData();
        }

        
    }
}
