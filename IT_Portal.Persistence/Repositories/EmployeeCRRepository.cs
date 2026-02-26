using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class EmployeeCRRepository : Iemployeecr
    {
        private readonly MicroLabsDevContext _context;

        public EmployeeCRRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<Employee>> GetEmployeCRowner()
        {
            var data = await _context.Employees.ToListAsync();
            return data;
        }
    }
}
