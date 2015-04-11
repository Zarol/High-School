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
    /// Interaction logic for MonthCalendar.xaml
    /// </summary>
    public partial class MonthCalendar : UserControl
    {
        int Year, Month;
        DateTime Date;
        DayControl[,] Days;
        public MonthCalendar()
        {
            InitializeComponent();
            Date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            Days = new DayControl[7, 5];
            initializeDays();
        }

        public MonthCalendar(int Year, int Month)
        {
            InitializeComponent();
            Date = new DateTime(Year, Month, 1);
            this.Year = Year;
            this.Month = Month;
            Days = new DayControl[7, 5];
            initializeDays();
        }

        private void initializeDays()
        {
            int dayCounter = 0;
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        dayCounter -= (int)Date.DayOfWeek;
                    }
                    Days[col, row] = new DayControl(Date.AddDays(dayCounter).Day);
                    Grid.SetRow(Days[col, row], row+1);
                    Grid.SetColumn(Days[col, row], col);
                    gridRoot.Children.Add(Days[col, row]);
                    dayCounter++;
                }
            }
        }
    }
}
