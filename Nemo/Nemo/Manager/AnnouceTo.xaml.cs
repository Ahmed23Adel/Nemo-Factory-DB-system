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
using System.Windows.Shapes;

namespace Nemo.Manager
{
    /// <summary>
    /// Interaction logic for AnnouceTo.xaml
    /// </summary>
    public partial class AnnouceTo : Window
    {
        SendAnnounc sendAnnounc;
        public AnnouceTo(SendAnnounc sendAnnounc)
        {
            InitializeComponent();
            this.sendAnnounc = sendAnnounc;
            allEmps.CellEditEnding += myDG_CellEditEnding;

            showEmps();
        }
        public void showEmps()
        {
            var x = sendAnnounc.GetAllEmps().DefaultView; ;
            allEmps.ItemsSource = sendAnnounc.GetAllEmps().DefaultView;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
     
            allEmps.CommitEdit();
            allEmps.CancelEdit();
        }


        void myDG_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            
        }

        private void allEmps_MouseDown(object sender, MouseButtonEventArgs e)
        {
            allEmps.CommitEdit();
            allEmps.CancelEdit();
        }

        private void allEmps_MouseLeave(object sender, MouseEventArgs e)
        {
            allEmps.CommitEdit();
            allEmps.CancelEdit();
        }

        private void selectAll(object sender, RoutedEventArgs e)
        {
            DataTable dt = sendAnnounc.GetAllEmps();
            for (int i = 0; i <dt.Rows.Count; i++)
            {
                dt.Rows[i]["Checked"] = true;    
            }
            allEmps.CommitEdit();
            allEmps.CancelEdit();
        }
    }
}
