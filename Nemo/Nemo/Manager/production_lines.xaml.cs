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
        ManagerOptoins parent;
        DataTable data;
        public production_lines(ManagerOptoins p)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            parent = p;
            getAllLines();
            addLinePage = new addLinePage();
        }
        public void getAllLines()
        {
            data = applayer.getAllLines();
            prodLinesGrid.ItemsSource = data.DefaultView;
            //prodLinesGrid.ItemsSource = 
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            parent.moreInfo.Content = addLinePage;

        }
    }
}
