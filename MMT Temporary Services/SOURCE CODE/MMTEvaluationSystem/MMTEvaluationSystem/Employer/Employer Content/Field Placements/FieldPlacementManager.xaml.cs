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
    /// Interaction logic for FieldPlacementManager.xaml
    /// </summary>
    public partial class FieldPlacementManager : UserControl
    {
        public DataEmployerInformation EmployerInformation;

        List<DataEmployeeInformation> AllEmployees;
        List<DataEmployeeInformation> CanSelectEmployees;
        List<DataFieldPlacement> AllFieldPlacements;
        List<DataFieldPlacement> FieldPlacements;
        List<FieldPlacementItem> FieldPlacementItems;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="EmployerInformation">The employer's information.</param>
        public FieldPlacementManager(DataEmployerInformation EmployerInformation)
        {
            InitializeComponent();
            this.EmployerInformation = EmployerInformation;
            AllEmployees = DataController.GetAllEmployees();
            CanSelectEmployees = new List<DataEmployeeInformation>();
            AllFieldPlacements = DataController.GetAllFieldPlacements();
            FieldPlacements = DataController.GetAllEmployerFieldPlacements(this.EmployerInformation);
            FieldPlacementItems = new List<FieldPlacementItem>();
            btnRefresh_Click(null, null);
            initializeFieldPlacementItems();
        }

        /// <summary>
        /// Initializes the field placement items for this manager.
        /// </summary>
        private void initializeFieldPlacementItems()
        {
            foreach (DataFieldPlacement dfp in FieldPlacements)
            {
                FieldPlacementItems.Add(new FieldPlacementItem(this, dfp));
            }
            foreach (FieldPlacementItem fpi in FieldPlacementItems)
            {
                stackContent.Children.Add(fpi);
            }
        }

        /// <summary>
        /// Adds field placements to this manager and to the database.
        /// </summary>
        /// <param name="FieldPlacement">The field placement to be added.</param>
        public void AddFieldPlacement(DataFieldPlacement FieldPlacement)
        {
            DataController.AddFieldPlacement(FieldPlacement);
            AllEmployees = DataController.GetAllEmployees();
            AllFieldPlacements = DataController.GetAllFieldPlacements();
            FieldPlacements = DataController.GetAllEmployerFieldPlacements(this.EmployerInformation);
        }

        /// <summary>
        /// Getter method for all employees not already placed within another employer.
        /// </summary>
        /// <returns>The list of all available employees.</returns>
        public List<DataEmployeeInformation> GetSelectableEmployees()
        {
            CanSelectEmployees.Clear();
            AllEmployees = DataController.GetAllEmployees();
            AllFieldPlacements = DataController.GetAllFieldPlacements();
            foreach (DataEmployeeInformation dei in AllEmployees)
            {
                bool canAdd = true;
                foreach (DataFieldPlacement dfp in AllFieldPlacements)
                {
                    if (dei.EmployeeNumber == dfp.EmployeeNumber)
                        canAdd = false;
                }
                if (canAdd == true)
                    CanSelectEmployees.Add(dei);
            }
            return CanSelectEmployees;
        }

        /// <summary>
        /// Event handler designed to add employees to the manager.
        /// </summary>
        /// <param name="sender">comboEmployees</param>
        /// <param name="e">SelectionChanged</param>
        private void comboEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedValue != null && ((ComboBox)sender).SelectedValue.ToString() != "")
            {
                string selectedString = ((ComboBox)sender).SelectedValue.ToString();
                string selectedFormattedNumber = selectedString.Substring(selectedString.IndexOf('#') + 1, 10);
                string unformattedNumber = selectedFormattedNumber.Substring(selectedFormattedNumber.IndexOfAny("123456789".ToCharArray()));
                DataFieldPlacement FieldPlacement = new DataFieldPlacement(int.Parse(unformattedNumber), EmployerInformation.EmployerNumber);
                AddFieldPlacement(FieldPlacement);
                FieldPlacementItem fieldItem = new FieldPlacementItem(this, FieldPlacement);
                stackContent.Children.Insert(0, fieldItem);
                btnRefresh_Click(null, null);
            }
        }

        /// <summary>
        /// Event handler designed to update the available employees.
        /// </summary>
        /// <param name="sender">btnRefresh</param>
        /// <param name="e">Click</param>
        public void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            comboEmployees.Items.Clear();
            List<DataEmployeeInformation> selectableEmployees = GetSelectableEmployees();
            foreach (DataEmployeeInformation dei in selectableEmployees)
            {
                comboEmployees.Items.Add(string.Format("{0} {1} [{2}]", dei.FirstName, dei.LastName, DataController.FormatUniqueNumber(dei.EmployeeNumber.ToString())));
            }
        }
    }
}
