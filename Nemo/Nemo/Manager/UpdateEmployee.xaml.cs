using System.Linq;
using System.Windows;
using System.Data;
using System.Windows.Media;
using System;

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
            appLayer = Database.AppLayer.GetInstance();
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
            DataTable dt = appLayer.SelectEmpAtId(id);

            string jptle = dt.Rows[0]["Jop_title"].ToString();
            if (jptle == "M") //Manager
                jop_title.SelectedIndex = 1;
            else if (jptle == "W")//Worker
                jop_title.SelectedIndex = 2;
            else if (jptle == "S")//supervisor
                jop_title.SelectedIndex = 3;
            else //not defined
                jop_title.SelectedIndex = 0;

            string genderChosen = dt.Rows[0]["Gender"].ToString();
            if (genderChosen == "M") //Male
                gender.SelectedIndex = 1;
            else if (genderChosen == "F")//Female
                gender.SelectedIndex = 2;
            else //not defined
                gender.SelectedIndex = 0;

            fName.Text = dt.Rows[0]["Fname"].ToString();
            lName.Text = dt.Rows[0]["Lname"].ToString();
            salary.Text = dt.Rows[0]["Salary"].ToString();
            bdate.Text = dt.Rows[0]["Bdata"].ToString();
            userNameField.Text = dt.Rows[0]["userName"].ToString();
            pass.Text = dt.Rows[0]["password"].ToString();
            nationalId.Text = dt.Rows[0]["NationalId"].ToString();
            address.Text = dt.Rows[0]["Address"].ToString();
            religion.Text = dt.Rows[0]["Religion"].ToString();

            string statChosen = dt.Rows[0]["Status"].ToString(); ;
            if (statChosen == "M")
                status.SelectedIndex = 1;
            else if (statChosen == "S")
                status.SelectedIndex = 2;
            else
                status.SelectedIndex = 0;

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
                MakeSound.MakeClick();
                if (MessageBox.Show("Are you sure you want to update this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MakeSound.MakeSent();
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
            if(salary.Text.Any(char.IsLetter))
            {
                IfNum0PrintFOrS("Balance contains letters; please change it and try again", "But you swore! Balance is still wrong");
                return false;
            }
            //userName shouldn't be empty
            if(string.IsNullOrEmpty(userNameField.Text))
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
            string indexGender = gender.SelectedIndex.ToString();
            string indexStatus = status.SelectedIndex.ToString();
            appLayer.UpdateEmpAtId(id,fName.Text.ToString().Trim(),
                lName.Text.ToString().Trim(),
                salary.Text.ToString().Trim(), 
                bdate.Text.ToString().Trim(),
                GetJopTitleAtIndex(index).ToString().Trim(),
                userNameField.Text.ToString().Trim(), 
                pass.Text.ToString().Trim(), 
                nationalId.Text.ToString().Trim(),
                GetGenderAtIndex(indexGender), 
                address.Text.ToString().Trim(),
                religion.Text.ToString().Trim(), 
                GetStatusAtIndex(indexStatus).ToString().Trim());

        }
        /// <summary>
        /// from index got from combo box of jop title {not defined, worker,supervisor,Manager} it returns the prober letter
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
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
            MakeSound.MakeClick();
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
                appLayer.DeleteAtId(id);
                this.Close();
                parentInstance.ModShow();
            }
        }



        private string GetGenderAtIndex(string index)
        {
            if (index == "0")
                return "N";//Not defined
            if (index == "1")
                return "M";//Manager
            if (index == "2")
                return "F";//Worker
            return "";

        }
        private string GetStatusAtIndex(string index)
        {
            if (index == "0")
                return "N";//Not defined
            if (index == "1")
                return "M";//Manager
            if (index == "2")
                return "S";//Worker
            return "";
        }
        /// <summary>
        /// Event is triggerd if user click on X button in that window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
        }
    }
}
