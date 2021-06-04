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
        public string machine = "N";
        workersAndMachinesPage workersPage;
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

        private void chooseMachine(object sender, MouseButtonEventArgs e)
        {
            /*
                var grid = sender as DataGrid;

                var cellValue = grid.SelectedValue;
                machine = cellValue.ToString();
            */
            if (machinesGrid.SelectedCells.Count > 0)
            {
                var CellValue = GetSelectedValue(machinesGrid);
                machine = CellValue;
                //CellValue is a variable of type string.

            }

        }
        private string GetSelectedValue(DataGrid grid)
        {
            DataGridCellInfo cellInfo = grid.SelectedCells[0];
            if (cellInfo == null) return null;

            DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
            if (column == null) return null;

            FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
            BindingOperations.SetBinding(element, TagProperty, column.Binding);

            return element.Tag.ToString();
        }

    }

}
