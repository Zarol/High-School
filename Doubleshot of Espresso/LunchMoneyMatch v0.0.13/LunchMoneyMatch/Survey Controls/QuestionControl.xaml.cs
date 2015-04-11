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

namespace LunchMoneyMatch.Survey_Controls
{
    /// <summary>
    /// Within each QuestionControl will be a "Question" object, passed in from a database
    /// The "Question" object will be used to fill in the labels on the xaml document
    /// </summary>
    public partial class QuestionControl : UserControl
    {
        Answer[] listOfAnswers;

        public QuestionControl(Question question)
        {
            InitializeComponent();
            listOfAnswers = new Answer[4];
            // Fill the listOfAnswers array with the answers from the given question, but in random order
            Random ran = new Random();
            Answer tempAnswer;
            int tempInt;
            questionLabel.Content = question.text;
            for (int i = 3; i >= 0; i--)
            {
                tempInt = ran.Next(i);
                tempAnswer = question.listOfAnswers[tempInt];
                listOfAnswers[i] = tempAnswer;
                question.listOfAnswers[tempInt] = question.listOfAnswers[i];
                question.listOfAnswers[i] = tempAnswer;
            }
            answerA.Content = listOfAnswers[0].text;
            answerB.Content = listOfAnswers[1].text;
            answerC.Content = listOfAnswers[2].text;
            answerD.Content = listOfAnswers[3].text;
        }
    }
}
