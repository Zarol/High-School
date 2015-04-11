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
    /// Interaction logic for RE.xaml
    /// </summary>
    public partial class RE : UserControl
    {
        public RE(String Header, Boolean hasInnerBorder)
        {

        }

        #region Public Methods

        public void addTextElement(String theText)
        {
            ResumeText resumeText = new ResumeText(theText);
        }

        public void addExpanderElement(ResumeExpander re)
        {
        }

        #endregion
    }
}
