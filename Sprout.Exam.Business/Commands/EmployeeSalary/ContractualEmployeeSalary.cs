namespace Sprout.Exam.Business.Commands.EmployeeSalary
{
    public class ContractualEmployeeSalary : IEmployeeSalary
    {
        private readonly decimal _workedDays;
        private const decimal _dailyRate = 500;
        public ContractualEmployeeSalary(decimal workedDays)
        {
            _workedDays = workedDays;
        }
        public decimal Calculate() => _workedDays * _dailyRate;
    }
}
