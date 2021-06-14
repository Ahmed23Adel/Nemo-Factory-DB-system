using Nemo.FiltersClasses;
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
    /// Interaction logic for FirlterEmps.xaml
    /// </summary>
    public partial class FilterEmpsSearch : Window
    {
        FiltersClasses.EmpFilter empFilter;
        searchEmps searchEmpsParentInstance;
        public FilterEmpsSearch(EmpFilter empFilter,searchEmps searchEmpsParentInstance)
        {
            InitializeComponent();
            this.empFilter = empFilter;
            this.searchEmpsParentInstance = searchEmpsParentInstance;
            LoadData();
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

        public void LoadData()
        {
            salGreater.Text = empFilter.salgreater;
            salLess.Text = empFilter.salLess;
            bdateGreater.Text = empFilter.bDategreater;
            bdateLess.Text = empFilter.bDateLess;
            hirDateGreater.Text = empFilter.hiringDategreater;
            hirDateLess.Text = empFilter.hiringDateLess;
            male.IsChecked = empFilter.male;
            female.IsChecked = empFilter.female;
            married.IsChecked = empFilter.married;
            single.IsChecked = empFilter.single;
        }
        private void Apply(object sender, RoutedEventArgs e)
        {
            if (IsDataValid())
            {
                empFilter.salgreater = salGreater.Text;
                empFilter.salLess = salLess.Text;
                empFilter.bDategreater = bdateGreater.Text;
                empFilter.bDateLess = bdateLess.Text;
                empFilter.hiringDategreater = hirDateGreater.Text;
                empFilter.hiringDateLess = hirDateLess.Text;

                empFilter.setMale((bool)male.IsChecked);
                empFilter.setFemale((bool)female.IsChecked);
                empFilter.setMarried((bool)married.IsChecked);
                empFilter.setSingle((bool)single.IsChecked);
                this.Close();
                searchEmpsParentInstance.searchAndFilter();
            }
        }
        private bool IsDataValid()
        {
            if (!string.IsNullOrEmpty(salGreater.Text) &&! string.IsNullOrEmpty(salLess.Text) && int.Parse(salGreater.Text) >= int.Parse(salLess.Text))
            {
                MessageBox.Show("Salaries boundaries is not valid, please fix it and try again.");
                return false;
            }
            
            if (!string.IsNullOrEmpty(bdateGreater.Text) &&! string.IsNullOrEmpty(bdateGreater.Text) && bdateGreater.SelectedDate >= bdateLess.SelectedDate)
            {
                MessageBox.Show("birtth date boundaries is not valid, please fix it and try again.");
                return false;
            }
            if (!string.IsNullOrEmpty(hirDateGreater.Text) &&! string.IsNullOrEmpty(hirDateLess.Text) && hirDateGreater.SelectedDate >= hirDateLess.SelectedDate)
            {
                MessageBox.Show("Hiring date boundaries is not valid, please fix it and try again.");
                return false;
            }
            return true;
        }
    }
}
