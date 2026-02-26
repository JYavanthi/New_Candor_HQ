using IT_Portal.Application.Features;
using IT_Portal.Persistence.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface Ipriority
    {
        Task<List<Priority>> Getpriority();

        Task<CommonRsult> CRPriority(SPPriority prioritytyp);
    }
}
