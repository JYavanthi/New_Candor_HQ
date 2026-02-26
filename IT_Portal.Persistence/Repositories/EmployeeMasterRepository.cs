using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class EmployeeMasterRepository : IEmployeeMasters
    {
        private readonly MicroLabsDevContext _context;

        public EmployeeMasterRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<object>> Getemplaoyedata()
        {
            var users = await _context.Employees.OrderBy(u => u.EmployeeId).Select(u => new Employee { EmployeeId = u.EmployeeId, FirstName = u.FirstName }).Take(100).ToListAsync();
            return users.Select(u => new Dictionary<string, object>
            { { "EmployeeId", u.EmployeeId },
            { "FirstName", u.FirstName }
            });
        }


    }
}

/*return await _dbContext.Users.OrderBy(u => u.Id).Select(u => new User { Id = u.Id, Name = u.Name }).Take(10).ToListAsync();
*/