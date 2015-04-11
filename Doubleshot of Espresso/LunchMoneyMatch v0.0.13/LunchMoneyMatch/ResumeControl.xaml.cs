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
    /// Interaction logic for ResumeControl.xaml
    /// </summary>
    public partial class ResumeControl : UserControl
    {
        public ResumeControl()
        {
            InitializeComponent();

        }

        #region Public Methods

        /// <summary>
        /// A method to add another expander to an existing element.
        /// </summary>
        /// <param name="parentName">The parent element to add to.</param>
        /// <param name="thisName">This elements new name.</param>
        /// <param name="hasBorder">Will the expander have a blue border at its opening and closing</param>
        public void addExpander(String parentName, String thisName, Boolean hasBorder)
        {
            StackPanel rootPanel;

            if ((rootPanel = getStackPanel(parentName, true)) == null)
                throw new ArgumentException("That StackPanel cannot be found or is null.", "parentName");
            if (String.IsNullOrWhiteSpace(thisName))
                throw new ArgumentException("The name for the new Expander cannot be empty.", "thisName");

            Border innerBorder = null;

            if (hasBorder)
            {
                innerBorder = new Border();
                innerBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB3CCF0"));
                innerBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                innerBorder.Margin = new Thickness(12, 10, 0, 10);
            }

            Expander theExpander = new Expander();
            theExpander.Header = thisName;
            theExpander.Margin = new Thickness(0, 5, 0, 5);

            StackPanel newPanel = new StackPanel();
            StackPanels.Add(new myStackPanel(thisName, newPanel));

            if (innerBorder != null)
            {
                innerBorder.Child = newPanel;
                theExpander.Content = innerBorder;
            }
            else
                theExpander.Content = newPanel;

            rootPanel.Children.Add(theExpander);

        }

        /// <summary>
        /// A method to add a body of text to a parent element.
        /// </summary>
        /// <param name="parentName">The element to add the text to.</param>
        /// <param name="theText">The text to add.</param>
        public void addText(String parentName, String theText)
        {
            StackPanel rootPanel;

            if ((rootPanel = getStackPanel(parentName, true)) == null)
                throw new ArgumentException("That StackPanel cannot be found or is null.", "parentName");
            if (String.IsNullOrWhiteSpace(theText))
                throw new ArgumentException("The text for this element cannot be null or empty.", "theText");


            TextBlock theTextBlock = new TextBlock();
            theTextBlock.TextWrapping = TextWrapping.Wrap;
            theTextBlock.Margin = new Thickness(12, 5, 0, 5);
            theTextBlock.Text = theText;

            rootPanel.Children.Add(theTextBlock);
        }

        /// <summary>
        /// A method to add a button to a parent element.
        /// </summary>
        /// <param name="parentName">The parent elements name</param>
        /// <param name="buttonText">The text for inside the button</param>
        /// <param name="eventHandler">The click event handler for when the button is clicked.</param>
        public void addButton(String parentName, String buttonText, RoutedEventHandler eventHandler)
        {
            StackPanel rootPanel;

            if ((rootPanel = getStackPanel(parentName,true)) == null)
                throw new ArgumentException("That StackPanel cannot be found or is null.", "parentName");
            if (String.IsNullOrWhiteSpace(buttonText))
                throw new ArgumentException("The button text annot be null or empty.", "buttonText");

            Button theButton = new Button();
            theButton.Margin = new Thickness(12, 5, 0, 5);
            theButton.Padding = new Thickness(5);
            theButton.Background = Brushes.White;
            theButton.Content = buttonText;
            theButton.HorizontalAlignment = HorizontalAlignment.Left;

            theButton.Click += eventHandler;

            rootPanel.Children.Add(theButton);
        }

        /// <summary>
        /// Removes a particular expander with a given name. 
        /// (Cannot be a root category)
        /// </summary>
        /// <param name="expanderName">The name of the expander to remove</param>
        public void removeExpander(String expanderName)
        {
            StackPanel rootPanel;
            if ((rootPanel = getStackPanel(expanderName, false)) == null)
                throw new ArgumentException("That StackPanel cannot be found or is null.", "parentName");

            Border borderToRemove = (rootPanel.Parent is Border) ? (Border)rootPanel.Parent : null;
            Expander expToRemove = null;

            if (borderToRemove != null)
                expToRemove = borderToRemove.Parent as Expander;
            else
                expToRemove = rootPanel.Parent as Expander;

            rootPanel = (StackPanel)expToRemove.Parent;
            
            if (expToRemove != null)
            {
                rootPanel.Children.Remove(expToRemove);
                
            }

            

        }

        public void addRootCategory(String categoryName, Boolean hasBorder)
        {
            StackPanel rootPanel = (StackPanel)this.FindName("RootPanel");

            if (rootPanel == null)
                throw new ArgumentException("That StackPanel cannot be found or is null.", "parentName");
            if (String.IsNullOrWhiteSpace(categoryName))
                throw new ArgumentException("The name for the new Category cannot be empty.", "thisName");

            Border innerBorder = null;

            if (hasBorder)
            {
                innerBorder = new Border();
                innerBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB3CCF0"));
                innerBorder.BorderThickness = new Thickness(0, 1, 0, 1);
                innerBorder.Margin = new Thickness(12, 10, 0, 10);
            }

            Expander theExpander = new Expander();
            theExpander.Header = categoryName;
            theExpander.Margin = new Thickness(0, 5, 0, 5);

            StackPanel newPanel = new StackPanel();
            StackPanels.Add(new myStackPanel(categoryName, newPanel));

            if (innerBorder != null)
            {
                innerBorder.Child = newPanel;
                theExpander.Content = innerBorder;
            }
            else
                theExpander.Content = newPanel;

            rootPanel.Children.Add(theExpander);
        }

        public void addRootCategories(String[] categories, Boolean hasBorder)
        {
            StackPanel rootPanel = (StackPanel)this.FindName("RootPanel");

            if (rootPanel == null)
                throw new ArgumentException("That StackPanel cannot be found or is null.", "parentName");


        }


        #endregion

        #region Private Methods

        /// <summary>
        /// A method that retrieves a stack panel with a given name.
        /// </summary>
        /// <param name="name">The name of the stackpanel</param>
        /// <returns>The StackPanel</returns>
        private StackPanel getStackPanel(String name, bool canBeCategory)
        {
            if (Categories.Contains(name))
            {
                if (canBeCategory)
                    return (StackPanel)this.FindName(name);
            }
            else
                foreach (myStackPanel mSP in StackPanels)
                    if (mSP.Name.Equals(name))
                        return mSP.Panel;
            return null;
        }

        #endregion

        #region Private Properties

        private List<string> Categories = new List<string>() { "Objective", "Skills", "Education", "Work_History", "Achievements", "Awards",
                                                                "Certifications", "Hobbies", "Social", "Community", "References"};
        private List<myStackPanel> StackPanels = new List<myStackPanel>();

        #endregion

        #region Private Classes

        /// <summary>
        /// A class to keep track of Stack Panels and their names
        /// </summary>
        private class myStackPanel
        {
            public String Name { get; set; }
            public StackPanel Panel { get; set; }
            public myStackPanel(String name, StackPanel sp)
            {
                this.Name = name;
                this.Panel = sp;
            }
        }

        #endregion

        //Not currentlty working
        #region Dependency Properties

        static ResumeControl()
        {

        }

        public static readonly DependencyProperty InnerBorderColorProperty = DependencyProperty.Register("InnerBorderColor", typeof(Color), typeof(ResumeControl));


        public Color InnerBorderColor
        {
            get { return (Color)GetValue(InnerBorderColorProperty); }
            set { SetValue(InnerBorderColorProperty, value); }
        }

        #endregion

    }
}

