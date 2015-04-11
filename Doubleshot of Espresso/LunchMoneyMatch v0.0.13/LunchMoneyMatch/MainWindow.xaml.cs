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
using System.Threading;
//NOTE: Wrap page grids into a tab control for animation

//TODO: Figure out why it doesn't animate when navigating pages, only when the window first loads 
//TODO: "Carousel" doesn't seem to fit with our program well, find out ways to spice up the program
//TODO: Research packing algorithm for drag and drop customizable Tiles.
//TODO: Allow everything to scale (Viewbox?)
//TODO: Allocate space for chatframe or desing our own "flyout" for the bottom of the page & make it semi-transparent
namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        ServerControl sc = new ServerControl();
        Login ls;
        public static AlertControl AlertControl;
        public MainWindow()
        {
            InitializeComponent();
            AlertControl = new AlertControl(frameMain.NavigationService);
            ls = new Login(sc);
            Thread connect = new Thread(() => { sc.Connect(); });
            connect.Start();
        }

        /// <summary>
        /// This method is designed to initialize the current page when the program starts.
        /// </summary>
        /// <param name="sender">The Main Window.</param>
        /// <param name="e">The Loaded Event.</param>
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            frameMain.Navigate(ls);
            Root.Children.Add(AlertControl);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //ar
        }
    }
}
