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

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Interaction logic for HelpPage.xaml
    /// </summary>
    public partial class HelpPage : Page
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public HelpPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Event handler designed to naviaget back to the main page.
        /// </summary>
        /// <param name="sender">btnBack</param>
        /// <param name="e">Click</param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
