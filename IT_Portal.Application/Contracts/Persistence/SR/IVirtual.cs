using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface IVirtual
    {
        Task<CommonRsult> PostVirtual(Virtual virt);
        Task<CommonRsult> GetVirtual(int srid);
    }
}
