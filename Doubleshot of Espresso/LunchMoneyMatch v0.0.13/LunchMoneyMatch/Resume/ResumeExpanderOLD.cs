using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace LunchMoneyMatch
{
    public class ResumeExpanderOLD : UserControl
    {
        public ResumeExpanderOLD(String Header, Boolean hasInnerBorder)
        {
            primaryExpander = new Expander();
            primaryExpander.Header = Header;
            primaryExpander.Margin = new Thickness(0, 5, 0, 5);

            myContent = new StackPanel();

            if (hasInnerBorder)
            {
                innerBorder = new Border();
                innerBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB3CCF0"));
                innerBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                innerBorder.Margin = new Thickness(12, 10, 0, 10);
                primaryExpander.Content = innerBorder;
                innerBorder.Child = myContent;
            }
            else
                primaryExpander.Content = myContent;

            this.AddChild(primaryExpander);
        }

        #region Public Methods

        public void addTextElement(String theText)
        {
            ResumeTextOLD resumeText = new ResumeTextOLD(theText);
            myContent.Children.Add(resumeText);
        }

        public void addExpanderElement(ResumeExpanderOLD re)
        {
            myContent.Children.Add(re);
        }

        #endregion

        #region Private Variables

        private Border innerBorder;
        private Expander primaryExpander;
        private StackPanel myContent;
        private Grid myGrid;
        #endregion
    }
}
