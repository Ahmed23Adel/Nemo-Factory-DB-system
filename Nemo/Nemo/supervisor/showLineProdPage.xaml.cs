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
    /// Interaction logic for showLineProdPage.xaml
    /// </summary>
    public partial class showLineProdPage : Page
    {
        DataTable data;
        Database.AppLayer applayer;
        public showLineProdPage(string username)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            loadData(username);
        }
        private void loadData(string username)
        {
            data = applayer.getProduction(username);
            showLineProdGrid.ItemsSource = data.DefaultView;
        }
    }
}
