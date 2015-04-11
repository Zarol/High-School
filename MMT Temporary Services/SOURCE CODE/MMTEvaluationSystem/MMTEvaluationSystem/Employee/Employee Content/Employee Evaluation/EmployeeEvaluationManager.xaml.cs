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

//TODO: Add spot for Recommendation

namespace MMTEvaluationSystem
{

    /// <summary>
    /// Interaction logic for EmployeeEvaluation.xaml
    /// </summary>
    public partial class EmployeeEvaluationManager : UserControl
    {
        const int EVALUATION_MAX_LENGTH = 256;
        EmployeeContent rootEmployeeContent;

        public List<DataEvaluationResult> listEvaluationData;
        DataEvaluationResult selectedEvaluationData;

        DateTime EvaluationDateNext;

        public int NumberOfEvaluations { get { return listEvaluationData.Count;}}

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="EmployeeContent">The employee content.</param>
        public EmployeeEvaluationManager(EmployeeContent EmployeeContent)
        {
            InitializeComponent();
            rootEmployeeContent = EmployeeContent;
        }

        /// <summary>
        /// Constructor for employees with evaluations.
        /// </summary>
        /// <param name="EmployeeContent">The employee content.</param>
        /// <param name="EmployeeNumber">The employee's unique number.</param>
        /// <param name="EvaluationData">The list of evaluations associated with the employee.</param>
        public EmployeeEvaluationManager(EmployeeContent EmployeeContent, int EmployeeNumber, List<DataEvaluationResult> EvaluationData)
        {            
            listEvaluationData = EvaluationData;
            rootEmployeeContent = EmployeeContent;
            InitializeComponent();
            initializeEvaluationData();
           
            UpdateAverageScore();
        }

        /// <summary>
        /// Adds an evaluation result to the manager's list and database.
        /// </summary>
        /// <param name="EvaluationData">The evaluation data to be added.</param>
        public void AddEvaluationResult(DataEvaluationResult EvaluationData)
        {
            EvaluationData.EvaluationDateNext = EvaluationDateNext;
            EvaluationData.OverallProgressScore = -1;
            EvaluationData.OverallProgressComment = "";
            EvaluationData.EmployerRecommendation = false;
            listEvaluationData.Add(EvaluationData);
            comboCurrentDate.Items.Add(EvaluationData.EvaluationDate);
            comboCurrentDate.SelectedIndex = comboCurrentDate.Items.Count - 1;
            selectedEvaluationData = EvaluationData;
            DataController.AddEvaluation(EvaluationData);
            rootEmployeeContent.EmployeeEvaluationOverall.btnApply_Click(null, null);
        }

        /// <summary>
        /// Event handler desigend to reload the Manager's information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            initializeDateSelection();
            if (listEvaluationData.Count != 0)
            {
                selectedEvaluationData = listEvaluationData[listEvaluationData.Count - 1];
                updateSelectedData();
            }
            else
                rootEmployeeContent.SwitchEvaluationItem("Add");
        }

        /// <summary>
        /// Initializes the evaluation data.
        /// </summary>
        private void initializeEvaluationData()
        {
            if (listEvaluationData != null)
            {
                //NumberOfEvaluations = listEvaluationData.Count;
                if (NumberOfEvaluations != 0)
                {
                    initializeDateSelection();
                    EvaluationDateNext = listEvaluationData[0].EvaluationDateNext;
                }
                else
                {
                    EvaluationDateNext = DateTime.Now;
                }
            } 
        }

        /// <summary>
        /// Initializes the combo box's selections with dates respective to the evaluations.
        /// </summary>
        private void initializeDateSelection()
        {
            comboCurrentDate.Items.Clear();
            if (listEvaluationData.Count != 0)
            {
                DataController.QuickSortEvaluationDate(listEvaluationData, 0, listEvaluationData.Count - 1);
                foreach (DataEvaluationResult ed in listEvaluationData)
                {
                    comboCurrentDate.Items.Add(ed.EvaluationDate.Date);
                }
                selectedEvaluationData = listEvaluationData[listEvaluationData.Count - 1];
                txtBoxNextDate.Text = selectedEvaluationData.EvaluationDateNext.ToShortDateString();
                comboCurrentDate.SelectedIndex = comboCurrentDate.Items.Count - 1;
            }
        }
        #region Text Change
        /// <summary>
        /// Event handler designed to display the remaining characters of a text box.
        /// </summary>
        /// <param name="sender">txtBoxQuality</param>
        /// <param name="e">TextChanged</param>
        private void txtBoxQuality_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblQualityRemain.Content = "Remaining Characters: " + (EVALUATION_MAX_LENGTH - txtBoxQuality.Text.Length);
        }

        /// <summary>
        /// Event handler designed to display the remaining characters of a text box.
        /// </summary>
        /// <param name="sender">txtBoxHabits</param>
        /// <param name="e">TextChanged</param>
        private void txtBoxHabits_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblHabitsRemain.Content = "Remaining Characters: " + (EVALUATION_MAX_LENGTH - txtBoxHabits.Text.Length);
        }

        /// <summary>
        /// Event handler designed to display the remaining characters of a text box.
        /// </summary>
        /// <param name="sender">txtBoxKnowledge</param>
        /// <param name="e">TextChanged</param>
        private void txtBoxKnowledge_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblKnowledgeRemain.Content = "Remaining Characters: " + (EVALUATION_MAX_LENGTH - txtBoxKnowledge.Text.Length);
        }

        /// <summary>
        /// Event handler designed to display the remaining characters of a text box.
        /// </summary>
        /// <param name="sender">txtBoxBehavior</param>
        /// <param name="e">TextChanged</param>
        private void txtBoxBehavior_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblBehaviorRemain.Content = "Remaining Characters: " + (EVALUATION_MAX_LENGTH - txtBoxBehavior.Text.Length);
        }
        #endregion

        #region Rating Changed
        /// <summary>
        /// Event handler designed to update the evaluation's score.
        /// </summary>
        /// <param name="sender">comboQuality</param>
        /// <param name="e">SelectionChanged</param>
        private void comboQuality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAverageScore();
        }
        /// <summary>
        /// Event handler designed to update the evaluation's score.
        /// </summary>
        /// <param name="sender">comboHabits</param>
        /// <param name="e">SelectionChanged</param>
        private void comboHabits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAverageScore();
        }
        /// <summary>
        /// Event handler designed to update the evaluation's score.
        /// </summary>
        /// <param name="sender">comboKnowledge</param>
        /// <param name="e">SelectionChanged</param>
        private void comboKnowledge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAverageScore();
        }
        /// <summary>
        /// Event handler designed to update the evaluation's score.
        /// </summary>
        /// <param name="sender">comboBehavior</param>
        /// <param name="e">SelectionChanged</param>
        private void comboBehavior_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAverageScore();
        }
        #endregion

        /// <summary>
        /// Update this evaluation's average score.
        /// </summary>
        private void UpdateAverageScore()
        {
            if (selectedEvaluationData != null)
            {
                if (comboQuality != null && comboHabits != null && comboKnowledge != null && comboBehavior != null)
                {
                    double AverageScore = ((comboQuality.SelectedIndex + 1) + (comboHabits.SelectedIndex + 1) + (comboKnowledge.SelectedIndex + 1) + (comboBehavior.SelectedIndex + 1)) / 4.0;
                    lblAverageScore.Content = "Average Score: " + AverageScore.ToString();
                    selectedEvaluationData.AverageScore = AverageScore;
                }
            }
        }

        /// <summary>
        /// Event handler designed to update the selected evaluation.
        /// </summary>
        /// <param name="sender">comboCurrentDate</param>
        /// <param name="e">SelectionChanged</param>
        private void comboCurrentDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ComboBox)sender).SelectedItem != null)
            {
            DateTime selectedDate = (DateTime)((ComboBox)sender).SelectedItem;
            foreach (DataEvaluationResult ed in listEvaluationData)
            {
                if (ed.EvaluationDate.Date == selectedDate)
                {
                    selectedEvaluationData = ed;
                }
            }
            updateSelectedData();
            }
        }

        /// <summary>
        /// Helper method designed to update the current data.
        /// </summary>
        private void updateSelectedData()
        {
            comboQuality.SelectedIndex = selectedEvaluationData.WorkQualityScore - 1;
            txtBoxQuality.Text = selectedEvaluationData.WorkQualityComment;

            comboHabits.SelectedIndex = selectedEvaluationData.WorkHabitScore - 1;
            txtBoxHabits.Text = selectedEvaluationData.WorkHabitComment;

            comboKnowledge.SelectedIndex = selectedEvaluationData.JobKnowledgeScore - 1;
            txtBoxKnowledge.Text = selectedEvaluationData.JobKnowledgeComment;

            comboBehavior.SelectedIndex = selectedEvaluationData.BehaviorScore - 1;
            txtBoxBehavior.Text = selectedEvaluationData.BehaviorComment;

            UpdateAverageScore();
            contentControlRoot.Reload();
        }

        /// <summary>
        /// Event handler designed to validate a date.
        /// </summary>
        /// <param name="sender">txtBoxNextDate</param>
        /// <param name="e">LostFocus</param>
        private void txtBoxNextDate_LostFocus(object sender, RoutedEventArgs e)
        {
            bool isValidDate = DateTime.TryParseExact(((TextBox)sender).Text, "mm/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out EvaluationDateNext);
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
        /// Event handler designed to submit changes in the evaluation to the database.
        /// </summary>
        /// <param name="sender">btnApply</param>
        /// <param name="e">Click</param>
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxNextDate.Background != Brushes.Red)
            {
                selectedEvaluationData.BehaviorScore = (byte)(comboBehavior.SelectedIndex + 1);
                selectedEvaluationData.BehaviorComment = txtBoxBehavior.Text;
                selectedEvaluationData.JobKnowledgeScore = (byte)(comboKnowledge.SelectedIndex + 1);
                selectedEvaluationData.JobKnowledgeComment = txtBoxKnowledge.Text;
                selectedEvaluationData.WorkHabitScore = (byte)(comboHabits.SelectedIndex + 1);
                selectedEvaluationData.WorkHabitComment = txtBoxHabits.Text;
                selectedEvaluationData.WorkQualityScore = (byte)(comboQuality.SelectedIndex + 1);
                selectedEvaluationData.WorkQualityComment = txtBoxQuality.Text;
                double AverageScore = ((comboQuality.SelectedIndex + 1) + (comboHabits.SelectedIndex + 1) + (comboKnowledge.SelectedIndex + 1) + (comboBehavior.SelectedIndex + 1)) / 4.0;
                selectedEvaluationData.AverageScore = AverageScore;
                selectedEvaluationData.EvaluationDateNext = EvaluationDateNext;
                DataController.EditEvaluation(selectedEvaluationData);
                rootEmployeeContent.EmployeeEvaluationOverall.btnApply_Click(null, null);
                contentControlRoot.Reload();
            }
        }

        /// <summary>
        /// Event handler designed to switch to the Add Evaluation screen.
        /// </summary>
        /// <param name="sender">btnNewEvaluation</param>
        /// <param name="e">Click</param>
        private void btnNewEvaluation_Click(object sender, RoutedEventArgs e)
        {
            rootEmployeeContent.SwitchEvaluationItem("Add");
        }

        /// <summary>
        /// Event handler designed to switch to the Overall Evaluation screen.
        /// </summary>
        /// <param name="sender">btnOverallProgress</param>
        /// <param name="e">Click</param>
        private void btnOverallProgress_Click(object sender, RoutedEventArgs e)
        {
            rootEmployeeContent.SwitchEvaluationItem("Overall");
        }

        /// <summary>
        /// Event handler designed to delete the currently selected evaluation from the list and database.
        /// </summary>
        /// <param name="sender">btnDelete</param>
        /// <param name="e">Click</param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataController.DeleteEvaluation(selectedEvaluationData);
            listEvaluationData.Remove(selectedEvaluationData);
            initializeDateSelection();
            if (listEvaluationData.Count != 0)
            {
                selectedEvaluationData = listEvaluationData[listEvaluationData.Count - 1];
                updateSelectedData();
            }
            else
                rootEmployeeContent.SwitchEvaluationItem("Add");
        }

    }
}
