namespace Sprout.Exam.Business.Commands.EmployeeSalary
{
    public class RegularEmployeeSalary : IEmployeeSalary
    {
        private const decimal _basicMonthly = 20000;
        private const int _numberOfDaysPerMonth = 22;
        private const decimal _tax = 12;
        private readonly decimal _absentDays;
        public RegularEmployeeSalary(decimal absentDays)
        {
            _absentDays = absentDays;
        }
        public decimal Calculate()
            => _basicMonthly - _absentDays * _basicMonthly / _numberOfDaysPerMonth - _basicMonthly * _tax / 100;
    }
}
