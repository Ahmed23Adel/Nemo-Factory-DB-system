using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shapes;
using Media = System.Windows.Media;
using Input= System.Windows.Input;
using Imaging = System.Windows.Media.Imaging;
using Controls = System.Windows.Controls;
using System.Windows.Media.Imaging;

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


            /*string server = "https://images2.boardingschoolreview.com";

            Uri serverUri = new Uri(server);

            string relativePath = "photo/780x600/1000/593/img-academy-bgYfVkg.webp";

            // needs UriKind arg, or UriFormatException is thrown
            Uri relativeUri = new Uri(relativePath, UriKind.Relative);

            // Uri(Uri, Uri) is the preferred constructor in this case
            Uri fullUri = new Uri(serverUri, relativeUri);

            Uri fullUriC = new Uri(@"D:\Zewail\Year 2\Spring\Database\friends.jpg");

            tempPic.Source = new BitmapImage(fullUriC);*/
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
                MakeSound.MakeSent();
                if (InsertEmployee() == 1)
                {
                    this.Close();
                    //it calls ModShow to update data in employees table
                    parentInstance.ModShow();
                }
                else
                {
                    MessageBox.Show("Username already exist in our database");
                }
                
                
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
            else if (index == "3")
                return "S";//Supervisor
            else
                return "";
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
        /// It check for data  in each data field, it it's first time to make error it will show certain msg, if second ot more it will show different msg
        /// </summary>
        /// <returns></returns>
        private bool IsDataValid()
        {
            if (!string.IsNullOrEmpty(nationalId.Text) && (nationalId.Text.Length != 14))
            {
                MessageBox.Show("National id lengthe is less or greater thatn 14 numbers");
                return false;
            }
            if (string.IsNullOrEmpty(fName.Text))
            {
                MessageBox.Show("First name is Null, please enter it");
                return false;
            }
            if (string.IsNullOrEmpty(lName.Text))
            {
                MessageBox.Show("Last name is Null, please enter it");
                return false;
            }
            //First name shouldn't have any digits
            if (fName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("User name contains numbers; please change it and try again", "But you swore! user name is still wrong");
                return false;
            }
            //last naem shouldn't have any digits
            if (lName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Last name contains numbers; please change it and try again", "But you swore! Last name is still wrong");
                return false;
            }
            //Balance shouldn't have any letters
            if (salary.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Balance contains letters; please change it and try again", "But you swore! Balance is still wrong");
                return false;
            }
            if (!string.IsNullOrEmpty(salary.Text )&& double.Parse(salary.Text) < 0)
            {
                MessageBox.Show("salary can't have negative value");
                return false;
            }
            // National id shouldn't have any letters
            if (nationalId.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Natoinal id contains letters; please change it and try again", "But you swore! National id is still wrong");
                return false;
            }
            //userName shouldn't be empty
            if (string.IsNullOrEmpty(userNameField.Text))
            {
                MessageBox.Show("user name is empty; I'm not gonne fill it for you! please change it and try again", "But you swore! user name is still empty");
                return false;
            }
            //pasword should be empty
            if (string.IsNullOrEmpty(pass.Text))
            {
                MessageBox.Show("Password is empty; I'm not gonne fill it for you! please change it and try again", "But you swore! Password is still empty");
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
        public int InsertEmployee()
        {
            MakeSound.MakeSent();

            string index = jop_title.SelectedIndex.ToString();
            string indexGender = gender.SelectedIndex.ToString();
            string indexStatus = status.SelectedIndex.ToString();

            return appLayer.InsertEmp(fName.Text.Trim()
                , lName.Text.Trim(),
                salary.Text.Trim(),
                bdate.Text.Trim(),
                GetJopTitleAtIndex(index).Trim(),
                userNameField.Text.Trim(),
                pass.Text.Trim(),
                nationalId.Text.Trim(),
                GetGenderAtIndex(indexGender).Trim(),
                address.Text.Trim(),
                religion.Text.Trim(), 
                GetStatusAtIndex(indexStatus).Trim());

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

        private void MaskNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextIsNumeric(e.Text);
        }

        private void MaskNumericPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string input = (string)e.DataObject.GetData(typeof(string));
                if (!TextIsNumeric(input)) e.CancelCommand();
            }
            else
            {
                e.CancelCommand();
            }
        }

        private bool TextIsNumeric(string input)
        {
            return input.All(c => Char.IsDigit(c) || Char.IsControl(c));
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MakeSound.MakeClick();
            parentInstance.Show();
        }
    }
}
