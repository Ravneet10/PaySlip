using System;
using System.Collections.Generic;
using System.Text;

using Business.PaySlip.Constants;

namespace Business.PaySlip.Domain
{
   public abstract class IncomeTaxCalc
    {
        public double CalculateIncomeTax(double AnnaulPackage)
        {
            if (AnnaulPackage < Constant.AnnualPackageConstant)
                return 0;

            else if (AnnaulPackage > Constant.AnnualPackageConstant && AnnaulPackage <= Constant.AnnualPackageSecondConstant)
            {
                return (0.19 * (AnnaulPackage - Constant.AnnualPackageConstant)) / 12;
            }

            else if (AnnaulPackage > Constant.AnnualPackageSecondConstant && AnnaulPackage <= 87000)
            {
                return (3572 + (0.325 * (AnnaulPackage - Constant.AnnualPackageSecondConstant))) / 12;
            }

            else if (AnnaulPackage > 87000 && AnnaulPackage <= 180000)
            {
                return (19882 + (0.37 * (AnnaulPackage - 87000))) / 12;
            }

            return (54232 + (0.45 * (AnnaulPackage - 180000))) / 12;
        }
    }
}
