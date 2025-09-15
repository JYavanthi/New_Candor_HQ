using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class VwSupportengineerRepository : IVWSupportEngineer
    {
        private readonly MicroLabsDevContext _context;

        public VwSupportengineerRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<VwSupportEngineer>> GetSuppotrEngineer()
        {
            var data = await _context.VwSupportEngineers.ToListAsync();
            return data;
        }
    }
}
