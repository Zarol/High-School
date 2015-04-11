using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSEServer
{
    class UserInfo
    {
        string firstname;
        string lastname;
        string email;
        public UserInfo(string email, string firstname, string lastname)
        {
            this.email = email;
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public string getFirstName() { return firstname; }
        public string getLastName() { return lastname; }
        public string getEmail() { return email; }
    }
}
