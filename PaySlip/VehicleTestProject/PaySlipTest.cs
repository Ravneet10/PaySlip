using Microsoft.VisualStudio.TestTools.UnitTesting;

using Business.PaySlip.Interface;
using Business.PaySlip.Provider;
using Business.PaySlip.Model;
using System;

namespace VehicleTestProject
{
    [TestClass]
    public class PaySlipTest
    {

        EmployeeDetails employeeDetails = new EmployeeDetails
        {
           FirstName="Ravneet",
           LastName="Kaur",
           SalaryMonth="March",
           SuperRate=9,
           AnnualSalary=60050
        };
        EmployeeDetails employeeDetailsEmpty = new EmployeeDetails();
        
        [TestMethod]
        public void GeneratepaySlip()
        {
            double incometax = 922;
            try
            {
                IPaySlip ps = new PaySlipProvider();
                EmployeePaySlipDetails ed=ps.GeneratePaySlip(employeeDetails);
                Assert.AreEqual(incometax, ed.IncomeTax);
            }
            catch(Exception e)
            {
                Assert.Fail("Exception thrown",e.Message);
            }
            
        }

        [TestMethod]
        public void GeneratepaySlipTestCase2()
        {
            double incometax = 0;
            try
            {
                IPaySlip ps = new PaySlipProvider();
                EmployeePaySlipDetails ed = ps.GeneratePaySlip(employeeDetailsEmpty);
                Assert.AreEqual(incometax, ed.IncomeTax);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
    }
}
