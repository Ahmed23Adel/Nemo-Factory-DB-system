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
    /// Interaction logic for UpdateMachine.xaml
    /// </summary>
    public partial class UpdateMachine : Window
    {
        string id;
        ManagerOptoins parentInstance;
        Database.AppLayer appLayer;
        string oldProdLineId;

        int numError;
        public UpdateMachine(string id, ManagerOptoins parentInstance)
        {
            InitializeComponent();
            this.id = id;
            this.parentInstance = parentInstance;
            appLayer = Database.AppLayer.GetInstance();
            numError = 0;
            LoadProductionLines();
            loadData();
        }
        public void LoadProductionLines()
        {
            

        }
        public void loadData()
        {
            DataTable dt = appLayer.GetMachineAtId(id);
            name.Text = dt.Rows[0]["Name"].ToString();
            startDate.Text = dt.Rows[0]["Start_date"].ToString();
            oldProdLineId = dt.Rows[0]["prodLine"].ToString();
            DataTable dtLines = appLayer.GetAllProductionLine();
            lines.ItemsSource = dtLines.DefaultView;

            for (int i = 0; i < dtLines.Rows.Count; i++)
            {
                
                if ( !string.IsNullOrEmpty(dt.Rows[0]["prodLine"].ToString())&&  int.Parse(dtLines.Rows[i]["ID"].ToString()) == int.Parse(dt.Rows[0]["prodLine"].ToString()))
                {
                    lines.SelectedIndex = i;
                    break;
                }
            }

        }

        /// <summary>
        /// This event is to be fired if user click on cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
            this.Close();
        }
        private void RemoveMac(object sender, RoutedEventArgs e)
        {
            //Make sure that user is sure to delete this employee
            MakeSound.MakeClick();
            if (MessageBox.Show("Are you sure you want to delete this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                appLayer.RemoveMachineAtId(id);
                this.Close();
                parentInstance.ModShow();
            }
        }

        /// <summary>
        /// this event is trigered if user clicks on update button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInfo(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeSent();

            //MakeSound.MakeClick();
            //make sure that user is sure to update info
            if (MessageBox.Show("Are you sure you want to update this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MakeSound.MakeSent();
                UpdateMachineAtId();
                this.Close();
                //it calls ModShow to update data in employees table
                parentInstance.ModShow();
            }

            

        }
        public bool IsDataValid()
        {
            if (string.IsNullOrEmpty(name.Text))
            {
                IfNum0PrintFOrS("Name of machine is empty, I'm not going to fill it for you. please fill it and try again", "Name of machine is still empty, please fill it and try again");

                return false;
            }
            return true;
            
        }

        private void IfNum0PrintFOrS(string msg1, string msg2)
        {
            if (numError == 0)
            {
                new Utilities.CustomMessageBox(msg1).Show();
                numError = 1;
            }
            else
            {
                new Utilities.CustomMessageBox(msg2).Show();
            }
        }
        private void UpdateMachineAtId()
        {
            appLayer.UpdateMachineAtId(id, name.Text, startDate.Text, oldProdLineId, lines.SelectedValue.ToString());
            MakeSound.MakeSent();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
        }




    }
}
