using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchMoneyMatch.Server
{
    /// <summary>
    /// This class is for creating a instance and storing UserInformation.
    /// </summary>
    public class UserInfo
    {
        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private string state;
        private string email;
        private string zipCode;
        private string areaCode;
        private string phoneNumber1;
        private string phoneNumber2;
        private string phoneNumber3;
        private string mobileNumberString;
        private TcpConnect tc = null;
        /// <summary>
        /// Generic Constructor. 
        /// </summary>
        /// <param name="user">The username associated with the account.</param>
        /// <param name="pass">The password associated with the account.</param>
        /// 
        public UserInfo(string user, string pass,string firstname,string lastname,string address
            ,string city,string state, string email,string zipCode,string areaCode)
        {

        }
        public bool isLoginCorrect()
        {

            return false;
        }
    }
}
