﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Business.PaySlip.Interface;
using Business.PaySlip.Provider;
using Business.PaySlip.Model;
using Business.PaySlip.Domain;

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

        EmployeeDetails employeeDetailsNegative = new EmployeeDetails
        {
            FirstName = "",
            LastName = "",
            SalaryMonth = "March",
            SuperRate = 9,
            AnnualSalary = 60050
        };

        EmployeeDetails employeeDetailsEmpty = new EmployeeDetails();
        [TestMethod]
        public void PositiveGeneratepaySlip()
        {
            double incometax = 922;
            try
            {
                IPaySlip ps = new PaySlipProvider();
                EmployeePaySlipDetails ed = ps.GeneratePaySlip(employeeDetails);
                Assert.AreEqual(incometax, ed.IncomeTax);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }

        [TestMethod]
        public void NegativeGeneratepaySlip()
        {
            double incometax = 922;
            try
            {
                IPaySlip ps = new PaySlipProvider();
                EmployeePaySlipDetails ed=ps.GeneratePaySlip(employeeDetailsEmpty);
                Assert.AreEqual(incometax, ed.IncomeTax);
            }
            catch(Exception e)
            {
                Assert.Fail("Exception thrown",e.Message);
            }
            
        }

      
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeRoundData()
        {
            try
            {
                double value = -10;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.RoundData(value);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        public void PositiveRoundData()
        {
            try
            {
                double value = 100;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.RoundData(value);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCalculateIncomeTax()
        {
            try
            {
                double value = -10;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateIncomeTax(value);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        public void PositiveCalculateIncomeTax()
        {
            try
            {
                double value = 625000;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateIncomeTax(value);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        public void PositiveCalculateGrossIncome()
        {
            try
            {
                double value = 625000;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateGrossIncome(value);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCalculateGrossincome()
        {
            try
            {
                double value = -10;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateGrossIncome(value);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        public void PositiveCalculateNetIncome()
        {
            try
            {
                double grossIncome = 625000,incomeTax=620;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateNetIncome(grossIncome, incomeTax);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCalculateNetIncome()
        {
            try
            {
                double grossIncome = 625, incomeTax = 625000;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateNetIncome(grossIncome, incomeTax);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        public void PositiveCalculateSuper()
        {
            try
            {
                double grossIncome = 625000, incomeTax = 620;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateSuper(grossIncome, incomeTax);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeCalculateSuper()
        {
            try
            {
                double grossIncome = 625, super = 0;
                IncomeTaxCalc ps = new PaySlipProvider();
                ps.CalculateSuper(grossIncome, super);
            }
            catch (Exception e)
            {
                Assert.Fail("Exception thrown", e.Message);
            }

        }
    }
}
