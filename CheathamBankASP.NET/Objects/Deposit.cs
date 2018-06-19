using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheathamBankASP.NET.Objects
{
    public class Deposit
    {
        public int TransNumber { get; set; }
        public  int CustAccountNumber { get; set; }
        public string TransType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set;}
    }
}