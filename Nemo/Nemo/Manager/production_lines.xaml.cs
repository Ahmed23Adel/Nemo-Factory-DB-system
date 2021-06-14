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
namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for production_lines.xaml
    /// </summary>
    public partial class production_lines : Page
    {

        Database.AppLayer applayer;
        addLinePage addLinePage;
        ManagerOptoins parentInstance;
        DataTable data;
        public production_lines(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            getAllLines();
            addLinePage = new addLinePage();
        }
        public void getAllLines()
        {
            data = applayer.getAllLines();
            prodLinesGrid.ItemsSource = data.DefaultView;        }

        private void addLine(object sender, MouseButtonEventArgs e)
        {
            MakeSound.MakeClick();
            new AddProductionLine(parentInstance).Show();
            parentInstance.Hide();

        }

        private void itm_delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this this?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                if (applayer.deleteLine(((DataRowView)prodLinesGrid.SelectedItem)["ID"].ToString()) > 0)
                    MessageBox.Show("Line deleted succesfully!");
                getAllLines();
            }
        }
        
        private void itm_update_Click(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            new UpdateProductionLine(((DataRowView)prodLinesGrid.SelectedItem)["ID"].ToString(),parentInstance).Show();
            parentInstance.Hide();
        }

        public void Refresh()
        {
            prodLinesGrid.ItemsSource = null;
            getAllLines();
        }
    }
}
