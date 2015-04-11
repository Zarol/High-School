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

//TODO: Go through and make sure items are NotFocusable (Tabbing)
//TODO: Alert the user of incorrect inputs

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        HelpPage HelpPage;
        ControlBar ControlBar;
        MainPage MainPage;
        string DataSelected = "Employee";
        string FilterSelected = "Unique Number";
        public static NavigationService NavigationService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();            
            NavigationService = frameContent.NavigationService;
            HelpPage = new HelpPage();
            ControlBar = new ControlBar();
            ControlBar.setSelectedSelectionChanged(comboSelected_SelectionChanged);
            ControlBar.setFilterSelectionChanged(comboFilter_SelectionChanged);
            ControlBar.setHelpClick(btnHelp_Click);
            MainPage = new MainPage(DataController.GetAllEmployees(), DataController.GetAllEmployers());
            comboSelected_SelectionChanged(ControlBar.comboSelected, null);
            comboFilter_SelectionChanged(ControlBar.comboFilter, null);

        }

        /// <summary>
        /// Event handler designed to close the database connection.
        /// </summary>
        /// <param name="sender">Window</param>
        /// <param name="e">Closed</param>
        private void Window_Closed(object sender, EventArgs e)
        {
            DataController.CloseConnection();
        }

        /// <summary>
        /// Event handler designed to open the database connection.
        /// </summary>
        /// <param name="sender">Window</param>
        /// <param name="e">Initialized</param>
        private void Window_Initialized(object sender, EventArgs e)
        {
            DataController.OpenConnection();
        }

        /// <summary>
        /// Event handler designed to populate the window when it is loaded.
        /// </summary>
        /// <param name="sender">MetroWindow</param>
        /// <param name="e">Loaded</param>
        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainPage);
            gridRoot.Children.Add(ControlBar);
        }

        /// <summary>
        /// Event handler designed to update the data selection.
        /// </summary>
        /// <param name="sender">comboSelected (ControlBar)</param>
        /// <param name="e">SelectionChanged</param>
        private void comboSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataSelected = ((ComboBox)sender).SelectedValue.ToString();
            DataSelected = DataSelected.Remove(0, 38);
            MainPage.SwitchSelected(DataSelected);
        }

        /// <summary>
        /// Event handler designed to udpate the sorting selection.
        /// </summary>
        /// <param name="sender">comboFilter (ControlBar)</param>
        /// <param name="e">SelectionChanged</param>
        private void comboFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterSelected = ((ComboBox)sender).SelectedValue.ToString();
            FilterSelected = FilterSelected.Remove(0, 38);
            List<DataEmployeeInformation> EmployeeList = new List<DataEmployeeInformation>();
            List<DataEmployerInformation> EmployerList = new List<DataEmployerInformation>();
            switch (DataSelected)
            {
                case "Employees":
                    EmployeeList = DataController.GetAllEmployees();
                    if (EmployeeList.Count == 0)
                        return;
                    break;
                case "Employers":
                    EmployerList = DataController.GetAllEmployers();
                    if (EmployerList.Count == 0)
                        return;
                    break;
            }
            switch (FilterSelected)
            {
                case "First Name":
                    switch (DataSelected)
                    {
                        case "Employees":
                            DataController.QuickSortEmployeeFirstName(EmployeeList, 0, EmployeeList.Count - 1);
                            break;
                        case "Employers":
                            DataController.QuickSortEmployerName(EmployerList, 0, EmployerList.Count - 1);
                            break;
                    }
                    break;
                case "Last Name":
                    switch (DataSelected)
                    {
                        case "Employees":
                            DataController.QuickSortEmployeeLastName(EmployeeList, 0, EmployeeList.Count - 1);
                            break;
                        case "Employers":
                            DataController.QuickSortEmployerName(EmployerList, 0, EmployerList.Count - 1);
                            break;
                    }
                    break;
                case "Unique Number":
                    switch (DataSelected)
                    {
                        case "Employees":
                            DataController.QuickSortEmployeeNumber(EmployeeList, 0, EmployeeList.Count - 1);
                            break;
                        case "Employers":
                            DataController.QuickSortEmployerNumber(EmployerList, 0, EmployerList.Count - 1);
                            break;
                    }
                    break;
                case "Overall Evaluation Score":
                    switch (DataSelected)
                    {
                        case "Employees":
                            DataController.QuickSortOverallEvaluations(EmployeeList, 0, EmployeeList.Count - 1);
                            break;
                        case "Employers":
                            DataController.QuickSortEmployerNumber(EmployerList, 0, EmployerList.Count - 1);
                            break;
                    }
                    break;
            }
            switch (DataSelected)
            {
                case "Employees":
                    MainPage.UpdateList(EmployeeList);
                    break;
                case "Employers":
                    MainPage.UpdateList(EmployerList);
                    break;
            }
        }

        /// <summary>
        /// Event handler designed to navigate to the Help Page.
        /// </summary>
        /// <param name="sender">btnHelp (ControlBar)</param>
        /// <param name="e">Click</param>
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(HelpPage);
        }
    }
}
