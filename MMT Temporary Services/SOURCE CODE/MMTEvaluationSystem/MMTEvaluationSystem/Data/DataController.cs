using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows;
using System.Windows.Media;
using System.Globalization;

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Static class designed to interface between runtime and the database.
    /// Also provides useful methods for use throughout the program.
    /// </summary>
    public static class DataController
    {
        #region Public Color Variables
        public readonly static Brush MMT_MAIN_BLUE = (Brush)new BrushConverter().ConvertFrom("#1585b5");
        public readonly static Brush MMT_ANALOGOUS_BLUE = (Brush)new BrushConverter().ConvertFrom("#46B8E9");
        public readonly static Brush MMT_BACKGROUND_GRAY = (Brush)new BrushConverter().ConvertFrom("#252525");
        #endregion

        #region Private Database Variables
        static int EmployeeKeys, EmployerKeys, EvaluationKeys;
        static string DatabaseName = "MMTDatabase.sdf";
        static SqlCeConnection SqlConnectionPublished = new SqlCeConnection(@"Data Source=|DataDirectory|" + "Database\\" + DatabaseName + ";Password =;");
        static SqlCeConnection SqlConnectionDebug = new SqlCeConnection(@"Data Source=C:\\Users\\Saharath\\Desktop\\MMTEvaluationSystem\\MMTEvaluationSystem\\MMT Database\\MMTDatabase.sdf;Password =;");
        static SqlCeConnection SelectedConnection = SqlConnectionPublished;
        static SqlCeCommand SqlCeCommand = new SqlCeCommand();
        static SqlCeDataReader SqlCeDataReader;
        static string Command;
        #endregion

        /// <summary>
        /// Initializes the database and its keys.
        /// </summary>
        private static void Initialize()
        {            
            if (SelectedConnection.State == System.Data.ConnectionState.Open)
            {
                SqlCeCommand.Connection = SelectedConnection;
                List<DataEmployeeInformation> TempEmployee = GetAllEmployees();
                if (TempEmployee.Count != 0)
                    EmployeeKeys = TempEmployee[TempEmployee.Count - 1].EmployeeNumber;
                else
                    EmployeeKeys = 1;
                List<DataEmployerInformation> TempEmployer = GetAllEmployers();
                if (TempEmployer.Count != 0)
                    EmployerKeys = TempEmployer[TempEmployer.Count - 1].EmployerNumber;
                else
                    EmployerKeys = 1;
                List<DataEvaluationResult> TempEvaluations = GetAllEvaluations();
                if (TempEvaluations.Count != 0)
                    EvaluationKeys = TempEvaluations[TempEvaluations.Count - 1].EvaluationNumber + 1;
                else
                    EvaluationKeys = 1;
            }
        }

        #region Database Connection
        /// <summary>
        /// Opens the database's connection
        /// </summary>
        /// <returns>True if connected, false if not connected.</returns>
        public static bool OpenConnection()
        {
            try
            {
                SelectedConnection.Open();
                Initialize();
                return true;
            }
            catch (SqlCeException E)
            {
                MessageBox.Show("Unable To Open Database Connection.\nError: " + E.ToString());
                return false;
            }
        }

        public static void CloseConnection()
        {
            SqlCeCommand.Dispose();
            SqlCeDataReader.Dispose();
            SelectedConnection.Close();
        }
        #endregion

        /// <summary>
        /// Methods used for sorting lists. Algorithm: Quick Sort - for its efficiency with medium sized lists and small code
        /// </summary>
        #region Sorting
        public static void QuickSort(List<IComparable> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            IComparable pivotPoint = elements[leftBound + (rightBound - leftBound) / 2];

            while (i <= j)
            {
                while ((elements[i]).CompareTo(pivotPoint) < 0)
                    i++;

                while ((elements[j]).CompareTo(pivotPoint) > 0)
                    j--;

                if (i <= j) //Swap
                {
                    IComparable temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSort(elements, leftBound, j);
            if (i < rightBound)
                QuickSort(elements, i, rightBound);
        }
        #region Employee
        public static void QuickSortEmployeeFirstName(List<DataEmployeeInformation> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            IComparable pivotPoint = elements[leftBound + (rightBound - leftBound) / 2].FirstName;

            while (i <= j)
            {
                while ((elements[i].FirstName).CompareTo(pivotPoint) < 0)
                    i++;

                while ((elements[j].FirstName).CompareTo(pivotPoint) > 0)
                    j--;

                if (i <= j) //Swap
                {
                    DataEmployeeInformation temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSortEmployeeFirstName(elements, leftBound, j);
            if (i < rightBound)
                QuickSortEmployeeFirstName(elements, i, rightBound);
        }
        public static void QuickSortEmployeeLastName(List<DataEmployeeInformation> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            IComparable pivotPoint = elements[leftBound + (rightBound - leftBound)/2].LastName;

            while (i <= j)
            {
                while ((elements[i].LastName).CompareTo(pivotPoint) < 0)
                    i++;

                while ((elements[j].LastName).CompareTo(pivotPoint) > 0)
                    j--;

                if (i <= j) //Swap
                {
                    DataEmployeeInformation temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSortEmployeeLastName(elements, leftBound, j);
            if (i < rightBound)
                QuickSortEmployeeLastName(elements, i, rightBound);
        }
        public static void QuickSortEmployeeNumber(List<DataEmployeeInformation> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            IComparable pivotPoint = elements[leftBound + (rightBound - leftBound) / 2].EmployeeNumber;

            while (i <= j)
            {
                while ((elements[i].EmployeeNumber).CompareTo(pivotPoint) < 0)
                    i++;

                while ((elements[j].EmployeeNumber).CompareTo(pivotPoint) > 0)
                    j--;

                if (i <= j) //Swap
                {
                    DataEmployeeInformation temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSortEmployeeNumber(elements, leftBound, j);
            if (i < rightBound)
                QuickSortEmployeeNumber(elements, i, rightBound);
        }
        public static void QuickSortOverallEvaluations(List<DataEmployeeInformation> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            double pivotPoint;
            double comparing;
            List<DataEvaluationResult> evaluationPivot = GetEvaluations(elements[leftBound + (rightBound - leftBound) / 2].EmployeeNumber);
            List<DataEvaluationResult> evaluationComparing;
            if (evaluationPivot.Count != 0)
                pivotPoint = evaluationPivot[0].OverallProgressScore;
            else
                pivotPoint = 0;

            while (i <= j)
            {
                evaluationComparing = GetEvaluations(elements[i].EmployeeNumber);
                if (evaluationComparing.Count != 0)
                    comparing = evaluationComparing[0].OverallProgressScore;
                else
                    comparing = 0;
                while ((comparing).CompareTo(pivotPoint) > 0)
                {
                    i++;
                    evaluationComparing = GetEvaluations(elements[i].EmployeeNumber);
                    if (evaluationComparing.Count != 0)
                        comparing = evaluationComparing[0].OverallProgressScore;
                    else
                        comparing = 0;
                }

                evaluationComparing = GetEvaluations(elements[j].EmployeeNumber);
                if (evaluationComparing.Count != 0)
                    comparing = evaluationComparing[0].OverallProgressScore;
                else
                    comparing = 0;
                while ((comparing).CompareTo(pivotPoint) < 0)
                {
                    j--;
                    evaluationComparing = GetEvaluations(elements[j].EmployeeNumber);
                    if (evaluationComparing.Count != 0)
                        comparing = evaluationComparing[0].OverallProgressScore;
                    else
                        comparing = 0;
                }

                if (i <= j) //Swap
                {
                    DataEmployeeInformation temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSortOverallEvaluations(elements, leftBound, j);
            if (i < rightBound)
                QuickSortOverallEvaluations(elements, i, rightBound);
        }
        #endregion
        #region Employer
        public static void QuickSortEmployerName(List<DataEmployerInformation> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            IComparable pivotPoint = elements[leftBound + (rightBound - leftBound) / 2].Name;

            while (i <= j)
            {
                while ((elements[i].Name).CompareTo(pivotPoint) < 0)
                    i++;

                while ((elements[j].Name).CompareTo(pivotPoint) > 0)
                    j--;

                if (i <= j) //Swap
                {
                    DataEmployerInformation temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSortEmployerName(elements, leftBound, j);
            if (i < rightBound)
                QuickSortEmployerName(elements, i, rightBound);
        }
        public static void QuickSortEmployerNumber(List<DataEmployerInformation> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            IComparable pivotPoint = elements[leftBound + (rightBound - leftBound) / 2].EmployerNumber;

            while (i <= j)
            {
                while ((elements[i].EmployerNumber).CompareTo(pivotPoint) < 0)
                    i++;

                while ((elements[j].EmployerNumber).CompareTo(pivotPoint) > 0)
                    j--;

                if (i <= j) //Swap
                {
                    DataEmployerInformation temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSortEmployerNumber(elements, leftBound, j);
            if (i < rightBound)
                QuickSortEmployerNumber(elements, i, rightBound);
        }
        #endregion
        #region Evaluations
        public static void QuickSortEvaluationDate(List<DataEvaluationResult> elements, int leftBound, int rightBound)
        {
            int i = leftBound, j = rightBound;
            IComparable pivotPoint = elements[leftBound + (rightBound - leftBound) / 2].EvaluationDate;

            while (i <= j)
            {
                while ((elements[i].EvaluationDate).CompareTo(pivotPoint) < 0)
                    i++;

                while ((elements[j].EvaluationDate).CompareTo(pivotPoint) > 0)
                    j--;

                if (i <= j) //Swap
                {
                    DataEvaluationResult temp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftBound < j)
                QuickSortEvaluationDate(elements, leftBound, j);
            if (i < rightBound)
                QuickSortEvaluationDate(elements, i, rightBound);
        }
        #endregion
        #endregion

        #region Program Helper Methods
        /// <summary>
        /// Getter method for EmployeeKeys.
        /// </summary>
        /// <returns>The next available employee key.</returns>
        public static int GetEmployeeKeys()
        {
            return EmployeeKeys;
        }
        /// <summary>
        /// Getter method for EmployerKeys.
        /// </summary>
        /// <returns>The next available employer key.</returns>
        public static int GetEmployerKeys()
        {
            return EmployerKeys;
        }
        /// <summary>
        /// Getter method for EvaluationKeys.
        /// </summary>
        /// <returns>The next available evaluation key.</returns>
        public static int GetEvaluationKeys()
        {
            return EvaluationKeys;
        }
        /// <summary>
        /// Converts a US State string into its abbreviation.
        /// </summary>
        /// <param name="State">A US State.</param>
        /// <returns>The respective abbreviation.</returns>
        public static string ConvertStateToAbbreviation(string State)
        {
            switch (State)
            {
                case "Alabama":
                    return "AL";
                case "Alaska":
                    return "AK";
                case "Arizona":
                    return "AZ";
                case "Arkansas":
                    return "AR";
                case "California":
                    return "CA";
                case "Colorado":
                    return "CO";
                case "Connecticut":
                    return "CT";
                case "Delaware":
                    return "DE";
                case "District Of Columbia":
                    return "DC";
                case "Florida":
                    return "FL";
                case "Georgia":
                    return "GA";
                case "Hawaii":
                    return "HI";
                case "Idaho":
                    return "ID";
                case "Illinois":
                    return "IL";
                case "Indiana":
                    return "IN";
                case "Iowa":
                    return "IA";
                case "Kansas":
                    return "KS";
                case "Kentucky":
                    return "KY";
                case "Louisiana":
                    return "LA";
                case "Maine":
                    return "ME";
                case "Maryland":
                    return "MD";
                case "Massachusetts":
                    return "MA";
                case "Michigan":
                    return "MI";
                case "Minnesota":
                    return "MN";
                case "Mississippi":
                    return "MS";
                case "Missouri":
                    return "MO";
                case "Montana":
                    return "MT";
                case "Nebraska":
                    return "NE";
                case "Nevada":
                    return "NV";
                case "New Hampshire":
                    return "NH";
                case "New Jersey":
                    return "NJ";
                case "New Mexico":
                    return "NM";
                case "New York":
                    return "NY";
                case "North Carolina":
                    return "NC";
                case "North Dakota":
                    return "ND";
                case "Ohio":
                    return "OH";
                case "Oklahoma":
                    return "OK";
                case "Oregon":
                    return "OR";
                case "Pennsylvania":
                    return "PA";
                case "Rhode Island":
                    return "RI";
                case "South Carolina":
                    return "SC";
                case "South Dakota":
                    return "SD";
                case "Tennessee":
                    return "TN";
                case "Texas":
                    return "TX";
                case "Utah":
                    return "UT";
                case "Vermont":
                    return "VT";
                case "Virginia":
                    return "VA";
                case "Washington":
                    return "WA";
                case "West Virginia":
                    return "WV";
                case "Wisconsin":
                    return "WI";
                case "Wyoming":
                    return "WY";
                default:
                    return "Invalid State.";
            }
        }
        /// <summary>
        /// Converts a US State abbreviation into its full name.
        /// </summary>
        /// <param name="Abbreviation">A US State abbreviation.</param>
        /// <returns>The full state name.</returns>
        public static string ConvertAbbreviationToState(string Abbreviation)
        {
            switch (Abbreviation)
            {
                case "AL":
                    return "Alabama";
                case "AK":
                    return "Alaska";
                case "AZ":
                    return "Arizona";
                case "AR":
                    return "Arkansas";
                case "CA":
                    return "California";
                case "CO":
                    return "Colorado";
                case "CT":
                    return "Connecticut";
                case "DE":
                    return "Delaware";
                case "DC":
                    return "District Of Columbia";
                case "FL":
                    return "Florida";
                case "GA":
                    return "Georgia";
                case "HI":
                    return "Hawaii";
                case "ID":
                    return "Idaho";
                case "IL":
                    return "Illinois";
                case "IN":
                    return "Indianna";
                case "IA":
                    return "Iowa";
                case "KS":
                    return "Kansas";
                case "KY":
                    return "Kentucky";
                case "LA":
                    return "Louisiana";
                case "ME":
                    return "Maine";
                case "MD":
                    return "Maryland";
                case "MA":
                    return "Massachusetts";
                case "MI":
                    return "Michigan";
                case "MN":
                    return "Minnesota";
                case "MS":
                    return "Mississippi";
                case "MO":
                    return "Missouri";
                case "MT":
                    return "Montana";
                case "NE":
                    return "Nebraska";
                case "NV":
                    return "Nevada";
                case "NH":
                    return "New Hampshire";
                case "NJ":
                    return "New Jersey";
                case "NM":
                    return "New Mexico";
                case "NY":
                    return "New York";
                case "NC":
                    return "North Carolina";
                case "ND":
                    return "North Dakota";
                case "OH":
                    return "Ohio";
                case "OK":
                    return "Oklahoma";
                case "OR":
                    return "Oregon";
                case "PA":
                    return "Pennsylvania";
                case "RI":
                    return "Rhode Island";
                case "SC":
                    return "South Carolina";
                case "SD":
                    return "South Dakota";
                case "TN":
                    return "Tennessee";
                case "TX":
                    return "Texas";
                case "UT":
                    return "Utah";
                case "VT":
                    return "Vermont";
                case "VA":
                    return "Virginia";
                case "WA":
                    return "Washington";
                case "WV":
                    return "West Virginia";
                case "WI":
                    return "Wisconsin";
                case "WY":
                    return "Wyoming";
                default:
                    return "Invalid Abbreviation";
            }
        }
        /// <summary>
        /// Converts a number into a formatted 10 digit number (by padding it with 0s).
        /// </summary>
        /// <param name="UniqueNumber">A unique number.</param>
        /// <returns>The formatted number padded with 0s.</returns>
        public static string FormatUniqueNumber(string UniqueNumber)
        {
            string temp = "#";
            switch (UniqueNumber.Length)
            {
                case 1:
                    temp += "000000000" + UniqueNumber;
                    break;
                case 2:
                    temp += "00000000" + UniqueNumber;
                    break;
                case 3:
                    temp += "0000000" + UniqueNumber;
                    break;
                case 4:
                    temp += "000000" + UniqueNumber;
                    break;
                case 5:
                    temp += "00000" + UniqueNumber;
                    break;
                case 6:
                    temp += "0000" + UniqueNumber;
                    break;
                case 7:
                    temp += "000" + UniqueNumber;
                    break;
                case 8:
                    temp += "00" + UniqueNumber;
                    break;
                case 9:
                    temp += "0" + UniqueNumber;
                    break;
                default:
                    temp += UniqueNumber;
                    break;
            }
            return temp;
        }
        #endregion

        #region Employee Commands
        /// <summary>
        /// Adds an employee to the database.
        /// </summary>
        /// <param name="EmployeeData">The employee data to be added.</param>
        public static void AddEmployee(DataEmployeeInformation EmployeeData)
        {
            EmployeeKeys++;
            Command = "insert into EmployeeTable(EmployeeNumber,FirstName,LastName,Email,Phone,Cell,Street,City,State,Zip) values(@EmployeeNumber,@FirstName,@LastName,@Email,@Phone,@Cell,@Street,@City,@State,@Zip);";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EmployeeNumber", EmployeeKeys));
            Parameters.Add(new SqlCeParameter("@FirstName", EmployeeData.FirstName));
            Parameters.Add(new SqlCeParameter("@LastName", EmployeeData.LastName));
            Parameters.Add(new SqlCeParameter("@Email", EmployeeData.Email));
            Parameters.Add(new SqlCeParameter("@Phone", EmployeeData.Phone));
            Parameters.Add(new SqlCeParameter("@Cell", EmployeeData.Cell));
            Parameters.Add(new SqlCeParameter("@Street", EmployeeData.Street));
            Parameters.Add(new SqlCeParameter("@City", EmployeeData.City));
            Parameters.Add(new SqlCeParameter("@State", EmployeeData.State));
            Parameters.Add(new SqlCeParameter("@Zip", EmployeeData.Zip));
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Deletes an employee from the database.
        /// </summary>
        /// <param name="EmployeeData">The employee data to be deleted.</param>
        public static void DeleteEmployee(DataEmployeeInformation EmployeeData)
        {
            Command = "DELETE from EmployeeTable where EmployeeNumber=@EmployeeNumber";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EmployeeNumber", EmployeeData.EmployeeNumber));
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Getter method for all stored employees.
        /// </summary>
        /// <returns>All stored employees.</returns>
        public static List<DataEmployeeInformation> GetAllEmployees()
        {
            List<DataEmployeeInformation> list = new List<DataEmployeeInformation>();
            Command = "select * from EmployeeTable";
            SqlCeDataReader = ExecuteReader();
            while (SqlCeDataReader.Read())
            {
                list.Add(new DataEmployeeInformation(SqlCeDataReader.GetInt32(0), //EmployeeNumber
                    SqlCeDataReader.GetString(1),   //First Name
                    SqlCeDataReader.GetString(2),   //Last Name
                    SqlCeDataReader.GetString(3),   //Email
                    SqlCeDataReader.GetString(4),   //Phone
                    SqlCeDataReader.GetString(5),   //Cell
                    SqlCeDataReader.GetString(6),   //Street
                    SqlCeDataReader.GetString(7),   //City
                    SqlCeDataReader.GetString(8),   //State
                    SqlCeDataReader.GetInt32(9)));  //Zip
            }
            return list;
        }
        /// <summary>
        /// Gets a specific employee's information in the database.
        /// </summary>
        /// <param name="UniqueNumber">The employee's unique number.</param>
        /// <returns>The employee's information if found.</returns>
        public static DataEmployeeInformation GetEmployee(int UniqueNumber)
        {
            Command = String.Format("select * from EmployeeTable where EmployeeNumber={0}", UniqueNumber);
            SqlCeDataReader = ExecuteReader();
            while (SqlCeDataReader.Read())
            {
                return (new DataEmployeeInformation(SqlCeDataReader.GetInt32(0), //EmployeeNumber
                    SqlCeDataReader.GetString(1),   //First Name
                    SqlCeDataReader.GetString(2),   //Last Name
                    SqlCeDataReader.GetString(3),   //Email
                    SqlCeDataReader.GetString(4),   //Phone
                    SqlCeDataReader.GetString(5),   //Cell
                    SqlCeDataReader.GetString(6),   //Street
                    SqlCeDataReader.GetString(7),   //City
                    SqlCeDataReader.GetString(8),   //State
                    SqlCeDataReader.GetInt32(9)));  //Zip
            }
            return new DataEmployeeInformation(0, "", "", "", "", "", "", "", "", 0);
        }
        /// <summary>
        /// Edits an employee's information in the database.
        /// </summary>
        /// <param name="EmployeeInformation">The edited employee information.</param>
        public static void EditEmployee(DataEmployeeInformation EmployeeInformation)
        {
            Command = "update EmployeeTable set Email=@Email,Phone=@Phone,Cell=@Cell,Street=@Street,City=@City,State=@State,Zip=@Zip where EmployeeNumber=@EmployeeNumber";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@Email", EmployeeInformation.Email));
            Parameters.Add(new SqlCeParameter("@Phone", EmployeeInformation.Phone));
            Parameters.Add(new SqlCeParameter("@Cell", EmployeeInformation.Cell));
            Parameters.Add(new SqlCeParameter("@Street",EmployeeInformation.Street));
            Parameters.Add(new SqlCeParameter("@City", EmployeeInformation.City));
            Parameters.Add(new SqlCeParameter("@State", ConvertStateToAbbreviation(EmployeeInformation.State)));
            Parameters.Add(new SqlCeParameter("@Zip", EmployeeInformation.Zip));
            Parameters.Add(new SqlCeParameter("@EmployeeNumber", EmployeeInformation.EmployeeNumber));
            ExecuteNonQuery(Parameters);
        }
        #endregion

        #region Employer Commands
        /// <summary>
        /// Adds an employer to the database.
        /// </summary>
        /// <param name="EmployerData">The employer data to be added.</param>
        public static void AddEmployer(DataEmployerInformation EmployerData)
        {
            EmployerKeys++;
            Command = "insert into EmployerTable(EmployerNumber,Name,Street,City,State,Zip,Phone,Email,Contact) values (@EmployerNumber,@Name,@Street,@City,@State,@Zip,@Phone,@Email,@Contact);";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EmployerNumber", EmployerKeys));
            Parameters.Add(new SqlCeParameter("@Name", EmployerData.Name));
            Parameters.Add(new SqlCeParameter("@Street", EmployerData.Street));
            Parameters.Add(new SqlCeParameter("@City", EmployerData.City));
            Parameters.Add(new SqlCeParameter("@State", EmployerData.State));
            Parameters.Add(new SqlCeParameter("@Zip", EmployerData.Zip));
            Parameters.Add(new SqlCeParameter("@Phone", EmployerData.Phone));
            Parameters.Add(new SqlCeParameter("@Email", EmployerData.Email));
            Parameters.Add(new SqlCeParameter("@Contact", EmployerData.Contact));
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Deletes and employer from the database.
        /// </summary>
        /// <param name="EmployerData">The employer information to delete.</param>
        public static void DeleteEmployer(DataEmployerInformation EmployerData)
        {
            Command = "DELETE from EmployerTable where EmployerNumber=@EmployerNumber";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EmployerNumber", EmployerData.EmployerNumber));
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Getter method for all employers in the database.
        /// </summary>
        /// <returns>All the employers in the database.</returns>
        public static List<DataEmployerInformation> GetAllEmployers()
        {
            List<DataEmployerInformation> list = new List<DataEmployerInformation>();
            Command = "select * from EmployerTable";
            SqlCeDataReader = ExecuteReader();
            while (SqlCeDataReader.Read())
            {
                list.Add((new DataEmployerInformation(SqlCeDataReader.GetInt32(0),
                    SqlCeDataReader.GetString(1),
                    SqlCeDataReader.GetString(2),
                    SqlCeDataReader.GetString(3),
                    SqlCeDataReader.GetString(4),
                    SqlCeDataReader.GetInt32(5),
                    SqlCeDataReader.GetString(6),
                    SqlCeDataReader.GetString(7),
                    SqlCeDataReader.GetString(8))));
            }
            return list;
        }
        /// <summary>
        /// Getter method for a specific employer's information.
        /// </summary>
        /// <param name="UniqueNumber">The employer's unique number.</param>
        /// <returns>The employer's information in the database.</returns>
        public static DataEmployerInformation GetEmployer(int UniqueNumber)
        {
            Command = String.Format("select * from EmployerTable where EmployerNumber={0}", UniqueNumber);
            SqlCeDataReader = ExecuteReader();
            while (SqlCeDataReader.Read())
            {
                return (new DataEmployerInformation(SqlCeDataReader.GetInt32(0),
                    SqlCeDataReader.GetString(1),
                    SqlCeDataReader.GetString(2),
                    SqlCeDataReader.GetString(3),
                    SqlCeDataReader.GetString(4),
                    SqlCeDataReader.GetInt32(5),
                    SqlCeDataReader.GetString(6),
                    SqlCeDataReader.GetString(7),
                    SqlCeDataReader.GetString(8)));
            }
            return new DataEmployerInformation(0,"","","","",0,"","","");
        }
        /// <summary>
        /// Getter method for a specific employer's information.
        /// </summary>
        /// <param name="EmployerName">The employer's unique name.</param>
        /// <returns>The employer's information in the database.</returns>
        public static DataEmployerInformation GetEmployer(string EmployerName)
        {
            Command = String.Format("select * from EmployerTable where Name='{0}'", EmployerName);
            SqlCeDataReader = ExecuteReader();
            while (SqlCeDataReader.Read())
            {
                return (new DataEmployerInformation(SqlCeDataReader.GetInt32(0),
                    SqlCeDataReader.GetString(1),
                    SqlCeDataReader.GetString(2),
                    SqlCeDataReader.GetString(3),
                    SqlCeDataReader.GetString(4),
                    SqlCeDataReader.GetInt32(5),
                    SqlCeDataReader.GetString(6),
                    SqlCeDataReader.GetString(7),
                    SqlCeDataReader.GetString(8)));
            }
            return new DataEmployerInformation(0, "", "", "", "", 0, "", "", "");
        }
        /// <summary>
        /// Edits the employer's information in the database.
        /// </summary>
        /// <param name="EmployerInformation">The edited employer information.</param>
        public static void EditEmployer(DataEmployerInformation EmployerInformation)
        {
            Command = "update EmployerTable set Email=@Email,Phone=@Phone,Contact=@Contact,Street=@Street,City=@City,State=@State,Zip=@Zip where EmployerNumber=@EmployerNumber";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@Email", EmployerInformation.Email));
            Parameters.Add(new SqlCeParameter("@Phone", EmployerInformation.Phone));
            Parameters.Add(new SqlCeParameter("@Contact", EmployerInformation.Contact));
            Parameters.Add(new SqlCeParameter("@Street", EmployerInformation.Street));
            Parameters.Add(new SqlCeParameter("@City", EmployerInformation.City));
            Parameters.Add(new SqlCeParameter("@State", ConvertStateToAbbreviation(EmployerInformation.State)));
            Parameters.Add(new SqlCeParameter("@Zip", EmployerInformation.Zip));
            Parameters.Add(new SqlCeParameter("@EmployerNumber", EmployerInformation.EmployerNumber));
            ExecuteNonQuery(Parameters);
        }
        #endregion

        #region Evaluation Result Commands
        /// <summary>
        /// Adds an evaluation into the database.
        /// </summary>
        /// <param name="EvaluationData">The evaluation data to be added.</param>
        public static void AddEvaluation(DataEvaluationResult EvaluationData)
        {
            Command = "insert into EvaluationResultsTable(EvaluationNumber,EmployeeNumber,EmployerNumber,EvaluationDate,EvaluationDateNext,WorkQualityScore,WorkQualityComment,WorkHabitScore,WorkHabitComment,JobKnowledgeScore,JobKnowledgeComment,BehaviorScore,BehaviorComment,AverageScore,OverallProgressScore,OverallProgressComment,EmployerRecommendation) values (@EvaluationNumber,@EmployeeNumber,@EmployerNumber,@EvaluationDate,@EvaluationDateNext,@WorkQualityScore,@WorkQualityComment,@WorkHabitScore,@WorkHabitComment,@JobKnowledgeScore,@JobKnowledgeComment,@BehaviorScore,@BehaviorComment,@AverageScore,@OverallProgressScore,@OverallProgressComment,@EmployerRecommendation);";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EvaluationNumber", EvaluationData.EvaluationNumber));
            Parameters.Add(new SqlCeParameter("@EmployeeNumber", EvaluationData.EmployeeNumber));
            Parameters.Add(new SqlCeParameter("@EmployerNumber", EvaluationData.EmployerNumber));
            Parameters.Add(new SqlCeParameter("@EvaluationDate", EvaluationData.EvaluationDate));
            Parameters.Add(new SqlCeParameter("@EvaluationDateNext", EvaluationData.EvaluationDateNext));
            Parameters.Add(new SqlCeParameter("@WorkQualityScore", EvaluationData.WorkQualityScore));
            Parameters.Add(new SqlCeParameter("@WorkQualityComment", EvaluationData.WorkQualityComment));
            Parameters.Add(new SqlCeParameter("@WorkHabitScore", EvaluationData.WorkHabitScore));
            Parameters.Add(new SqlCeParameter("@WorkHabitComment", EvaluationData.WorkHabitComment));
            Parameters.Add(new SqlCeParameter("@JobKnowledgeScore", EvaluationData.JobKnowledgeScore));
            Parameters.Add(new SqlCeParameter("@JobKnowledgeComment", EvaluationData.JobKnowledgeComment));
            Parameters.Add(new SqlCeParameter("@BehaviorScore", EvaluationData.BehaviorScore));
            Parameters.Add(new SqlCeParameter("@BehaviorComment", EvaluationData.BehaviorComment));
            Parameters.Add(new SqlCeParameter("@AverageScore", EvaluationData.AverageScore));
            Parameters.Add(new SqlCeParameter("@OverallProgressScore", EvaluationData.OverallProgressScore));
            Parameters.Add(new SqlCeParameter("@OverallProgressComment", EvaluationData.OverallProgressComment));
            Parameters.Add(new SqlCeParameter("@EmployerRecommendation", EvaluationData.EmployerRecommendation));
            EvaluationKeys++;
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Deletes an evaluation from the database.
        /// </summary>
        /// <param name="EvaluationData">The evaluation data to be deleted.</param>
        public static void DeleteEvaluation(DataEvaluationResult EvaluationData)
        {
            Command = "DELETE from EvaluationResultsTable where EvaluationNumber=@EvaluationNumber";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EvaluationNumber", EvaluationData.EvaluationNumber));
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Edits an evaluation in the database.
        /// </summary>
        /// <param name="EvaluationData">The edited evaluation data.</param>
        public static void EditEvaluation(DataEvaluationResult EvaluationData)
        {
            Command = "update EvaluationResultsTable set EvaluationDateNext=@EvaluationDateNext,WorkQualityScore=@WorkQualityScore,WorkQualityComment=@WorkQualityComment,WorkHabitScore=@WorkHabitScore,WorkHabitComment=@WorkHabitComment,JobKnowledgeScore=@JobKnowledgeScore,JobKnowledgeComment=@JobKnowledgeComment,BehaviorScore=@BehaviorScore,BehaviorComment=@BehaviorComment,AverageScore=@AverageScore,OverallProgressScore=@OverallProgressScore,OverallProgressComment=@OverallProgressComment,EmployerRecommendation=@EmployerRecommendation where EvaluationNumber=@EvaluationNumber";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EvaluationDateNext", EvaluationData.EvaluationDateNext));
            Parameters.Add(new SqlCeParameter("@WorkQualityScore", EvaluationData.WorkQualityScore));
            Parameters.Add(new SqlCeParameter("@WorkQualityComment", EvaluationData.WorkQualityComment));
            Parameters.Add(new SqlCeParameter("@WorkHabitScore", EvaluationData.WorkHabitScore));
            Parameters.Add(new SqlCeParameter("@WorkHabitComment", EvaluationData.WorkHabitComment));
            Parameters.Add(new SqlCeParameter("@JobKnowledgeScore", EvaluationData.JobKnowledgeScore));
            Parameters.Add(new SqlCeParameter("@JobKnowledgeComment", EvaluationData.JobKnowledgeComment));
            Parameters.Add(new SqlCeParameter("@BehaviorScore", EvaluationData.BehaviorScore));
            Parameters.Add(new SqlCeParameter("@BehaviorComment", EvaluationData.BehaviorComment));
            Parameters.Add(new SqlCeParameter("@AverageScore", EvaluationData.AverageScore));
            Parameters.Add(new SqlCeParameter("@OverallProgressScore", EvaluationData.OverallProgressScore));
            Parameters.Add(new SqlCeParameter("@OverallProgressComment", EvaluationData.OverallProgressComment));
            Parameters.Add(new SqlCeParameter("@EmployerRecommendation", EvaluationData.EmployerRecommendation));
            Parameters.Add(new SqlCeParameter("@EvaluationNumber", EvaluationData.EvaluationNumber));
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Getter method for all of an employee's evaluations.
        /// </summary>
        /// <param name="EmployeeNumber">The employee's unique number.</param>
        /// <returns>All of the employee's evaluations in the database.</returns>
        public static List<DataEvaluationResult> GetEvaluations(int EmployeeNumber)
        {
            List<DataEvaluationResult> List = new List<DataEvaluationResult>();
            Command = String.Format("select * from EvaluationResultsTable where EmployeeNumber={0}", EmployeeNumber);
            SqlCeDataReader = ExecuteReader();
            
            while (SqlCeDataReader.Read())
            {
                List.Add(new DataEvaluationResult(SqlCeDataReader.GetInt32(0),
                    SqlCeDataReader.GetInt32(1),
                    SqlCeDataReader.GetInt32(2),
                    SqlCeDataReader.GetDateTime(3),
                    SqlCeDataReader.GetDateTime(4),
                    SqlCeDataReader.GetByte(5),
                    SqlCeDataReader.GetString(6),
                    SqlCeDataReader.GetByte(7),
                    SqlCeDataReader.GetString(8),
                    SqlCeDataReader.GetByte(9),
                    SqlCeDataReader.GetString(10),
                    SqlCeDataReader.GetByte(11),
                    SqlCeDataReader.GetString(12),
                    SqlCeDataReader.GetDouble(13),
                    SqlCeDataReader.GetDouble(14),
                    SqlCeDataReader.GetString(15),
                    SqlCeDataReader.GetBoolean(16)));
            }
            return List;
        }
        /// <summary>
        /// Getter method for all evaluations the employer is associated with.
        /// </summary>
        /// <param name="EmployerInformation">The employer's information.</param>
        /// <returns>All evaluations associated with the employer.</returns>
        public static List<DataEvaluationResult> GetEvaluations(DataEmployerInformation EmployerInformation)
        {
            List<DataEvaluationResult> List = new List<DataEvaluationResult>();
            Command = String.Format("select * from EvaluationResultsTable where EmployerNumber={0}", EmployerInformation.EmployerNumber);
            SqlCeDataReader = ExecuteReader();

            while (SqlCeDataReader.Read())
            {
                List.Add(new DataEvaluationResult(SqlCeDataReader.GetInt32(0),
                    SqlCeDataReader.GetInt32(1),
                    SqlCeDataReader.GetInt32(2),
                    SqlCeDataReader.GetDateTime(3),
                    SqlCeDataReader.GetDateTime(4),
                    SqlCeDataReader.GetByte(5),
                    SqlCeDataReader.GetString(6),
                    SqlCeDataReader.GetByte(7),
                    SqlCeDataReader.GetString(8),
                    SqlCeDataReader.GetByte(9),
                    SqlCeDataReader.GetString(10),
                    SqlCeDataReader.GetByte(11),
                    SqlCeDataReader.GetString(12),
                    SqlCeDataReader.GetDouble(13),
                    SqlCeDataReader.GetDouble(14),
                    SqlCeDataReader.GetString(15),
                    SqlCeDataReader.GetBoolean(16)));
            }
            return List;
        }
        /// <summary>
        /// Getter method for all evaluations within the database.
        /// </summary>
        /// <returns>All evaluations stored within the database.</returns>
        public static List<DataEvaluationResult> GetAllEvaluations()
        {
            List<DataEvaluationResult> List = new List<DataEvaluationResult>();
            Command = "select * from EvaluationResultsTable";
            SqlCeDataReader = ExecuteReader();

            while (SqlCeDataReader.Read())
            {
                List.Add(new DataEvaluationResult(SqlCeDataReader.GetInt32(0),
                    SqlCeDataReader.GetInt32(1),
                    SqlCeDataReader.GetInt32(2),
                    SqlCeDataReader.GetDateTime(3),
                    SqlCeDataReader.GetDateTime(4),
                    SqlCeDataReader.GetByte(5),
                    SqlCeDataReader.GetString(6),
                    SqlCeDataReader.GetByte(7),
                    SqlCeDataReader.GetString(8),
                    SqlCeDataReader.GetByte(9),
                    SqlCeDataReader.GetString(10),
                    SqlCeDataReader.GetByte(11),
                    SqlCeDataReader.GetString(12),
                    SqlCeDataReader.GetDouble(13),
                    SqlCeDataReader.GetDouble(14),
                    SqlCeDataReader.GetString(15),
                    SqlCeDataReader.GetBoolean(16)));
            }
            return List;
        }
        #endregion

        #region Field Placement Commands
        /// <summary>
        /// Adds a field placement to the database.
        /// </summary>
        /// <param name="FieldPlacement">The field placement data.</param>
        public static void AddFieldPlacement(DataFieldPlacement FieldPlacement)
        {
            Command = "insert into FieldPlacementTable(EmployeeNumber,EmployerNumber) values(@EmployeeNumber,@EmployerNumber);";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EmployeeNumber", FieldPlacement.EmployeeNumber));
            Parameters.Add(new SqlCeParameter("@EmployerNumber", FieldPlacement.EmployerNumber));
            ExecuteNonQuery(Parameters);
        }
        /// <summary>
        /// Getter method for all field placements in the database.
        /// </summary>
        /// <returns>All the field placements in the database.</returns>
        public static List<DataFieldPlacement> GetAllFieldPlacements()
        {
            List<DataFieldPlacement> list = new List<DataFieldPlacement>();
            Command = "select * from FieldPlacementTable";
            SqlCeDataReader = ExecuteReader();
            while (SqlCeDataReader.Read())
            {
                list.Add(new DataFieldPlacement(SqlCeDataReader.GetInt32(0), SqlCeDataReader.GetInt32(1)));
            }
            return list;
        }
        /// <summary>
        /// Getter method for all field placements associated with an employer.
        /// </summary>
        /// <param name="EmployerInformation">The employer's information.</param>
        /// <returns>All field placements associated with the employer.</returns>
        public static List<DataFieldPlacement> GetAllEmployerFieldPlacements(DataEmployerInformation EmployerInformation)
        {
            List<DataFieldPlacement> List = new List<DataFieldPlacement>();
            Command = String.Format("select * from FieldPlacementTable where EmployerNumber={0}", EmployerInformation.EmployerNumber);
            SqlCeDataReader = ExecuteReader();

            while (SqlCeDataReader.Read())
            {
                List.Add(new DataFieldPlacement(SqlCeDataReader.GetInt32(0), SqlCeDataReader.GetInt32(1)));
            }
            return List;

        }
        /// <summary>
        /// Getter method for the field placement associated with an employee.
        /// </summary>
        /// <param name="EmployeeInformation">The employee's information.</param>
        /// <returns>The employee's associated field placement.</returns>
        public static DataFieldPlacement GetEmployeeFieldPlacement(DataEmployeeInformation EmployeeInformation)
        {
            Command = String.Format("select * from FieldPlacementTable where EmployeeNumber={0}", EmployeeInformation.EmployeeNumber);
            SqlCeDataReader = ExecuteReader();
            while (SqlCeDataReader.Read())
            {
                return new DataFieldPlacement(SqlCeDataReader.GetInt32(0), SqlCeDataReader.GetInt32(1));
            }
            return new DataFieldPlacement(-1, -1);
        }
        /// <summary>
        /// Deletes a field placement from the database.
        /// </summary>
        /// <param name="FieldPlacement">The field placement to be deleted.</param>
        public static void DeleteFieldPlacement(DataFieldPlacement FieldPlacement)
        {
            Command = "DELETE from FieldPlacementTable where EmployeeNumber=@EmployeeNumber";
            List<SqlCeParameter> Parameters = new List<SqlCeParameter>();
            Parameters.Add(new SqlCeParameter("@EmployeeNumber", FieldPlacement.EmployeeNumber));
            ExecuteNonQuery(Parameters);
        }
        #endregion

        #region Execution Commands
        /// <summary>
        /// Helper method to execute a non-query for the database.
        /// </summary>
        /// <param name="Parameters">A command's parameters.</param>
        /// <returns>The string result of the command.</returns>
        private static string ExecuteNonQuery(List<SqlCeParameter> Parameters)
        {
            SqlCeCommand.Parameters.Clear();
            if (SelectedConnection.State == System.Data.ConnectionState.Open)
            {
                SqlCeCommand.CommandText = Command;
                foreach (SqlCeParameter param in Parameters)
                {
                    SqlCeCommand.Parameters.Add(param);
                }
                return SqlCeCommand.ExecuteNonQuery().ToString();
            }
            else
                return "Database connection invalid.";
        }

        /// <summary>
        /// Helper method to execute a reader for the database.
        /// </summary>
        /// <returns>The reader associated with the command.</returns>
        private static SqlCeDataReader ExecuteReader()
        {
            SqlCeCommand.Parameters.Clear();
            if (SelectedConnection.State == System.Data.ConnectionState.Open)
            {
                SqlCeCommand.CommandText = Command;
                return SqlCeCommand.ExecuteReader();
            }
            else
                return null;
        }

        /// <summary>
        /// Helper method to execute a scalar for the database.
        /// </summary>
        /// <returns>The string associated with the command.</returns>
        private static string ExecuteScalar()
        {
            SqlCeCommand.Parameters.Clear();
            if (SelectedConnection.State == System.Data.ConnectionState.Open)
            {
                SqlCeCommand.CommandText = Command;
                return SqlCeCommand.ExecuteScalar().ToString();
            }
            else
                return "Database connection invalid.";
        }
        #endregion
    }
}
