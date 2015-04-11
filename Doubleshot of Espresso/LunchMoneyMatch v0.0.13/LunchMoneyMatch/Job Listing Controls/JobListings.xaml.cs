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
using System.Windows.Media.Animation;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using LunchMoneyMatch.Server;

namespace LunchMoneyMatch
{


    /// <summary>
    /// Interaction logic for JobListings.xaml
    /// </summary>
    public partial class JobListings : Page
    {
        ServerControl sc;
        public JobListings(ServerControl sc)
        {
            this.sc = sc;
            InitializeComponent();
        }

        private void gridRoot_Loaded(object sender, RoutedEventArgs e)
        {
           // Test();
        }

        public void Test()
        {
            if (sc.CanConnect())
            {
                
            }
            else
            {
                gridMatchRange.Visibility = Visibility.Hidden;

                #region Listing One
                JobListingItem listingOne = new JobListingItem(98, "Space Monkey", "Your duty is to get on the space shuttle and fly it.", "NASA", "Cape Canaveral / Space");
                listingOne.setClickEvent(itemBtnApply_Click);
                listingOne.Application.AddFreeResponseQuestion("What is your favorite super hero?", 1500);
                List<string> mc1 = new List<string>();
                mc1.Add("99");
                mc1.Add("A Google");
                mc1.Add("'The value of Pi'");
                mc1.Add("Any number with the prefix 'Hella'");
                listingOne.Application.AddMultipleChoiceQuestion("In your opinion, which of the values is larger?", mc1);
                listingOne.Application.AddFreeResponseQuestion("Is Saharath the absolute most amazing man on this entire Earth?");
                listingOne.Application.AddFreeResponseQuestion("If you've answered no, at least explain why Saharath is better than Ivica in as many ways possible.", 3000);
                stackPanelMatches.Children.Add(listingOne);
                #endregion

                #region Listing Two
                JobListingItem listingTwo = new JobListingItem();
                listingTwo.setClickEvent(itemBtnApply_Click);
                listingTwo.Application.AddFreeResponseQuestion("Grrr rawr rawr grrr?");
                stackPanelMatches.Children.Add(listingTwo);
                #endregion

                stackPanelMatches.Children.Add(new JobListingItem());
                stackPanelMatches.Children.Add(new JobListingItem());
                stackPanelMatches.Children.Add(new JobListingItem());
                stackPanelMatches.Children.Add(new JobListingItem());
                stackPanelMatches.Children.Add(new JobListingItem());
                stackPanelMatches.Children.Add(new JobListingItem());
                stackPanelMatches.Children.Add(new JobListingItem());
                stackPanelMatches.Children.Add(new JobListingItem());
            }
        }

        private void itemBtnApply_Click(object sender, RoutedEventArgs e)
        {
            Button sender_ = (Button)sender;
            Grid rootGrid = (Grid)sender_.Parent;
            Border rootBorder = (Border)rootGrid.Parent;
            JobListingItem rootClass = (JobListingItem)rootBorder.Parent;
            if (gridJobApplication.Children.Count != 0)
            {
                gridJobApplication.Children.RemoveAt(0);
                contentControlApplication.Reload();
                gridJobApplication.Children.Add(rootClass.Application);
            }
            else
            {
                gridJobApplication.Children.Add(rootClass.Application);            
                Storyboard collapseItems = (Storyboard)gridItems.FindResource("CollapseItems");
                collapseItems.Begin();
            }
            

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }
    }
}
