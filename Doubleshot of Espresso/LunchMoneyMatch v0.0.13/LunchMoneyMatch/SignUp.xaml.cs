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
using System.Net.Mail;
//Necessary Metro Imports
using MahApps.Metro.Actions;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MahApps.Metro.Converters;
using MahApps.Metro.Native;
using LunchMoneyMatch.Server;
using System.Threading;

//TODO: Scroll the tab index with the btnNext / btnPrevious clicks (Notice how going all the way to finalize through button clicks doesn't show the tab)
//TODO: Turn Male / Female Symbols into pictures
//TODO: btnSignUp_Click() method [IVICA!]
namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        #region Instance Variables
        #region Account Creation Variables
        string strEmail, strVerifyEmail, strPassword, strVerifyPassword, strFirstName, strLastName, strGender;
        DateTime dateOfBirth, dateAccountCreated;
        int intDate, intMonth, intYear;
        string strIPCreated;
        #endregion
        
        int signupTabAmt;
        bool[] boolMoveForward;
        Login refs;
        ServerControl sc = null;
        #endregion

        /// <summary>
        /// Default Constructor for the page SignUp.
        /// </summary>
        /// <param name="refs">TODO: I don't know what this is.</param>
        public SignUp(Login refs,ServerControl sc)
        {
            InitializeComponent();

            signupTabAmt = tabControlSignUp.Items.Count;
            boolMoveForward = new bool[signupTabAmt]; //0-Email,1-Password,2-Name,3-Gender,4-DOB,5-Terms,6-Final
            boolMoveForward[3] = true;

            #region Initialize Account Creation Variables
            strEmail = "";
            strVerifyEmail = "";
            strPassword = "";
            strVerifyPassword = "";
            strFirstName = "";
            strLastName = "";
            strGender = "Male";
            dateOfBirth = new DateTime();
            intDate = 0;
            intYear = 0;
            intMonth = 0;
            dateAccountCreated = new DateTime();
            strIPCreated = "";
            #endregion

            this.refs = refs;
            this.sc = sc;
        }

        /// <summary>
        /// Triggers when the page is loaded.
        /// Initalizes any control specific variable.
        /// </summary>
        /// <param name="sender">The page (SignUp).</param>
        /// <param name="e">The Loaded event.</param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.RemoveBackEntry();
            initalizeDateOfBirthFields();
            //LoadTermsAndConditions("C:\\Users\\Saharath\\Desktop\\RAWR.txt");
        }

        /// <summary>
        /// Helper method designed to load the date of birth fields such as months, days, and years.
        /// </summary>
        private void initalizeDateOfBirthFields()
        {
            //Initailze the Months Combo Box
            comboBoxMonth.Items.Add("January");
            comboBoxMonth.Items.Add("February");
            comboBoxMonth.Items.Add("March");
            comboBoxMonth.Items.Add("April");
            comboBoxMonth.Items.Add("May");
            comboBoxMonth.Items.Add("June");
            comboBoxMonth.Items.Add("July");
            comboBoxMonth.Items.Add("August");
            comboBoxMonth.Items.Add("September");
            comboBoxMonth.Items.Add("October");
            comboBoxMonth.Items.Add("November");
            comboBoxMonth.Items.Add("December");

            for (int i = 1900; i <= DateTime.Today.Year; i++)  //Initialize the Years Combo Box
                comboBoxYear.Items.Add(i);
        }

        /// <summary>
        /// Designed to load the Terms and Conditions from a file.
        /// </summary>
        /// <param name="fileName">The path of the file to be loaded.</param>
        private void LoadTermsAndConditions(string fileName)
        {
            TextRange range;
            System.IO.FileStream fStream;
            if (System.IO.File.Exists(fileName))
            {
                range = new TextRange(richTxtTermsAndConditions.Document.ContentStart, richTxtTermsAndConditions.Document.ContentEnd);
                fStream = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate);
                range.Load(fStream, System.Windows.DataFormats.Text);
                fStream.Close();
            }
        }

        /// <summary>
        /// Triggers when the Next button is clicked.
        /// Will move the selected page to the next page as long as there is another page and the information of that page has been filled.
        /// </summary>
        /// <param name="sender">The Next button (btnNext).</param>
        /// <param name="e">The Click event.</param>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

            if (tabControlSignUp.SelectedIndex < signupTabAmt && boolMoveForward[tabControlSignUp.SelectedIndex] == true)
            {
                tabControlSignUp.SelectedIndex++;
                FocusManager.SetFocusedElement((DependencyObject)tabControlSignUp.Items.GetItemAt(tabControlSignUp.SelectedIndex), (IInputElement)tabControlSignUp.Items.GetItemAt(tabControlSignUp.SelectedIndex));
            }
        }

        /// <summary>
        /// Triggers when the Previous button is clicked.
        /// Will move the selected page to the previous page as long as there is a previous page.
        /// </summary>
        /// <param name="sender">The Previous button (btnPrevious).</param>
        /// <param name="e">The Click event.</param>
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (tabControlSignUp.SelectedIndex > 0)
            {
                tabControlSignUp.SelectedIndex--;
                FocusManager.SetFocusedElement((DependencyObject)tabControlSignUp.Items.GetItemAt(tabControlSignUp.SelectedIndex), (IInputElement)tabControlSignUp.Items.GetItemAt(tabControlSignUp.SelectedIndex));
            }
        }

        /// <summary>
        /// This method will return the user to a newly created login page.
        /// </summary>
        /// <param name="sender">The Cancel button.</param>
        /// <param name="e">The Click event.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(refs);
        }

        /// <summary>
        /// Triggers when focus is lost on the E-Mail text box.
        /// Checks if the E-Mail used is valid.
        /// </summary>
        /// <param name="sender">The E-Mail text box (txtEmail).</param>
        /// <param name="e">The event handler (LostFocus).</param>
        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            string strTempCheck = txtEmail.Text.ToLower();
            string strCheckPatten = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Match match = Regex.Match(strTempCheck.Trim(), strCheckPatten, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                strEmail = strTempCheck;
                txtEmail.Background = Brushes.White;
            }
            else
            {
                strEmail = "Invalid Email";
                txtEmail.Background = Brushes.Red;
                boolMoveForward[tabControlSignUp.SelectedIndex] = false;
            }
            //CreatFakeUser();
        }
        private void CreatFakeUser()
        {
              txtEmail.Text = "rawr@live.com";
              txtVerifyEmail.Text = "rawr@live.com";
              txtPassword.Password = "Rawr12345";
              txtVerifyPassword.Password = "Rawr12345";
              txtFinalizeEmail.Text = "rawr@live.com";
              txtFirstName.Text = "Test";
              txtLastName.Text = "RTest";
              
        //    String[] signupInformation = new String[8];
        //  //  signupInformation[0] = strEmail;
        //    signupInformation[1] = strPassword;
        //    signupInformation[2] = strFirstName;
        //    signupInformation[3] = strLastName;
        //    signupInformation[4] = strGender;
        //    signupInformation[5] = dateOfBirth.ToShortDateString();
        //    signupInformation[6] = DateTime.Now.ToShortDateString();
        //    signupInformation[7] = ""; //TODO: STORE USER'S IP ADDRESS
        }
        /// <summary>
        /// Triggers when focus is lost on the Verify E-Mail text box.
        /// Checks if the Verify E-Mail matches with the E-Mail.
        /// </summary>
        /// <param name="sender">The Verify E-Mail text box (txtVerifyEmail).</param>
        /// <param name="e">The event handler (LostFocus).</param>
        private void txtVerifyEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            string strTempCheck = txtVerifyEmail.Text.ToLower();

            if (strTempCheck.Equals(strEmail) == true && !strTempCheck.Equals("") && !strTempCheck.Equals("Invalid Email"))
            {
                strVerifyEmail = strTempCheck;
                txtVerifyEmail.Background = Brushes.White;
                btnNext.IsEnabled = true;
                tabPassword.IsEnabled = true;
                boolMoveForward[tabControlSignUp.SelectedIndex] = true;
            }
            else
            {
                strVerifyEmail = "Invalid Verify Email";
                txtVerifyEmail.Background = Brushes.Red;
                boolMoveForward[tabControlSignUp.SelectedIndex] = false;
            }
        }

        /// <summary>
        /// Triggers when focus is lost on the Password text box.
        /// Checks if the Password has the necessary requiresments: Betwen 6-16 characters, upper case, lower case, and one number.
        /// </summary>
        /// <param name="sender">The Password text box (txtPassword).</param>
        /// <param name="e">The event handler (LostFocus).</param>
        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            string strTempCheck = txtPassword.Password;
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
                    strPassword = "Invalid Password";
                    txtPassword.Background = Brushes.Red;
                    boolMoveForward[tabControlSignUp.SelectedIndex] = false;
                    break;
                }
                else if ((i == (boolRequirements.Length - 1)) && (boolRequirements[i] == true))
                {
                    strPassword = strTempCheck;
                    txtPassword.Background = Brushes.White;
                }
            }
        }

        /// <summary>
        /// Triggers when focus is lost on the Verify Password text box.
        /// Checks if the Verify Password matches with the Password.
        /// </summary>
        /// <param name="sender">The Verify Password text box (txtVerifyPassword).</param>
        /// <param name="e">The event handler (LostFocus).</param>
        private void txtVerifyPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            string strTempCheck = txtVerifyPassword.Password;

            if (strTempCheck.Equals(strPassword) == true && !strTempCheck.Equals("") && !strTempCheck.Equals("Invalid Password"))
            {
                strVerifyPassword = strTempCheck;
                txtVerifyPassword.Background = Brushes.White;
                btnNext.IsEnabled = true;
                tabName.IsEnabled = true;
                boolMoveForward[tabControlSignUp.SelectedIndex] = true;
            }
            else
            {
                strVerifyPassword = "Invalid Verify Password";
                txtVerifyPassword.Background = Brushes.Red;
                boolMoveForward[tabControlSignUp.SelectedIndex] = false;
            }
        }

        /// <summary>
        /// Triggers when focus is lost on the First Name text box.
        /// Checks if the First Name is valid.
        /// </summary>
        /// <param name="sender">The First Name text box (txtFirstName).</param>
        /// <param name="e">The event handler (LostFocus).</param>
        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            string strTempCheck = txtFirstName.Text;
            bool boolError = false;

            if (strTempCheck.Length == 0)
                boolError = true;
            else
            {
                foreach (char c in strTempCheck)
                {
                    if (char.IsLetter(c))
                        boolError = false;
                    else if (c.Equals('-'))
                        boolError = false;
                    else if (c.Equals('\''))
                        boolError = false;
                    else if (c.Equals(' '))
                        boolError = false;
                    else
                    {
                        boolError = true;
                        break;
                    }
                }
            }
            if (boolError == false)
            {
                strFirstName = strTempCheck;
                txtFirstName.Background = Brushes.White;
            }
            else
            {
                strFirstName = "Invalid First Name";
                txtFirstName.Background = Brushes.Red;
                boolMoveForward[tabControlSignUp.SelectedIndex] = false;
            }
        }

        /// <summary>
        /// Triggers when focus is lost on the Last Name text box.
        /// Checks if the Last Name is valid.
        /// </summary>
        /// <param name="sender">The Last Name text box (txtLastName).</param>
        /// <param name="e">The event handler (LostFocus).</param>
        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            string strTempCheck = txtLastName.Text;
            bool boolError = false;

            if (strTempCheck.Length == 0)
                boolError = true;
            else
            {
                foreach (char c in strTempCheck)
                {
                    if (char.IsLetter(c))
                        boolError = false;
                    else if (c.Equals('-'))
                        boolError = false;
                    else if (c.Equals('\''))
                        boolError = false;
                    else if (c.Equals(' '))
                        boolError = false;
                    else
                    {
                        boolError = true;
                        break;
                    }
                }
            }
            if (boolError == false)
            {
                strLastName = strTempCheck;
                txtLastName.Background = Brushes.White;
                boolMoveForward[tabControlSignUp.SelectedIndex] = true;
                

            }
            else
            {
                strLastName = "Invalid Last Name";
                txtLastName.Background = Brushes.Red;
                boolMoveForward[tabControlSignUp.SelectedIndex] = false;
            }
        }

        /// <summary>
        /// Triggers when the Gender toggle switch is checked.
        /// Sets the gender to female.
        /// </summary>
        /// <param name="sender">The gender toggle switch (toggleSwitchGender).</param>
        /// <param name="e">The Checked event.</param>
        private void toggleSwitchGender_Checked(object sender, RoutedEventArgs e)
        {
            strGender = "Female";
            borderSelected.Margin = rectFemale.Margin;
            rectMale.Opacity = .5;
            rectFemale.Opacity = 1;
        }

        /// <summary>
        /// Triggers when the Gender toggle switch is unchecked.
        /// Sets the gender to male.
        /// </summary>
        /// <param name="sender">The gender toggle switch (toggleSwitchGender).</param>
        /// <param name="e">The Unchecked event.</param>
        private void toggleSwitchGender_Unchecked(object sender, RoutedEventArgs e)
        {
            strGender = "Male";
            borderSelected.Margin = rectMale.Margin;
            rectMale.Opacity = 1;
            rectFemale.Opacity = .5;
        }

        /// <summary>
        /// Triggers when the month combo box's selection has been changed.
        /// Will set the date of birth month to the selected month and change the days to the amount of days within that box.
        /// </summary>
        /// <param name="sender">The month combo box (comboBoxMonth).</param>
        /// <param name="e">The Selection Changed event.</param>
        private void comboBoxMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int days = 31;
            switch (comboBoxMonth.SelectedIndex)
            {
                case 1:
                    days = 31;
                    break;
                case 2:
                    days = 29;
                    break;
                case 3:
                    days = 31;
                    break;
                case 4:
                    days = 30;
                    break;
                case 5:
                    days = 31;
                    break;
                case 6:
                    days = 30;
                    break;
                case 7:
                    days = 31;
                    break;
                case 8:
                    days = 31;
                    break;
                case 9:
                    days = 30;
                    break;
                case 10:
                    days = 31;
                    break;
                case 11:
                    days = 30;
                    break;
                case 12:
                    days = 31;
                    break;
            }
            int c = comboBoxDate.Items.Count; //32
            for (int i = 0; i < (c - days - 1); i++) // i = 32, i > 29, i--
                comboBoxDate.Items.RemoveAt(days + 1); 
            for (int i = c; i <= days; i++)
                comboBoxDate.Items.Add(i);
            intMonth = comboBoxMonth.SelectedIndex;
            dateOfBirthValidation();
        }

        /// <summary>
        /// Triggers when the date combo box's selection has been changed.
        /// Will set the date of birth date to the selected date.
        /// </summary>
        /// <param name="sender">The date combo box (comboBoxDate).</param>
        /// <param name="e">The Selection Changed event.</param>
        private void comboBoxDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            intDate = comboBoxDate.SelectedIndex;
            dateOfBirthValidation();
        }

        /// <summary>
        /// Triggers when the year combo box's selection has been changed.
        /// Will set the date of birth year to the selected year.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            intYear = comboBoxYear.SelectedIndex;
            dateOfBirthValidation();
        }

        /// <summary>
        /// Designed as a helper method to assign the date of birth only once every field has been given a value.
        /// It will also allow the movement to the next page upon validation.
        /// Must be called after the selection has been changed for date, month, and year boxes.
        /// </summary>
        private void dateOfBirthValidation()
        {
            if (intDate != 0 && intMonth != 0 && intYear != 0)
            {
                dateOfBirth = new DateTime((intYear + 1899), intMonth, intDate);
                boolMoveForward[4] = true;
            }
        }        

        /// <summary>
        /// Triggers when the terms and conditions accept button is checked.
        /// Allows the user to move to the finalization page.
        /// </summary>
        /// <param name="sender">The terms and conditions accept button (btnAccept).</param>
        /// <param name="e">The Checked event.</param>
        private void toggleBtnAccept_Checked(object sender, RoutedEventArgs e)
        {
            boolMoveForward[5] = true;
        }

        /// <summary>
        /// Triggers when the terms and conditions accept button is unchecked.
        /// Forbids the user to move to the finalization page.
        /// </summary>
        /// <param name="sender">The terms and conditions accept button (btnAccept).</param>
        /// <param name="e">The Unchecked Event.</param>
        private void toggleBtnAccept_Unchecked(object sender, RoutedEventArgs e)
        {
            boolMoveForward[5] = false;
        }

        /// <summary>
        /// Triggers when the selected tab is the Finalize tab.
        /// It will display the information provided to be reviewed by the user.
        /// </summary>
        /// <param name="sender">The finalize tab (tabFinalize).</param>
        /// <param name="e">The Got Focus event.</param>
        private void tabFinalize_GotFocus(object sender, RoutedEventArgs e)
        {
            txtFinalizeEmail.Text = "E-Mail: " + strEmail;
            txtFinalizeName.Text = "Name: " + strFirstName + " " + strLastName;
            txtFinalizeGender.Text = "Gender: " + strGender;
            txtFinalizeDateOfBirth.Text = "Date of Birth: " + dateOfBirth.ToShortDateString();
        }  
              
        /// <summary>
        /// TODO:
        /// Triggers when the sign up button is clicked.
        /// This method will pass the aggregated information for an account to be created with the server.
        /// The user will be returned to the login page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (sc.CanConnect())
            {
                String[] info = getSignUpInformation();
                StringBuilder sb = new StringBuilder();
                foreach (String x in info)
                {
                    sb.Append(x + ";");
                }
                sb.Append("EOS;");
                MessageBox.Show(sb.ToString());
                sc.tc.sendMessage("idcreation");
                if (sc.tc.getMessage().Contains("OK"))
                {
                    sc.tc.sendMessage(sb.ToString());
                    if (sc.tc.getMessage().Contains("gg"))
                    {
                        MainWindow.AlertControl.Push("Account Created Successfully!", null, false);
                        refs.setEmailAndPassword(info[0], info[1]);
                        NavigationService.Navigate(refs);
                    }
                }
            }
            else
            {
                MainWindow.AlertControl.Push("Error In Account Creation", null, true);
            }
        }

        /// <summary>
        /// Helper method designed to compile and return the account creation variables as an array of strings.
        /// Index:
        /// E-Mail - 0
        /// Password - 1
        /// First name - 2
        /// Last Name - 3
        /// Gender - 4 (0 = female,1 = male)
        /// Date of Birth - 5
        /// Date of Accoutn Creation - 6
        /// IP Upon Creation - 7
        /// </summary>
        private String[] getSignUpInformation()
        {
            String[] signupInformation = new String[8];
            signupInformation[0] = txtEmail.Text;
            signupInformation[1] = txtVerifyPassword.Password;
            signupInformation[2] = txtFirstName.Text;
            signupInformation[3] = txtLastName.Text;
            signupInformation[4] = (toggleSwitchGender.IsChecked == true ? "1" : "0");
            signupInformation[5] = dateOfBirth.ToShortDateString();
            signupInformation[6] = DateTime.Now.ToShortDateString();
            signupInformation[7] = ""; //TODO: STORE USER'S IP ADDRESS

            return signupInformation;
        }
    }
}
