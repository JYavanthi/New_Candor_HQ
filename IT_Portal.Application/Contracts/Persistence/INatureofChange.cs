using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface INatureofChange
    {
        Task<CommonRsult> PostNatureofchange(SPNatureofchange natureofchange);
    }
}
