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

namespace MMTEvaluationSystem
{
    /// <summary>
    /// Interaction logic for InformationButtons.xaml
    /// </summary>
    public partial class InformationButtons : UserControl
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public InformationButtons()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Helper method designed to route the events of all the buttons within this control.
        /// </summary>
        /// <param name="Edit">The method associated with the Edit button's click event.</param>
        /// <param name="Okay">The method associated with the Okay button's click event.</param>
        /// <param name="Cancel">The method associated with the Cancel button's click event.</param>
        public void setAllButtonClickEvents(RoutedEventHandler Edit, RoutedEventHandler Okay, RoutedEventHandler Cancel)
        {
            setEditClickEvent(Edit);
            setOkayClickEvent(Okay);
            setCancelClickEvent(Cancel);
        }

        /// <summary>
        /// Designed to route btnEdit's click event.
        /// </summary>
        /// <param name="Method">The method to route btnEdit's click event to.</param>
        public void setEditClickEvent(RoutedEventHandler Method)
        {
            btnEdit.Click += Method;
        }

        /// <summary>
        /// Designed to route btnOkay's click event.
        /// </summary>
        /// <param name="Method">The method to route btnOkay's click event to.</param>
        public void setOkayClickEvent(RoutedEventHandler Method)
        {
            btnOkay.Click += Method;
        }

        /// <summary>
        /// Designed to route btnCancel's click event.
        /// </summary>
        /// <param name="Method">The method to route btnCancel's click event to.</param>
        public void setCancelClickEvent(RoutedEventHandler Method)
        {
            btnCancel.Click += Method;
        }
    }
}
