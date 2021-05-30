using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data;

namespace Nemo.supervisor
{
    /// <summary>
    /// Interaction logic for viewAssignedMachines.xaml
    /// </summary>
  

    public partial class viewAssignedMachines : Page
    {
        Database.AppLayer applayer;
        DataTable data;
        public viewAssignedMachines()
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            loadData();
        }

        
        private void loadData()
        {
            data = applayer.loadAssignedMachines();
            machinesgrid.ItemsSource = data.DefaultView;
        }

    }
}
