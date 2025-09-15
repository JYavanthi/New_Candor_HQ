using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR.Software;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRSoftwareController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly ISoftware _soft;

        public SRSoftwareController(MicroLabsDevContext context, ISoftware soft)
        {
            this._context = context;
            this._soft = soft;
        }
        [HttpPost("SaveSupport")]
        public async Task<CommonRsult> PostSoftware(SPSoftware sPSoftware)
        {
            var data = await _soft.PostSoftware(sPSoftware);
            return data;
        }
    }
}
