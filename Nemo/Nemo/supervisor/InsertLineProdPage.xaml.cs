﻿using System;
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
        private void loadData(string username)
        {
            loadLines(username);
            loadProducts();
            for (int i = 0; i < lines.Rows.Count; i++) //populate the choices from datatable
            {
                combo_line.Items.Add(lines.Rows[i]["name"] + "  ID:" + lines.Rows[i]["id"]);
            }
            for (int i = 0; i < lines.Rows.Count; i++)
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
        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_amount.Text))
            {
                int linesIndex = combo_line.SelectedIndex;
                int prodIndex = combo_product.SelectedIndex;
                int linesId = int.Parse(lines.Rows[linesIndex]["id"].ToString());
                int prodId = int.Parse(products.Rows[prodIndex]["id"].ToString());
                if (applayer.insertProduction(linesId, prodId, int.Parse(txt_amount.Text.ToString())) ==0)
                {
                    applayer.updateProdcution(linesId, prodId, int.Parse(txt_amount.Text.ToString()));
                }
            }
            else
            {
                MessageBox.Show("Amount is empty, please fill it");
            }

        }
    }

}
