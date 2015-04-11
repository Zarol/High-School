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

namespace LunchMoneyMatch
{
    #region Data Structure
    /// <summary>
    /// Data Structure for Notifications to be stored
    /// The Content and Link may only be defined during creation.
    /// The Index represents the current position in relation to other Notifications.
    /// </summary>
    struct Notifications
    {
        internal readonly String Content;
        internal Page Link;
        internal bool IsWarning;
        internal Notifications(String content, Page link, bool isWarning)
        {
            Content = content;
            Link = link;
            IsWarning = isWarning;
        }
    }
    #endregion

    /// <summary>
    /// Interaction logic for NotificationControl.xaml
    /// Note: If you wish to use the control in your page, the Notification Control MUST be passed in.
    /// </summary>
    public partial class AlertControl : UserControl
    {
        #region Public Methods
        /// <summary>
        /// Default Constructor
        /// Should only be created once on the Main Window to be used throughout the program.
        /// The Notification Control allows Messages to be displayed to the user.
        /// Each message may also be linked to a page. The newest message will always be displayed first.
        /// </summary>
        /// <param name="navigationSerivce"></param>
        public AlertControl(NavigationService navigationSerivce)
        {
            InitializeComponent();
            Notification = new Notifications();

            rollDown = (Storyboard)FindResource("rollDown");
            rollUp = (Storyboard)FindResource("rollUp");

            isRevealed = false;

            ControlTimer = new DispatcherTimer();
            ControlTimer.Tick += new EventHandler(ControlTimer_Tick);
            ControlTimer.Interval = new TimeSpan(0, 0, REVEAL_TIME);

            ns = navigationSerivce;
        }

        /// <summary>
        /// Pushes a message onto the Notification Control. The message will then be displayed immediately.
        /// </summary>
        /// <param name="message">The string that will be displayed to the user. MAX 60 Characters.</param>
        /// <param name="link">The page that user will go to when the message is clicked. May be null.</param>
        public void Push(String message, Page link)
        {
            Push(message, link, false);
        }

        /// <summary>
        /// Pushes a message onto the Notification Control. The message will then be displayed immediately.
        /// </summary>
        /// <param name="message">The string that will be displayed to the user. MAX 60 Characters.</param>
        /// <param name="link">The page that user will go to when the message is clicked. May be null.</param>
        /// <param name="isWarning">If the message is a warning, the color of the control will be red.</param>
        public void Push(String message, Page link, bool isWarning)
        {
            if (message.Length <= 70)
            {
                Notification = new Notifications(message, link, isWarning);
                updateContent();
                Reveal();
            }
            else
            {
                throw new Exception("Message is longer than 70 Characters!!!");
            }
        }

        /// <summary>
        /// Forces the Navigation Control to display itself as long as it is holding a notification.
        /// </summary>
        public void Reveal()
        {
            if (Notification.Content != "")
            {
                if (isRevealed == false)
                {
                    rollDown.Begin();
                    ControlTimer.Start();
                    isRevealed = true;
                }
            }
        }

        /// <summary>
        /// Tests the Notification Control by pushing notifications into the control.
        /// </summary>
        public void Test()
        {
          //  Push("Grrrr.", new Navigation(sc), true);
        }
        #endregion

        #region Private Variables
        Notifications Notification;
        const int REVEAL_TIME = 15;
        DispatcherTimer ControlTimer;
        Storyboard rollDown, rollUp;
        bool isRevealed;
        NavigationService ns;
        #endregion

        #region Private Methods
        /// <summary>
        /// Helper method designed to update the Navigation Control's XAML controls to whichever notification is selected.
        /// It must be called after any edits are made to the data of Navigation Control.
        /// </summary>
        private void updateContent()
        {
            lblContent.Content = Notification.Content;
            if (Notification.Link != null)
                    lblContent.Foreground = Brushes.White;
                else
                    lblContent.Foreground = Brushes.Black;
            if (Notification.IsWarning == true)
                    gridContent.Background = (Brush)new BrushConverter().ConvertFrom("#CC0000");
                else
                    gridContent.Background = (Brush)new BrushConverter().ConvertFrom("#41a907");
        }

        /// <summary>
        /// The Tick trigger method for the ControlTimer.
        /// It is designed to hide the control after the timer's interval has passed.
        /// It will also stop itself from triggering again.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlTimer_Tick(object sender, EventArgs e)
        {
            rollUp.Begin();
            isRevealed = false;
            if (sender != null)
                (sender as DispatcherTimer).Stop();
        }


        /// <summary>
        /// This method will remove the currently selected notification from the control.
        /// It will also bring up the next notification if there is another one.
        /// </summary>
        /// <param name="sender">The Remove Button (btnRemove).</param>
        /// <param name="e">The Click Event.</param>
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ControlTimer_Tick(null, null);
            updateContent();
        }

        /// <summary>
        /// This method will take the user to page that has been linked by the selected
        /// content as long as it exists. It will also dispose of the content in the process.
        /// </summary>
        /// <param name="sender">The notification content (lblContent).</param>
        /// <param name="e">The Preview Mouse Left Button Up Event.</param>
        private void lblContent_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
                if (Notification.Link != null)
                {
                    ns.Navigate(Notification.Link);
                    btnRemove_Click(null, null);
                }
        }
        #endregion
    }

    /// <summary>
    /// This class dynmically set's the actual notification bar from the actual location of the control.
    /// It offsets it vertically and makes room for the window's header.
    /// </summary>
    internal class offsetVertical : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new Thickness((double)value[0], -((double)value[1] + 30), (double)value[2], (double)value[3] + 30);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
