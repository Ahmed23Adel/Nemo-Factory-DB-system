using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for SendAnnounc.xaml
    /// </summary>
    public partial class SendAnnounc : Page
    {
        ManagerOptoins parentInstance;
        DataTable listEmps;
        Database.AppLayer appLayer;
        List<KeyValuePair<int, bool>> chosenPeople;
        string userName, password;
        public SendAnnounc(ManagerOptoins parentInstance,string userName,string password)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            chosenPeople = new List<KeyValuePair<int, bool>>();
            this.userName = userName;
            this.password = password;
            LoadEmps();
        }

        private void sendMsg(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to send this messege?", "Are you sure Nemo?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MediaPlayer mplayer = new MediaPlayer();
                mplayer.Open(new Uri(@"../../SoundEffects/sent.mp3", UriKind.Relative));
                mplayer.Play();

                appLayer.InsertMsgToEmps(userName, password, subject.Text.Trim().ToString(), msg.Text.Trim().ToString(), listEmps);
                subject.Text = "";
                msg.Text = "";
                parentInstance.ModShow();
                
            }
        }



        private void Button_Click_to(object sender, RoutedEventArgs e)
        {
            new AnnouceTo(this).Show();
        }

        public void LoadEmps()
        {
            listEmps = appLayer.selectAllEmpsForSending();
            listEmps.Columns.Add("Checked", typeof(System.Boolean));
            for (int i = 0; i < listEmps.Rows.Count; i++)
                listEmps.Rows[i]["Checked"] = false;
            
        }
        public DataTable GetAllEmps()
        {
            return listEmps;
        }

        public List<KeyValuePair<int, bool>> getChosenPeople()
        {
            return chosenPeople;
        }
    }
}
