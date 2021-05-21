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

namespace Nemo.Utilities
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        string errorMsg;
        string imgUri;
        public CustomMessageBox(string erroMsg,string imgUri = ".. / Images / lazy.ico")
        {
            InitializeComponent();
            this.errorMsg = erroMsg;
            this.imgUri = imgUri;
            messageText.Text = erroMsg;

            //var uriSource = new Uri(@imgUri, UriKind.Relative);
            //errImg.Source = new BitmapImage(uriSource);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
