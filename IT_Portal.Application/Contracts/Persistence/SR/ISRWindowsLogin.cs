using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISRWindowsLogin
    {
        Task<CommonRsult> PostSRWindowLogin(SRWindowslogin SRWL);
        Task<CommonRsult> GetSRWindowLogin();
        Task<CommonRsult> GetSRWindowValue(int srid);
    }
}
