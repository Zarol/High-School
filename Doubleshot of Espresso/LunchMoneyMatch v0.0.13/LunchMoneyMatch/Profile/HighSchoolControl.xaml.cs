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
    /// <summary>
    /// Interaction logic for HighSchoolControl.xaml
    /// </summary>
    public partial class HighSchoolControl : UserControl
    {
        HighSchoolInfo HighSchoolInfo;

        /// <summary>
        /// Default Constructor that creates a blank high school information control
        /// </summary>
        public HighSchoolControl()
        {
            InitializeComponent();
            HighSchoolInfo = new HighSchoolInfo();
        }

        public HighSchoolControl(HighSchoolInfo HighSchoolInfo)
        {
            InitializeComponent();
            this.HighSchoolInfo = HighSchoolInfo;
            initializeFields();
        }

        public HighSchoolInfo getHighSchoolInfo()
        {
                return HighSchoolInfo;
        }

        private void initializeFields()
        {
            txtBoxSchoolName.Text = HighSchoolInfo.SchoolName;
            comboState.SelectedItem = HighSchoolInfo.State;
            txtBoxStartYear.Text = HighSchoolInfo.StartYear.ToShortDateString();
            txtBoxEndYear.Text = HighSchoolInfo.EndYear.ToShortDateString();
            chkGraduated.IsChecked = HighSchoolInfo.Graduated;
            txtBoxGPA.Text = HighSchoolInfo.GPA.ToString();
        }

        //Add all the checks, if check is invalid, set local (HighSchoolInfo.isValid = false)
        //REGEX years 01/01/2013
    }
}
