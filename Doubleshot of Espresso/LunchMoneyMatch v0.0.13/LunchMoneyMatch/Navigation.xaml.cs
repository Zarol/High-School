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

//Necessary Metro Imports
using MahApps.Metro.Actions;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MahApps.Metro.Converters;
using MahApps.Metro.Native;
using LunchMoneyMatch.Server;

//TODO: Insert Icons for each tile
//TODO: Match first name & last name labels with account
//TODO: Allow for profile picture
//TODO: Allow for tiles to be drag & drop & rearranged
namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Page
    {
        ServerControl sc;
        public Navigation(ServerControl sc)
        {
            InitializeComponent();
            this.sc = sc;
        }

        private void tileResume_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Resume());
        }

        private void tileSettings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Settings());
        }

        private void tileProfile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile(sc));
        }

        private void tileJob_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new JobListings(sc));
        }

        private void tileCalendar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Calendar());
        }
    }
}
