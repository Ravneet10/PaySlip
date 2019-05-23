using System;
using System.Collections.Generic;
using System.Text;
using Business.PaySlip.Interface;
using Business.PaySlip.Model;
using Business.PaySlip.Domain;
namespace Business.PaySlip.Provider
{
    public class PaySlipProvider : IncomeTaxCalc, IPaySlip
    {
        public EmployeePaySlipDetails GeneratePaySlip(EmployeeDetails employeeDetails)
        {

            double grossIncome = CalculateGrossIncome(employeeDetails.AnnualSalary);
            double incomeTax = CalculateIncomeTax(employeeDetails.AnnualSalary);
            incomeTax= RoundData(incomeTax);
            double netIncome = CalculateNetIncome(grossIncome,incomeTax);
            double super = CalculateSuper(grossIncome, employeeDetails.SuperRate);

            var paySlipDetails = new EmployeePaySlipDetails
            {
                FirstName = employeeDetails.FirstName,
                LastName = employeeDetails.LastName,
                PayPeriod = employeeDetails.SalaryMonth,
                GrossIncome = grossIncome,
                IncomeTax = incomeTax,
                NetIncome = netIncome,
                Super = super
            };
            return paySlipDetails;
        }
       

    }
}
