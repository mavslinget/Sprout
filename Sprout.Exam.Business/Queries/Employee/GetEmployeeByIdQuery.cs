using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Contexts;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Queries.Employee
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
    }
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto>
    {
        private IApplicationDbContext _applicationDbContext;
        private IMapper _mapper;
        public GetEmployeeByIdQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                ?? throw new Exception("Employee Not Found");
            var result = _mapper.Map<EmployeeDto>(employee);
            return result;
        }
    }
}
