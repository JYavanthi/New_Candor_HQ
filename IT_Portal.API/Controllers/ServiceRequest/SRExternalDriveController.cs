using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRExternalDriveController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly ISRExternalDrive _sRExternalDrive;

        public SRExternalDriveController(MicroLabsDevContext context, ISRExternalDrive sRExternalDrive)
        {
            this._context = context;
            this._sRExternalDrive = sRExternalDrive;
        }

        [HttpPost("PostSRExternal")]
        public async Task<CommonRsult> PostExternalDrive(SRExternalDrive SRED)
        {
            var data = await _sRExternalDrive.PostExternalDrive(SRED);
            return data;
        }
        [HttpGet("GetSRExternal")]
        public async Task<CommonRsult> GetExternalDrive(int srid)
        {
            return await _sRExternalDrive.GetExternalDrive(srid);
        }

    }
}
