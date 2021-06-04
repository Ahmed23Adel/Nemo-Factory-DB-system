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
    /// Interaction logic for workersAndMachinesPage.xaml
    /// </summary>
    /// 
   
    public partial class workersAndMachinesPage : Page
    {
        
        Database.AppLayer applayer;
        DataTable data;
        public List<string> assignedWorkers = new List<string>();
        //MachinesPage loadMachines;
        // public List<string> assignedWorkers;
       // var window = new MachinesPage;



        public bool verifyClickedIsClicked = false;
        public workersAndMachinesPage(string userName)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            loadData(userName);
            MachineButton.Click += assignClicked;
        }

        public void loadData(string userName)
        {
            data = applayer.getWorkersAndMachines(userName);
            if (data.Columns["IsChecked"] == null) data.Columns.Add("IsChecked", typeof(bool));
            // reset IsChecked in all rows

            //loop to know which item is selected and get the cell you want from it
         

            for (int i = 0; i < data.Rows.Count; i++) data.Rows[i]["IsChecked"] = false;
            workersAndMachinesGrid.ItemsSource = data.DefaultView;
        }

        public void assignClicked(object sender, RoutedEventArgs e)
        {
            /*
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if (!(bool)data.Rows[i]["IsChecked"])
                {
                    MessageBox.Show("You have not selected any worrker!");     //func() is just an example not implemented yet
                    return;
                }
            }
            //for (int i = 0; i < data.Rows.Count; i++)
            */
       
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ((bool)data.Rows[i]["IsChecked"])
                {
                    assignedWorkers.Add(data.Rows[i]["ID"].ToString());
                    //applayer.sendAssignedWorkerId(data.Rows[i]["ID"].ToString());     //func() is just an example not implemented yet
              
                } 
            }
          //  assignClickedIsClicked = true;
            MachineButton.Visibility = Visibility.Hidden;
        }
    

        

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MachineButton.Visibility = Visibility.Visible;
            return;
        }

        private void verifySelectionClicked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < data.Rows.Count; i++)
            {
                if ((bool)data.Rows[i]["IsChecked"])
                {
                    assignedWorkers.Add(data.Rows[i]["ID"].ToString());
                    //applayer.sendAssignedWorkerId(data.Rows[i]["ID"].ToString());     //func() is just an example not implemented yet

                }
            }
            verifyClickedIsClicked = true;
            MachineButton.Visibility = Visibility.Hidden;
        }
    }
}
