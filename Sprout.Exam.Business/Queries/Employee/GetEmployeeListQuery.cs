using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Queries.Employee
{
    public class GetEmployeeListQuery : IRequest<List<EmployeeDto>>
    {
    }

    public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeDto>>
    {
        private IApplicationDbContext _applicationDbContext;
        private IMapper _mapper;
        public GetEmployeeListQueryHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeeList = await _applicationDbContext.Employees.Where(x => !x.IsDeleted).ToListAsync();
            var result = _mapper.Map<List<EmployeeDto>>(employeeList);

            return result;
        }
    }
}
