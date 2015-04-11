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

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Interaction logic for InformationDisplay.xaml
    /// </summary>
    public partial class InformationDisplay : UserControl
    {
        bool Employer = false;
        /// <summary>
        /// Default Constructor that displays the testing information.
        /// </summary>
        public InformationDisplay()
        {
            InitializeComponent();
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
        public InformationDisplay(string Email, string Phone, string Cell, string Street, string City, string State, int Zip)
        {
            InitializeComponent();
            setAllInfo(Email, Phone, Cell, Street, City, State, Zip);
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="EmployerInformation">The employer's information.</param>
        public InformationDisplay(DataEmployerInformation EmployerInformation)
        {
            InitializeComponent();
            lblCell.Content = "Contact:";
            Employer = true;
            setAllInfo(EmployerInformation.Email, EmployerInformation.Phone, EmployerInformation.Contact, EmployerInformation.Street, EmployerInformation.City, EmployerInformation.State, EmployerInformation.Zip);
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="EmployeeInformation">The employee's information</param>
        public InformationDisplay(DataEmployeeInformation EmployeeInformation)
        {
            InitializeComponent();
            setAllInfo(EmployeeInformation.Email, EmployeeInformation.Phone, EmployeeInformation.Cell, EmployeeInformation.Street, EmployeeInformation.City, EmployeeInformation.State, EmployeeInformation.Zip);
        }

        /// <summary>
        /// Sets all the information on the display.
        /// </summary>
        /// <param name="Email">The item's e-mail address.</param>
        /// <param name="Phone">The item's 10-digit unformatted phone number.</param>
        /// <param name="Cell">The item's 10-digit unformatted cell phone number.</param>
        /// <param name="Address">The item's formatted address.</param>
        public void setAllInfo(string Email, string Phone, string Cell, string Address)
        {
            setEmail(Email);
            setPhone(Phone);
            setCell(Cell);
            setAddress(Address);
        }

        
        /// <summary>
        /// Sets all the information on the display.
        /// </summary>
        /// <param name="Email">The item's e-mail address.</param>
        /// <param name="Phone">The item's 10-digit unformatted phone number.</param>
        /// <param name="Cell">The item's 10-digit unformatted cell phone number.</param>
        /// <param name="Street">The item's street.</param>
        /// <param name="City">The item's city.</param>
        /// <param name="State">The item's state.</param>
        /// <param name="Zip">The item's zip code.</param>
        public void setAllInfo(string Email, string Phone, string Cell, string Street, string City, string State, int Zip)
        {
            setEmail(Email);
            setPhone(Phone);
            setCell(Cell);
            setAddress(Street, City, State, Zip);
        }

        /// <summary>
        /// Sets the e-mail of the display.
        /// </summary>
        /// <param name="Email">The item's e-mail address.</param>
        public void setEmail(string Email)
        {
            if (Email != "")
                lblEmailInfo.Content = Email;
            else
                lblEmailInfo.Content = "N/A";
        }

        /// <summary>
        /// Sets the phone number of the display.
        /// </summary>
        /// <param name="Phone">The item's 10-digit unformatted phone number.</param>
        public void setPhone(string Phone)
        {
            lblPhoneInfo.Content = formatPhoneNumbers(Phone);
        }

        /// <summary>
        /// Sets the cell phone number of the display.
        /// </summary>
        /// <param name="Cell">The item's 10-digit unformatted cell phone number.</param>
        public void setCell(string Cell)
        {
            if (Employer == false)
                lblCellInfo.Content = formatPhoneNumbers(Cell);
            else
                lblCellInfo.Content = Cell;
        }

        /// <summary>
        /// Sets the address of the display.
        /// </summary>
        /// <param name="Address">The item's formatted address.</param>
        public void setAddress(string Address)
        {
            lblAddressInfo.Content = Address;
        }

        /// <summary>
        /// Sets the address of the display.
        /// </summary>
        /// <param name="Street">The item's street.</param>
        /// <param name="City">The item's city.</param>
        /// <param name="State">The item's state.</param>
        /// <param name="Zip">The item's zip code.</param>
        public void setAddress(string Street, string City, string State, int Zip)
        {
            string Address = string.Format("{0}, {1}, {2}, {3}", Street, City, State, Zip);
            setAddress(Address);
        }

        /// <summary>
        /// Helper method to format a 10-digit phone number.
        /// </summary>
        /// <param name="Number">An unformatted 10-digit phone number.</param>
        /// <returns>The formatted 10-digit phone number.</returns>
        private string formatPhoneNumbers(string Number)
        {
            if (Number != "")
            {
                string areaCode = Number.Substring(0, 3);
                string firstThree = Number.Substring(3, 3);
                string lastThree = Number.Substring(6, 4);
                return string.Format("({0}) {1}-{2}", areaCode, firstThree, lastThree);
            }
            else
            {
                return "N/A";
            }
        }
    }
}
