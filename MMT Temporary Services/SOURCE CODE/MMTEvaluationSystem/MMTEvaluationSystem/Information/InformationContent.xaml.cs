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
    /// Interaction logic for InformationItem.xaml
    /// </summary>
    public partial class InformationContent : UserControl
    {
        InformationButtons InformationButtons;
        InformationDisplay InformationDisplay;
        InformationEdit InformationEdit;
        public DataEmployeeInformation EmployeeInformation;
        public DataEmployerInformation EmployerInformation;
        string SelectedType;

        /// <summary>
        /// Default Constructor that displays the testing information.
        /// </summary>
        public InformationContent()
        {
            InitializeComponent();
            InformationButtons = new InformationButtons();
            InformationButtons.setAllButtonClickEvents(btnEdit_Click, btnOkay_Click, btnCancel_Click);
            InformationDisplay = new InformationDisplay();
            InformationEdit = new InformationEdit();
            stackPanelRoot.Children.Add(InformationDisplay);
            stackPanelRoot.Children.Add(InformationButtons);
        }

        /// <summary>
        /// Overloaded Constructor 
        /// </summary>
        /// <param name="EmployeeInformation">The employee's information.</param>
        public InformationContent(DataEmployeeInformation EmployeeInformation)
        {
            InitializeComponent(); 
            this.EmployeeInformation = EmployeeInformation;
            SelectedType = "Employee";
            Initialize();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="EmployerInformation">The employer's information.</param>
        public InformationContent(DataEmployerInformation EmployerInformation)
        {
            InitializeComponent();
            this.EmployerInformation = EmployerInformation;
            SelectedType = "Employer";
            Initialize();
        }

        /// <summary>
        /// Helper method designed to initialize this control's variables.
        /// </summary>
        private void Initialize()
        {
            InformationButtons = new InformationButtons();
            InformationButtons.setAllButtonClickEvents(btnEdit_Click, btnOkay_Click, btnCancel_Click);
            switch (SelectedType)
            {
                case "Employee":
                    txtName.Text = EmployeeInformation.FirstName + " " + EmployeeInformation.LastName;
                    txtUniqueNumber.Text = DataController.FormatUniqueNumber(EmployeeInformation.EmployeeNumber.ToString());
                    InformationDisplay = new InformationDisplay(EmployeeInformation.Email, EmployeeInformation.Phone, EmployeeInformation.Cell, EmployeeInformation.Street, EmployeeInformation.City, EmployeeInformation.State, EmployeeInformation.Zip);
                    InformationEdit = new InformationEdit(EmployeeInformation.Email, EmployeeInformation.Phone, EmployeeInformation.Cell, EmployeeInformation.Street, EmployeeInformation.City, EmployeeInformation.State, EmployeeInformation.Zip);
                    break;
                case "Employer":
                    txtName.Text = EmployerInformation.Name;
                    txtUniqueNumber.Text =  DataController.FormatUniqueNumber(EmployerInformation.EmployerNumber.ToString());
                    InformationDisplay = new InformationDisplay(EmployerInformation);
                    InformationEdit = new InformationEdit(EmployerInformation);
                    break;
                default:
                    InformationDisplay = new InformationDisplay(EmployerInformation.Email, EmployerInformation.Phone, "N/A", EmployerInformation.Street, EmployerInformation.City, EmployerInformation.State, EmployerInformation.Zip);
                    InformationEdit = new InformationEdit(EmployerInformation.Email, EmployerInformation.Phone, "N/A", EmployerInformation.Street, EmployerInformation.City, EmployerInformation.State, EmployerInformation.Zip);
                    break;
            }

            stackPanelRoot.Children.Add(InformationDisplay);
            stackPanelRoot.Children.Add(InformationButtons);
        }

        /// <summary>
        /// Designed to add other controls into this control's stack panel.
        /// </summary>
        /// <param name="sender">The UIElement to add to this control's stack panel.</param>
        public void AddItem(object sender)
        {
            stackPanelRoot.Children.Add((UIElement)sender);
        }

        /// <summary>
        /// Event handler designed to switch to the information edit control.
        /// </summary>
        /// <param name="sender">btnEdit</param>
        /// <param name="e">Click</param>
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
                stackPanelRoot.Children.RemoveAt(3);
                stackPanelRoot.Children.Insert(3, InformationEdit);
                ((Button)sender).Visibility = Visibility.Hidden;
                InformationButtons.btnOkay.Visibility = Visibility.Visible;
                InformationButtons.btnCancel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Event handler designed to apply the changes of any edits made to the information.
        /// </summary>
        /// <param name="sender">btnOkay</param>
        /// <param name="e">Click</param>
        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            if (InformationEdit.informationValid())
            {
                switch (SelectedType)
                {
                    case "Employee":
                        List<object> editedEmployee = InformationEdit.getAllInformation();
                        EmployeeInformation.Email = (string)editedEmployee[0];
                        EmployeeInformation.Phone = (string)editedEmployee[1];
                        EmployeeInformation.Cell = (string)editedEmployee[2];
                        EmployeeInformation.Street = (string)editedEmployee[3];
                        EmployeeInformation.City = (string)editedEmployee[4];
                        EmployeeInformation.State = (string)editedEmployee[5];
                        EmployeeInformation.Zip = (int)editedEmployee[6];
                        InformationDisplay.setAllInfo(EmployeeInformation.Email, EmployeeInformation.Phone, EmployeeInformation.Cell, EmployeeInformation.Street, EmployeeInformation.City, EmployeeInformation.State, EmployeeInformation.Zip);
                        DataController.EditEmployee(EmployeeInformation);
                        break;
                    case "Employer":
                        List<object> editedEmployer = InformationEdit.getAllInformation();
                        EmployerInformation.Street = (string)editedEmployer[0];
                        EmployerInformation.City = (string)editedEmployer[1];
                        EmployerInformation.State = (string)editedEmployer[2];
                        EmployerInformation.Zip = (int)editedEmployer[3];
                        EmployerInformation.Phone = (string)editedEmployer[4];
                        EmployerInformation.Email = (string)editedEmployer[5];
                        EmployerInformation.Contact = (string)editedEmployer[6];
                        InformationDisplay.setAllInfo(EmployerInformation.Email, EmployerInformation.Phone, EmployerInformation.Contact, EmployerInformation.Street, EmployerInformation.City, EmployerInformation.State, EmployerInformation.Zip);
                        DataController.EditEmployer(EmployerInformation);
                        break;
                    default:
                        break;
                }
                stackPanelRoot.Children.RemoveAt(3);
                stackPanelRoot.Children.Insert(3, InformationDisplay);
                InformationButtons.btnEdit.Visibility = Visibility.Visible;
                ((Button)sender).Visibility = Visibility.Hidden;
                InformationButtons.btnCancel.Visibility = Visibility.Hidden;
            }
            else
            {
                //INFORMATION INVALID
            }
        }

        /// <summary>
        /// Designed to switch back to the information display control and dispose of any edits.
        /// </summary>
        /// <param name="sender">btnCancel</param>
        /// <param name="e">Click</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            stackPanelRoot.Children.RemoveAt(3);
            stackPanelRoot.Children.Insert(3, InformationDisplay);
            InformationButtons.btnEdit.Visibility = Visibility.Visible;
            InformationButtons.btnOkay.Visibility = Visibility.Hidden;
            ((Button)sender).Visibility = Visibility.Hidden;
            InformationEdit.setFields();
        }
    }
}
