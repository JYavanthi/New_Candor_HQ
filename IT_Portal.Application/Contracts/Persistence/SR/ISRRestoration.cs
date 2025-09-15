using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRRestoration
    {
        Task<CommonRsult> PostSRRestoration(SRRestoration restoration);

        Task<CommonRsult> GetSRRestoration(int srid);
    }
}
