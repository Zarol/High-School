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
    /// Interaction logic for EmployerContent.xaml
    /// </summary>
    public partial class EmployerContent : UserControl
    {
        InformationContent EmployerInformation;
        public FieldPlacementManager FieldPlacementManager;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="EmployerInformation">The employer information.</param>
        public EmployerContent(DataEmployerInformation EmployerInformation)
        {
            InitializeComponent();
            this.EmployerInformation = new InformationContent(EmployerInformation);
            this.FieldPlacementManager = new FieldPlacementManager(EmployerInformation);
            initialize();
        }

        /// <summary>
        /// Helper method designed to display this control's content.
        /// </summary>
        private void initialize()
        {
            stackRoot.Children.Add(EmployerInformation);
            stackRoot.Children.Add(FieldPlacementManager);
        }
    }
}
