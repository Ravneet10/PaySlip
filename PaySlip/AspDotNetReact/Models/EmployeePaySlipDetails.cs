using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDotNetReact.Models
{
    public class EmployeePaySlipDetails
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string PayPeriod { set; get; }
        public double GrossIncome { set; get; }
        public double IncomeTax { set; get; }
        public double NetIncome { set; get; }
        public double Super { set; get; }
    }   
}