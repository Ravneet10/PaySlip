using System;
using System.Collections.Generic;
using System.Text;
using Business.PaySlip.Interface;
using Business.PaySlip.Model;
namespace Business.PaySlip.Provider
{
    public class PaySlipProvider : IPaySlip
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
            data = data <= 0.50 ? Math.Floor(data) : Math.Round(data, MidpointRounding.AwayFromZero);

        }
        private double CalculateIncomeTax(double AnnaulPackage)
        {
            if (AnnaulPackage < 18200)
                return 0;

            else if (AnnaulPackage > 18200 && AnnaulPackage <= 37000)
            {
                return (0.19 * (AnnaulPackage - 18200)) / 12;
            }

            else if (AnnaulPackage > 37000 && AnnaulPackage <= 87000)
            {
                return (3572 + (0.325 * (AnnaulPackage - 37000))) / 12;
            }

            else if (AnnaulPackage > 87000 && AnnaulPackage <= 180000)
            {
                return (19882 + (0.37 * (AnnaulPackage - 87000))) / 12;
            }

            return (54232 + (0.45 * (AnnaulPackage - 180000))) / 12;
        }
    }
}
