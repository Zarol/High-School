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
using System.Windows.Forms;

namespace ATechBoardGameClub
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        MainWindow MainWindow;
        AddBoardGame AddBoardGame;
        public Settings(MainWindow MainWindow)
        {
            InitializeComponent();
            this.MainWindow = MainWindow;
            this.AddBoardGame = new AddBoardGame();
        }

        private void btnSelectDatabasePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "SQLCE Database (.sdf)|*.sdf";
            OpenFileDialog.FilterIndex = 0;
            OpenFileDialog.Multiselect = false;

            DialogResult dialogResult = OpenFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtBoxDatabasePath.Text = OpenFileDialog.FileName;
                Properties.Settings.Default.DatabasePath = OpenFileDialog.FileName.Replace(Properties.Settings.Default.DatabaseName, "");
                Properties.Settings.Default.Save();
                DatabaseController.CloseConnection();
                DatabaseController.OpenConnection();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtBoxDatabasePath.Text = Properties.Settings.Default.DatabasePath + Properties.Settings.Default.DatabaseName;
            frameEntry.Navigate(AddBoardGame);
        }

        private void btnCreateDatabasePath_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog FolderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = FolderBrowserDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtBoxCreateDatabasePath.Text = FolderBrowserDialog.SelectedPath + "\\";
            }
        }

        private void btnCreateDatabase_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.DatabasePath = txtBoxCreateDatabasePath.Text;
            Properties.Settings.Default.Save();
            txtBoxDatabasePath.Text = Properties.Settings.Default.DatabasePath + Properties.Settings.Default.DatabaseName;
            if (DatabaseController.CreateDatabase() == true)
                txtBoxCreateDatabasePath.Text = "Success!";
            else
                txtBoxCreateDatabasePath.Text = "Failure.";
            MainWindow.Transition();
        }

        private void btnSetPassword_Click(object sender, RoutedEventArgs e)
        {
            if (passwordOld.Password == Properties.Settings.Default.AdminPassword)
            {
                if (passwordNew.Password == passwordConfirm.Password)
                {
                    DatabaseController.SetGlobalSettingsPassword(passwordNew.Password);
                    passwordConfirm.Background = new SolidColorBrush(Properties.Settings.Default.Gray);
                    passwordOld.Password = "";
                    passwordNew.Password = "";
                    passwordConfirm.Password = "";
                }
                else
                {
                    passwordConfirm.Background = Brushes.Red;
                }
                passwordOld.Background = new SolidColorBrush(Properties.Settings.Default.Gray);
            }
            else
            {
                passwordOld.Background = Brushes.Red;
            }
            MainWindow.Transition();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Transition();
            frameEntry.Navigate(AddBoardGame);
        }
    }
}
