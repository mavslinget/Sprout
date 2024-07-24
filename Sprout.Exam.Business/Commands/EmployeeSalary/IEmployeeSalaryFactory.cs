namespace Sprout.Exam.Business.Commands.EmployeeSalary
{
    public interface IEmployeeSalaryFactory
    {
        IEmployeeSalary Build(int employeeTypeId, decimal absentDays, decimal workedDays);
    }
}