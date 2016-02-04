﻿using System;
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
using Facebook;

namespace WCCFNew
{
    /// <summary>
    /// Interaction logic for facebook.xaml
    /// </summary>
    public partial class facebook : Window
    {
        private const string AppId = "145634995501895"; // FB given app id - Found on Dev Site.
        private const string ExtendedPermissions = "publish_actions"; // Permissions granted to the user
        private string _accessToken; // needed to carry out any tasks
        private bool postSuccess; // True / False for successful post
        //private string postDirection; // Decides where to post the status to
        List<string> postDirectionList = new List<string>(); // List of post directions

        public facebook()
        {
            InitializeComponent();
        }

        private void btnClearFB_Click(object sender, RoutedEventArgs e)
        {
            txtMessageFB.Clear();
        }

        private void DisplayAppropriateMessage(FacebookOAuthResult facebookOAuthResult)
        {
            // If OAuth Doesnt return Null
            if (facebookOAuthResult != null)
            {
                // If OAuth Authentication was successful
                if (facebookOAuthResult.IsSuccess)
                {
                    // Instatiates the AccessToken Variable and creates a FB Client Object
                    _accessToken = facebookOAuthResult.AccessToken;
                    var fb = new FacebookClient(facebookOAuthResult.AccessToken);

                    // Gets the users name through a query on the Graph API
                    dynamic result = fb.Get("/me");
                    var name = result.name;

                    // Welcomes the user after a successful login
                    MessageBox.Show("Success. Hello " + name);
                    btnLogoutFB.IsEnabled = true;
                    btnLoginFB.IsEnabled = false;
                    txtMessageFB.IsEnabled = true;
                    btnClearFB.IsEnabled = true;
                    btnSubmitFB.IsEnabled = true;
                    cbGroup.IsEnabled = true;
                    cbWall.IsEnabled = true;
                    cbPage.IsEnabled = true;
                }
                else
                {
                    // If OAuth fails, a message box will return a short error description.
                    MessageBox.Show(facebookOAuthResult.ErrorDescription);
                }
            }
        }

        // Makes a status post
        private void StatusPost()
        {
            try
            {
                //if (cbGroup.IsChecked == true)
                //{
                //    postDirection = "1514789935483590/feed";
                //}
                //else if (cbWall.IsChecked == true)
                //{
                //    postDirection = "me/feed";
                //}
                //else if (cbPage.IsChecked == true)
                //{
                //    postDirection = "1724637344489496/feed";
                //}
                //else
                //{
                //    postDirection = null;
                //}

                var fb = new FacebookClient(_accessToken);
                dynamic result;

                if (cbGroup.IsChecked == true)
                {
                    postDirectionList.Add("1514789935483590/feed");
                }
                if (cbWall.IsChecked == true)
                {
                    postDirectionList.Add("me/feed");
                }
                if (cbPage.IsChecked == true)
                {
                    postDirectionList.Add("1724637344489496/feed");
                }
                if (cbGroup.IsChecked == false && cbPage.IsChecked == false && cbWall.IsChecked == false)
                {
                    postDirectionList.Add(null);
                }

                foreach (string item in postDirectionList)
                {
                    result = fb.Post(item, new // Change the group id here!!!
                    {
                        message = txtMessageFB.Text
                    });
                }

                postSuccess = true;
            }
            catch (Exception)
            {
                postSuccess = false;
            }

            //try
            //{
            //    var fb = new FacebookClient(_accessToken);
            //    dynamic result = fb.Post(postDirection, new // Change the group id here!!!
            //    {
            //        message = txtMessageFB.Text
            //    });

            //    postSuccess = true;
            //}
            //catch (Exception)
            //{
            //    postSuccess = false;
            //}
        }

        // Submits the status post
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            StatusPost();
            if (postSuccess == true)
            {
                MessageBox.Show("Success! The message was successfully posted!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (postSuccess == false)
            {
                MessageBox.Show("Error, Please make sure at least one option is checked.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            postDirectionList.Clear();
        }

        // Logs the user into their Facebook account
        private void btnFBLogin_Click(object sender, RoutedEventArgs e)
        {
            var fbLoginDialog = new FacebookLoginDialog(AppId, ExtendedPermissions); // Creates the Facebook login dialog
            fbLoginDialog.ShowDialog(); // Shows the login form

            DisplayAppropriateMessage(fbLoginDialog.facebookOAuthResult); // DisplaysAppropriateMessage for the OAuth Result
        }

        // Logs the user out of their account
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var webBrowser = new WebBrowser(); // Creates web browser object
                var fb = new FacebookClient(); // Creates a Facebook Client object
                var logoutUrl = fb.GetLogoutUrl(new { access_token = _accessToken, next = "https://www.facebook.com/connect/login_success.html" });
                webBrowser.Navigate(logoutUrl);
                MessageBox.Show("Logged out", "Logged Out", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Error! Could not log you out at this time. Please try again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            btnLogoutFB.IsEnabled = false;
            btnLoginFB.IsEnabled = true;
            txtMessageFB.IsEnabled = false;
            btnClearFB.IsEnabled = false;
            btnSubmitFB.IsEnabled = false;
            cbGroup.IsEnabled = false;
            cbWall.IsEnabled = false;
            cbPage.IsEnabled = false;
        }
    }
}
