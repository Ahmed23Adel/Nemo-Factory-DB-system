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
    /// Interaction logic for viewAssignedMachinesPage.xaml
    /// </summary>
    public partial class viewAssignedMachinesPage : Page
    {


        Database.AppLayer applayer;
        DataTable data;
        public viewAssignedMachinesPage(string userName)
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

    }

}
