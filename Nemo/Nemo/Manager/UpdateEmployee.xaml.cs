using System.Linq;
using System.Windows;
using System.Data;


namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        string id;
        Database.AppLayer appLayer;
        //This is just for funny word that will be shown to user it he types wrong data twice
        int numError;
        ManagerOptoins parentInstance;
        public UpdateEmployee(string id, ManagerOptoins parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.getInstance();
            this.id = id;
            numError = 0;
            this.parentInstance = parentInstance;

            LoadData();
        }

        /// <summary>
        /// This function load all data regarding the user by id
        /// </summary>
        private void LoadData()
        {
            DataTable dt = appLayer.selectEmpAtId(id);

            //First check for jop title if could be either M: Manager W:Worker S:Supervisor or null:Not defined
            string jptle = dt.Rows[0]["Jop_title"].ToString();
            if (jptle == "M") //Manager
                jop_title.SelectedIndex = 1;
            else if (jptle == "W")//Worker
                jop_title.SelectedIndex = 2;
            else if (jptle == "S")//supervisor
                jop_title.SelectedIndex = 3;
            else //not defined
                jop_title.SelectedIndex = 0;

            fName.Text = dt.Rows[0]["Fname"].ToString();
            lName.Text = dt.Rows[0]["Lname"].ToString();
            balance.Text = dt.Rows[0]["Balance"].ToString();
            bdate.Text = dt.Rows[0]["Bdata"].ToString();
            userName.Text = dt.Rows[0]["userName"].ToString();
            pass.Text = dt.Rows[0]["password"].ToString();
        }

        /// <summary>
        /// this event is trigered if user clicks on update button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateInfo(object sender, RoutedEventArgs e)
        {
            if (IsDataValid())
            {
                //make sure that user is sure to update info
                if (MessageBox.Show("Are you sure you want to update this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    UpdateEmp();
                    this.Close();
                    //it calls ModShow to update data in employees table
                    parentInstance.ModShow();
                }
            }

        }

        /// <summary>
        /// It check for data  in each data field, it it's first time to make error it will show certain msg, if second ot more it will show different msg
        /// </summary>
        /// <returns></returns>
        private bool IsDataValid()
        {
            //First name shouldn't have any digits
            if(fName.Text.Any(char.IsDigit))
            {
                IfNum0PrintFOrS("User name contains numbers; please change it and try again", "But you swore! user name is still wrong");
                return false;
            }
            //last naem shouldn't have any digits
            if(lName.Text.Any(char.IsDigit))
            {
                IfNum0PrintFOrS("Last name contains numbers; please change it and try again", "But you swore! Last name is still wrong");
                return false;
            }
            //Balance shouldn't have any letters
            if(balance.Text.Any(char.IsLetter))
            {
                IfNum0PrintFOrS("Balance contains letters; please change it and try again", "But you swore! Balance is still wrong");
                return false;
            }
            //userName shouldn't be empty
            if(string.IsNullOrEmpty(userName.Text))
            {
                IfNum0PrintFOrS("user name is empty; I'm not gonne fill it for you! please change it and try again", "But you swore! user name is still empty");
                return false;
            }
            //pasword should be empty
            if(string.IsNullOrEmpty(pass.Text))
            {
                IfNum0PrintFOrS("Password is empty; I'm not gonne fill it for you! please change it and try again", "But you swore! Password is still empty");
                return false;
            }
            return true;
        }
        /// <summary>
        /// this function checks if numError ==1 if 1 then it will print msg2 otherwiser will print msg1
        /// </summary>
        /// <param name="msg1"></param>
        /// <param name="msg2"></param>
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
        /// <summary>
        /// It call updateEmpAtId to update employee data
        /// </summary>
        private void UpdateEmp()
        {
            string index = jop_title.SelectedIndex.ToString();
            appLayer.updateEmpAtId(id, fName.Text, lName.Text,balance.Text,bdate.Text,GetJopTitleAtIndex(index),userName.Text,pass.Text);
        }

        private string GetJopTitleAtIndex(string index)
        {
            if (index == "0")
                return "N";//Not defined
            if (index == "1")
                return "M";//Manager
            if (index == "2")
                return "W";//Worker
            else
                return "S";//Supervisor
        }

        /// <summary>
        /// This event is to be fired if user click on cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            parentInstance.Show();
            this.Close();
        }
        /// <summary>
        /// This event is to be trigerd if user clicks on remove 
        /// is to remove this employee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveEmp(object sender, RoutedEventArgs e)
        {
            //Make sure that user is sure to delete this employee
            if (MessageBox.Show("Are you sure you want to delete this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                appLayer.deleteAtId(id);
                this.Close();
                parentInstance.ModShow();
            }
        }

        /// <summary>
        /// Event is triggerd if user click on X button in that window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parentInstance.Show();
        }
    }
}
