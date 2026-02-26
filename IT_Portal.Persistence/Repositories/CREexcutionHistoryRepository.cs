using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class CREexcutionHistoryRepository : ICRExecutionHistory
    {
        private readonly MicroLabsDevContext _context;

        public CREexcutionHistoryRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<CrexecutionPlanHistory>> GetExecutionHistory()
        {
            var data = await _context.CrexecutionPlanHistories.ToListAsync();
            return data;
        }
    }
}
