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
using System.Windows.Shapes;
using System.Data;

namespace Nemo.supervisor
{
    /// <summary>
    /// Interaction logic for supervisor.xaml
    /// </summary>
    public partial class supervisor : Window
    {
        Database.AppLayer applayer;
        string username, password;
        viewAssignedMachinesPage machinesPage;
        viewAssignedLinesPage linesPage;
        workersAndMachinesPage workersPage;
        MyProfile myProfilePage;

        showLineProdPage productionPage;
        InsertLineProdPage insertProductionPage;



        private void ViewAssignedMachines(object sender, MouseButtonEventArgs e)
        {
            SupervisorFrame.Content = machinesPage;
        }

        private void ViewAssignedLines(object sender, MouseButtonEventArgs e)
        {
            SupervisorFrame.Content = linesPage;
        }

        private void MyProfile(object sender, MouseButtonEventArgs e)
        {
            SupervisorFrame.Content = myProfilePage;
        }

        public void ViewWorkers(object sender, MouseButtonEventArgs e)
        {
            machinesPage.loadData(this.username);
            workersPage.loadData(this.username);
            SupervisorFrame.Content = workersPage;
            

                /*
                for (int i = 0; i < workersPage.assignedWorkers.Count; i++)
                {


                    /*
                    if ((bool)data.Rows[i]["IsChecked"])
                    {
                        applayer.sendAssignedWorkerId(data.Rows[i]["ID"].ToString());     //func() is just an example not implemented yet
                    }
                    
                }
                */
        }
      

    

        private void chooseMachineSup(object sender, MouseButtonEventArgs e)
        {
            if (machinesPage.machine != "N")
            {
                foreach (var id in workersPage.assignedWorkers)
                {
                    applayer.sendAssignedWorkerId(id, machinesPage.machine);
                }
                workersPage.loadData(this.username);
                SupervisorFrame.Content = workersPage;
            }
        }


        private void showButtonMove(object sender, MouseEventArgs e)
        {
            if (workersPage.verifyClickedIsClicked)
            {
                ChooseMachine.Visibility = Visibility.Visible;
                workersPage.verifyClickedIsClicked = false;
            }
        }

        private void chooseMachineClick(object sender, RoutedEventArgs e)
        {
            ChooseMachine.Visibility = Visibility.Collapsed;
            machinesPage.loadData(this.username);
            SupervisorFrame.Content = machinesPage;
        }

        private void insertAmount(object sender, MouseButtonEventArgs e)
        {
            SupervisorFrame.Content = insertProductionPage;
        }
        
        private void showDailyAmount(object sender, MouseButtonEventArgs e)
        {
            productionPage.loadData(username);
            SupervisorFrame.Content = productionPage;
        }

        public supervisor(string username, string password)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            this.username = username;
            this.password = password;
            //loadBasicData();
            machinesPage = new viewAssignedMachinesPage(username);
            linesPage = new viewAssignedLinesPage(username);
            workersPage = new workersAndMachinesPage(username);
            myProfilePage = new MyProfile(username, password);
         
            productionPage = new showLineProdPage(username);
            insertProductionPage = new InsertLineProdPage(username);
        }



            /*private void loadBasicData()
            {
                DataTable dt = applayer.GetBasicDataForUserNamePass(username, password);
                this.Title = "Welcome Nemo (" + dt.Rows[0]["Fname"].ToString() + ")";
            }
            private void loadAssignedMachines()
            {
                machinesPage.loadData(this.username);
                SupervisorFrame.Content = machinesPage;
            }private void loadAssignedLines()
            {
                linesPage.loadData(this.username);
                SupervisorFrame.Content = linesPage;
            }

            private void SupervisorFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
            {

            }

            private void loadWorkers()
            {
                workersPage.loadData(this.username);
                SupervisorFrame.Content = workersPage;
            }*/


        }
    }
