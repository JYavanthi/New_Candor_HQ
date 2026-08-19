using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckListController : ControllerBase
    {
        private readonly ICheckList _checklistcontext;

        public CheckListController(ICheckList checklistcontext)
        {
            this._checklistcontext = checklistcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetChecklist()
        {
            var data = await _checklistcontext.Getchecklist();
            return Ok(data);
        }

        [HttpPost("ChecklistPost")]
        public async Task<IActionResult> PostRefrence([FromBody]SPCheckList obj)
        {
            var spObj = await _checklistcontext.postchecklist(obj);
            return Ok(spObj);
        }
    }
}
