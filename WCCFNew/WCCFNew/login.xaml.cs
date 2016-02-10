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
using System.IO;

namespace WCCFNew
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        private string fbAccessToken;
        facebook fbClass = new facebook();
        public login()
        {
            InitializeComponent();
            fbAccessToken = File.ReadAllText(@"C:\Users\hgull\Documents\Visual Studio 2015\Projects\GitHub\WCCFNew\WCCFNew\bin\Debug\AccessTokenStorage\accessToken.txt");
            if (fbAccessToken.Count() == 0)
            {
                fbClass.Login();
            }
        }

        public string getStoredToken
        {
            get
            {
                return fbAccessToken;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainMenu mm = new mainMenu();
            mm.Show();
        }
    }
}
