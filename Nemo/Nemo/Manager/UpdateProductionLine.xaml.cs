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
using System.Windows.Shapes;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for UpdateProductionLine.xaml
    /// </summary>
    public partial class UpdateProductionLine : Window
    {
        string lineIdl;
        Database.AppLayer appLayer;
        ManagerOptoins parentInstance;
        public UpdateProductionLine(string lineId, ManagerOptoins parentInstance)
        {
            InitializeComponent();
            this.lineIdl = lineId;
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            LoadData();
        }

        public void LoadData()
        {
            DataTable dtLines = appLayer.GetProductionLineAtId(lineIdl);
            DataTable dtSupervisors = appLayer.GetAllSupervisors();
            name.Text = dtLines.Rows[0]["Name"].ToString();
            location.Text = dtLines.Rows[0]["Location"].ToString();
            supervisors.ItemsSource = dtSupervisors.DefaultView;
            for (int i = 0; i < dtSupervisors.Rows.Count; i++)
            {
                if (int.Parse(dtSupervisors.Rows[i]["ID"].ToString() )== int.Parse(dtLines.Rows[0]["Supervisor_id"].ToString()))
                {
                    supervisors.SelectedIndex = i;
                    break;
                }
            }
        }
        private void cancel(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            this.Hide();
            parentInstance.Show();
        }
        
        private void remove(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            if (MessageBox.Show("Are you sure you want to delete this production line?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                appLayer.DeleteProductionLineAtId(lineIdl);
                MakeSound.MakeSent();
                parentInstance.ModShow();

            }
        }
        
        private void update(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            if (MessageBox.Show("Are you sure you want to update this production line?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                appLayer.UpdateProductionLineAtId(lineIdl, name.Text, location.Text, supervisors.SelectedValue.ToString());
                parentInstance.ModShow();
                this.Close();
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
        }
    }
}
