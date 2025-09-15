using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRFTPAccess
    {
        Task<CommonRsult> PostFTPAccess(SRFTPAccess sRFTPAccess);
        Task<CommonRsult> GetFTPAccess(int srid);
    }
}
