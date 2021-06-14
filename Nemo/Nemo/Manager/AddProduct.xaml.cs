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
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        ManagerOptoins parentInstance;
        Database.AppLayer appLayer;
        public AddProduct(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            this.parentInstance = parentInstance;
            appLayer = Database.AppLayer.GetInstance();

            LoadProductionLines();
        }
        public void LoadProductionLines()
        {
            DataTable dtLines = appLayer.GetAllProductionLine();
            lines.ItemsSource = dtLines.DefaultView;

        }
        private void InsertProductClicked(object sender, RoutedEventArgs e)
        {
            if (IsDataValid())
            {
                MakeSound.MakeSent();
                InsertNewProduct();
                this.Close();
                parentInstance.ModShow();

            }

        }


        private void Cancel(object sender, RoutedEventArgs e)
        {

            MakeSound.MakeClick();
            this.Close();
            parentInstance.Show();
        }




        public void InsertNewProduct()
        {
            appLayer.InsertNewProduct(name.Text, cost.Text);
            InsertNewLineProduct();
        }

        public void InsertNewLineProduct()
        {
            string prodId = appLayer.GetLastProduct();
            if(lines.SelectedIndex != -1)
                     appLayer.LinkProductToProductoinLine(lines.SelectedValue.ToString(),prodId);
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

        public bool IsDataValid()
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                MessageBox.Show("Name is empty, please fill it and try again");
                return false;
            }
          
            return true;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
        }
    }
}
