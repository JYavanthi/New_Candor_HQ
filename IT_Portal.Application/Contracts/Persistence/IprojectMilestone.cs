using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IprojectMilestone
    {
        Task<CommonRsult> saveProjectMilestone(SPProjectMilestone spProjectMilestone);

        Task<CommonRsult> getProjectMilestone();

        Task<CommonRsult> getMilestoneByProjectId(int id);

        Task<CommonRsult> getMilestoneByMilestoneId(int id);

        Task<CommonRsult> DeleteMilestoneById(int id);


    }
}
