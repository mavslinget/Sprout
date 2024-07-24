using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.EmployeeSalary
{
    public class GetEmployeeSalaryCommand : IRequest<decimal>
    {
        public int Id { get; set; }
        public decimal AbsentDays { get; set; }
        public decimal WorkedDays { get; set; }
    }

    public class GetEmployeeSalaryCommandHandler : IRequestHandler<GetEmployeeSalaryCommand, decimal>
    {
        private IApplicationDbContext _applicationDbContext;
        private IEmployeeSalaryFactory _employeeSalaryFactory;
        public GetEmployeeSalaryCommandHandler(IApplicationDbContext applicationDbContext, IEmployeeSalaryFactory employeeSalaryFactory)
        {
            _applicationDbContext = applicationDbContext;
            _employeeSalaryFactory = employeeSalaryFactory;
        }
        public async Task<decimal> Handle(GetEmployeeSalaryCommand request, CancellationToken cancellationToken)
        {
            var employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new Exception("Employee Not Found");

            var employeeSalary = _employeeSalaryFactory.Build(employee.EmployeeTypeId, request.AbsentDays, request.WorkedDays);
            return employeeSalary.Calculate();
        }
    }
}
