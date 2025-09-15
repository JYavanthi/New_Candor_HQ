using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRRemoteAccess
    {
        Task<CommonRsult> PostSRRemoteAccess(SRRemoteAccess access);
        Task<CommonRsult> GetSRRemoteAccess();
        Task<CommonRsult> GetSRRemoteAccessById(int Srid);

    }
}
