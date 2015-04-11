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
    /// Interaction logic for JobListingItem.xaml
    /// </summary>
    public partial class JobListingItem : UserControl
    {
        #region Public Variables
        //Each item has its own application
        public JobListingApplication Application;
        #endregion

        #region Public Methods
        /// <summary>
        /// Default Constructor that represents a test job listing item
        /// </summary>
        public JobListingItem()
        {
            InitializeComponent();

            lblMatchPercent.Content = "100%";
            txtJobTitle.Text = "Job Title";
            txtDescription.Text = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." + 
                "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." + 
                "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." + 
                "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
            txtCompanyName.Text = "Company Name";
            txtLocation.Text = "Job City, Job State";
            Application = new JobListingApplication();
        }

        /// <summary>
        /// The legitimate Constructor that creates a new Job Listing Item.
        /// </summary>
        /// <param name="jobMatch">The percent match of the job listing with the user.</param>
        /// <param name="jobTitle">The title of the job listing.</param>
        /// <param name="jobDescription">The general description of the job listing.</param>
        /// <param name="jobCompany">The company associated with the job listing.</param>
        /// <param name="jobLocation">The physical location of the job.</param>
        public JobListingItem(int jobMatch, string jobTitle, string jobDescription, string jobCompany, string jobLocation)
        {
            InitializeComponent();

            lblMatchPercent.Content = jobMatch.ToString() + "%";
            txtJobTitle.Text = jobTitle;
            txtDescription.Text = jobDescription;
            txtCompanyName.Text = jobCompany;
            txtLocation.Text = jobLocation;
            Application = new JobListingApplication();
        }

        /// <summary>
        /// This method will apply a click event method to the "apply" button.
        /// </summary>
        /// <param name="method">The method (RoutedEventHandler) to be called when the button is clicked.</param>
        public void setClickEvent(RoutedEventHandler method)
        {
            btnApply.Click += method;
        }
        #endregion
    }
}
