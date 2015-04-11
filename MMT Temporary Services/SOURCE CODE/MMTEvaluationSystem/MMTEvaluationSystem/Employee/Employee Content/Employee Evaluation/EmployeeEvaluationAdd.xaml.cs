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
using System.Globalization;

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Interaction logic for EmployeeEvaluationAdd.xaml
    /// </summary>
    public partial class EmployeeEvaluationAdd : UserControl
    {
        EmployeeContent RootEmployeeContent;
        string EmployerName;
        DateTime Date;
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="EmployeeContent">The employee content.</param>
        public EmployeeEvaluationAdd(EmployeeContent EmployeeContent)
        {
            InitializeComponent();
            RootEmployeeContent = EmployeeContent;
        }

        /// <summary>
        /// Event handler designed to reload this control's information.
        /// </summary>
        /// <param name="sender">UserControl</param>
        /// <param name="e">Loaded</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            txtBoxDate.Background = DataController.MMT_BACKGROUND_GRAY;
            txtBoxDate.Text = "";
            EmployerName = "";
            comboEmployer.Items.Clear();
            List<DataEmployerInformation> AllEmployers = DataController.GetAllEmployers();
            foreach (DataEmployerInformation DEI in AllEmployers)
            {
                comboEmployer.Items.Add(DEI.Name);
            }
        }

        /// <summary>
        /// Event handler designed to validate a date.
        /// </summary>
        /// <param name="sender">txtBoxDate</param>
        /// <param name="e">LostFocus</param>
        private void txtBoxDate_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isValidDate = DateTime.TryParseExact(((TextBox)sender).Text,"MM/dd/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out Date);
            if (isValidDate == false)
            {
                ((TextBox)sender).Background = Brushes.Red;
            }
            else
            {
                ((TextBox)sender).Background = DataController.MMT_BACKGROUND_GRAY;
            }
        }

        /// <summary>
        /// Helper method designed to determine if the information is valid.
        /// </summary>
        /// <returns>True if valid, false if invalid.</returns>
        private bool InformationValid()
        {
            if (txtBoxDate.Background == Brushes.Red || comboEmployer.SelectedIndex == -1 || EmployerName == "")
            {
                txtBoxDate_LostFocus(txtBoxDate, null);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Event handler designed to return to the Evaluation Manager.
        /// </summary>
        /// <param name="sender">btnCancel</param>
        /// <param name="e">Click</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            RootEmployeeContent.SwitchEvaluationItem("Manager");
        }

        /// <summary>
        /// Event handler designed to create an employee.
        /// </summary>
        /// <param name="sender">btnOkay</param>
        /// <param name="e">Click</param>
        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            if (InformationValid() == true)
            {
                int EmployeeNumber = RootEmployeeContent.EmployeeNumber;
                int EmployerNumber = DataController.GetEmployer(EmployerName).EmployerNumber;
                RootEmployeeContent.EmployeeEvaluationManager.AddEvaluationResult(new DataEvaluationResult(DataController.GetEvaluationKeys(),EmployeeNumber, EmployerNumber, Date));            
                RootEmployeeContent.SwitchEvaluationItem("Manager");
            }

        }

        /// <summary>
        /// Event handler designed to change the selected employer value.
        /// </summary>
        /// <param name="sender">comboEmployer</param>
        /// <param name="e">SelectionChanged</param>
        private void comboEmployer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
                EmployerName = ((ComboBox)sender).SelectedItem.ToString();
        }

    }
}
