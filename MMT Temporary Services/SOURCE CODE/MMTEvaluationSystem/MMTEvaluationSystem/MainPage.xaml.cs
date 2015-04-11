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
using MahApps.Metro.Controls;

namespace MMTEvaluationSystem
{

    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public string Selected = "Employee";
        private List<DataEmployeeInformation> EmployeeData;
        private List<EmployeeItem> EmployeeItems;

        private List<DataEmployerInformation> EmployerData;
        private List<EmployerItem> EmployerItems;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overloaded Constructor
        /// </summary>
        /// <param name="Employees">The list of all employees.</param>
        /// <param name="Employers">The list of all employers.</param>
        public MainPage(List<DataEmployeeInformation> Employees, List<DataEmployerInformation> Employers)
        {
            InitializeComponent();

            EmployeeItems = new List<EmployeeItem>();
            EmployeeData = Employees;
            initializeEmployeeItems();

            EmployerItems = new List<EmployerItem>();
            EmployerData = Employers;
            initializeEmployerItems();

            loadItems();
        }

        /// <summary>
        /// Updates the page's list of employees.
        /// </summary>
        /// <param name="EmployeeList">The list of all employees.</param>
        public void UpdateList(List<DataEmployeeInformation> EmployeeList)
        {
            EmployeeData = EmployeeList;
            clearContent();
            initializeEmployeeItems();
            loadItems();
        }

        /// <summary>
        /// Updates the page's list of employers.
        /// </summary>
        /// <param name="EmployerList">The list of all employers.</param>
        public void UpdateList(List<DataEmployerInformation> EmployerList)
        {
            EmployerData = EmployerList;
            clearContent();
            initializeEmployerItems();
            loadItems();
        }

        /// <summary>
        /// Helper method that switches between the employee and employer content.
        /// </summary>
        /// <param name="Selection">The content to switch to (Employees, Employers).</param>
        public void SwitchSelected(string Selection)
        {
            switch (Selection)
            {
                case "Employees":
                    Selected = "Employee";
                    clearContent();
                    EmployeeData = DataController.GetAllEmployees();
                    initializeEmployeeItems();
                    loadItems();
                    break;

                case "Employers":
                    Selected = "Employer";
                    clearContent();
                    EmployerData = DataController.GetAllEmployers();
                    initializeEmployerItems();
                    loadItems();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Clears all items and content within the page.
        /// </summary>
        private void clearContent()
        {
            stackPanelItems.Children.Clear();
            gridContent.Children.Clear();
        }

        /// <summary>
        /// Add employees or employers to the page's stack.
        /// </summary>
        /// <param name="Type">The type of item.</param>
        /// <param name="Item">The item to be added to the stack.</param>
        public void addToStack(string Type, object Item)
        {
            switch (Type)
            {
                case "Employee":
                    ((EmployeeItem)Item).setItemClickEvent(item_Click);
                    stackPanelItems.Children.Add((EmployeeItem)Item);
                    EmployeeItems.Add((EmployeeItem)Item);
                    break;
                case "Employer":
                    ((EmployerItem)Item).setItemClickEvent(item_Click);
                    stackPanelItems.Children.Add((EmployerItem)Item);
                    EmployerItems.Add(((EmployerItem)Item));
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Helper method designed to initialize employee items with respect to the page's data.
        /// </summary>
        private void initializeEmployeeItems()
        {
            EmployeeItems.Clear();
            foreach (DataEmployeeInformation ei in EmployeeData)
            {
                EmployeeItems.Add(new EmployeeItem(ei,DataController.GetEvaluations(ei.EmployeeNumber),this));
                EmployeeItems[EmployeeItems.Count - 1].setItemClickEvent(item_Click);
            }
        }

        /// <summary>
        /// Helper method designed to initialize employer items with respect to the page's data.
        /// </summary>
        private void initializeEmployerItems()
        {
            EmployerItems.Clear();
            foreach (DataEmployerInformation ei in EmployerData)
            {
                EmployerItems.Add(new EmployerItem(ei,this));
                EmployerItems[EmployerItems.Count - 1].setItemClickEvent(item_Click);
            }
        }

        /// <summary>
        /// Loads the page's stack with the respective content.
        /// </summary>
        private void loadItems()
        {
            switch (Selected)
            {
                case "Employee":
                    foreach (EmployeeItem ei in EmployeeItems)
                    {
                        stackPanelItems.Children.Add(ei);
                    }
                    break;
                case "Employer":
                    foreach (EmployerItem ei in EmployerItems)
                    {
                        stackPanelItems.Children.Add(ei);
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Event handler designed to display the content of the item clicked.
        /// </summary>
        /// <param name="sender">EmployeeItem or EmployerItem</param>
        /// <param name="e">Click</param>
        private void item_Click(object sender, MouseEventArgs e)
        {
            Type ItemType = (((MetroContentControl)((Border)sender).Parent).Parent).GetType();
            if (ItemType.Name == "EmployeeItem")
            {
                EmployeeItem rootClass = (EmployeeItem)((MetroContentControl)((Border)sender).Parent).Parent;
                rootClass.contentControlRoot.Reload();
                highlightClick(rootClass);
                if (gridContent.Children.Count == 0)
                {
                    contentControlContent.Reload();
                    gridContent.Children.Add(rootClass.EmployeeContent);
                }
                else
                {
                    gridContent.Children.RemoveAt(0);
                    contentControlContent.Reload();
                    gridContent.Children.Add(rootClass.EmployeeContent);
                }
            }
            else if (ItemType.Name == "EmployerItem")
            {
                EmployerItem rootClass = (EmployerItem)((MetroContentControl)((Border)sender).Parent).Parent;
                rootClass.contentControlRoot.Reload();
                highlightClick(rootClass);
                rootClass.EmployerContent.FieldPlacementManager.btnRefresh_Click(null, null);
                if (gridContent.Children.Count == 0)
                {
                    contentControlContent.Reload();
                    gridContent.Children.Add(rootClass.EmployerContent);
                }
                else
                {
                    gridContent.Children.RemoveAt(0);
                    contentControlContent.Reload();
                    gridContent.Children.Add(rootClass.EmployerContent);
                }
            }
        }

        /// <summary>
        /// Helper method designed to highlight the item that was clicked.
        /// </summary>
        /// <param name="Item">EmployerItem or EmployeeItem</param>
        private void highlightClick(object Item)
        {
            switch (Selected)
            {
                case "Employee":
                    EmployeeItem selectedEmployeeItem = (EmployeeItem)Item;
                    foreach (EmployeeItem ei in EmployeeItems)
                    {
                        if (ei == selectedEmployeeItem)
                            ei.gridRoot.Background = DataController.MMT_ANALOGOUS_BLUE;
                        else
                            ei.gridRoot.Background = DataController.MMT_BACKGROUND_GRAY;
                    }
                    break;
                case "Employer":
                    EmployerItem selectedEmployerItem = (EmployerItem)Item;
                    foreach (EmployerItem ei in EmployerItems)
                    {
                        if (ei == selectedEmployerItem)
                            ei.gridRoot.Background = DataController.MMT_ANALOGOUS_BLUE;
                        else
                            ei.gridRoot.Background = DataController.MMT_BACKGROUND_GRAY;
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Event handler designed to display the add controls of the selected content.
        /// </summary>
        /// <param name="sender">btnAddNew</param>
        /// <param name="e">Click</param>
        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            switch (Selected)
            {
                case "Employee":
                    if (gridContent.Children.Count == 0)
                    {
                        contentControlContent.Reload();
                        gridContent.Children.Add(new EmployeeAdd(this));
                    }
                    else
                    {
                        gridContent.Children.RemoveAt(0);
                        contentControlContent.Reload();
                        gridContent.Children.Add(new EmployeeAdd(this));
                    }
                    break;
                case "Employer":
                    if (gridContent.Children.Count == 0)
                    {
                        contentControlContent.Reload();
                        gridContent.Children.Add(new EmployerAdd(this));
                    }
                    else
                    {
                        gridContent.Children.RemoveAt(0);
                        contentControlContent.Reload();
                        gridContent.Children.Add(new EmployerAdd(this));
                    }
                    break;
                default:
                    throw new Exception("Unhandled Add New: " + Selected);
            }
            
        }
    }
}
