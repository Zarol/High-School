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
    /// Interaction logic for EmployeeItem.xaml
    /// </summary>
    public partial class EmployeeItem : UserControl
    {
        public EmployeeContent EmployeeContent;
        public EmployeeEvaluationManager EmployeeEvaluationManager;
        public DataEmployeeInformation EmployeeInformation;
        public List<DataEvaluationResult> EmployeeEvaluationData;

        MainPage MainPage;

        /// <summary>
        /// Default Constructor that displays the testing information.
        /// </summary>
        public EmployeeItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor Method
        /// </summary>
        /// <param name="EmployeeInformation">The employee's information.</param>
        /// <param name="EmployeeEvaluationData">The list of evaluations associated with the employee.</param>
        /// <param name="MainPage">The main page.</param>
        public EmployeeItem(DataEmployeeInformation EmployeeInformation, List<DataEvaluationResult> EmployeeEvaluationData, MainPage MainPage)
        {
            InitializeComponent();
            this.EmployeeInformation = EmployeeInformation;            
            this.EmployeeEvaluationData = EmployeeEvaluationData;
            EmployeeContent = new EmployeeContent(this);
            this.MainPage = MainPage;
            txtName.Text = this.EmployeeInformation.FirstName + " " + this.EmployeeInformation.LastName;
            InitializeEvaluations();
        }

        /// <summary>
        /// Helper method designed to initialize the evaluations associated with the employee.
        /// </summary>
        private void InitializeEvaluations()
        {
            if (EmployeeEvaluationData != null && EmployeeEvaluationData.Count != 0 )
            {
                EmployeeContent.stackRoot.Children.Add(EmployeeContent.EmployeeEvaluationManager);
            }
            else
            {
                EmployeeContent.stackRoot.Children.Add(EmployeeContent.AddEmployeeEvaluation);
            }
        }

        /// <summary>
        /// Routed event handler designed to set borderRoot's click event.
        /// </summary>
        /// <param name="Method">The method to be routed for borderRoot.</param>
        public void setItemClickEvent(MouseButtonEventHandler Method)
        {
            borderRoot.MouseLeftButtonUp += Method;
        }

        /// <summary>
        /// Event handler designed to delete this control.
        /// </summary>
        /// <param name="sender">btnDelete</param>
        /// <param name="e">Click</param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<DataEvaluationResult> DeletingEvals = DataController.GetEvaluations(EmployeeInformation.EmployeeNumber);
            foreach (DataEvaluationResult der in DeletingEvals)
                DataController.DeleteEvaluation(der);
            DataFieldPlacement DeletingPlacement = DataController.GetEmployeeFieldPlacement(EmployeeInformation);
            DataController.DeleteFieldPlacement(DeletingPlacement);
            DataController.DeleteEmployee(EmployeeInformation);
            MainPage.gridContent.Children.Clear();
            MainPage.stackPanelItems.Children.Remove(this);
        }
    }
}
