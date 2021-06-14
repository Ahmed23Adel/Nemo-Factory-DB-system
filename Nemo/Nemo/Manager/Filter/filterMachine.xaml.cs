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

namespace Nemo.Manager.Filter
{
    /// <summary>
    /// Interaction logic for filterMachine.xaml
    /// </summary>
    public partial class filterMachine : Window
    {
        FiltersClasses.MachineFilter machineFilter;
        Search.SearchMachines searchEmpsParentInstance;
        public filterMachine(FiltersClasses.MachineFilter machineFilter, Search.SearchMachines searchEmpsParentInstance)
        {
            InitializeComponent();
            this.searchEmpsParentInstance = searchEmpsParentInstance;
            this.machineFilter = machineFilter;
            LoadDate();
        }
        public void LoadDate()
        {
            startDateLess.Text = machineFilter.startDateLess;
            startDateGreater.Text = machineFilter.startDateGreater;
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

        private bool TextIsNumeric(string input)
        {
            return input.All(c => Char.IsDigit(c) || Char.IsControl(c));
        }

        private void Apply(object sender, RoutedEventArgs e)
        {
            if (IsDataValid())
            {
                machineFilter.startDateGreater = startDateGreater.Text;
                machineFilter.startDateLess = startDateLess.Text;
                this.Close();
                searchEmpsParentInstance.searchAndFilter();
            }
        }
        private bool IsDataValid()
        {
            if (!string.IsNullOrEmpty(startDateGreater.Text) && !string.IsNullOrEmpty(startDateLess.Text) && startDateGreater.SelectedDate >= startDateLess.SelectedDate)
            {
                MessageBox.Show("Hiring date boundaries is not valid, please fix it and try again.");
                return false;
            }
            return true;
        }
    }
}
