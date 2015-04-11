using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows;
using System.Data;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace ATechBoardGameClub
{
    public static class DatabaseController
    {
        #region Database Variables
        static SqlCeConnection SqlCeConnection = new SqlCeConnection(@"Data Source=" + Properties.Settings.Default.DatabasePath + Properties.Settings.Default.DatabaseName + ";Password =;");
        static SqlCeCommand SqlCeCommand;
        static SqlCeDataReader SqlCeDataReader;
        static string Command;
        #endregion

        #region Database Connection
        public static bool OpenConnection()
        {
            try
            {
                SqlCeConnection.Open();
                SqlCeCommand = SqlCeConnection.CreateCommand();
                return true;
            }
            catch (SqlCeException ex)
            {
                MessageBox.Show("Unable to Open Database Connection.\nPlease access the administration panel to either 1) Create a new Database or 2) Set the correct path for the Database.\n\nError: " + ex.ToString());
                return false;
            }
        }

        public static void CloseConnection()
        {
            if (SqlCeCommand != null)
                SqlCeCommand.Dispose();
            if (SqlCeDataReader != null)
                SqlCeDataReader.Dispose();
            if (SqlCeConnection != null)
                SqlCeConnection.Close();
        }
        #endregion

        #region Program Helpers
        public static BitmapImage ConvertBytesToImage(byte[] ImageStream)
        {
            MemoryStream stream = new MemoryStream(ImageStream);
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();
            return image;
        }
        public static byte[] ConvertImageToBytes(BitmapImage Image)
        {
            //STREAM SOURCE IS NULL.
            Stream stream = Image.StreamSource;
            byte[] buffer = null;
            if (stream != null && stream.Length > 0)
            {
                using (BinaryReader br = new BinaryReader(stream))
                {
                    buffer = br.ReadBytes((Int32)stream.Length);
                }
            }
            return buffer;
        }
        #endregion

        #region Database Access
        public static string GetGlobalSettingsPassword()
        {
                Command = "SELECT * FROM GlobalSettings";
                SqlCeDataReader = ExecuteReader();
                if (SqlCeDataReader != null)
                {
                    SqlCeDataReader.Read();
                    return SqlCeDataReader.GetString(0);    //Password
                }
                else
                    return Properties.Settings.Default.AdminPassword;
        }
        public static void SetGlobalSettingsPassword(string Password)
        {
            if (SqlCeConnection.State == ConnectionState.Open)
            {
                Command = "UPDATE GlobalSettings SET SettingsPassword=@NewPassword WHERE SettingsPassword=@OldPassword";
                List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
                Parameters.Add(new SqlCeParameter("@NewPassword", Password));
                Parameters.Add(new SqlCeParameter("@OldPassword", Properties.Settings.Default.AdminPassword));
                ExecuteNonQuery(Parameters);
                Properties.Settings.Default.AdminPassword = Password;
            }
            else
            {
                MessageBox.Show("Database Connection Invalid.");
            }
        }
        public static void AddBoardGamePreset(DataBoardGamePreset BoardGamePreset)
        {
            Command = "INSERT INTO Presets(UniqueID, Image, Name, Genre, SubClass, Difficulty, SetupTime, GameTime, VideoLink, MinPlayers, MaxPlayers, Rating, Summary, TotalCopies, AvailableCopies, WebsiteLink) VALUES (@UniqueID, @Image, @Name, @Genre, @SubClass, @Difficulty, @SetupTime, @GameTime, @VideoLink, @MinPlayers, @MaxPlayers, @Rating, @Summary, @TotalCopies, @AvailableCopies, @WebsiteLink);";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@UniqueID", BoardGamePreset.UniqueID));
            Parameters.Add(new SqlCeParameter("@Image", ConvertImageToBytes(BoardGamePreset.Image)));
            Parameters.Add(new SqlCeParameter("@Name", BoardGamePreset.Name));
            Parameters.Add(new SqlCeParameter("@Genre", BoardGamePreset.Genre));
            Parameters.Add(new SqlCeParameter("@SubClass", BoardGamePreset.SubClass));
            Parameters.Add(new SqlCeParameter("@Difficulty", BoardGamePreset.Difficulty));
            Parameters.Add(new SqlCeParameter("@SetupTime", BoardGamePreset.SetupTime));
            Parameters.Add(new SqlCeParameter("@GameTime", BoardGamePreset.GameTime));
            Parameters.Add(new SqlCeParameter("@VideoLink", BoardGamePreset.VideoLink));
            Parameters.Add(new SqlCeParameter("@MinPlayers", BoardGamePreset.MinPlayers));
            Parameters.Add(new SqlCeParameter("@MaxPlayers", BoardGamePreset.MaxPlayers));
            Parameters.Add(new SqlCeParameter("@Rating", BoardGamePreset.Rating));
            Parameters.Add(new SqlCeParameter("@Summary", BoardGamePreset.Summary));
            Parameters.Add(new SqlCeParameter("@TotalCopies", BoardGamePreset.TotalCopies));
            Parameters.Add(new SqlCeParameter("@AvailableCopies", BoardGamePreset.AvailableCopies));
            Parameters.Add(new SqlCeParameter("@WebsiteLink", BoardGamePreset.WebsiteLink));
            ExecuteNonQuery(Parameters);
        }
        public static int GetAvailablePresetUniqueKey()
        {
            Command = "SELECT * FROM Presets";
            SqlCeDataReader = ExecuteReader();
            return SqlCeDataReader.GetInt32(0);
        }
        //public static List<DataBoardGamePreset> GetAllPresests()
        //{
        //    List<DataBoardGamePreset> Presets = new List<DataBoardGamePreset>();
        //    Command = "SELECT * FROM Presets";
        //    SqlCeDataReader = ExecuteReader();
        //    while (SqlCeDataReader.Read())
        //    {
        //        Presets.Add(new DataBoardGamePreset(SqlCeDataReader.GetInt32(0),
        //            Convert.FromBase64String(SqlCeDataReader.GetString(1)),

        //    }
        //}
        #endregion

        #region Database Creation
        public static bool CreateDatabase()
        {
            if (File.Exists(Properties.Settings.Default.DatabasePath + Properties.Settings.Default.DatabaseName))
            {
                MessageBox.Show("Database already exists at this path.");
                return false;
            }
            else
            {
                try
                {
                    CloseConnection();
                    SqlCeConnection.ConnectionString = @"Data Source=" + Properties.Settings.Default.DatabasePath + Properties.Settings.Default.DatabaseName + ";Password =;";
                    SqlCeEngine Engine = new SqlCeEngine(SqlCeConnection.ConnectionString);
                    Engine.CreateDatabase();
                    if (OpenConnection())
                    {
                        Command = "CREATE TABLE Presets(UniqueID INT PRIMARY KEY NOT NULL, Image IMAGE, Name NVARCHAR (100) NOT NULL, Genre NVARCHAR (100), SubClass NVARCHAR (100), Difficulty TINYINT, SetupTime TINYINT, GameTime SMALLINT, VideoLink NVARCHAR (255), MinPlayers TINYINT, MaxPlayers TINYINT, Rating REAL, Summary NVARCHAR (500), TotalCopies TINYINT, AvailableCopies TINYINT, WebsiteLink NVARCHAR (255))";
                        ExecuteNonQuery(null);
                        Command = "CREATE TABLE Inventory(Barcode NVARCHAR(25) NOT NULL, Present INT)";
                        ExecuteNonQuery(null);
                        Command = "CREATE TABLE GlobalSettings(SettingsPassword NVARCHAR(24))";
                        ExecuteNonQuery(null);
                        Command = "INSERT INTO GlobalSettings(SettingsPassword) values (@SettingsPassword);";
                        List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
                        Parameters.Add(new SqlCeParameter("@SettingsPassword", "BoardGameClubNumber1!"));
                        ExecuteNonQuery(Parameters);
                    }
                    Engine.Dispose();
                }
                catch (SqlCeException e)
                {
                    ShowDatabaseErros(e);
                    return false;
                }
                Properties.Settings.Default.AdminPassword = DatabaseController.GetGlobalSettingsPassword();
                Properties.Settings.Default.Save();
                return true;
            }
        }
        #endregion

        #region Database Execution Commands
        private static string ExecuteNonQuery(List<SqlCeParameter> Parameters)
        {
            try
            {
                SqlCeCommand.Parameters.Clear();
                if (SqlCeConnection.State == ConnectionState.Open)
                {
                    SqlCeCommand.CommandText = Command;
                    if (Parameters != null)
                    {
                        foreach (SqlCeParameter param in Parameters)
                        {
                            SqlCeCommand.Parameters.Add(param);
                        }
                    }
                    return SqlCeCommand.ExecuteNonQuery().ToString();
                }
                else
                    return "Database connection invalid.";
            }
            catch (SqlCeException e)
            {
                ShowDatabaseErros(e);
                return null;
            }
        }

        private static SqlCeDataReader ExecuteReader()
        {
            try
            {
                SqlCeCommand.Parameters.Clear();
                if (SqlCeConnection.State == ConnectionState.Open)
                {
                    SqlCeCommand.CommandText = Command;
                    return SqlCeCommand.ExecuteReader();
                }
                else
                    return null;
            }
            catch (SqlCeException e)
            {
                ShowDatabaseErros(e);
                return null;
            }
        }

        private static string ExecuteScalar()
        {
            try
            {
                SqlCeCommand.Parameters.Clear();
                if (SqlCeConnection.State == ConnectionState.Open)
                {
                    SqlCeCommand.CommandText = Command;
                    return SqlCeCommand.ExecuteScalar().ToString();
                }
                else
                    return "Database connection invalid.";
            }
            catch (SqlCeException e)
            {
                ShowDatabaseErros(e);
                return null;
            }
        }
        #endregion

        private static void ShowDatabaseErros(SqlCeException e)
        {
            SqlCeErrorCollection SqlCeErrorCollection = e.Errors;
            StringBuilder StringBuilder = new StringBuilder();
            Exception InnerException = e.InnerException;

            foreach (SqlCeError error in SqlCeErrorCollection)
            {
                StringBuilder.Append("Error Code: " + error.HResult.ToString("X"));
                StringBuilder.Append("\nMessage: " + error.Message);
                StringBuilder.Append("\nMinor Error: " + error.NativeError);
                StringBuilder.Append("\nSource: " + error.Source);

                foreach (int numParm in error.NumericErrorParameters)
                    if (0 != numParm)
                        StringBuilder.Append("\nNumber Parameter: " + numParm);

                foreach (string errorParm in error.ErrorParameters)
                    if (String.Empty != errorParm)
                        StringBuilder.Append("\nError Parameter: " + errorParm);

                MessageBox.Show(StringBuilder.ToString());
                StringBuilder.Remove(0, StringBuilder.Length);
            }
        }
    }
}
