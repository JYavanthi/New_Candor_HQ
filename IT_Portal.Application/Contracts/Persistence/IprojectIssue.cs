using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IprojectIssue
    {
        Task<CommonRsult> saveProjectIssue(SPprojectIssue model);

        Task<CommonRsult> deleteProjectIssueById(int id);

        Task<CommonRsult> getProIssueProById(int id);

        //Task<CommonRsult> getProjectIssue(SPprojectIssue model);

        Task<CommonRsult> getProIssueById(int id);
    }
}
