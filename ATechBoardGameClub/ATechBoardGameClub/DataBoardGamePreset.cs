using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace ATechBoardGameClub
{
    public class DataBoardGamePreset
    {
        public int UniqueID;
        public BitmapImage Image;
        public string Name;
        public string Genre;
        public string SubClass;
        public int Difficulty;
        public int SetupTime;
        public int GameTime;
        public string VideoLink;
        public int MinPlayers;
        public int MaxPlayers;
        public double Rating;
        public string Summary;
        public int TotalCopies;
        public int AvailableCopies;
        public string WebsiteLink;
        public DataBoardGamePreset(int UniqueID, BitmapImage Image, string Name, string Genre, string SubClass, int Difficulty, int SetupTime, int GameTime, string VideoLink, int MinPlayers, int MaxPlayers, double Rating, string Summary, int TotalCopies, int AvailableCopies, string WebsiteLink)
        {
            this.UniqueID = UniqueID;
            this.Image = Image;
            this.Name = Name;
            this.Genre = Genre;
            this.SubClass = SubClass;
            this.Difficulty = Difficulty;
            this.SetupTime = SetupTime;
            this.GameTime = GameTime;
            this.VideoLink = VideoLink;
            this.MinPlayers = MinPlayers;
            this.MaxPlayers = MaxPlayers;
            this.Rating = Rating;
            this.Summary = Summary;
            this.TotalCopies = TotalCopies;
            this.AvailableCopies = AvailableCopies;
            this.WebsiteLink = WebsiteLink;
        }
    }
}
