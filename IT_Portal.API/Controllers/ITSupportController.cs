using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITSupportController : ControllerBase
    {
        private readonly ISupportID _supportcontext;

        public ITSupportController(ISupportID supportcontext)
        {
            this._supportcontext = supportcontext;
        }

        [HttpGet("GetSupport")]
        public async Task<IActionResult> GetSupportTeam()
        {
            var data = await _supportcontext.GetSuppotID();
            return Ok(data);
        }


        /*[HttpGet("GetSupport")]
        public async Task<IActionResult> getService([FromQuery] ESRfilterRequest request)
        {
            var spObj = await _supportcontext.getService(request);
            return Ok(spObj);
        }*/

        [HttpPost("ModulePost")]
        public async Task<IActionResult> PostModule(SPModule obj)
        {
            var spObj = await _supportcontext.Modulename(obj);
            return Ok(spObj);
        }
    }
}
