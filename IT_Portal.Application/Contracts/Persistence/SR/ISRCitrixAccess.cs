using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRCitrixAccess
    {
        Task<CommonRsult> PostCitrixAccess(SRCitrixAccess sRCitrix);
        Task<CommonRsult> GetCitrixAccess();
        Task<CommonRsult> GetCitrixValue(int srid);

    }
}
