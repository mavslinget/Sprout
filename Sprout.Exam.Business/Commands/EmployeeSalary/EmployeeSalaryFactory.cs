using Sprout.Exam.Common.Enums;
using System;

namespace Sprout.Exam.Business.Commands.EmployeeSalary
{
    public class EmployeeSalaryFactory : IEmployeeSalaryFactory
    {
        public IEmployeeSalary Build(int employeeTypeId, decimal absentDays, decimal workedDays)
        {
            return employeeTypeId switch
            {
                (int)EmployeeType.Regular => new RegularEmployeeSalary(absentDays),
                (int)EmployeeType.Contractual => new ContractualEmployeeSalary(workedDays),
                _ => throw new ArgumentNullException(nameof(employeeTypeId)),
            };
        }
    }
}
