using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class softwareService : IsoftwareService
    {
        private readonly MicroLabsDevContext _context;

        public softwareService(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public List<ServiceMaster1> GetServicelist()
        {
            List<ServiceMaster1> serviceMasters = _context.ServiceMasters1.ToList();
            ; return serviceMasters;
        }

        public async Task<CommonRsult> getSoftwareVersionData()
        {

            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwSoftwareVersions.ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
    }
}