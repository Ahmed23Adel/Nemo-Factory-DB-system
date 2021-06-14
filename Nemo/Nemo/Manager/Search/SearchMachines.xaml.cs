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

namespace Nemo.Manager.Search
{
    /// <summary>
    /// Interaction logic for SearchMachines.xaml
    /// </summary>
    /// 
 
    public partial class SearchMachines : Window
    {
        Database.AppLayer appLayer;

        FiltersClasses.MachineFilter machineFilter;

        ManagerOptoins parentInstance;
        public SearchMachines(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            this.machineFilter = new FiltersClasses.MachineFilter();
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
        private void MaskNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextIsNumeric(e.Text);
        }

        private void MaskNumericPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string input = (string)e.DataObject.GetData(typeof(string));
                if (!TextIsNumeric(input)) e.CancelCommand();
            }
            else
            {
                e.CancelCommand();
            }
        }
        private void Filters(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            new Filter.filterMachine( machineFilter,this).Show();
        }
        private void searchable_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchAndFilter();
        }
        private bool TextIsNumeric(string input)
        {
            return input.All(c => Char.IsDigit(c) || Char.IsControl(c));
        }
        public void searchAndFilter()
        {
            machineFilter.name = searchable.Text.Trim();
            DataTable dt = appLayer.searchAndFilterMachines(machineFilter);
            allMachines.ItemsSource = null;
            allMachines.ItemsSource = dt.DefaultView;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
        }

    }
}
