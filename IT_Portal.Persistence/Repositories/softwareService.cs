using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
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
        public List<ServiceMaster> GetServicelist()
        {
            List<ServiceMaster> serviceMasters = _context.ServiceMasters.ToList();
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