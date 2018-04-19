using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheathamBankASP.NET.Objects
{
    public class Customer
    {
        public Customer() { }
        public int AccountNumber { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}