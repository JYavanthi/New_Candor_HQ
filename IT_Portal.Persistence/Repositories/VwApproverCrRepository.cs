using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class VwApproverCrRepository : IVWApproverCR
    {
        private readonly MicroLabsDevContext _context;

        public VwApproverCrRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<VwApproverCr>> GetApproversCR()
        {
            var data = await _context.VwApproverCrs.ToListAsync();
            return data;
        }

        public async Task<List<Approver>> GetCrApproverData(ErequesGetApprover apprReq)
        {
            var data = await _context.Approvers.Where(m => m.CategoryId == apprReq.CategoryId
            && m.ClassificationId == apprReq.ClassificationId && m.Approverstage == apprReq.stage
            && m.PlantId == apprReq.PlantId).ToListAsync();
            return data;
        }
    }
}
