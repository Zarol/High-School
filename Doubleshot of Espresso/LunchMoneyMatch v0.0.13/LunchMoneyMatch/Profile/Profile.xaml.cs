using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Text.RegularExpressions;

using LunchMoneyMatch.Server;

namespace LunchMoneyMatch
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// TODO: Need to transfer user's First Name, Last Name, Email Address, and Date of Birth to Profile Page. 
    /// TODO: Send all information to Resume Page
    /// </summary>
    public partial class Profile : Page
    {
        string firstName, lastName, address, city, currentState, highSchoolState, collegeState, email, zipcodeString, areaCodeString, phoneNumberString1, phoneNumberString2, mobileNumberString, highSchoolName, collegeName, collegeDegree, collegeMajor;
        int zipcode, phoneNumber1, phoneNumber2, mobileNumber;
        float highSchoolGPA, collegeGPA;

        #region Jay's Code
        HighSchoolHandler HighSchoolHandler;
        #endregion


        ServerControl sc = null;

        public Profile(ServerControl sc)
        {           
            this.sc = sc;
            InitializeComponent();

            HighSchoolHandler = new HighSchoolHandler();
            stackEducation.Children.Add(HighSchoolHandler);


            firstName = "";
            lastName = "";
            address = "";
            city = "";
            highSchoolState = "";
            collegeState = "";
            email = "";
            zipcodeString = "";
            areaCodeString = "";
            phoneNumberString1 = "";
            phoneNumberString2 = "";
            mobileNumberString = "";
            highSchoolName = "";
            collegeName = "";
            collegeMajor = "";
            zipcode = 0;
            collegeDegree = "";
            //areaCode = 0;
            phoneNumber1 = 0;
            phoneNumber2 = 0;
            mobileNumber = 0;
            //dateOfBirth = 0;


            FillStates();
            FillGPA();
            FillYears();
            FillDegree();
            

            //comboBoxStates.ItemsSource = _States;
            //comboBoxHighSchoolState.ItemsSource = _States;
            //comboBoxCollegeState.ItemsSource = _States;
            //comboBoxHighSchoolGPA.ItemsSource = _GPA;
            //comboBoxCollegeGPA.ItemsSource = _GPA;
            //comboBoxHighSchoolYear.ItemsSource = _Years;
            //comboBoxCollegeYear.ItemsSource = _Years;
        }
        public void FillStates()
        {
            _States.Add("Alabama");
            _States.Add("Alaska");
            _States.Add("Arizona");
            _States.Add("Arkansas");
            _States.Add("California");
            _States.Add("Colorado");
            _States.Add("Connecticut");
            _States.Add("Delaware");
            _States.Add("Florida");
            _States.Add("Georgia");
            _States.Add("Hawaii");
            _States.Add("Idaho");
            _States.Add("Illinois");
            _States.Add("Indiana");
            _States.Add("Iowa");
            _States.Add("Kansas");
            _States.Add("Kentucky");
            _States.Add("Louisiana");
            _States.Add("Maine");
            _States.Add("Maryland");
            _States.Add("Massachusetts");
            _States.Add("Michigan");
            _States.Add("Minnesota");
            _States.Add("Mississippi");
            _States.Add("Missouri");
            _States.Add("Montana");
            _States.Add("Nebraska");
            _States.Add("Nevada");
            _States.Add("New Hampshire");
            _States.Add("New Jersey");
            _States.Add("New Mexico");
            _States.Add("New York");
            _States.Add("North Carolina");
            _States.Add("North Dakota");
            _States.Add("Ohio");
            _States.Add("Oklahoma");
            _States.Add("Pennsylvania");
            _States.Add("Rhode Island");
            _States.Add("South Carolina");
            _States.Add("South Dakota");
            _States.Add("Tennessee");
            _States.Add("Texas");
            _States.Add("Utah");
            _States.Add("Vermont");
            _States.Add("Virginia");
            _States.Add("Washington");
            _States.Add("West Virginia");
            _States.Add("Wisconsin");
            _States.Add("Wyoming");
             
        }

        public void FillGPA()
        {
            for (int i = 0; i <= 40; i += 1)
            {
                _GPA.Add( (i/10.0F).ToString() );  //Initialize the GPA Combo Box
            }

        }

        public void FillYears()
        {
            for (int i = 1900; i <= DateTime.Today.Year; i++)  //Initialize the Years Combo Box
                _Years.Add(i);
        }
        private ObservableCollection<string> _States = new ObservableCollection<string>();
        public ObservableCollection<string> States 
        { 
            get 
            { 
                return _States; 
            }
           
        }
        private ObservableCollection<string> _GPA = new ObservableCollection<string>();
        public ObservableCollection<string> GPA
        {
            get
            {
                return _GPA;
            }

        }
        private ObservableCollection<int> _Years = new ObservableCollection<int>();
        public ObservableCollection<int> Years
        {
            get
            {
                return _Years;
            }

        }

        public void FillDegree()
        {
            //comboBoxDegree.Items.Add("Bachelor");
            //comboBoxDegree.Items.Add("Masters");
            //comboBoxDegree.Items.Add("PhD");
        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            //TODO: Get user's first name from server
            firstName = txtFirstName.Text;
         
         
        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TODO: Get user's last name from server
            lastName = txtLastName.ToString();
         
        }

        private void txtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            address = txtAddress.ToString();
            
        }

        private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
        {
            city = txtCity.ToString();
            
        }
       

        private void txtZipcode_TextChanged(object sender, TextChangedEventArgs e)
        {
            zipcodeString = txtZipcode.ToString();
            zipcode = int.Parse(zipcodeString);
            
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            //TODO: Get user's email address from server
            email = txtEmail.ToString();
            
        }

        private void txtAreaCode_LostFocus(object sender, RoutedEventArgs e)
        {
            bool success = true;
            areaCodeString = txtAreaCode.Text;
            
            if (areaCodeString.Length > 3 | areaCodeString.Length == 0)
            {
                success = false;
                txtAreaCode.Background = Brushes.Red;
            }
            else
            {
                if (ContainsLetters(areaCodeString))
                {
                    success = false;
                    txtAreaCode.Background = Brushes.Red;
                }
                else
                {
                    success = true;
                    txtAreaCode.Background = Brushes.White;
                }
                
            }
       
          
            if (success == true)
            {
                txtAreaCode.Background = Brushes.White;
                //areaCode = int.Parse(areaCodeString);

                txtAreaCode.Text = areaCodeString;
            }
          
        }
        public bool ContainsLetters(string areaCodeString)
        {
            //Regex regex = new Regex(@"^[azA-Z]");
            Regex regex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$");
            return regex.IsMatch(areaCodeString);
            
        }
        private void txtPhone1_LostFocus(object sender, RoutedEventArgs e)
        {
            bool success = true;
            phoneNumberString1 = txtPhone1.Text;
            if (phoneNumberString1.Length > 3 | phoneNumberString1.Length == 0)
            {
                success = false;
                txtPhone1.Background = Brushes.Red;
            }
            else
            {
                byte[] asciiBytes = Encoding.ASCII.GetBytes(phoneNumberString1);
                foreach (byte b in asciiBytes)
                {
                    for (int asc = 48; asc <= 57; asc++)
                    {
                        if (b == asc)
                        {
                            success = true;
                            txtPhone1.Background = Brushes.White;
                            break;

                        }
                        else
                        {
                            success = false;
                            txtPhone1.Background = Brushes.Red;
                        }
                    }
                }
            }


            if (success == true)
            {
                txtPhone1.Background = Brushes.White;
                phoneNumber1 = int.Parse(phoneNumberString1);

                txtPhone1.Text = phoneNumberString1;
            }
        }
        private void txtPhone2_LostFocus(object sender, RoutedEventArgs e)
        {
            bool success = true;
            phoneNumberString2 = txtPhone2.Text;

            if (phoneNumberString2.Length > 4 | phoneNumberString2.Length == 0)
            {
                success = false;
                txtPhone2.Background = Brushes.Red;
            }
            else
            {



                byte[] asciiBytes = Encoding.ASCII.GetBytes(phoneNumberString2);
                foreach (byte b in asciiBytes)
                {
                    for (int asc = 48; asc <= 57; asc++)
                    {
                        if (b == asc)
                        {
                            success = true;
                            txtPhone2.Background = Brushes.White;
                            break;

                        }
                        else
                        {
                            success = false;
                            txtPhone2.Background = Brushes.Red;
                        }
                    }
                }
            }

            if (success == true)
            {
                txtPhone2.Background = Brushes.White;
                phoneNumber2 = int.Parse(phoneNumberString2);

                txtPhone2.Text = phoneNumberString2;
            }
        }
        private void txtMobile_TextChanged(object sender, TextChangedEventArgs e)
        {
            mobileNumberString = txtMobile.ToString();
            mobileNumber = int.Parse(mobileNumberString);
            
        }

        private void comboBoxStates_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentState = comboBoxStates.SelectedValue.ToString();
            
        }

        //private void comboBoxHighSchoolState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    highSchoolState = comboBoxHighSchoolState.SelectedValue.ToString();
        //}

        //private void comboBoxCollegeState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    collegeState = comboBoxCollegeState.SelectedValue.ToString();
        //}
        //private void comboBoxHighSchoolGPA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    highSchoolGPA = float.Parse(comboBoxHighSchoolGPA.SelectedValue.ToString());
            
        //}

        //private void comboBoxCollegeGPA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    collegeGPA = float.Parse(comboBoxCollegeGPA.SelectedValue.ToString());
        //}

        //private void txtHighSchoolName_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    highSchoolName = txtHighSchoolName.Text;
        //}

        //private void txtCollegeName_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    collegeName = txtCollegeName.Text;
        //}

        //private void comboBoxDegree_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    collegeDegree = comboBoxDegree.SelectedValue.ToString();
        //}

        //private void txtCollegeMajor_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    collegeMajor = txtCollegeMajor.Text;
        //}

     

       

       
        
    }
}
