using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMTEvaluationSystem
{
    public class DataEmployeeInformation
    {
        public int EmployeeNumber {  get; private set; }
        public string FirstName {  get; private set; }
        public string LastName {  get; private set; }
        public string Email;
        public string Phone;
        public string Cell;
        public string Street;
        public string City;
        public string State;
        public int Zip;

        /// <summary>
        /// Default Constructor for the data structure of an employee.
        /// </summary>
        /// <param name="EmployeeNumber">The unique number.</param>
        /// <param name="FirstName">The first name.</param>
        /// <param name="LastName">The last name.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Phone">The phone number.</param>
        /// <param name="Cell">The cell phone number.</param>
        /// <param name="Street">The street address.</param>
        /// <param name="City">The city name.</param>
        /// <param name="State">The state name.</param>
        /// <param name="Zip">The 5-digit zip code.</param>
        public DataEmployeeInformation(int EmployeeNumber, string FirstName, string LastName, string Email, string Phone, string Cell, string Street, string City, string State, int Zip)
        {
            this.EmployeeNumber = EmployeeNumber;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Cell = Cell;
            this.Street = Street;
            this.City = City;
            this.State = DataController.ConvertAbbreviationToState(State);
            this.Zip = Zip;
        }
    }
}
