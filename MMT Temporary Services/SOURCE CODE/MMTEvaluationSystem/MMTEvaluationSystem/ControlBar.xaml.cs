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
using System.IO;

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Interaction logic for ControlBar.xaml
    /// </summary>
    public partial class ControlBar : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ControlBar()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Designed to route the event of comboSeleced's selection changed event.
        /// </summary>
        /// <param name="Method">The method to route to comboSelected's SelectionChanged.</param>
        public void setSelectedSelectionChanged(SelectionChangedEventHandler Method)
        {
            comboSelected.SelectionChanged += Method;
        }

        /// <summary>
        /// Designed to route the events of comboFilter's selection changed event.
        /// </summary>
        /// <param name="Method">The method to route to comboFiler's SelectionChanged.</param>
        public void setFilterSelectionChanged(SelectionChangedEventHandler Method)
        {
            comboFilter.SelectionChanged += Method;
        }

        /// <summary>
        /// Designed to route the events of btnHelp's click event.
        /// </summary>
        /// <param name="Method">The method to route to btnHelp's Click.</param>
        public void setHelpClick(RoutedEventHandler Method)
        {
            btnHelp.Click += Method;
        }

        /// <summary>
        /// Event handler designed to export all of the data within the database into text files.
        /// </summary>
        /// <param name="sender">btnExport</param>
        /// <param name="e">Click</param>
        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            byte[] padding = new UTF8Encoding(true).GetBytes(" | ");
            byte[] newline = new UTF8Encoding(true).GetBytes("\r\n");
            string ExportPath = Directory.GetCurrentDirectory() + "\\Data Files";
            if (!Directory.Exists(ExportPath))
                Directory.CreateDirectory(ExportPath);
            #region Employee
            string EmployeeFile = ExportPath + "\\EMPLOYEES.txt";
            if (File.Exists(EmployeeFile))
                File.Delete(EmployeeFile);
            using (FileStream fs = File.Create(EmployeeFile))
            {
                
                foreach (DataEmployeeInformation dei in DataController.GetAllEmployees())
                {
                    byte[] firstName = new UTF8Encoding(true).GetBytes("Name: " + dei.FirstName + " ");
                    fs.Write(firstName, 0, firstName.Length);
                    byte[] lastName = new UTF8Encoding(true).GetBytes(dei.LastName);
                    fs.Write(lastName, 0, lastName.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] email = new UTF8Encoding(true).GetBytes("Email: " + dei.Email);
                    fs.Write(email, 0, email.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] phone = new UTF8Encoding(true).GetBytes("Phone: " + dei.Phone);
                    fs.Write(phone, 0, phone.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] cell = new UTF8Encoding(true).GetBytes("Cell: " + dei.Cell);
                    fs.Write(cell, 0, cell.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] street = new UTF8Encoding(true).GetBytes("Street: " + dei.Street);
                    fs.Write(street, 0, street.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] city = new UTF8Encoding(true).GetBytes("City: " + dei.City);
                    fs.Write(city, 0, city.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] state = new UTF8Encoding(true).GetBytes("State: " + dei.State);
                    fs.Write(state, 0, state.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] zip = new UTF8Encoding(true).GetBytes("Zip: " + dei.Zip.ToString());
                    fs.Write(zip, 0, zip.Length);
                    fs.Write(newline,0,newline.Length);
                    fs.Write(newline, 0, newline.Length);
                }
            }
            #endregion

            #region Employer
            string EmployerFile = ExportPath + "\\EMPLOYERS.txt";
            if (File.Exists(EmployerFile))
                File.Delete(EmployerFile);
            using (FileStream fs = File.Create(EmployerFile))
            {
                foreach (DataEmployerInformation dei in DataController.GetAllEmployers())
                {
                    byte[] name = new UTF8Encoding(true).GetBytes("Name: " + dei.Name);
                    fs.Write(name, 0, name.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] contact = new UTF8Encoding(true).GetBytes("Contact: " + dei.Contact);
                    fs.Write(contact, 0, contact.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] email = new UTF8Encoding(true).GetBytes("Email: " + dei.Email);
                    fs.Write(email, 0, email.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] phone = new UTF8Encoding(true).GetBytes("Phone: " + dei.Phone);
                    fs.Write(phone, 0, phone.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] street = new UTF8Encoding(true).GetBytes("Street: " + dei.Street);
                    fs.Write(street, 0, street.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] city = new UTF8Encoding(true).GetBytes("City: " + dei.City);
                    fs.Write(city, 0, city.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] state = new UTF8Encoding(true).GetBytes("State: " + dei.State);
                    fs.Write(state, 0, state.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] zip = new UTF8Encoding(true).GetBytes("Zip: " + dei.Zip.ToString());
                    fs.Write(zip, 0, zip.Length);
                    fs.Write(newline, 0, newline.Length);
                    fs.Write(newline, 0, newline.Length);
                }
            }
            #endregion

            #region Evaluation Results
            string EvaluationResultsFile = ExportPath + "\\EVALUATION_RESULTS.txt";
            if (File.Exists(EvaluationResultsFile))
                File.Delete(EvaluationResultsFile);
            using (FileStream fs = File.Create(EvaluationResultsFile))
            {
                foreach (DataEvaluationResult der in DataController.GetAllEvaluations())
                {
                    byte[] evaluationNumber = new UTF8Encoding(true).GetBytes("Evaluation Number: " + der.EvaluationNumber.ToString());
                    fs.Write(evaluationNumber, 0, evaluationNumber.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] employeeNumber = new UTF8Encoding(true).GetBytes("Employee Number: " + der.EmployeeNumber.ToString() + " --> ");
                    fs.Write(employeeNumber, 0, employeeNumber.Length);
                    byte[] employerNumber = new UTF8Encoding(true).GetBytes("Employer Number: " + der.EmployerNumber.ToString());
                    fs.Write(employerNumber, 0, employerNumber.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] evaluationDate = new UTF8Encoding(true).GetBytes("Evaluation Date: " + der.EvaluationDate.ToShortDateString());
                    fs.Write(evaluationDate, 0, evaluationDate.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] evaluationDateNext = new UTF8Encoding(true).GetBytes("Next Evaluation Date: " + der.EvaluationDateNext.ToShortDateString());
                    fs.Write(evaluationDateNext, 0, evaluationDateNext.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] workQualityScore = new UTF8Encoding(true).GetBytes("Work Quality Score: " + der.WorkQualityScore.ToString() + " - ");
                    fs.Write(workQualityScore, 0, workQualityScore.Length);
                    byte[] workQualityComment = new UTF8Encoding(true).GetBytes("Work Quality Comment: " + der.WorkQualityComment);
                    fs.Write(workQualityComment, 0, workQualityComment.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] workHabitScore = new UTF8Encoding(true).GetBytes("Work Habit Score: " + der.WorkHabitScore.ToString() + " - ");
                    fs.Write(workHabitScore, 0, workHabitScore.Length);
                    byte[] workHabitComment = new UTF8Encoding(true).GetBytes("Work Habit Comment: " + der.WorkHabitComment);
                    fs.Write(workHabitComment, 0, workHabitComment.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] jobKnowledgeScore = new UTF8Encoding(true).GetBytes("Job Knowledge Score: " + der.JobKnowledgeScore.ToString() + " - ");
                    fs.Write(jobKnowledgeScore, 0, jobKnowledgeScore.Length);
                    byte[] jobKnowledgeComment = new UTF8Encoding(true).GetBytes("Job Knowledge Comment: " + der.JobKnowledgeComment);
                    fs.Write(jobKnowledgeComment, 0, jobKnowledgeComment.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] behaviorScore = new UTF8Encoding(true).GetBytes("Behavior Score: " + der.BehaviorScore.ToString() + " - ");
                    fs.Write(behaviorScore, 0, behaviorScore.Length);
                    byte[] behaviorComment = new UTF8Encoding(true).GetBytes("Behavior Comment: " + der.BehaviorComment);
                    fs.Write(behaviorComment, 0, behaviorComment.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] averageScore = new UTF8Encoding(true).GetBytes("Average Score: " + der.AverageScore.ToString());
                    fs.Write(averageScore, 0, averageScore.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] overallProgressScore = new UTF8Encoding(true).GetBytes("Overall Progress Score: " + der.OverallProgressScore.ToString() + " - ");
                    fs.Write(overallProgressScore, 0, overallProgressScore.Length);
                    byte[] overallProgressComment = new UTF8Encoding(true).GetBytes("Overall Progress Comment: " + der.OverallProgressComment);
                    fs.Write(overallProgressComment, 0, overallProgressComment.Length);
                    fs.Write(padding, 0, padding.Length);
                    byte[] employerRecommendation = new UTF8Encoding(true).GetBytes("Employer Recommendation: " + der.EmployerRecommendation.ToString());
                    fs.Write(employerRecommendation, 0, employerRecommendation.Length);
                    fs.Write(newline, 0, newline.Length);
                    fs.Write(newline, 0, newline.Length);
                }
            }
            #endregion

            #region Field Placements
            string FieldPlacementFile = ExportPath + "\\FIELD_PLACEMENTS.txt";
            if (File.Exists(FieldPlacementFile))
                File.Delete(FieldPlacementFile);
            using (FileStream fs = File.Create(FieldPlacementFile))
            {
                foreach (DataFieldPlacement dfp in DataController.GetAllFieldPlacements())
                {
                    byte[] employerNumber = new UTF8Encoding(true).GetBytes("Employer Number: " + dfp.EmployerNumber.ToString() + " --> ");
                    fs.Write(employerNumber, 0, employerNumber.Length);
                    byte[] employeeNumber = new UTF8Encoding(true).GetBytes("Employee Number: " + dfp.EmployeeNumber.ToString());
                    fs.Write(employeeNumber, 0, employeeNumber.Length);
                    fs.Write(newline, 0, newline.Length);
                    fs.Write(newline, 0, newline.Length);
                }
            }
            #endregion
            System.Diagnostics.Process.Start("explorer.exe", ExportPath);
        }
    }
}
