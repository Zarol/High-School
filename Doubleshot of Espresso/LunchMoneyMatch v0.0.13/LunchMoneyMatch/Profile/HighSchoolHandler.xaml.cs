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
    public struct HighSchoolInfo
    {
        public string SchoolName, State;
        public DateTime StartYear, EndYear;
        public bool Graduated;
        public double GPA;
        public bool isValid;
        public HighSchoolInfo(string SchoolName, string State, DateTime StartYear, DateTime EndYear, bool Graduated, double GPA)
        {
            this.SchoolName = SchoolName;
            this.State = State;
            this.StartYear = StartYear;
            this.EndYear = EndYear;
            this.Graduated = Graduated;
            this.GPA = GPA;
            isValid = false;
        }
    }

    /// <summary>
    /// Interaction logic for HighSchoolHandler.xaml
    /// </summary>
    public partial class HighSchoolHandler : UserControl
    {
        private HighSchoolButtons highSchoolButtons;
        private List<HighSchoolInfo> ListHighSchoolInfo;
        private List<HighSchoolControl> ListHighSchoolControl;

        /// <summary>
        /// Default Test Constructor
        /// </summary>
        public HighSchoolHandler()
        {
            InitializeComponent();
            highSchoolButtons = new HighSchoolButtons();
            highSchoolButtons.setAdd_Click(btnAdd_Click);
            highSchoolButtons.setRemove_Click(btnRemove_Click);
            ListHighSchoolInfo = new List<HighSchoolInfo>();
            ListHighSchoolInfo.Add(new HighSchoolInfo("A-Tech", "Nevada", new DateTime(2009, 8, 1), new DateTime(2013, 6, 11), true, 3.75));
            ListHighSchoolInfo.Add(new HighSchoolInfo("A-Tech2", "Nevada", new DateTime(2005, 8, 1), new DateTime(2009, 6, 11), false, 3.375));
            ListHighSchoolControl = new List<HighSchoolControl>();
            initializeHighSchoolInfo();
            stackRoot.Children.Add(highSchoolButtons);
        }

        public HighSchoolHandler(List<HighSchoolInfo> ListHighSchoolInfo)
        {
            InitializeComponent();
            highSchoolButtons = new HighSchoolButtons();
            highSchoolButtons.setAdd_Click(btnAdd_Click);
            highSchoolButtons.setRemove_Click(btnRemove_Click);
            this.ListHighSchoolInfo = ListHighSchoolInfo;
            ListHighSchoolControl = new List<HighSchoolControl>();
            initializeHighSchoolInfo();
            stackRoot.Children.Add(highSchoolButtons);
        }

        public List<HighSchoolInfo> getAllHighSchoolInfo()
        {
            setAllHighSchoolInfo();
            return ListHighSchoolInfo;
        }

        private void setAllHighSchoolInfo()
        {
            foreach (HighSchoolControl hsc in ListHighSchoolControl)
            {
                //check if valid, if not then don't add
                ListHighSchoolInfo.Add(hsc.getHighSchoolInfo());
            }
        }

        private void initializeHighSchoolInfo()
        {
            if (ListHighSchoolInfo != null && ListHighSchoolInfo.Count != 0)
            {
                foreach (HighSchoolInfo hsi in ListHighSchoolInfo)
                {
                    ListHighSchoolControl.Add(new HighSchoolControl(hsi));
                }
                foreach (HighSchoolControl hsc in ListHighSchoolControl)
                {
                    stackRoot.Children.Add(hsc);
                }
            }
            else
            {
                ListHighSchoolControl.Add(new HighSchoolControl());
                stackRoot.Children.Add(ListHighSchoolControl[0]);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ListHighSchoolControl != null && ListHighSchoolControl.Count != 4)
            {
                ListHighSchoolControl.Add(new HighSchoolControl());
                stackRoot.Children.Insert(ListHighSchoolControl.Count - 1, ListHighSchoolControl[ListHighSchoolControl.Count - 1]); //Add the last created high school control to the stack
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ListHighSchoolControl != null && ListHighSchoolControl.Count != 1)
            {
                ListHighSchoolControl.RemoveAt(ListHighSchoolControl.Count - 1);
                stackRoot.Children.RemoveAt(stackRoot.Children.Count - 2);
            }
        }
    }
}
