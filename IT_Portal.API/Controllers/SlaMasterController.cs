using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlaMasterController : ControllerBase
    {
        private readonly ISlaMaster _slacontext;
        private readonly MicroLabsDevContext _context;

        public SlaMasterController(ISlaMaster slacontext, MicroLabsDevContext context)
        {
            this._slacontext = slacontext;
            this._context = context;
        }

        [HttpPost("PostSlamaster")]
        public async Task<IActionResult> InsertSlaMaster(SPSlaMaster obj)
        {
            var spObj = await _slacontext.postslamaster(obj);
            return Ok(spObj);
        }

        [HttpGet("GetSlaList")]
        public async Task<IActionResult> GetSlaList(int id)
        {
            var data = await _slacontext.GetSLAlist(id);
            return Ok(data);
        }

        [HttpGet("getSlaByCatId")]
        public async Task<IActionResult> getSlaByCatId([FromQuery] ErequestPRdate req)
        {
            var data = await _slacontext.getSlaByCatId(req);
            return Ok(data);
        }

        [HttpGet("deleteById")]
        public async Task<IActionResult> deleteSla(int id)
        {
            var data = _slacontext.deleteSlaByCatId(id);
            return Ok(data);
        }

        [HttpGet("GetWorkingDate")]
        public async Task<IActionResult> GetSlaList([FromQuery] EworkingDayCalReq EworkingDetailsObj)
        {
            var data = _slacontext.getWorkingDays(EworkingDetailsObj);
            return Ok(data);
        }
        //here is the code
    }
}
