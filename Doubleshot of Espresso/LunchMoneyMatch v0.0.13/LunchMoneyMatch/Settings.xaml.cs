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
using System.Text.RegularExpressions;

//Necessary Metro Imports
using MahApps.Metro.Actions;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MahApps.Metro.Converters;
using MahApps.Metro.Native;

namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
            //currentAccountEmailLabel.append(userInfo.getEmail());
        }

        private void changePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             * if(oldPasswordPBox.password = userInfo.currentPassword)
             * {
             *   if(newPasswordPBox.password = confirmPasswordPBox.password)
             *   {
             *   userInfo.currentPassword = oldPasswordPBox.password
             *   }
             *   else
             *   {
             *     passwordsDoNotMatchErrorLabel.Visibility = Visible
             *   }
             * }
             * else
             * {
             *   oldPasswordErrorLabel.Visibility = Visible
             * }
             */
        }

        private void changeEmailButton_Click(object sender, RoutedEventArgs e)
        {
            if (newEmailTextBox.Text != "" || confirmEmailTextBox.Text != "")
            {
                if (newEmailTextBox.Text == confirmEmailTextBox.Text)
                {
                    if (isValidEmail(newEmailTextBox.Text))
                    {
                        // Send confirmation e-mail to said e-mail
                        confirmationEmailSentLabel.Visibility = Visibility.Visible;
                        emailsDoNotMatchErrorLabel.Visibility = Visibility.Hidden;
                        newEmailTextBox.Background = Brushes.White;
                        confirmEmailTextBox.Background = Brushes.White;
                    }
                    else
                    {
                        newEmailTextBox.Background = Brushes.Red;
                        confirmEmailTextBox.Background = Brushes.Red;
                        invalidEmailErrorLabel.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    emailsDoNotMatchErrorLabel.Visibility = Visibility.Visible;
                    newEmailTextBox.Background = Brushes.Red;
                    confirmEmailTextBox.Background = Brushes.Red;
                }
            }
        }

        private bool isValidEmail(string email)
        {
            string strTempCheck = email.ToLower();
            string strCheckPatten = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Match match = Regex.Match(strTempCheck.Trim(), strCheckPatten, RegexOptions.IgnoreCase);
            if (match.Success)
                return true;
            else return false;
        }

        private bool isValidPassword(string password)
        {
            string strTempCheck = password;
            const int MIN_PASS_LENGTH = 6;
            const int MAX_PASS_LENGTH = 18;
            bool[] boolRequirements = new bool[4]; //Length, Upper, Lower, Number

            //boolRequirements[0], Length
            if (strTempCheck.Length >= MIN_PASS_LENGTH && strTempCheck.Length <= MAX_PASS_LENGTH)
                boolRequirements[0] = true;
            else
                boolRequirements[0] = false;

            foreach (char c in strTempCheck)
            {
                //boolRequirements[1], Upper
                if (char.IsUpper(c))
                    boolRequirements[1] = true;
                //boolRequirements[2], Lower
                else if (char.IsLower(c))
                    boolRequirements[2] = true;
                //boolRequirements[3], Number
                else if (char.IsNumber(c))
                    boolRequirements[3] = true;
            }

            for (int i = 0; i < boolRequirements.Length; i++)
            {
                if (boolRequirements[i] == false)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
