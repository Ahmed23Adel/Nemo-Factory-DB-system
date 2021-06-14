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
    /// Interaction logic for AddProductionLine.xaml
    /// </summary>
    /// 

    
    public partial class AddProductionLine : Window
    {
        DataTable d;
        Database.AppLayer appLayer;
        int sup;
        ManagerOptoins parentInstance;
        public AddProductionLine(ManagerOptoins parentInstance)
        {
            InitializeComponent();
            appLayer = Database.AppLayer.GetInstance();
            this.parentInstance = parentInstance;
            d = appLayer.getAllSupervisors();
            for (int i = 0; i < d.Rows.Count; i++)
            {
                combo_supervisor.Items.Add(d.Rows[i]["name"] + "  ID:" + d.Rows[i]["id"]);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();

            txt_line.Text = "";
            txt_location.Text = "";
            combo_supervisor.SelectedIndex = -1;
            this.Close();
            parentInstance.Show();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            MakeSound.MakeClick();

            if (combo_supervisor.SelectedIndex <= -1) MessageBox.Show("Please choose a supervisor for the line");
            else
            {

                sup = int.Parse(d.Rows[combo_supervisor.SelectedIndex]["id"].ToString());
                if (appLayer.insertLine(txt_line.Text, txt_location.Text, sup) > 0) //3rd argument of the function
                {
                    MessageBox.Show("Congratulations The line is added Successfully");
                    MakeSound.MakeSent();
                    this.Close();
                    parentInstance.ModShow();

                }
                else MessageBox.Show("Unfortunately line was not added");

            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            MakeSound.MakeClick();
            parentInstance.Show();
        }
       
    }
}
