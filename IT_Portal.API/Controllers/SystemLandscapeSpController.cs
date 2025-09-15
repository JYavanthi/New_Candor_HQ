using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemLandscapeSpController : ControllerBase
    {
        private readonly ISystemlandscapeSp _syscontext;

        public SystemLandscapeSpController(ISystemlandscapeSp syscontext)
        {
            this._syscontext = syscontext;
        }

        [HttpPost("PostSystemLandscape")]
        public async Task<IActionResult> InsertSystemlandscape(SystemlandscapeSP obj)
        {
            var spObj = await _syscontext.InsertSystemlandscape(obj);
            return Ok(spObj);
        }
    }
}
