using IT_Portal.Application.Features;
using IT_Portal.Persistence.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IsoftwareService
    {

        public List<ServiceMaster> GetServicelist();
        public Task<CommonRsult> getSoftwareVersionData();
    }
}