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

namespace Nemo.Worker
{
    /// <summary>
    /// Interaction logic for worker.xaml
    /// </summary>
    public partial class worker : Window
    {
        Database.AppLayer applayer;
        string username, password;
        public worker(string username, string password)
        {
            InitializeComponent();
            applayer = Database.AppLayer.GetInstance();
            this.username = username;
            this.password = password;
            loadBasicData();

        }

        private void loadBasicData()
        {
            DataTable dt = applayer.GetBasicDataForUserNamePass(username, password);
            this.Title = "Welcome Nemo (" + dt.Rows[0]["Fname"].ToString() + ")";
            
        }

    }
}
