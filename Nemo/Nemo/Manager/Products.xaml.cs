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
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        Database.AppLayer appLayer;

        ManagerOptoins parentInstance;
        public Products(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            loadData();
        }
        private void MenuItemUpdate(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            DataRowView drv = (DataRowView)allProducts.SelectedItem;//get selected row
            String result = (drv["ID"]).ToString();//get the id to search by it.
            new UpadteProduct(result, parentInstance).Show();//showing updateEmployee to update Data
            parentInstance.Hide();
        }

        private void MenuItemDelete(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            if (MessageBox.Show("Are you sure you want to delete this item?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                DataRowView drv = (DataRowView)allProducts.SelectedItem;//get selected row
                String result = (drv["ID"]).ToString();//get the id to search by it.
                appLayer.DeleteProductAtId(result);
                Refresh();
            }
        }
        private void InsertNewProduct(object sender, MouseButtonEventArgs e)
        {
            MakeSound.MakeClick();
            new AddProduct(parentInstance).Show();
            parentInstance.Hide();
        }
        public void loadData()
        {
            DataTable dt = appLayer.GetAllProducts();
            allProducts.ItemsSource = dt.DefaultView;
        }

        public void Refresh()
        {
            allProducts.ItemsSource = null;
            loadData();
        }
    }
}
