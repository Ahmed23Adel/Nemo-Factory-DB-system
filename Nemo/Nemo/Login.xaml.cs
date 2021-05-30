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

namespace Nemo
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        int numError;
        Database.AppLayer appLayer;
        public Login()
        {
            
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            numError = 0;
            password.PreviewKeyDown += EnterClicked;
            userName.PreviewKeyDown += EnterClicked;
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (isDataValid())
            {
                checkUserNamePass();

            }
        }

        private bool isDataValid()
        {
            if (string.IsNullOrEmpty(userName.Text))
            {
                ifNum0PrintFOrS("User name is Empty, I'm not going to fill it for you! fill it and try again.", "But you swore! user name is still wrong");
                return false;
            }
            
            if (string.IsNullOrEmpty(password.Password))
            {
                ifNum0PrintFOrS("Password is Empty, I'm not going to fill it for you! fill it and try again. ", "But you swore! password is still wrong");
                return false;
            }
            if (userName.Text.Length > 50)
            {
                ifNum0PrintFOrS("User name length is more than 50 characters, please fix it and try again.", "But you swore! user name is still so long; it's more than 50 characters");
                return false;
            }
            
            if (password.Password.Length > 50)
            {
                ifNum0PrintFOrS("password length is more than 50 characters, please fix it and try again.", "But you swore! password is still so long; it's more than 50 characters");
                return false;
            }
            return true;
        }

        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                checkUserNamePass();
            }
        }

        private void checkUserNamePass()
        {

            if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.NONE)
            {
                ifNum0PrintFOrS("User name or password is wrong", "But you swore! User name or password is still wrong");
                
            }

            if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.MNGR)
            {
                new Manager.ManagerOptoins(userName.Text, password.Password).Show();
                this.Close();
            }    
            if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.SPRVSR)
            {
                new supervisor.supervisor(userName.Text, password.Password).Show();
                this.Close();
            }    
            if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.WRKR)
            {
                new Worker.worker(userName.Text, password.Password).Show();
                this.Close();
            }    
            
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
    }
}
