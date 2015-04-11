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
    /// Interaction logic for CollegeControl.xaml
    /// </summary>
    public partial class CollegeControl : UserControl
    {
        CollegeInfo CollegeInfo;

        public CollegeControl()
        {
            InitializeComponent();
            CollegeInfo = new CollegeInfo();
        }

        public CollegeControl(CollegeInfo CollegeInfo)
        {
            InitializeComponent();
            this.CollegeInfo = CollegeInfo;
            initializeFields();
        }

        public CollegeInfo getCollegeInfo()
        {
            return CollegeInfo;
        }

        private void initializeFields()
        {
            txtCollegeName = CollegeInfo.CollegeName;
            comboCollegeState.selectedItem = CollegeInfo.CollegeState;
            comboCollegeGPA.selectedItem = CollegeInfo.CollegeGPA;
            comboCollegeDegree.selectedItem = CollegeInfo.CollegeDegree;
            txtCollegeMajor = CollegeInfo.CollegeMajor;
            comboCollegeStartYear.selectedItem = CollegeInfo.CollegeStartYear;
            comboCollegeEndYear.selectedItem = CollegeInfo.CollegeEndYear;
        }

        //Add all the checks, if check is invalid, set local (CollegeInfo.isValid = false)
        //REGEX years 01/01/2013
    }
}
