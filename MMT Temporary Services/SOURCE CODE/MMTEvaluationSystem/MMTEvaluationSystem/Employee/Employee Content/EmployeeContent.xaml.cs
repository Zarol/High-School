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
    /// Interaction logic for EmployeeContent.xaml
    /// </summary>
    public partial class EmployeeContent : UserControl
    {
        public int EmployeeNumber { get; private set; }

        EmployeeItem RootEmployeeItem;
        public InformationContent InformationContent { get; private set; }
        public EmployeeEvaluationAdd AddEmployeeEvaluation;
        public EmployeeEvaluationManager EmployeeEvaluationManager { get; private set; }
        public EmployeeEvaluationOverall EmployeeEvaluationOverall { get; private set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="EmployeeItem"></param>
        public EmployeeContent(EmployeeItem EmployeeItem)
        {
            InitializeComponent();
            RootEmployeeItem = EmployeeItem;
            InformationContent = new InformationContent(RootEmployeeItem.EmployeeInformation);
            EmployeeEvaluationManager = new EmployeeEvaluationManager(this,RootEmployeeItem.EmployeeInformation.EmployeeNumber, RootEmployeeItem.EmployeeEvaluationData);
            AddEmployeeEvaluation = new EmployeeEvaluationAdd(this);
            EmployeeEvaluationOverall = new EmployeeEvaluationOverall(RootEmployeeItem.EmployeeInformation, this);
            EmployeeNumber = InformationContent.EmployeeInformation.EmployeeNumber;
            stackRoot.Children.Add(InformationContent);
        }

        /// <summary>
        /// Switches this control's current content
        /// </summary>
        /// <param name="Type">The content to switch to (Add, Manager, Overall).</param>
        public void SwitchEvaluationItem(string Type)
        {
            switch (Type)
            {
                case "Add":
                        stackRoot.Children.RemoveAt(1);
                        stackRoot.Children.Add(AddEmployeeEvaluation);
                    break;
                case "Manager":
                    if (EmployeeEvaluationManager.listEvaluationData.Count != 0)
                    {
                        stackRoot.Children.RemoveAt(1);
                        stackRoot.Children.Add(EmployeeEvaluationManager);
                    }
                    break;
                case "Overall":
                    stackRoot.Children.RemoveAt(1);
                    stackRoot.Children.Add(EmployeeEvaluationOverall);
                    break;
                default:
                    break;
            }
        }
    }
}
