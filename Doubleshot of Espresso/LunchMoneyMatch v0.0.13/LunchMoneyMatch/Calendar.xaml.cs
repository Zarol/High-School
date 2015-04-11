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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Page
    {
        DateTime Now;
        int YearCount, MonthCount;
        string SelectedCalendar;
        MonthCalendar MonthCalendar;
        public Calendar()
        {
            InitializeComponent();
            Now = DateTime.Now;
            setDateLabel();
            SelectedCalendar = "Month";
            CreateNewCalendar();
            addSelectedCalendar();
            
        }

        private void setDateLabel()
        {
            string Month, Year;
            switch (Now.AddYears(YearCount).AddMonths(MonthCount).Month)
            {
                case 1:
                    Month = "January";
                    break;
                case 2:
                    Month = "Februrary";
                    break;
                case 3:
                    Month = "March";
                    break;
                case 4:
                    Month = "April";
                    break;
                case 5:
                    Month = "May";
                    break;
                case 6:
                    Month = "June";
                    break;
                case 7:
                    Month = "July";
                    break;
                case 8:
                    Month = "August";
                    break;
                case 9:
                    Month = "September";
                    break;
                case 10:
                    Month = "October";
                    break;
                case 11:
                    Month = "November";
                    break;
                case 12:
                    Month = "December";
                    break;
                default:
                    Month = "Switch Mis-Match";
                    break;
            }
            Year = Now.AddYears(YearCount).AddMonths(MonthCount).Year.ToString();
            lblMonthYear.Content = Month + " " + Year;
        }

        private void incrementDate(int Year, int Month)
        {
            MonthCount += Month;
            YearCount += Year;
            if (MonthCount == 12)
            {
                MonthCount = 0;
                YearCount++;
            }
            else if (MonthCount == 0)
            {
                MonthCount = 12;
                YearCount--;
            }
        }

        private void addSelectedCalendar()
        {
            switch (SelectedCalendar)
            {
                case "Month":
                    if (gridCalendar.Children.Count != 0)
                    {
                        contentControlCalendar.Reload();
                        gridCalendar.Children.RemoveAt(0);
                        gridCalendar.Children.Add(MonthCalendar);
                    }
                    else
                    {
                        contentControlCalendar.Reload();
                        gridCalendar.Children.Add(MonthCalendar);
                    }
                    break;
                default:
                    contentControlCalendar.Reload();
                    gridCalendar.Children.Add(MonthCalendar);
                    break;
            }
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            incrementDate(0, -1);
            setDateLabel();
            CreateNewCalendar();
            addSelectedCalendar();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            incrementDate(0, 1);
            setDateLabel();
            CreateNewCalendar();
            addSelectedCalendar();
        }

        private void btnToday_Click(object sender, RoutedEventArgs e)
        {
            YearCount = 0;
            MonthCount = 0;
            setDateLabel();
            CreateNewCalendar();
            addSelectedCalendar();
        }

        private void CreateNewCalendar()
        {
            switch (SelectedCalendar)
            {
                case "Month":
                    MonthCalendar = new MonthCalendar(Now.AddYears(YearCount).Year, Now.AddMonths(MonthCount).Month);
                    break;
                default:
                    break;
            }
        }


    }
}
