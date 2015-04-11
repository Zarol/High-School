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

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Interaction logic for InformationEdit.xaml
    /// </summary>
    public partial class InformationEdit : UserControl
    {
        public bool Employer;
        string Email, Phone, Cell, Street, City, State;
        string Contact;
        int Zip;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public InformationEdit()
        {
            InitializeComponent();
            InitializeStates();

            //this.Email = "SaharathKleips@yahoo.com";
            //this.Phone = "";
            //this.Cell = "7024167268";
            //this.Street = "8504 Del Ray Avenue";
            //this.City = "Las Vegas";
            //this.State = "Nevada";
            //this.Zip = 89117;
            //setFields();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="Email">The item's e-mail address.</param>
        /// <param name="Phone">The item's 10-digit unformatted phone number.</param>
        /// <param name="Cell">The item's 10-digit unformatted cell phone number.</param>
        /// <param name="Address">The item's formatted address.</param>
        public InformationEdit(string Email, string Phone, string Cell, string Address)
        {
            InitializeComponent();
            InitializeStates();
            this.Email = Email;
            this.Phone = Phone;
            this.Cell = Cell;
            List<string> address = breakAddress(Address);
            this.Street = address[0];
            this.City = address[1];
            this.State = address[2];
            this.Zip = int.Parse(address[3]);
            setFields();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="Email">The item's e-mail address.</param>
        /// <param name="Phone">The item's 10-digit unformatted phone number.</param>
        /// <param name="Cell">The item's 10-digit unformatted cell phone number.</param>
        /// <param name="Street">The item's street.</param>
        /// <param name="City">The item's city.</param>
        /// <param name="State">The item's state.</param>
        /// <param name="Zip">The item's zip code.</param>
        public InformationEdit(string Email, string Phone, string Cell, string Street, string City, string State, int Zip)
        {
            InitializeComponent();
            InitializeStates();
            this.Email = Email;
            this.Phone = Phone;
            this.Cell = Cell;
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
            setFields();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="EmployerData">The employer's information.</param>
        public InformationEdit(DataEmployerInformation EmployerData)
        {
            InitializeComponent();
            InitializeStates();
            this.Email = EmployerData.Email;
            this.Phone = EmployerData.Phone;
            this.Contact = EmployerData.Contact;
            this.Street = EmployerData.Street;
            this.City = EmployerData.City;
            this.State = EmployerData.State;
            this.Zip = EmployerData.Zip;
            setEmployerEdit();
        }

        /// <summary>
        /// Gets all the information for the item.
        /// </summary>
        /// <returns>The information in a list: (string)email, (string)phone, (string)cell, (string)street, (string)city, (string)state, (int)zip.</returns>
        public List<object> getAllInformation()
        {
            if (Employer == false)
            {
                setAllInformation();
                List<object> information = new List<object>();
                information.Add(Email);
                information.Add(Phone);
                information.Add(Cell);
                information.Add(Street);
                information.Add(City);
                information.Add(State);
                information.Add(Zip);
                return information;
            }
            else
            {
                setAllInformation();
                List<object> information = new List<object>();
                information.Add(Street);
                information.Add(City);
                information.Add(State);
                information.Add(Zip);
                information.Add(Phone);
                information.Add(Email);
                information.Add(Contact);
                return information;
            }
        }

        /// <summary>
        /// Sets the XAML fields to their respective internal variables.
        /// </summary>
        public void setFields()
        {
            if (Employer == false)
            {
                txtEmail.Text = Email;
                txtEmail.Background = DataController.MMT_BACKGROUND_GRAY;
                txtPhone.Text = Phone;
                txtPhone.Background = DataController.MMT_BACKGROUND_GRAY;
                txtCell.Text = Cell;
                txtCell.Background = DataController.MMT_BACKGROUND_GRAY;
                txtStreet.Text = Street;
                txtStreet.Background = DataController.MMT_BACKGROUND_GRAY;
                txtCity.Text = City;
                txtCity.Background = DataController.MMT_BACKGROUND_GRAY;
                comboState.SelectedItem = State;
                txtZip.Text = Zip.ToString();
                txtZip.Background = DataController.MMT_BACKGROUND_GRAY;
            }
            else
            {
                txtEmail.Text = Email;
                txtEmail.Background = DataController.MMT_BACKGROUND_GRAY;
                txtPhone.Text = Phone;
                txtPhone.Background = DataController.MMT_BACKGROUND_GRAY;
                lblCell.Content = "Contact";
                txtCell.Text = Contact;
                txtCell.MaxLength = 70;
                MahApps.Metro.Controls.TextboxHelper.SetWatermark(txtCell, "Jean M. Buckley");
                txtCell.Background = DataController.MMT_BACKGROUND_GRAY;
                txtStreet.Text = Street;
                txtStreet.Background = DataController.MMT_BACKGROUND_GRAY;
                txtCity.Text = City;
                txtCity.Background = DataController.MMT_BACKGROUND_GRAY;
                comboState.SelectedItem = State;
                if (Zip == 0)
                    txtZip.Text = "";
                else
                    txtZip.Text = Zip.ToString();
                txtZip.Background = DataController.MMT_BACKGROUND_GRAY;
            }
        }

        /// <summary>
        /// Checks if the information contained in the control is valid.
        /// Any information that is invalid will be updated to alert the user.
        /// </summary>
        /// <returns>True if valid. False if invalid.</returns>
        public bool informationValid()
        {
                txtEmail_LostFocus(txtEmail, null);
                txtPhone_LostFocus(txtPhone, null);
                txtCell_LostFocus(txtCell, null);
                txtStreet_LostFocus(txtStreet, null);
                txtCity_LostFocus(txtCity, null);
                txtZip_LostFocus(txtZip, null);

            if (txtEmail.Background == Brushes.Red || txtPhone.Background == Brushes.Red || txtCell.Background == Brushes.Red || txtStreet.Background == Brushes.Red || txtCity.Background == Brushes.Red || txtZip.Background == Brushes.Red)
                return false;
            else
                return true;
        }

        public void setEmployerEdit()
        {
            Employer = true;
            setFields();
        }

        /// <summary>
        /// Helper method that sets all of the XAML fields to internal variables.
        /// </summary>
        private void setAllInformation()
        {
            if (Employer == false)
            {
                Email = txtEmail.Text;
                Phone = txtPhone.Text;
                Cell = txtCell.Text;
                Street = txtStreet.Text;
                City = txtCity.Text;
                State = comboState.SelectedItem.ToString();
                Zip = int.Parse(txtZip.Text);
            }
            else
            {
                Email = txtEmail.Text;
                Phone = txtPhone.Text;
                Contact = txtCell.Text;
                Street = txtStreet.Text;
                City = txtCity.Text;
                State = comboState.SelectedItem.ToString();
                Zip = int.Parse(txtZip.Text);
            }
        }

        /// <summary>
        /// Helper method to break an address' components.
        /// </summary>
        /// <param name="Address">The formatted address.</param>
        /// <returns>The list of the address' components: street, city, state, zip</returns>
        private List<string> breakAddress(string Address)
        {
            const string CHECK_PATTERN = @"""[^""\r\n]*""|'[^'\r\n]*'|[^,\r\n]*";
            Regex regex = new Regex(CHECK_PATTERN);    //Will break apart a string by commas
            Match match = regex.Match(Address);
            List<string> address = new List<string>();

            while (match.Success)
            {
                if(match.Value != "")
                    address.Add(match.Value.Trim());
                match = match.NextMatch();
            }

            return address;
        }

        /// <summary>
        /// Initializes the states combo box to the appropriate USA states.
        /// </summary>
        private void InitializeStates()
        {
            comboState.Items.Add("Alabama");
            comboState.Items.Add("Alaska");
            comboState.Items.Add("Arizona");
            comboState.Items.Add("Arkansas");
            comboState.Items.Add("California");
            comboState.Items.Add("Colorado");
            comboState.Items.Add("Connecticut");
            comboState.Items.Add("Delaware");
            comboState.Items.Add("District Of Columbia");
            comboState.Items.Add("Florida");
            comboState.Items.Add("Georgia");
            comboState.Items.Add("Hawaii");
            comboState.Items.Add("Idaho");
            comboState.Items.Add("Illinois");
            comboState.Items.Add("Indiana");
            comboState.Items.Add("Iowa");
            comboState.Items.Add("Kansas");
            comboState.Items.Add("Kentucky");
            comboState.Items.Add("Louisiana");
            comboState.Items.Add("Maine");
            comboState.Items.Add("Maryland");
            comboState.Items.Add("Massachusetts");
            comboState.Items.Add("Michigan");
            comboState.Items.Add("Minnesota");
            comboState.Items.Add("Mississippi");
            comboState.Items.Add("Missouri");
            comboState.Items.Add("Montana");
            comboState.Items.Add("Nebraska");
            comboState.Items.Add("Nevada");
            comboState.Items.Add("New Hampshire");
            comboState.Items.Add("New Jersey");
            comboState.Items.Add("New Mexico");
            comboState.Items.Add("New York");
            comboState.Items.Add("North Carolina");
            comboState.Items.Add("North Dakota");
            comboState.Items.Add("Ohio");
            comboState.Items.Add("Oklahoma");
            comboState.Items.Add("Oregon");
            comboState.Items.Add("Pennsylvania");
            comboState.Items.Add("Rhode Island");
            comboState.Items.Add("South Carolina");
            comboState.Items.Add("South Dakota");
            comboState.Items.Add("Tennessee");
            comboState.Items.Add("Texas");
            comboState.Items.Add("Utah");
            comboState.Items.Add("Vermont");
            comboState.Items.Add("Virginia");
            comboState.Items.Add("Washington");
            comboState.Items.Add("West Virginia");
            comboState.Items.Add("Wisconsin");
            comboState.Items.Add("Wyoming");
            comboState.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles txtEmail's LostFocus event.
        /// Will check if the email is valid.
        /// </summary>
        /// <param name="sender">txtEmail</param>
        /// <param name="e">LostFocus</param>
        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            const string CHECK_PATTERN = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$"; //The regex pattern for emails
            string email = ((TextBox)sender).Text;
            if (email == "")    //Nothing is accepted
                return;
            Match match = Regex.Match(email.Trim(), CHECK_PATTERN, RegexOptions.IgnoreCase);
            if (match.Success)  //Checks if the text box's string is a valid email
            {
                //Success
                ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
            }
            else
            {
                //Fail
                ((TextBox)sender).Background = Brushes.Red;
            }
        }

        /// <summary>
        /// Handles txtPhone's LostFocus event.
        /// Will check if the phone number is valid.
        /// </summary>
        /// <param name="sender">txtPhone</param>
        /// <param name="e">LostFocus</param>
        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            const string CHECK_PATTERN = @"(?<!\d)\d{10}(?!\d)";    //Must be 10 consecutive digits
            string phone = ((TextBox)sender).Text;
            if (phone == "")    //Nothing is accepted
                return;
            Match match = Regex.Match(phone.Trim(), CHECK_PATTERN);
            if (match.Success)  //Checks if the text box's string is a valid phone number
            {
                //SUCCESS
                ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
            }
            else
            {
                //FAILURE
                ((TextBox)sender).Background = Brushes.Red;
            }
        }

        /// <summary>
        /// Handles txtCell's LostFocus event.
        /// </summary>
        /// <param name="sender">txtCell</param>
        /// <param name="e">LostFocus</param>
        private void txtCell_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Employer == false)
            {
                const string CHECK_PATTERN = @"(?<!\d)\d{10}(?!\d)";    //Must be 10 consecutive digits
                string cell = ((TextBox)sender).Text;
                if (cell == "")    //Nothing is accepted
                    return;
                Match match = Regex.Match(cell.Trim(), CHECK_PATTERN);
                if (match.Success)  //Checks if the text box's string is a valid cell phone number
                {
                    //SUCCESS
                    ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
                }
                else
                {
                    //FAILURE
                    ((TextBox)sender).Background = Brushes.Red;
                }
            }
            else
            {
                const string CHECK_PATTERN = @"^[\p{L}\p{M}' \.\-]+$";
                string contact = ((TextBox)sender).Text;
                Match match = Regex.Match(contact.Trim(), CHECK_PATTERN);
                if (match.Success)
                {
                    ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
                }
                else
                {
                    ((TextBox)sender).Background = Brushes.Red;
                }
            }
        }

        /// <summary>
        /// Handles txtStreet's LostFocus event.
        /// NOT YET IMPLEMENTED.
        /// </summary>
        /// <param name="sender">txtStreet</param>
        /// <param name="e">LostFocus</param>
        private void txtStreet_LostFocus(object sender, RoutedEventArgs e)
        {
            string street = ((TextBox)sender).Text;
            if (street == "")
                ((TextBox)sender).Background = Brushes.Red;
            else
                ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
            //How to validate a street address?
        }

        /// <summary>
        /// Handles txtCity's LostFocus event.
        /// NOT YET IMPLEMENTED.
        /// </summary>
        /// <param name="sender">txtCity</param>
        /// <param name="e">LostFocus</param>
        private void txtCity_LostFocus(object sender, RoutedEventArgs e)
        {
            string city = ((TextBox)sender).Text;
            if (city == "")
                ((TextBox)sender).Background = Brushes.Red;
            else
                ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
            //How to validate a city?
        }

        /// <summary>
        /// Handles txtZip's LostFocus event.
        /// </summary>
        /// <param name="sender">txtZip</param>
        /// <param name="e">LostFocus</param>
        private void txtZip_LostFocus(object sender, RoutedEventArgs e)
        {
            const string CHECK_PATTERN = @"(?<!\d)\d{5}(?!\d)";
            string phone = ((TextBox)sender).Text;
            Match match = Regex.Match(phone.Trim(), CHECK_PATTERN);
            if (match.Success)
            {
                //SUCCESS
                ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
            }
            else
            {
                //FAILURE
                ((TextBox)sender).Background = Brushes.Red;
            }
        }
    }
}
