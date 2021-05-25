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

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        Database.AppLayer appLayer;
        ManagerOptoins parentInstance;
        //This is just for funny word that will be shown to user it he types wrong data twice
        int numError;

        public AddEmployee(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            numError = 0;

        }
        /// <summary>
        /// This event is fired when user clicks on insert 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InserteInfo(object sender, RoutedEventArgs e)
        {
            if (IsDataValid())
            {
                InsertEmployee();
                this.Close();
                //it calls ModShow to update data in employees table
                parentInstance.ModShow();
                
            }
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
            parentInstance.Show();
            this.Close();
        }
        /// <summary>
        /// It check for data  in each data field, it it's first time to make error it will show certain msg, if second ot more it will show different msg
        /// </summary>
        /// <returns></returns>
        private bool IsDataValid()
        {
            //First name shouldn't have any digits
            if (fName.Text.Any(char.IsDigit))
            {
                IfNum0PrintFOrS("User name contains numbers; please change it and try again", "But you swore! user name is still wrong");
                return false;
            }
            //last naem shouldn't have any digits
            if (lName.Text.Any(char.IsDigit))
            {
                IfNum0PrintFOrS("Last name contains numbers; please change it and try again", "But you swore! Last name is still wrong");
                return false;
            }
            //Balance shouldn't have any letters
            if (balance.Text.Any(char.IsLetter))
            {
                IfNum0PrintFOrS("Balance contains letters; please change it and try again", "But you swore! Balance is still wrong");
                return false;
            }
            //National id shouldn't have any letters
            if (nationalId.Text.Any(char.IsLetter))
            {
                IfNum0PrintFOrS("Natoinal id contains letters; please change it and try again", "But you swore! National id is still wrong");
                return false;
            }
            //userName shouldn't be empty
            if (string.IsNullOrEmpty(userName.Text))
            {
                IfNum0PrintFOrS("user name is empty; I'm not gonne fill it for you! please change it and try again", "But you swore! user name is still empty");
                return false;
            }
            //pasword should be empty
            if (string.IsNullOrEmpty(pass.Text))
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
        /// Insert new employee from entered data
        /// </summary>
        public void InsertEmployee()
        {
                string nationalIdText = nationalId.Text.Trim();
                string fNameText = fName.Text.Trim();
                string lNameText = lName.Text.Trim();
                string balanceText = balance.Text.Trim();
                string userNameText = userName.Text.Trim();
                string passText = pass.Text.Trim();
                string index = jop_title.SelectedIndex.ToString();
                string jopTitleText = GetJopTitleAtIndex(index);
                string bDateText = bdate.Text.Trim();
                appLayer.InsertEmp(fNameText, lNameText, balanceText, bDateText, jopTitleText, userNameText, passText, nationalIdText);
            
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parentInstance.Show();
        }
    }
}
