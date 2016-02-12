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
using System.Web;
using System.IO;

namespace WCCFNew
{
    /// <summary>
    /// Interaction logic for SettingsPG.xaml
    /// </summary>
    public partial class SettingsPG : Page
    {
        Uri myUri;
        string temp, finalID;
        string[] groupID;

        public SettingsPG()
        {
            InitializeComponent();
        }

        // Sets the given url as the posting group (by parsing for group ID)
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                myUri = new Uri(txtFBGroupUrl.Text);
                temp = myUri.ToString();
                temp = temp.Substring(32);
                groupID = temp.Split('/');
                finalID = groupID[0];
                File.WriteAllText(@"FacebookID's\groupID.txt", finalID);
                MessageBox.Show("Facebook Group Set! Settings Applied", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                groupID = null;
            }
            catch (UriFormatException)
            {
                MessageBox.Show("Error, please make sure to enter a valid URL", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("An unexpected error has occured", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Clears the group url link box
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtFBGroupUrl.Clear();
        }
    }
}
