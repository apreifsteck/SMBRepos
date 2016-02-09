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

        private void EMailBTN_Click(object sender, RoutedEventArgs e)
        {
            GMailPG gm = new GMailPG();
            this.NavigationService.Navigate(gm);
        }

        private void FBBTN_Click(object sender, RoutedEventArgs e)
        {
            FacebookPG fb = new FacebookPG();
            this.NavigationService.Navigate(fb);
        }

        private void QuickPostBTN_Click(object sender, RoutedEventArgs e)
        {
            QuickPost myqp = new QuickPost();
            this.NavigationService.Navigate(myqp);
        }

        private void TwitterBTN_Click(object sender, RoutedEventArgs e)
        {
            TwitterPG tp = new TwitterPG();
            this.NavigationService.Navigate(tp);
        }
    }
}
