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
using System.Data;
namespace Nemo.Worker
{
    /// <summary>
    /// Interaction logic for anouncementsWindow.xaml
    /// </summary>
    public partial class anouncementsWindow : Window
    {
        worker parent;
        DataTable data;
        Database.AppLayer appLayer;
        public anouncementsWindow(worker parent,string username)
        {
            InitializeComponent();
            this.parent = parent;
            appLayer = Database.AppLayer.GetInstance();
            loadData(username);
        }
        private void loadData(string username)
        {
            data = appLayer.getMessages(username);

            if (data.Rows.Count != 0) MessageBox.Show(data.Rows[0]["Name"].ToString());
            grid_msgs.ItemsSource = data.DefaultView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            parent.Show();
            //this.Close();
        }
    }
}
