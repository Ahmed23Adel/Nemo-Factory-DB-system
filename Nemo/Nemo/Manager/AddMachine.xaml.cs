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
                MakeSound.MakeSent();
                InsertNewMahice();
                this.Close();
                parentInstance.ModShow();

            }

        }


        private void Cancel(object sender, RoutedEventArgs e)
        {

            MakeSound.MakeClick();
            this.Close();
            parentInstance.Show();
        }

        public bool isDataValid()
        {
            return true;
        }

        public void InsertNewMahice()
        {
            appLayer.InsertMachine(name.Text.Trim(), startDate.Text.Trim()) ;

        }
    }
}
