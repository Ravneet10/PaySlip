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

            double grossIncome = employeeDetails.AnnualSalary / 12;
            RoundData(ref grossIncome);
            double incomeTax = CalculateIncomeTax(Convert.ToDouble(employeeDetails.AnnualSalary));
            RoundData(ref incomeTax);

            double netIncome = grossIncome - incomeTax;
            RoundData(ref netIncome);
            double super = (grossIncome * employeeDetails.SuperRate) / 100;
            RoundData(ref super);
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
        public void RoundData(ref double data)
        {
            if (data > 0)
            {
                data = data <= 0.50 ? Math.Floor(data) : Math.Round(data, MidpointRounding.AwayFromZero);

            }
            else
            {
                throw new ArgumentException("Invalid format");
            }

        }

    }
}
