using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Contexts
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
