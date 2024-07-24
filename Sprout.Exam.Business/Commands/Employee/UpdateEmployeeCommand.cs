using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.Employee
{
    public class UpdateEmployeeCommand : EditEmployeeDto, IRequest<EmployeeDto>
    {
    }
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private IApplicationDbContext _applicationDbContext;
        private IMapper _mapper;
        public UpdateEmployeeCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(e => e.Id == request.Id)
                ?? throw new Exception("Employee Not Found");
            employee.FullName = request.FullName;
            employee.Tin = request.Tin;
            employee.Birthdate = request.Birthdate;
            employee.EmployeeTypeId = request.TypeId;
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }
    }
}
