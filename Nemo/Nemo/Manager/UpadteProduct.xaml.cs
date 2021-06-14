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
    /// Interaction logic for UpadteProduct.xaml
    /// </summary>
    public partial class UpadteProduct : Window
    {
        string id;
        ManagerOptoins parentInstance;
        Database.AppLayer appLayer;
        string oldLineId;
        public UpadteProduct(string id, ManagerOptoins parentInstance)
        {
            InitializeComponent();
            this.id = id;
            this.parentInstance = parentInstance;
            appLayer = Database.AppLayer.GetInstance();
            loadData();
        }
        public void LoadProductionLines()
        {
            DataTable dtLines = appLayer.GetAllProductionLine();
            lines.ItemsSource = dtLines.DefaultView;

        }
        public void loadData()
        {
            DataTable dt = appLayer.GetProductAtId(id);
            name.Text = dt.Rows[0]["Name"].ToString();
            cost.Text = dt.Rows[0]["cost"].ToString();
            oldLineId = dt.Rows[0]["prodLine"].ToString();
            DataTable dtLines = appLayer.GetAllProductionLine();
            lines.ItemsSource = dtLines.DefaultView;

            for (int i = 0; i < dtLines.Rows.Count; i++)
            {

                if (!string.IsNullOrEmpty(dt.Rows[0]["prodLine"].ToString()) && int.Parse(dtLines.Rows[i]["ID"].ToString()) == int.Parse(dt.Rows[0]["prodLine"].ToString()))
                {
                    lines.SelectedIndex = i;
                    break;
                }
            }
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {

            MakeSound.MakeClick();
            this.Close();
            parentInstance.Show();
        }

        


        private void RemoveProduct(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delte this product?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                appLayer.DeleteProductAtId(id);
                this.Close();
                //it calls ModShow to update data in employees table
                parentInstance.ModShow();
            }
        }
        private void UpdateProduct(object sender, RoutedEventArgs e)
        {
            if (IsDataValid())
            {
                if (MessageBox.Show("Are you sure you want to update this product?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MakeSound.MakeSent();
                    UpdateProductAtId();
                    this.Close();
                    //it calls ModShow to update data in employees table
                    parentInstance.ModShow();
                }
            }
        }
        public void UpdateProductAtId()
        {
            appLayer.UpdateProductAtId(id, name.Text, cost.Text);
            updateLinkProductToProductionLine();
        }
        public void updateLinkProductToProductionLine()
        {
            appLayer.UpdateLinkProductToProductionLine(id,lines.SelectedValue.ToString(), lines.SelectedValue.ToString());
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
