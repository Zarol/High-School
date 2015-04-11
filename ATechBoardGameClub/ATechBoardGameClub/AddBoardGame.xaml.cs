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
using System.Drawing;
using System.Windows.Forms;

namespace ATechBoardGameClub
{
    /// <summary>
    /// Interaction logic for AddBoardGame.xaml
    /// </summary>
    public partial class AddBoardGame : Page
    {
        DataBoardGamePreset BoardGamePreset;
        public AddBoardGame()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BoardGamePreset = new DataBoardGamePreset(0, null, "", "", "", 0, 0, 0, "", 0, 0, 0.0, "", 0, 0, "");
            txtBoxBarcode.Focus();
        }        
        
        private void txtBoxVideoLink_TextChanged(object sender, TextChangedEventArgs e)
        {
            string uri = txtBoxVideoLink.Text.Replace("watch?v=", "embed/");
            webBrowser.Navigate(uri);
            BoardGamePreset.VideoLink = uri;
        }

        private void btnImagePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Image Files (*.jpeg, *.jpg, *.png, *.bmp, *.gif, *.tiff, *.ico)|*.jpeg; *.jpg; *.png; *.bmp; *.gif; *.tiff; *.ico";
            OpenFileDialog.FilterIndex = 0;
            OpenFileDialog.Multiselect = false;

            DialogResult dialogResult = OpenFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtBoxImagePath.Text = OpenFileDialog.FileName;
                BoardGamePreset.Image = new BitmapImage(new Uri(@OpenFileDialog.FileName));
                imageImage.Source = BoardGamePreset.Image;
            }
        }

        private void txtBoxBarcode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxGenre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxSubClass_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxDifficulty_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxSetupTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxGameTime_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxMinPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxMaxPlayers_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxRating_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBlockSummary_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtBoxWebsite_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            BoardGamePreset.UniqueID = 0;   //TODO:
            BoardGamePreset.Name = txtBoxName.Text;
            BoardGamePreset.Genre = txtBoxGenre.Text;
            BoardGamePreset.SubClass = txtBoxSubClass.Text; 
            BoardGamePreset.Difficulty = int.Parse(txtBoxDifficulty.Text);
            BoardGamePreset.SetupTime = int.Parse(txtBoxSetupTime.Text);
            BoardGamePreset.GameTime = int.Parse(txtBoxGameTime.Text);
            BoardGamePreset.MinPlayers = int.Parse(txtBoxMinPlayers.Text);
            BoardGamePreset.MaxPlayers = int.Parse(txtBoxMaxPlayers.Text);
            BoardGamePreset.Rating = double.Parse(txtBoxRating.Text);
            BoardGamePreset.Summary = txtBlockSummary.Text;
            BoardGamePreset.TotalCopies = 0;    //TODO:
            BoardGamePreset.AvailableCopies = BoardGamePreset.TotalCopies;
            BoardGamePreset.WebsiteLink = txtBoxWebsite.Text;
            DatabaseController.AddBoardGamePreset(BoardGamePreset);
        }

    }
}
