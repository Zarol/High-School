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

//Necessary Metro Imports
using MahApps.Metro.Actions;
using MahApps.Metro.Behaviours;
using MahApps.Metro.Controls;
using MahApps.Metro.Converters;
using MahApps.Metro.Native;


//Current headers are: Objective, Skills, Education, Work_History, Achievements, Awards, Certifications, Hobbies, Social, Community, References

//TODO: Each Expander will contain one expander, each expander will probably contain multiple expanders (this time with headers such as Bachelor's Degree in Science but hiding information that state's he graduated from UNR) this is so we can control how much information is seen by the employer...
namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for Resume.xaml
    /// </summary>
    public partial class Resume : Page
    {
        public Resume()
        {
            InitializeComponent();
            LoadResumeInfo(null);
           // /*ResumeExpander work = new ResumeExpander("Work", true);
           // work.addTextElement("rawr");
           // work.addTextElement("zrawr");
           // ResumeController.addRootExpander(work);
           // ResumeExpander workz = new ResumeExpander("Workz", true);
           // workz.addTextElement("rawr");
           // workz.addTextElement("zrawr");
           // work.addExpanderElement(workz);*/
           //// ResumeController.addRootCategory(
           //// ResumeController.addRootCategory("Main Character", true);
           //// ResumeController.addText("Main Character", "Main String");
           //// ResumeController.addText("Main Character", "Main Character Stuff");
           //// ResumeController.addText("Main Character", "Other Stuff");

        }

        /// <summary>
        /// TODO: Load the resume information from the server
        /// </summary>
        /// <param name="info">Some type of object that contains the server information</param>
        public void LoadResumeInfo(Object info)
        {
            String[] categories = new String[] { "Objective", "Skills", "Education" };
            //ResumeController.addRootCategories(categories, false);
        }
    }
}
