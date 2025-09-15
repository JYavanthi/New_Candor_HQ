using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class softwareServiceController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly IsoftwareService _SoftwareServicecontext;
        public softwareServiceController(MicroLabsDevContext context, IsoftwareService software)
        {
            this._context = context;
            this._SoftwareServicecontext = software;
        }

        [HttpGet("GetServiceList")]
        public IActionResult GetSlaList()
        {
            var data = _SoftwareServicecontext.GetServicelist();
            return Ok(data);
        }


        [HttpGet("GetSoftwareVersion")]
        public IActionResult GetSoftwareVersion()
        {
            var data = _SoftwareServicecontext.getSoftwareVersionData();
            return Ok(data);
        }

    }
}
