using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISupportID
    {
        Task<List<Support>> GetSuppotID();
        /*
                Task<CommonRsult> GetSuppotID();*/


        Task<CommonRsult> Modulename(SPModule suportmodule);
    }
}
