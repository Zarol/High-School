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
    /// Interaction logic for ApplicationFreeResponseQuestion.xaml
    /// </summary>
    public partial class ApplicationFreeResponseQuestion : UserControl
    {
        #region Public Methods
        /// <summary>
        /// Default Constructor class that initalizes the question.
        /// </summary>
        /// <param name="Question">The question to be asked.</param>
        public ApplicationFreeResponseQuestion(string Question)
        {
            InitializeComponent();
            txtBlockQuestion.Text = Question;
            txtBoxAnswer_TextChanged(null, null);
        }

        /// <summary>
        /// Constructor class that allows the restriction of characters within the answer.
        /// </summary>
        /// <param name="Question">The question to be asked.</param>
        /// <param name="MaxCharacters">The max character length of the answer.</param>
        public ApplicationFreeResponseQuestion(string Question, int MaxCharacters)
        {            
            InitializeComponent();
            txtBlockQuestion.Text = Question;
            txtBoxAnswer.MaxLength = MaxCharacters;
            txtBoxAnswer_TextChanged(null, null);
        }

        /// <summary>
        /// Getter method for the user's answer to the question.
        /// </summary>
        /// <returns>The user's answer.</returns>
        public string GetAnswer()
        {
            return txtBoxAnswer.Text;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Event listener method designed to update the amount of characters remaining in the answer.
        /// </summary>
        /// <param name="sender">The text box being edited (txtBoxAnswer).</param>
        /// <param name="e">The TextChanged event.</param>
        private void txtBoxAnswer_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblMaxChar.Content = "Characters Remaining: " + (txtBoxAnswer.MaxLength - txtBoxAnswer.Text.Length);
        }
        #endregion
    }
}
