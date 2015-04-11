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
    /// Interaction logic for EmployerItem.xaml
    /// </summary>
    public partial class EmployerItem : UserControl
    {
        public DataEmployerInformation EmployerInformation;
        public EmployerContent EmployerContent;
        MainPage MainPage;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="EmployerInformation">The employer's information.</param>
        /// <param name="MainPage">The main page.</param>
        public EmployerItem(DataEmployerInformation EmployerInformation, MainPage MainPage)
        {
            InitializeComponent();
            this.EmployerInformation = EmployerInformation;
            EmployerContent = new EmployerContent(this.EmployerInformation);
            this.MainPage = MainPage;
            txtName.Text = this.EmployerInformation.Name;
        }

        /// <summary>
        /// Routed event handler for this control's click event.
        /// </summary>
        /// <param name="Method">The method to be routed to borderRoot's click event.</param>
        public void setItemClickEvent(MouseButtonEventHandler Method)
        {
            borderRoot.MouseLeftButtonUp += Method;
        }

        /// <summary>
        /// Event handler designed to remove this control completely.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            List<DataFieldPlacement> DeletingPlacements = DataController.GetAllEmployerFieldPlacements(EmployerInformation);
            foreach (DataFieldPlacement dfp in DeletingPlacements)
                DataController.DeleteFieldPlacement(dfp);
            List<DataEvaluationResult> DeletingEvaluations = DataController.GetEvaluations(EmployerInformation);
            foreach (DataEvaluationResult der in DeletingEvaluations)
                DataController.DeleteEvaluation(der);
            DataController.DeleteEmployer(EmployerInformation);
            MainPage.gridContent.Children.Clear();
            MainPage.stackPanelItems.Children.Remove(this);
        }
    }
}
