using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IprojectTask
    {

        Task<CommonRsult> saveProjectTask(SPProjecttask projectTask);

        //Task<CommonRsult> postProjectTask(SP_Projecttask projectTask);

        Task<CommonRsult> getTaskById(int taskId);

        Task<CommonRsult> getTask(int projectId);

        Task<CommonRsult> deleteTaskById(int id);

    }
}
