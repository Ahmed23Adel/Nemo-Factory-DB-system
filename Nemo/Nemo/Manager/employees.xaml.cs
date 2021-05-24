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
using System.Data;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for employees.xaml
    /// </summary>
    public partial class employees : Page
    {
        Database.AppLayer appLayer;
        Manager_options parentInstance;
        public employees(Manager_options parentInstance)
        {

            InitializeComponent();

            appLayer = Database.AppLayer.getInstance();
            loadData();
            this.parentInstance = parentInstance;
        }

        private void loadData()
        {
            DataTable dt = appLayer.selectAllEmps();
            allEmps.ItemsSource = dt.DefaultView;

           
        }

       
        private void MenuItem_MouseDown_update(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)allEmps.SelectedItem;
            String result = (drv["ID"]).ToString();
            new UpdateEmployee(result,parentInstance).Show();
            parentInstance.Hide();

        }
        private void MenuItem_MouseDown_delete(object sender, RoutedEventArgs e)
        {
            new Utilities.CustomMessageBox("DELETE").Show();
        }
        
        private void MenuItem_MouseDown_MakeManger(object sender, RoutedEventArgs e)
        {
            new Utilities.CustomMessageBox("DELETE").Show();
        }
        
        private void MenuItem_MouseDown_Worker(object sender, RoutedEventArgs e)
        {
            new Utilities.CustomMessageBox("DELETE").Show();
        }
        
        private void MenuItem_MouseDown_supervisor(object sender, RoutedEventArgs e)
        {
            new Utilities.CustomMessageBox("DELETE").Show();
        }
        
        private void give_bonus(object sender, RoutedEventArgs e)
        {
            DataRowView drv = (DataRowView)allEmps.SelectedItem;
            String result = (drv["ID"]).ToString();
            new Utilities.CustomMessageBox(result).Show();
    

        }

        public void refresh()
        {
            allEmps.ItemsSource = null;
            loadData();
        }

        
    }
}
