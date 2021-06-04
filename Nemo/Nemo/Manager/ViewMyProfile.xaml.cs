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
    /// Interaction logic for ViewMyProfile.xaml
    /// </summary>
    public partial class ViewMyProfile : Window
    {
        string id;
        string userName;
        string password;
        int numError;

        Database.AppLayer appLayer;
        ManagerOptoins parentInstance;
        public ViewMyProfile(string userName, string password, ManagerOptoins parentInstance)
        {
            InitializeComponent();
            this.userName = userName;
            this.password = password;
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            numError = 0;
            LoadData();

        }

        public void LoadData()
        {
            DataTable dt = appLayer.selectEmpAtUserNamePass(userName, password);
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
            if (statChosen == "S")
                status.SelectedIndex = 2;
            else
                status.SelectedIndex = 0;
        }
        //<summary>
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

        private void Update(object sender, RoutedEventArgs e)
        {
            if (IsDataValid())

            {
                MakeSound.MakeClick();
                if (MessageBox.Show("Are you sure you want to update your data ?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    MakeSound.MakeSent();

                    string index = jop_title.SelectedIndex.ToString();
                    string indexGender = gender.SelectedIndex.ToString();
                    string indexStatus = status.SelectedIndex.ToString();
                    appLayer.UpdateaEmpAtUserNamePass(fName.Text.Trim()
                        , lName.Text.Trim(),
                        salary.Text.Trim(),
                        bdate.Text.Trim(),
                        GetJopTitleAtIndex(index).Trim(),
                        userNameField.Text.Trim(), 
                        pass.Text.Trim(),
                        nationalId.Text.Trim(),
                        GetGenderAtIndex(indexGender).Trim(), 
                        address.Text.Trim(), 
                        religion.Text.Trim().Trim(), 
                        GetStatusAtIndex(indexStatus).Trim(),
                        userName, password);
                    this.Close();
                    parentInstance.ModShow(userNameField.Text, pass.Text);
                }
            }
        }

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
            if (salary.Text.Any(char.IsLetter))
            {
                IfNum0PrintFOrS("Balance contains letters; please change it and try again", "But you swore! Balance is still wrong");
                return false;
            }
            //userName shouldn't be empty
            if (string.IsNullOrEmpty(userNameField.Text))
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
    }
}
