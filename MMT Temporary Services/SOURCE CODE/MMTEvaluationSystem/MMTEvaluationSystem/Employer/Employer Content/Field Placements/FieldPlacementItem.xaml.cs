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
    /// Interaction logic for FieldPlacementItem.xaml
    /// </summary>
    public partial class FieldPlacementItem : UserControl
    {
        FieldPlacementManager FieldPlacementManager;
        InformationDisplay SelectedEmployeeInformation;
        DataFieldPlacement FieldPlacement;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="FieldPlacementManager">The field placement manager.</param>
        public FieldPlacementItem(FieldPlacementManager FieldPlacementManager)
        {
            InitializeComponent();
            this.FieldPlacementManager = FieldPlacementManager;
            initializeInfoDisplay();
            gridInfoDisplay.Children.Add(SelectedEmployeeInformation);
        }

        /// <summary>
        /// Constructor for employers with pre-existing field placements.
        /// </summary>
        /// <param name="FieldPlacementManager">The field placement manager.</param>
        /// <param name="FieldPlacement">The field placements associated with this employer.</param>
        public FieldPlacementItem(FieldPlacementManager FieldPlacementManager, DataFieldPlacement FieldPlacement)
        {
            InitializeComponent();
            this.FieldPlacementManager = FieldPlacementManager;
            this.FieldPlacement = FieldPlacement;
            initializeInfoDisplay();
            gridInfoDisplay.Children.Add(SelectedEmployeeInformation);
        }

        /// <summary>
        /// Initializes the data to be displayed per item.
        /// </summary>
        private void initializeInfoDisplay()
        {
            if (FieldPlacement == null)
                SelectedEmployeeInformation = new InformationDisplay();
            else
            {
                DataEmployeeInformation tempInfo = DataController.GetEmployee(FieldPlacement.EmployeeNumber);
                SelectedEmployeeInformation = new InformationDisplay(tempInfo);
                lblName.Content = tempInfo.FirstName + " " + tempInfo.LastName;
            }
        }

        /// <summary>
        /// Event handler designed to remove this control.
        /// </summary>
        /// <param name="sender">btnDelete</param>
        /// <param name="e">Click</param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            contentControlRoot.Reload();
            DataController.DeleteFieldPlacement(FieldPlacement);
            FieldPlacementManager.stackContent.Children.Remove(this);
        }
    }
}
