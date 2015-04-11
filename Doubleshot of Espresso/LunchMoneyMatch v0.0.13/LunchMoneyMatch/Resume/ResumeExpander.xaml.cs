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
    /// Interaction logic for ResumeExpander.xaml
    /// </summary>
    public partial class ResumeExpander : UserControl
    {
        public ResumeExpander(String theHeader, Boolean hasInnerBorder)
        {
            InitializeComponent();

            myExpander.Header = theHeader;

            if (!hasInnerBorder)
                innerBorder.BorderThickness = new Thickness(0);

        }
    }
}
