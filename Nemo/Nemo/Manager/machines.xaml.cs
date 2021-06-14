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

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for machines.xaml
    /// </summary>

    public partial class machines : Page
    {

        Database.AppLayer appLayer;

        ManagerOptoins parentInstance;
        public machines(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            loadData();
        }

        private void MenuItemUpdate(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            DataRowView drv = (DataRowView)allMachines.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            new UpdateMachine(result, parentInstance).Show();//showing updateEmployee to update Data
            parentInstance.Hide();
        }

        private void MenuItemDelete(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            if (MessageBox.Show("Are you sure you want to delete this this?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                DataRowView drv = (DataRowView)allMachines.SelectedItem;//get selected row
                String result = (drv["ID"]).ToString();//get the id to search by it.
                appLayer.RemoveMachineAtId(result);
                Refresh();
            }
        }

        private void InsertNewMachine(object sender, MouseButtonEventArgs e)
        {
            MakeSound.MakeClick();
            new AddMachine(parentInstance).Show();
            parentInstance.Hide();
        }

        public void loadData()
        {
            DataTable dt = appLayer.GetAllMachines();
            allMachines.ItemsSource = dt.DefaultView;
        }

        public void Refresh()
        {
            allMachines.ItemsSource = null;
            loadData();
        }

        private void search(object sender, MouseButtonEventArgs e)
        {
            new Search.SearchMachines(parentInstance).Show();
            parentInstance.Hide();
            MakeSound.MakeClick();
        }
    }
}
