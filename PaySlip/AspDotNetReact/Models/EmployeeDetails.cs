using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspDotNetReact.Models
{
    public class EmployeeDetails
    {

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public double AnnualSalary { set; get; }
        public double SuperRate { set; get; }
        public string SalaryMonth { set; get; }

    }
}