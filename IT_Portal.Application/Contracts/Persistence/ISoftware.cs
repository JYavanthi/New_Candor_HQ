using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR.Software;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISoftware
    {
        Task<CommonRsult> PostSoftware(SPSoftware sPSoftware);
    }
}
