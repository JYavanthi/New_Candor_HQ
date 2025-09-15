using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IprojectGroup
    {
        Task<CommonRsult> PostProjectGroup(SPprojectGroup request);
        Task<CommonRsult> getProjectGroup();

        Task<CommonRsult> getProjectGroupById(int id);
    }

}
