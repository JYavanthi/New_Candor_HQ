using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class ExecuteReportRepository : IVWcrexecute
    {
        private readonly MicroLabsDevContext _context;

        public ExecuteReportRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<VwExecPlan>> Getexecutereport()
        {
            var data = await _context.VwExecPlans.ToListAsync();

            return data;
        }
    }
}
