using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;

//Necessary Metro Imports
using MahApps.Metro.Actions;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MahApps.Metro.Converters;
using MahApps.Metro.Native;

using LunchMoneyMatch.Server;

namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        ServerControl sc = null;

        public Login(ServerControl sc)
        {
            InitializeComponent();
            this.sc = sc;
        }

        /// <summary>
        /// Triggers when the Remember E-Mail button is clicked.
        /// TODO: This method is designed set the property to remember the E-Mail on start up.
        /// </summary>
        /// <param name="sender">An on/off button that will determine the property status.</param>
        /// <param name="e">The Click Event.</param>
        private void toggleBtnRemember_Click(object sender, RoutedEventArgs e)
        {
            if (toggleBtnRemember.IsChecked == true)
                brushRememberEmail.Visual = (Canvas)this.FindResource("appbar_check");
            else
                brushRememberEmail.Visual = (Canvas)this.FindResource("appbar_close");
        }

        /// <summary>
        /// This method will set the current page to the user navigation page when it is correctly matched with information from the server.
        /// TODO: Match info w/ server & transition to next page if correct
        /// TODO: Alert user if mismatch
        /// </summary>
        /// <param name="sender">The Login button.</param>
        /// <param name="e">The Click Event.</param>
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((txtEmail.Text == "" && txtPassword.Password == ""))
            {
                NavigationService.Navigate(new Navigation(sc));
            }
            else
            {
                if (sc.CanConnect())
                {
                    if (sc.LogIn(txtEmail.Text, txtPassword.Password) != null)
                    {
                        NavigationService.Navigate(new Navigation(sc));
                    }
                }
            }
        }

        /// <summary>
        /// This method will set the current page to the sign up page.
        /// </summary>
        /// <param name="sender">The Sign Up button.</param>
        /// <param name="e">The Click Event.</param>
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp(this, sc));
        }

        /// <summary>
        /// This method will set the current page to the forgot password page.
        /// TODO: Close the current page & Show the sign up page
        /// </summary>
        /// <param name="sender">The Forgot Password button.</param>
        /// <param name="e">The Click Event.</param>
        private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.RemoveBackEntry();
        }
        public void setEmailAndPassword(string email, string password)
        {
            txtEmail.Text = email;
            txtPassword.Password = password;
        }
    }
}
