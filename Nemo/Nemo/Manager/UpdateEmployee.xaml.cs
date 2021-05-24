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


namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for UpdateEmployee.xaml
    /// </summary>
    public partial class UpdateEmployee : Window
    {
        string id;
        Database.AppLayer appLayer;
        int numError;
        Manager_options parentInstance;
        public UpdateEmployee(string id, Manager_options parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.getInstance();
            this.id = id;
            numError = 0;
            this.parentInstance = parentInstance;

            loadData();
        }

        private void loadData()
        {
            DataTable dt = appLayer.selectEmpAtId(id);


            string jptle = dt.Rows[0]["Jop_title"].ToString();
            if (jptle == "M") //Manager
                jop_title.SelectedIndex = 1;
            else if (jptle == "E")//Employee
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

        private void updateInfo(object sender, RoutedEventArgs e)
        {
            if (isDataValid())
            {
                if (MessageBox.Show("Are you sure you want to update this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    updateEmp();
                    this.Close();
                    parentInstance.ModShow();
                }
            }

        }

        private bool isDataValid()
        {
            if(fName.Text.Any(char.IsDigit))
            {
                ifNum0PrintFOrS("User name contains numbers; please change it and try again", "But you swore! user name is still wrong");
                return false;
            }
            if(lName.Text.Any(char.IsDigit))
            {
                ifNum0PrintFOrS("Last name contains numbers; please change it and try again", "But you swore! Last name is still wrong");
                return false;
            }
            
            if(balance.Text.Any(char.IsLetter))
            {
                ifNum0PrintFOrS("Balance contains letters; please change it and try again", "But you swore! Balance is still wrong");
                return false;
            }
            if(string.IsNullOrEmpty(userName.Text))
            {
                ifNum0PrintFOrS("user name is empty; I'm not gonne fill it for you! please change it and try again", "But you swore! user name is still empty");
                return false;
            }
            if(string.IsNullOrEmpty(pass.Text))
            {
                ifNum0PrintFOrS("Password is empty; I'm not gonne fill it for you! please change it and try again", "But you swore! Password is still empty");
                return false;
            }
            return true;
        }
        //this function checks if numError ==1 if 1 then it will print msg2 otherwiser will print msg1
        private void ifNum0PrintFOrS(string msg1, string msg2)
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

        private void updateEmp()
        {
            //(string id, string Fname,string Lname, string Balance, string Bdata, string Jop_title,string userName,string password)
            string index = jop_title.SelectedIndex.ToString();
            appLayer.updateEmpAtId(id, fName.Text, lName.Text,balance.Text,bdate.Text,getJopTitleAtIndex(index),userName.Text,pass.Text);
        }

        private string getJopTitleAtIndex(string index)
        {
            if (index == "0")
                return "N";
            if (index == "1")
                return "M";
            if (index == "2")
                return "E";
            else
                return "S";
        }

        private void cancel(object sender, RoutedEventArgs e)
        {
            parentInstance.Show();
            this.Close();
        }
        private void removeEmp(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("Are you sure you want to delete this employee?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                appLayer.deleteAtId(id);
                this.Close();
                parentInstance.ModShow();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            parentInstance.Show();
        }
    }
}
