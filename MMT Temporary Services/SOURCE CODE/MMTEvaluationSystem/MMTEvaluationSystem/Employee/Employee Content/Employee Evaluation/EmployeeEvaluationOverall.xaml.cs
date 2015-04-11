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
    /// Interaction logic for EmployeeOverallEvaluations.xaml
    /// </summary>
    public partial class EmployeeEvaluationOverall : UserControl
    {
        const int EVALUATION_MAX_LENGTH = 256;

        EmployeeContent EmployeeContent;

        double OverallScore;

        DataEmployeeInformation EmployeeData;
        List<DataEvaluationResult> EvaluationData;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="EmployeeData">The employee's data.</param>
        /// <param name="EmployeeContent">The employee content.</param>
        public EmployeeEvaluationOverall(DataEmployeeInformation EmployeeData, EmployeeContent EmployeeContent)
        {
            this.EmployeeData = EmployeeData;
            this.EmployeeContent = EmployeeContent;
            InitializeComponent();
        }

        /// <summary>
        /// Event handler designed to display the remaining characters of a text box.
        /// </summary>
        /// <param name="sender">txtBoxComment</param>
        /// <param name="e">TextChanged</param>
        private void txtBoxComment_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblCommentRemain.Content = "Remaining Characters: " + (EVALUATION_MAX_LENGTH - txtBoxComment.Text.Length);
        }

        /// <summary>
        /// Event handler designed to reload the control's data. 
        /// </summary>
        /// <param name="sender">UserControl</param>
        /// <param name="e">Loaded</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            EvaluationData = DataController.GetEvaluations(EmployeeData.EmployeeNumber);
            DataController.QuickSortEvaluationDate(EvaluationData, 0, EvaluationData.Count - 1);
            initializeData();
            lblOverallScore.Content = "Overall Score: " + OverallScore;
            txtBoxComment.Text = EvaluationData[0].OverallProgressComment;
            chkRecommend.IsChecked = EvaluationData[0].EmployerRecommendation;
        }

        /// <summary>
        /// Helper method designed to initialize the control's data.
        /// </summary>
        private void initializeData()
        {
            stackEvaluations.Children.Clear();
            OverallScore = 0;
            int count = 0;
            foreach (DataEvaluationResult edr in EvaluationData)
            {
                count++;
                OverallScore += edr.AverageScore;
                stackEvaluations.Children.Add(new EmployeeEvaluationDisplay(edr));
            }
            OverallScore /= count;
        }

        /// <summary>
        /// Event handler designed to set the overall information for all related evaluations.
        /// </summary>
        /// <param name="sender">btnApply</param>
        /// <param name="e">Click</param>
        public void btnApply_Click(object sender, RoutedEventArgs e)
        {
            EvaluationData = DataController.GetEvaluations(EmployeeData.EmployeeNumber);
            foreach (DataEvaluationResult edr in EvaluationData)
            {
                edr.OverallProgressComment = txtBoxComment.Text;
                edr.OverallProgressScore = OverallScore;
                edr.EmployerRecommendation = (bool)chkRecommend.IsChecked;
                DataController.EditEvaluation(edr);
            }
        }

        /// <summary>
        /// Event handler designed to switch to the Evaluation Manager.
        /// </summary>
        /// <param name="sender">btnBack</param>
        /// <param name="e">Click</param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EmployeeContent.SwitchEvaluationItem("Manager");
        }
    }
}
