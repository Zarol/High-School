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
    /// Interaction logic for HighSchoolButtons.xaml
    /// </summary>
    public partial class HighSchoolButtons : UserControl
    {
        public HighSchoolButtons()
        {
            InitializeComponent();
        }
        /**
         * The idea here is that we need to keep the add/remove buttons for the high school control at the bottom of the last
         * high school item. So, we can seperate the buttons into their own seperate control and simply attach their event
         * handlers elsewhere by passing in methods.
         * 
         * You can see this being implemented in the HighSchoolHandler.
         */ 
        public void setAdd_Click(RoutedEventHandler Method)
        {
            btnAdd.Click += Method;
        }
        public void setRemove_Click(RoutedEventHandler Method)
        {
            btnRemove.Click += Method;
        }
    }
}
