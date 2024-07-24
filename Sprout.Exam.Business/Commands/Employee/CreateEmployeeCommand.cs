using AutoMapper;
using MediatR;
using Sprout.Exam.Business.DataTransferObjects;
using Sprout.Exam.DataAccess.Contexts;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.Business.Commands.Employee
{
    public class CreateEmployeeCommand : CreateEmployeeDto, IRequest<int>
    {
    }

    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, int>
    {
        private IApplicationDbContext _applicationDbContext;
        private IMapper _mapper;

        public CreateEmployeeCommandHandler(IApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Sprout.Exam.DataAccess.Entities.Employee>(request);
            var result = await _applicationDbContext.Employees.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return result.Entity.Id;
        }
    }
}
