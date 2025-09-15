using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRExternalDrive
    {
        Task<CommonRsult> PostExternalDrive(SRExternalDrive SRED);
        Task<CommonRsult> GetExternalDrive(int srid);
    }
}
