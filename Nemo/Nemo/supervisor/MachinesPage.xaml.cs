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

namespace Nemo.supervisor
{
    /// <summary>
    /// Interaction logic for MachinesPage.xaml
    /// </summary>
    public partial class MachinesPage : Page
    {
        Database.AppLayer applayer;
        DataTable data;
       // public string machine = "N";

        public MachinesPage(string userName)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            loadData(userName);
        }

        public void loadData(string userName)
        {
            data = applayer.loadAssignedMachines(userName);
            machinesGrid.ItemsSource = data.DefaultView;
        }

        private void sendMachineChoice(object sender, MouseButtonEventArgs e)
        {

        }
        /*
public void Assign(object sender, MouseButtonEventArgs e)
{
   var grid = sender as DataGrid;

   var cellValue = grid.SelectedValue;
   machine = cellValue.ToString();
}
*/
    }
}
