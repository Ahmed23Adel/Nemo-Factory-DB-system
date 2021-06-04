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
            loadData(username); 
        }
        private void loadData(string username)
        {
            loadLines(username);
            loadProducts();
            for (int i = 0; i < lines.Rows.Count; i++) //populate the choices from datatable
            {
                combo_line.Items.Add(lines.Rows[i]["name"] + "  ID:" + lines.Rows[i]["id"]);
            }
            for (int i = 0; i < products.Rows.Count; i++)
            {
                combo_product.Items.Add(lines.Rows[i]["name"] + "  ID:" + lines.Rows[i]["id"]);
            }
        }
        private void loadLines(string username)
        {
            lines=applayer.getLineNameAndID(username);
        }
        private void loadProducts()
        {
            products=applayer.getAllProducts();
        }

        int lineID, prodID, amount;
        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            if (combo_line.SelectedIndex == -1) MessageBox.Show("Please Choose a line!");
            else if (combo_product.SelectedIndex==-1) MessageBox.Show("Please Choose a product!");
            else if (string.IsNullOrEmpty(txt_amount.Text) || txt_amount.Text.Any(char.IsDigit)) MessageBox.Show("Please Enter valid amount!");
            else
            {
                if (applayer.doesLineProduces(lineID))
                {
                    if (applayer.updateProdcution(lineID, prodID, amount) > 0)
                        MessageBox.Show("Amount updated succesfully");
                }
                else
                {
                    if (applayer.insertProduction(lineID, prodID, amount) > 0)
                        MessageBox.Show("Amount added succesfully");
                }

            }
        }
    }

}

