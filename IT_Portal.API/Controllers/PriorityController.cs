using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        private readonly Ipriority _prioritycontext;

        public PriorityController(Ipriority prioritycontext)
        {
            this._prioritycontext = prioritycontext;
        }

        [HttpGet]
        public async Task<IActionResult> Getpriority()
        {
            var data = await _prioritycontext.Getpriority();
            return Ok(data);
        }

        [HttpPost("PostPrority")]
        public async Task<IActionResult> PostPriority(SPPriority obj)
        {
            var spObj = await _prioritycontext.CRPriority(obj);
            return Ok(spObj);
        }
    }
}
