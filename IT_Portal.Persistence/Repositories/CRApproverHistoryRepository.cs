using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class CRApproverHistoryRepository : ICRApproverHistory
    {
        private readonly MicroLabsDevContext _context;

        public CRApproverHistoryRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<CrapproverHistory>> GetCRApproverHistory()
        {
            var data = await _context.CrapproverHistories.ToListAsync();
            return data;
        }
    }
}
