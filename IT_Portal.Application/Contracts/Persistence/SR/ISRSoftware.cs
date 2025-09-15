using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR.Software;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRSoftware
    {
        Task<CommonRsult> PostSoftware(SPSoftware sPSoftware);
        Task<CommonRsult> GetSoftware(int srid);

    }
}
