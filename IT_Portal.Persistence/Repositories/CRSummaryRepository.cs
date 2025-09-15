using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class CRSummaryRepository : ICRSummary
    {
        private readonly MicroLabsDevContext _context;

        public CRSummaryRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<VwChangeRequestSummary>> GetSummaryRepport()
        {
            var data = await _context.VwChangeRequestSummaries.ToListAsync();
            return data;
        }
    }
}