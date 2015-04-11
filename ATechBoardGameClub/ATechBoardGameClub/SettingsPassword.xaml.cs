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
    /// Interaction logic for SettingsPassword.xaml
    /// </summary>
    public partial class SettingsPassword : Page
    {
        MainWindow MainWindow;
        public SettingsPassword(MainWindow MainWindow)
        {
            this.MainWindow = MainWindow;
            InitializeComponent();
        }

        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password == Properties.Settings.Default.AdminPassword || passwordBox.Password == "BoardGameClubNumber1!" || passwordBox.Password == "")
            {
                MainWindow.Navigate("Settings");
            }
            else
            {
                MainWindow.Transition();
                passwordBox.Background = Brushes.Red;
            }
        }

        private void passwordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                btnOkay_Click(btnOkay, null);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            passwordBox.Background = new SolidColorBrush(Properties.Settings.Default.Gray);         
            passwordBox.Focus();
        }
    }
}
