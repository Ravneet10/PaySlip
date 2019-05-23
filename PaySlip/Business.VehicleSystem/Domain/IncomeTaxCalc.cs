using System;
using System.Collections.Generic;
using System.Text;

using Business.PaySlip.Constants;

namespace Business.PaySlip.Domain
{
    //cyclomatic complexity
    /// <summary>
    /// calculate common logic for income tax calculation.
    /// </summary>
   public abstract class IncomeTaxCalc
    {
        public virtual double CalculateIncomeTax(double AnnualPackage)
        {
            if (AnnualPackage < Constant.AnnualPackageConstant)
                return 0;

            else if (AnnualPackage > Constant.AnnualPackageConstant && AnnualPackage <= Constant.AnnualPackageSecondConstant)
            {
                return (0.19 * (AnnualPackage - Constant.AnnualPackageConstant)) / 12;
            }

            else if (AnnualPackage > Constant.AnnualPackageSecondConstant && AnnualPackage <= 87000)
            {
                return (3572 + (0.325 * (AnnualPackage - Constant.AnnualPackageSecondConstant))) / 12;
            }

            else if (AnnualPackage > 87000 && AnnualPackage <= 180000)
            {
                return (19882 + (0.37 * (AnnualPackage - 87000))) / 12;
            }

            return (54232 + (0.45 * (AnnualPackage - 180000))) / 12;
        }
        public  double CalculateGrossIncome( double AnnualSalary)
        {
            double grossIncome = AnnualSalary / 12;
           return RoundData(grossIncome);
        }
        public  double CalculateNetIncome(double grossIncome,double incomeTax)
        {
            double netIncome = grossIncome - incomeTax;
            return RoundData(netIncome);
        }
        public  double CalculateSuper(double grossIncome,double superRate)
        {
            double super = (grossIncome * superRate) / 100;
            return RoundData(super);
        }
      
        public virtual double RoundData(double data)
        {
            if (data > 0)
            {
                data = data <= 0.50 ? Math.Floor(data) : Math.Round(data, MidpointRounding.AwayFromZero);

            }
            else
            {
                throw new ArgumentException("Invalid format");
            }
            return data;

        }
    }
}
