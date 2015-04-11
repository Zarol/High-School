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
    /// Interaction logic for ApplicationMultipleChoiceQuestion.xaml
    /// </summary>
    public partial class ApplicationMultipleChoiceQuestion : UserControl
    {
        #region Private Variables
        //The answer selected
        string Answer;
        #endregion

        #region Public Methods
        /// <summary>
        /// The Constructor that initalizes an application's custom multiple choice question.
        /// </summary>
        /// <param name="Question">The question to be asked to the user.</param>
        /// <param name="Answers">The list of answers the user can select.</param>
        public ApplicationMultipleChoiceQuestion(string Question, List<string> Answers)
        {
            InitializeComponent();
            txtBlockQuestion.Text = Question;

            loadAnswers(Answers);
        }        
        
        /// <summary>
        /// Getter method for the selected answer.
        /// </summary>
        /// <returns>The selected answer to the question.</returns>
        public string GetAnswer()
        {
            return Answer;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Helper method designed to load the answers into radio buttons and add them into the control.
        /// </summary>
        /// <param name="Answers">The list of answers to be added to radio buttons.</param>
        private void loadAnswers(List<string> Answers)
        {
            if (Answers.Count != 0 && Answers != null)
            {
                foreach( string s in Answers)
                {
                    RadioButton tempRad = new RadioButton();
                    TextBlock tempTxt = new TextBlock();
                    tempRad.GroupName = "Answers";
                    tempRad.HorizontalAlignment = HorizontalAlignment.Left;
                    tempRad.FontSize = 16;
                    tempRad.Margin = new Thickness(5);
                    stackPanelRadioAnswers.Children.Add(tempRad);                    

                    tempTxt.TextWrapping = TextWrapping.Wrap;
                    tempTxt.Text = s;
                    tempRad.Content = tempTxt;                    
                    
                    tempRad.Checked += radAnswers_IsChecked;
                    tempRad.IsChecked = true;
                }
            }
        }

        /// <summary>
        /// Event listener method for when the custom radio buttons are checked.
        /// </summary>
        /// <param name="sender">The radio button.</param>
        /// <param name="e">The IsChecked event.</param>
        private void radAnswers_IsChecked(object sender, EventArgs e)
        {
            RadioButton tempRad = (RadioButton)sender;
            TextBlock tempTxt = (TextBlock)tempRad.Content;
            Answer = tempTxt.Text;
        }
        #endregion
    }
}
