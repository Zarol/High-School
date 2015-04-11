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
    /// Within the SurveyPage will be several QuestionControls, and a "Submit" button which will update the user's profile with the questions they answered
    /// The SurveyPage will randomly populate the set number of QuestionControls each time a SurveyPage is generated.
    /// There will be a maximum number of QuestionsControls per page, but no minimum as there is no definite guarantee the user will always have a set number of questions left to answer.
    /// </summary>
    public partial class SurveyPage : Page
    {
        public SurveyPage()
        {
            InitializeComponent();
            MainGrid.Children.Add(new QuestionControl(new Question("Question", (PrimaryTrait)1, (SecondaryTrait)1, "answerA", "answerB", "answerC", "answerD")));
        }
    }
}
