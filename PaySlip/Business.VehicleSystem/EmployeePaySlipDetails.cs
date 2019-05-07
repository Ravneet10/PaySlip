using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.PaySlip.Model
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
    public class EmployeeDetails
    {

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public double AnnualSalary { set; get; }
        public double SuperRate { set; get; }
        public string SalaryMonth { set; get; }

    }
}