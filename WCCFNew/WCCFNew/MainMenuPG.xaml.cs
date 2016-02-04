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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WCCFNew
{
    /// <summary>
    /// Interaction logic for MainMenuPG.xaml
    /// </summary>
    public partial class MainMenuPG : Page
    {
        public MainMenuPG()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            QuickPost qp = new QuickPost();
            this.NavigationService.Navigate(qp);
        }
    }
}
