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

namespace ATechBoardGameClub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        Page PageCheckOut;
        Page PageSettingsPassword;
        Page PageSettings;
        public MainWindow()
        {
            if (DatabaseController.OpenConnection() == true)
            {
                Properties.Settings.Default.AdminPassword = DatabaseController.GetGlobalSettingsPassword();
                Properties.Settings.Default.Save();
            }
            PageCheckOut = new CheckOut();            
            PageSettings = new Settings(this);
            InitializeComponent();            
            PageSettingsPassword = new SettingsPassword(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Page">CheckOut, SettingsPassword, Settings</param>
        public void Navigate(string Page)
        {
            switch (Page)
            {
                case "CheckOut":
                    frameNavigation.Navigate(PageCheckOut);
                    break;
                case "SettingsPassword":
                    frameNavigation.Navigate(PageSettingsPassword);
                    break;
                case "Settings":
                    frameNavigation.Navigate(PageSettings);
                    break;
                default:
                    frameNavigation.Navigate(PageCheckOut);
                    break;
            }
            contentControlRoot.Reload();
        }

        public void Transition()
        {
            contentControlRoot.Reload();
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            DatabaseController.CloseConnection();
        }

        private void MetroWindow_Initialized(object sender, EventArgs e)
        {
            frameNavigation.Navigate(PageCheckOut);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            Navigate("CheckOut");
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Navigate("SettingsPassword");
        }
    }
}
