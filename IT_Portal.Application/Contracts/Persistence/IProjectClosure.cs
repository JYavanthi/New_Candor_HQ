using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IProjectClosure
    {
        Task<CommonRsult> PostProjclosure(ProjectClosure projectClosure);
        Task<CommonRsult> getClosureByProjectId(int projectid);
    }
}
