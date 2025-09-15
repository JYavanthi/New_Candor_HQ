using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{

    public class ViewChangeRequestRepository : IViewChangeRequest
    {
        private readonly MicroLabsDevContext _context;

        public ViewChangeRequestRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetVieChangerequets(EcrFilterRequest filterRquest)
        {
            try
            {
                var result = new CommonRsult();
                if (filterRquest.crId != 0)
                {
                    var data = await _context.VwChangeRequests.Where(m => filterRquest.crId == m.Itcrid).ToListAsync();

                    result.Data = data;
                    return result;
                }
                else
                {
                    var data = await _context.VwChangeRequests
                    .Where(m =>
                        (filterRquest.PlantIds == null || !filterRquest.PlantIds.Any() || filterRquest.PlantIds.Contains((int)m.Plantcode)) &&
                        (filterRquest.Categories == null || !filterRquest.Categories.Any() || filterRquest.Categories.Contains(m.ItcategoryId)) &&
                        (filterRquest.ClassificationId == null || m.ItclassificationId == filterRquest.ClassificationId) &&
                        (filterRquest.Priority == null || m.PriorityType == filterRquest.Priority) &&
                        (string.IsNullOrEmpty(filterRquest.Status) || m.Status == filterRquest.Status) &&
                        (!filterRquest.StartDate.HasValue || m.Crdate >= filterRquest.StartDate.Value.Date) &&
                        (!filterRquest.EndDate.HasValue || m.Crdate <= filterRquest.EndDate.Value.Date) &&
                        (string.IsNullOrEmpty(filterRquest.RfcChangeNumber) || m.Crcode == filterRquest.RfcChangeNumber)
                    ).ToListAsync();

                    data = data
            .Skip((filterRquest.pageNumber - 1) * filterRquest.pageSize)
            .Take(filterRquest.pageSize)
            .ToList();
                    result.Count = _context.VwChangeRequests.Count();
                    result.Data = data;
                    result.Data = data;
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
