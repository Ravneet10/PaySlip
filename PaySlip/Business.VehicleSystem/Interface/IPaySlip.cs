using Business.PaySlip.Model;

namespace Business.PaySlip.Interface
{
    public interface IPaySlip
    {
        EmployeePaySlipDetails GeneratePaySlip(EmployeeDetails employeeDetails);

    }
}
