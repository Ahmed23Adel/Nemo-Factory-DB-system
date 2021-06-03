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
    /// Interaction logic for AddMachine.xaml
    /// </summary>
    public partial class AddMachine : Window
    {
        Database.AppLayer appLayer;
        ManagerOptoins parentInstance;
        public AddMachine(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
        }

        private void InsertMachineClicked(object sender, RoutedEventArgs e)
        {
            if (isDataValid())
            {
                InsertNewMahice();
                this.Close();
                parentInstance.ModShow();

            }

        }


        private void Cancel(object sender, RoutedEventArgs e)
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(@"../../SoundEffects/click.mp3", UriKind.Relative));
            mplayer.Play();
            this.Close();
            parentInstance.Show();
        }

        public bool isDataValid()
        {
            return true;
        }

        public void InsertNewMahice()
        {
            MediaPlayer mplayer = new MediaPlayer();
            mplayer.Open(new Uri(@"../../SoundEffects/sent.mp3", UriKind.Relative));
            mplayer.Play();
            appLayer.InsertMachine(name.Text, startDate.Text);

        }
    }
}
