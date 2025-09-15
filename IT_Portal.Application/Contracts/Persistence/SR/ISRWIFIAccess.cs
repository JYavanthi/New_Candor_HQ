using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRWIFIAccess
    {
        Task<CommonRsult> PostWIFIAccess(SRWIFIAccess sRWIFI);
        Task<CommonRsult> GetWIFIAccess(int srid);
    }
}
