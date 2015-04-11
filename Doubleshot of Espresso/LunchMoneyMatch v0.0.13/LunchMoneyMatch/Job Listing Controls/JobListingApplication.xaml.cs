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

namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for JobListingApplication.xaml
    /// </summary>
    public partial class JobListingApplication : UserControl
    {
        #region Private Variables
        //The list of question objects within an application. Each object MUST have a GetAnswer() method.
        List<object> Questions;
        #endregion

        #region Public Methods
        /// <summary>
        /// Default Constructor class that tests the application.
        /// </summary>
        public JobListingApplication()
        {
            InitializeComponent();
            Questions = new List<object>();
            lblJobTitle.Content = "Job Title";
            lblCompanyName.Content = "Company Name";
            lblSummary.Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        }

        /// <summary>
        /// The legitimate Constructor class that initalizes the application's components.
        /// </summary>
        /// <param name="JobTitle">The title of the job listing.</param>
        /// <param name="CompanyName">The company associated with the job listing.</param>
        /// <param name="Summary">The general summary of the job listing.</param>
        public JobListingApplication(string JobTitle, string CompanyName, string Summary )
        {
            InitializeComponent();
            Questions = new List<object>();
            lblJobTitle.Content = JobTitle;
            lblCompanyName.Content = CompanyName;
            lblSummary.Content = Summary;
        }

        /// <summary>
        /// Adds a free response question to the application with the default answer length.
        /// </summary>
        /// <param name="Question">The question to be asked.</param>
        public void AddFreeResponseQuestion(string Question)
        {
            AddFreeResponseQuestion(Question, 2500);
        }

        /// <summary>
        /// Adds a free response question to the application with a custom answer length.
        /// </summary>
        /// <param name="Question">The question to be asked.</param>
        /// <param name="MaxCharacter">The maximum character length for the answer.</param>
        public void AddFreeResponseQuestion(string Question, int MaxCharacter)
        {
            Questions.Add(new ApplicationFreeResponseQuestion(Question, MaxCharacter));
            stackPanelContent.Children.Add((ApplicationFreeResponseQuestion)Questions[Questions.Count-1]);
        }

        /// <summary>
        /// Adds a multiple choice question to the application.
        /// </summary>
        /// <param name="Question">The question to be asked.</param>
        /// <param name="Answers">The list of answers that can be selected.</param>
        public void AddMultipleChoiceQuestion(string Question, List<string> Answers)
        {
            Questions.Add(new ApplicationMultipleChoiceQuestion(Question, Answers));
            stackPanelContent.Children.Add((ApplicationMultipleChoiceQuestion)Questions[Questions.Count - 1]);
        }
        #endregion
    }
}
