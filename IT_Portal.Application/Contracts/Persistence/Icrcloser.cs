using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface Icrcloser
    {
        Task<CommonRsult> CRcloser(Crcloser crcloser);
    }
}
