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

        int numError;
        public UpdateMachine(string id, ManagerOptoins parentInstance)
        {
            InitializeComponent();
            this.id = id;
            this.parentInstance = parentInstance;
            appLayer = Database.AppLayer.GetInstance();
            numError = 0;
            loadData();
        }

        public void loadData()
        {
            DataTable dt = appLayer.GetMachineAtId(id);
            name.Text = dt.Rows[0]["Name"].ToString();
            startDate.Text = dt.Rows[0]["Start_date"].ToString();
        }

        /// <summary>
        /// This event is to be fired if user click on cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(@"../../SoundEffects/click.mp3", UriKind.Relative));
            mplayer.Play();
            parentInstance.Show();
            this.Close();
        }
        private void RemoveMac(object sender, RoutedEventArgs e)
        {
            //Make sure that user is sure to delete this employee
            if (MessageBox.Show("Are you sure you want to delete this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
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
            if (true)
            {
                //make sure that user is sure to update info
                if (MessageBox.Show("Are you sure you want to update this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                   UpdateMachineAtId();
                    this.Close();
                    //it calls ModShow to update data in employees table
                    parentInstance.ModShow();
                }

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
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(@"../../SoundEffects/click.mp3", UriKind.Relative));
            mplayer.Play();
            appLayer.UpdateMachineAtId(id, name.Text, startDate.Text);

        }







    }
}
