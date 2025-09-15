using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
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

        public async Task<List<EmployeeMaster>> GetEmployeCRowner()
        {
            var data = await _context.EmployeeMasters.ToListAsync();
            return data;
        }
    }
}
