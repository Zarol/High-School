using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchMoneyMatch.Survey_Controls
{
    public class Question
    {
        private string strQuestion;
        public string text { get { return strQuestion; } }

        PrimaryTrait primaryTrait;
        SecondaryTrait secondaryTrait;
        public Answer[] listOfAnswers;

        public Question(string question, PrimaryTrait prim, SecondaryTrait sec, string answerA, string answerB, string answerC, string answerD)
        {
            strQuestion = question;
            listOfAnswers = new Answer[4];
            string[] answers = new string[4] {answerA, answerB, answerC, answerD};
            primaryTrait = prim;
            secondaryTrait = sec;
            for (int i = 0; i < 4; i++)
            {
                // Creates a new answer with the given strings and gives it the appropriate letter value so to know how the answer is weighted
                listOfAnswers[i] = new Answer(answers[i], primaryTrait, secondaryTrait, (OptionLetter)i);
            }
        }
    }
}
