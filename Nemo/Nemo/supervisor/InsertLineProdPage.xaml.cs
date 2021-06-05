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
namespace Nemo.supervisor
{
    /// <summary>
    /// Interaction logic for InsertLineProdPage.xaml
    /// </summary>
    public partial class InsertLineProdPage : Page
    {
        Database.AppLayer applayer;
        DataTable lines;
        DataTable products;
        public InsertLineProdPage(string username)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            loadData(username);
        }
        public void loadData(string username)
        {
            loadLines(username);
            loadProducts();
            for (int i = 0; i < lines.Rows.Count; i++) //populate the choices from datatable
            {
                combo_line.Items.Add(lines.Rows[i]["name"] + "  ID:" + lines.Rows[i]["id"]);
            }
            for (int i = 0; i < products.Rows.Count; i++)
            {
                combo_product.Items.Add(products.Rows[i]["name"] + "  ID:" + products.Rows[i]["id"]);
            }
        }
        private void loadLines(string username)
        {
            lines = applayer.getLineNameAndID(username);
        }
        private void loadProducts()
        {
            products = applayer.getAllProducts();
        }


        int lineID, prodID, amount, linesIndex, prodIndex;
        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {

            if (combo_line.SelectedIndex == -1) MessageBox.Show("Please Choose a line!");
            else if (combo_product.SelectedIndex == -1) MessageBox.Show("Please Choose a product!");
            else if (string.IsNullOrEmpty(txt_amount.Text) || !(txt_amount.Text.All(char.IsDigit))) MessageBox.Show("Please Enter valid amount!");
            else
            {
                linesIndex = combo_line.SelectedIndex;
                prodIndex = combo_product.SelectedIndex;
                lineID = int.Parse(lines.Rows[linesIndex]["id"].ToString());
                prodID = int.Parse(products.Rows[prodIndex]["id"].ToString());
                amount = int.Parse(txt_amount.Text.ToString());
                if (applayer.doesLineProduces(lineID,prodID)) //check if the line already prodces this product
                {
                    if (applayer.updateProdcution(lineID, prodID, amount) > 0)
                        MessageBox.Show("Amount updated succesfully");
                    else MessageBox.Show("Failed to update");
                }
                else 
                {
                    if (applayer.insertProduction(lineID, prodID, amount) > 0)
                        MessageBox.Show("Amount added succesfully");
                    else MessageBox.Show("Failed to add");
                }

            }
        }
    }
}



