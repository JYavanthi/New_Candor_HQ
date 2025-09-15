using IT_Portal.Application.Features;
using IT_Portal.Application.Features.ServiceCitrix;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IServiceCitrixList
    {
        Task<CommonRsult> PostServiceCitrix(SPServiceCitrix serviceCitrix);

        Task<CommonRsult> PostServiceCitrixApp(SPServiceCitrixApp serviceCitrixApp);
    }
}
