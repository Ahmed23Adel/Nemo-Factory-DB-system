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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for RecievedMsgs.xaml
    /// </summary>
    public partial class RecievedMsgs : Page
    {
        string userName, password;
        Database.AppLayer appLayer;
        public RecievedMsgs(string userName,string password)
        {
            InitializeComponent();
            this.userName = userName;
            this.password = password;
            appLayer = Database.AppLayer.GetInstance();
            LoadData();
        }

        public void Refresh()
        {
            allMsgs.ItemsSource = null;
            LoadData();
        }

        public void LoadData()
        {
            DataTable dt = appLayer.SelectAllRecievedMsgs(userName, password);
            allMsgs.ItemsSource = dt.DefaultView;
        }
    }
}
