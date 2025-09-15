using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface IAntivirus
    {
        Task<CommonRsult> PostAntivirus(Antivirus antivirus);
        Task<CommonRsult> GetAntivirus(int srid);
    }
}
