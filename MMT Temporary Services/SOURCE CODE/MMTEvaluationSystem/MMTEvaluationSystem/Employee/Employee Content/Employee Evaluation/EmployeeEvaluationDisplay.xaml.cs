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
    /// Interaction logic for EmployeeEvaluationDisplay.xaml
    /// </summary>
    public partial class EmployeeEvaluationDisplay : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="EvaluationResult"></param>
        public EmployeeEvaluationDisplay(DataEvaluationResult EvaluationResult)
        {
            InitializeComponent();
            lblDate.Content = string.Format("Date: {0} ({1})", EvaluationResult.EvaluationDate.ToLongDateString(), EvaluationResult.EvaluationDate.ToShortDateString());
            lblWorkQuality.Content = "Work Quality Score: " + EvaluationResult.WorkQualityScore;
            txtBlockWorkQuality.Text = string.Format("\t{0}\n", EvaluationResult.WorkQualityComment);
            lblWorkHabit.Content = "Work Habit Score: " + EvaluationResult.WorkHabitScore;
            txtBlockWorkHabit.Text = string.Format("\t{0}\n", EvaluationResult.WorkHabitComment);
            lblJobKnowledge.Content = "Job Knowledge Score: " + EvaluationResult.JobKnowledgeScore;
            txtBlockJobKnowledge.Text = string.Format("\t{0}\n", EvaluationResult.JobKnowledgeComment);
            lblBehavior.Content = "Behavior Score: " + EvaluationResult.BehaviorScore;
            txtBlockBehavior.Text = string.Format("\t{0}\n", EvaluationResult.BehaviorComment);
        }
    }
}
