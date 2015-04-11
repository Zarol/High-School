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
using System.Windows.Shapes;

namespace LunchMoneyMatch.Survey_Controls
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class QuestionGeneratorConfirmationDialog : Window
    {
        public QuestionGeneratorConfirmationDialog(Question question)
        {
            InitializeComponent();
            QuestionText.Content += question.text;
            AnswerA.Content += question.listOfAnswers[0].text;
            AnswerB.Content += question.listOfAnswers[1].text;
            AnswerC.Content += question.listOfAnswers[2].text;
            AnswerD.Content += question.listOfAnswers[3].text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
