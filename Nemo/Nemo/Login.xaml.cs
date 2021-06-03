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
        //num Error is only used in for funny part when shoing error
        int numError;
        Database.AppLayer appLayer;

        public Login()
        {
            
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            numError = 0;
            //I added an event when user click enter(return) this event should be triggerd instead of clicking on Login button
            password.PreviewKeyDown += EnterClicked;
            userName.PreviewKeyDown += EnterClicked;
        }

        //User clicked on Login button
        private void LogIn(object sender, RoutedEventArgs e)
        {
            //Check first about data.
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
        
        //When user clicks enter either when he/she is in username or password field
        void EnterClicked(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                checkUserNamePass();
            }
        }
        //Check for user name or password
        //After checking it will direct him to prober window with prober access
        //unless jop title is not specified.
        private void checkUserNamePass()
        {

           
            try
            {
                if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.NONE)
                {
                    ifNum0PrintFOrS("User name or password is wrong", "But you swore! User name or password is still wrong");
                    MediaPlayer mplayer = new MediaPlayer();
                    mplayer.Open(new Uri(@"../../SoundEffects/sad.mp3", UriKind.Relative));
                    mplayer.Play();

                }
                if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.MNGR)
                {
                    MediaPlayer mplayer = new MediaPlayer();
                    mplayer.Open(new Uri(@"../../SoundEffects/done.mp3", UriKind.Relative));
                    mplayer.Play();
                    new Manager.ManagerOptoins(userName.Text, password.Password).Show();
                    this.Close();
                }
                if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.SPRVSR)
                {
                    MediaPlayer mplayer = new MediaPlayer();
                    mplayer.Open(new Uri(@"../../SoundEffects/done.mp3", UriKind.Relative));
                    mplayer.Play();
                    new supervisor.supervisor(userName.Text, password.Password).Show();
                    this.Close();
                }
                if (appLayer.IsUserNamePassExist(userName.Text, password.Password) == DEFs.JOP_TITLES.WRKR)
                {
                    MediaPlayer mplayer = new MediaPlayer();
                    mplayer.Open(new Uri(@"../../SoundEffects/done.mp3", UriKind.Relative));
                    mplayer.Play();
                    new Worker.worker(userName.Text, password.Password).Show();
                    this.Close();
                }
            }
            catch (Exceptions.JopTitleNotFound e)
            {
                MessageBox.Show("Actually user name and password exist in our database, but there is no jop title; we can't direct you to prober window. \n please contact you supervisor or manager","Fatal Error",MessageBoxButton.OKCancel,MessageBoxImage.Error);
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
