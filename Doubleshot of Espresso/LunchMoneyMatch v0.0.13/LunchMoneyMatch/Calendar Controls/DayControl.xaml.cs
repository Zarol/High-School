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
    /// Interaction logic for DayControl.xaml
    /// </summary>
    public partial class DayControl : UserControl
    {
        int Day;
        public DayControl()
        {
            InitializeComponent();
            initialize();
        }

        public DayControl(int Day)
        {
            InitializeComponent();
            this.Day = Day; 
            initialize();
        }

        private void initialize()
        {
            lblDay.Content = Day;
        }
    }
}
