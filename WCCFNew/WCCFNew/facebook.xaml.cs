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

namespace WCCFNew
{
    /// <summary>
    /// Interaction logic for facebook.xaml
    /// </summary>
    public partial class facebook : Window
    {
        public facebook()
        {
            InitializeComponent();
        }

        private void btnClearFB_Click(object sender, RoutedEventArgs e)
        {
            txtMessageFB.Clear(); //  hello world
        }
    }
}
