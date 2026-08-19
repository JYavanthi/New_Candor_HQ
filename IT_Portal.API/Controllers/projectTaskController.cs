using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class projectTaskController : ControllerBase
    {
        private readonly IprojectTask _projectTask;
        private readonly MicroLabsDevContext _context;
        public projectTaskController(IprojectTask projectTask, MicroLabsDevContext context)
        {
            this._projectTask = projectTask;
            this._context = context;
        }

        [HttpPost("saveProjectTask")]
        public async Task<IActionResult> saveProjectTask(SPProjecttask projectTask)
        {
            var spObj = await _projectTask.saveProjectTask(projectTask);
            return Ok(spObj);
        }

        [HttpGet("getTask")]
        public async Task<CommonRsult> getTask(int proId)
        {
            return await _projectTask.getTask(proId);
        }

        [HttpGet("getTaskByTaskId")]
        public async Task<CommonRsult> getTaskById(int taskId)
        {
            return await _projectTask.getTaskById(taskId);
        }

        [HttpGet("deleteTaskById")]
        public async Task<IActionResult> deleteTaskById(int taskId)
        {
            var spObj = await _projectTask.deleteTaskById(taskId);
            return Ok(spObj);
        }


    }
}
