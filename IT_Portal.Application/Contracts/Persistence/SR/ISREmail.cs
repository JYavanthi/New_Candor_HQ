using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public interface ISREmail
    {
        Task<CommonRsult> PostEmailReq(SREmailRequest sREmail);
        Task<CommonRsult> GetEmailvalue(int srid);
        Task<CommonRsult> GetSREmailGroups();
    }
}
