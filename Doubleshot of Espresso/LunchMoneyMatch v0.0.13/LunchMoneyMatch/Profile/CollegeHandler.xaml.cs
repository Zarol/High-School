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

namespace LunchMoneyMatch
{
    public struct CollegeInfo
    {
        public string CollegeName, CollegeMajor, CollegeState, CollegeDegree;
        public DateTime CollegeStartYear, CollegeEndYear;
        public double CollegeGPA;
        public bool isValid;
        public CollegeInfo(string CollegeName, string CollegeState, DateTime CollegeStartYear, DateTime CollegeEndYear, bool Graduated, double CollegeGPA, string CollegeMajor, string CollegeDegree)
        {
            this.CollegeName = CollegeName;
            this.CollegeState = CollegeState;
            this.CollegeStartYear = CollegeStartYear;
            this.CollegeEndYear = CollegeEndYear;
            this.CollegeGPA = CollegeGPA;
            this.CollegeMajor = CollegeMajor;
            this.CollegeDegree = CollegeDegree;
            isValid = false;
        }
    }
    /// <summary>
    /// Interaction logic for CollegeHandler.xaml
    /// </summary>
    public partial class CollegeHandler : UserControl
    {
        public CollegeHandler()
        {
            InitializeComponent();
        }
    }
}
