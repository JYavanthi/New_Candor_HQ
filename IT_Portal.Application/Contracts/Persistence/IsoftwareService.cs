using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IsoftwareService
    {

        public List<ServiceMaster1> GetServicelist();
        public Task<CommonRsult> getSoftwareVersionData();
    }
}