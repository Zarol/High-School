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
    /// Interaction logic for EmployerAdd.xaml
    /// </summary>
    public partial class EmployerAdd : UserControl
    {
        MainPage MainPage;

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="MainPage">The service's main page.</param>
        public EmployerAdd(MainPage MainPage)
        {
            InitializeComponent();
            InformationEdit.setEmployerEdit();
            InformationButtons.btnEdit.Visibility = Visibility.Hidden;
            InformationButtons.btnOkay.Visibility = Visibility.Visible;
            InformationButtons.setOkayClickEvent(btnOkay_Click);
            InformationButtons.btnCancel.Visibility = Visibility.Visible;
            InformationButtons.setCancelClickEvent(btnCancel_Click);
            InformationEdit.comboState.SelectedIndex = 0;
            this.MainPage = MainPage;
        }

        /// <summary>
        /// Checks if the information is valid.
        /// </summary>
        /// <returns>True if valid, false if invalid.</returns>
        private bool InformationValid()
        {
            if (InformationEdit.informationValid() == true && txtBoxCompany.Text != "")
            {
                return true;
            }
            else
            {
                if (txtBoxCompany.Text == "")
                    txtBoxCompany.Background = Brushes.Red;
                else
                    txtBoxCompany.Background = DataController.MMT_BACKGROUND_GRAY;
                return false;
            }
        }

        /// <summary>
        /// Creates an employer in the database and in the service's list.
        /// </summary>
        private void createEmployer()
        {
            List<object> info = new List<object>();
            info.Add(txtBoxCompany.Text);
            List<object> baseInfo = InformationEdit.getAllInformation();
            info.AddRange(baseInfo);
            DataEmployerInformation temp = new DataEmployerInformation(0, (string)info[0], (string)info[1], (string)info[2], (string)info[3], (int)info[4], (string)info[5], (string)info[6], (string)info[7]);
            temp.State = DataController.ConvertStateToAbbreviation((string)info[3]);
            DataController.AddEmployer(temp);

            MainPage.addToStack("Employer", new EmployerItem(DataController.GetEmployer(DataController.GetEmployerKeys()),MainPage));
            MainPage.gridContent.Children.Remove(this);
        }

        /// <summary>
        /// Creates an employer if the information is valid.
        /// </summary>
        /// <param name="sender">btnOkay</param>
        /// <param name="e">Click</param>
        private void btnOkay_Click(object sender, RoutedEventArgs e)
        {
            if (InformationValid())
            {
                createEmployer();
            }
        }

        /// <summary>
        /// Removes this control from the service.
        /// </summary>
        /// <param name="sender">btnCancel</param>
        /// <param name="e">Click</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainPage.gridContent.Children.Remove(this);
        }
    }
}
