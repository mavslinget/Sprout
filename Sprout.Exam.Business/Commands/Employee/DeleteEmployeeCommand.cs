using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.Employee
{
    public class DeleteEmployeeCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, int>
    {
        private IApplicationDbContext _applicationDbContext;

        public DeleteEmployeeCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken)
                ?? throw new Exception("Employee not found");
            employee.IsDeleted = true;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;

        }
    }
}
