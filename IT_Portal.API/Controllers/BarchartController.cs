using IT_Portal.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarchartController : ControllerBase
    {
        private readonly IBarchartvalue _barchartcontext;

        public BarchartController(IBarchartvalue barchartcontext)
        {
            this._barchartcontext = barchartcontext;
        }

        [HttpGet("Getbarchart")]
        public async Task<IActionResult> GetViewExecute()
        {
            var data = await _barchartcontext.GetBarchartvalue();
            return Ok(data);
        }
    }
}
