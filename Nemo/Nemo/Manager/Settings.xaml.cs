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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        ManagerOptoins paretnInstance;
        public Settings(ManagerOptoins paretnInstanc)
        {
            InitializeComponent();
            this.paretnInstance = paretnInstanc;
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
            paretnInstance.Close();
            
        }
        
        

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            paretnInstance.Show();
        }
    }
}
