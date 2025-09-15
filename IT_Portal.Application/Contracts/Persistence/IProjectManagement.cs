using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IProjectManagement
    {
        Task<CommonRsult> saveProject(SPProjectMaster spProjectMaster);
        Task<CommonRsult> getProject();
        Task<CommonRsult> getProjectById(int id);
        Task<CommonRsult> getProIssueById(int id);
        Task<CommonRsult> getProIssueProById(int id);
        //Task<CommonRsult> getProjectMilestone();
        //Task<CommonRsult> getMilestoneByProjectId(int id);
        Task<CommonRsult> getTask(int projectId);
        Task<CommonRsult> getTaskById(int taskId);
        Task<CommonRsult> saveProjectMember(SPMemebers spProjectMember);
        Task<CommonRsult> getMemberByMemberId(int proId);
        Task<CommonRsult> getMemberByProId(int proId);
        Task<CommonRsult> getIssueByProId(int proId);
        Task<CommonRsult> getIssue();
        Task<CommonRsult> getIssueByIssueId(int IssueId);
        //Task<CommonRsult> getMilestoneByMilestoneId(int id);
        //Task<CommonRsult> DeleteMilestoneById(int milestoneId);
        Task<CommonRsult> DeleteMembersById(int memberId);
        Task<CommonRsult> saveProjectCheckList(SPProjectChecklist checklist);
        Task<CommonRsult> getCheckiListByProId(int proId);
        Task<CommonRsult> getCheckListByCheckListId(int CheckListId);
        Task<CommonRsult> DeleteChecklistById(int id);
        Task<CommonRsult> deleteProjectIssueById(int id);
        Task<CommonRsult> deleteTaskById(int id);
        Task<CommonRsult> PrHistory(int projectid);
    }
}
