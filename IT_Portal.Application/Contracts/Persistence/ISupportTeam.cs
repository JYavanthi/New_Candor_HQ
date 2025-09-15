using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISupportTeam
    {
        Task<List<VwSupportTeamDtl>> GetSuppotr();
        Task<List<VwSupportTeamAll>> GetSuppotAll(int supportId);
        Task<CommonRsult> InsertSupportTeam(SPSupportTeamTable supportteam);
        Task<CommonRsult> InsertSupportTeam(supportTeamCopy request);
        Task<CommonRsult> getSupportTeamData(int supportTeamId);

    }
}
