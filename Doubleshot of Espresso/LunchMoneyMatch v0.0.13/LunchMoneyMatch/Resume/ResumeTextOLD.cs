using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace LunchMoneyMatch
{
    class ResumeTextOLD : StackPanel
    {
        public ResumeTextOLD(String theText)
        {
            this.theText = theText;
            theTextBlock = new TextBlock();
            theTextBlock.TextWrapping = TextWrapping.Wrap;
            theTextBlock.Margin = new Thickness(12, 5, 0, 5);
            theTextBlock.Text = theText;
            this.Children.Add(theTextBlock);
        }

        public void changeText(String newText)
        {
            this.theText = newText;
            theTextBlock.Text = newText;
        }

        public void appendText(String textToAppend)
        {
            this.theText += textToAppend;
            theTextBlock.Text += textToAppend;
        }

        #region Private Properties

        private String theText;
        private TextBlock theTextBlock;

        #endregion
    }
}
