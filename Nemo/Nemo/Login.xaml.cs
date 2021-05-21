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
        public Login()
        {
            
            InitializeComponent();
            numError = 0;
            new Manager.Manager_options().Show();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (isDataValid())
            { 

            }
        }

        private bool isDataValid()
        {
            if (string.IsNullOrEmpty(userName.Text))
            {
                if (numError == 0)
                {
                    new Utilities.CustomMessageBox("User name is Empty, I'm not going to fill it for you! fill it and try again.").Show();
                    numError = 1;
                }
                else 
                {
                    new Utilities.CustomMessageBox("But you swore! user name is still wrong").Show();
                }

                return false;
            }
            
            if (string.IsNullOrEmpty(password.Password))
            {
                if (numError == 0)
                {
                    new Utilities.CustomMessageBox("Password" +
                     " is Empty, I'm not going to fill it for you! fill it and try again.").Show();
                    numError = 1;
                }
                else
                {
                    new Utilities.CustomMessageBox("But you swore! password is still wrong").Show();
                    numError = 1;
                }

                

                return false;
            }
            return true;
        }
    }
}
