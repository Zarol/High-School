using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMTEvaluationSystem
{
    public class DataEmployerInformation
    {
        public int EmployerNumber { get; private set; }
        public string Name { get; private set; }       
        public string Street;
        public string City;
        public string State;
        public int Zip;
        public string Phone;
        public string Email;
        public string Contact;

        /// <summary>
        /// Default constructor for the data structor of an employer.
        /// </summary>
        /// <param name="EmployerNumber">The unique number.</param>
        /// <param name="Name">The name.</param>
        /// <param name="Street">The street address.</param>
        /// <param name="City">The city name.</param>
        /// <param name="State">The state name.</param>
        /// <param name="Zip">The 5-digit zip code.</param>
        /// <param name="Phone">The phone number.</param>
        /// <param name="Email">The email.</param>
        /// <param name="Contact">The employer's contact name.</param>
        public DataEmployerInformation(int EmployerNumber, string Name, string Street, string City, string State, int Zip, string Phone, string Email, string Contact)
        {
            this.EmployerNumber = EmployerNumber;
            this.Name = Name;
            this.Street = Street;
            this.City = City;
            this.State = State;
            this.Zip = Zip;
            this.Phone = Phone;
            this.Email = Email;
            this.Contact = Contact;
        }
    }
}
