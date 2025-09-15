using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRUSBAccess
    {
        Task<CommonRsult> PostUSBAccess(SRUSBAccess sRURL);
        Task<CommonRsult> GetUSBAccess();
        Task<CommonRsult> GetUSBIdValue(int srid);
        Task<CommonRsult> GetAssetDetails(string Empno);

    }
}
