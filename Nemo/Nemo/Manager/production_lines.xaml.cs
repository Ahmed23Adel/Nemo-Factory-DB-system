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
        public production_lines()
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            getAllLines();
        }
        public void getAllLines()
        {
            //prodLinesGrid.ItemsSource = applayer.getAllLines().DefaultView;
        }

       
    }
}
