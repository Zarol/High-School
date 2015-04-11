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
    /// Interaction logic for EmployeeAdd.xaml
    /// </summary>
    public partial class EmployeeAdd : UserControl
    {
        MainPage MainPage;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="MainPage">The service's main page.</param>
        public EmployeeAdd(MainPage MainPage)
        {
            InitializeComponent();
            InformationButtons.btnEdit.Visibility = Visibility.Hidden;
            InformationButtons.btnOkay.Visibility = Visibility.Visible;
            InformationButtons.setOkayClickEvent(btnOkay_Click);
            InformationButtons.btnCancel.Visibility = Visibility.Visible;
            InformationButtons.setCancelClickEvent(btnCancel_Click);
            this.MainPage = MainPage;
        }

        /// <summary>
        /// Checks if the information is valid.
        /// </summary>
        /// <returns>True if valid, false if invalid.</returns>
        private bool InformationValid()
        {
            if (InformationEdit.informationValid() == true && txtBoxFirstName.Text != "" && txtBoxLastName.Text != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a new employee into the database and the service's list.
        /// </summary>
        private void createEmployee()
        {
            List<object> info = new List<object>();
            info.Add(txtBoxFirstName.Text);
            info.Add(txtBoxLastName.Text);
            List<object> baseInfo = InformationEdit.getAllInformation();
            info.AddRange(baseInfo);
            DataEmployeeInformation temp = new DataEmployeeInformation(0, (string)info[0], (string)info[1], (string)info[2], (string)info[3], (string)info[4], (string)info[5], (string)info[6], (string)info[7], (int)info[8]);
            temp.State = DataController.ConvertStateToAbbreviation((string)info[7]);
            DataController.AddEmployee(temp);

            MainPage.addToStack("Employee", new EmployeeItem(DataController.GetEmployee(DataController.GetEmployeeKeys()), null, MainPage));
            MainPage.gridContent.Children.Remove(this);
        }

        /// <summary>
        /// Event handler method for btnOkay.
        /// Creates an employee if the information is valid.
        /// </summary>
        /// <param name="sender">btnOkay</param>
        /// <param name="e">Click</param>
        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            if (InformationValid())
            {
                createEmployee();
            }
            else
            {
                txtBoxFirstName_LostFocus(txtBoxFirstName, null);
                txtBoxLastName_LostFocus(txtBoxLastName, null);
            }
        }

        /// <summary>
        /// Event handler method for btnCancel.
        /// Removes itself from the service.
        /// </summary>
        /// <param name="sender">btnCancel</param>
        /// <param name="e">Click</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainPage.gridContent.Children.Remove(this);
        }

        /// <summary>
        /// Event handler method for txtBoxFirstName.
        /// Checks if the text is a valid name.
        /// </summary>
        /// <param name="sender">txtBoxFirstName</param>
        /// <param name="e">LostFocus</param>
        private void txtBoxFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            const string CHECK_PATTERN = @"^[\p{L}\p{M}' \.\-]+$";
            string firstName = ((TextBox)sender).Text;
            Match match = Regex.Match(firstName.Trim(), CHECK_PATTERN);
            if (match.Success)
            {
                ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
            }
            else
            {
                ((TextBox)sender).Background = Brushes.Red;
            }
        }

        /// <summary>
        /// Event handler method for txtBoxLastName.
        /// Checks if the text is a valid name.
        /// </summary>
        /// <param name="sender">txtBoxLastName</param>
        /// <param name="e">LostFocus</param>
        private void txtBoxLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            const string CHECK_PATTERN = @"^[\p{L}\p{M}' \.\-]+$";
            string lastName = ((TextBox)sender).Text;
            Match match = Regex.Match(lastName.Trim(), CHECK_PATTERN);
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
}
