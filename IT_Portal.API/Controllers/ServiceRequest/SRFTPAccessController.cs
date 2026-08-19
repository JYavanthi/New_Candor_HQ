using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRFTPAccessController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly ISRFTPAccess _sRFTP;

        public SRFTPAccessController(MicroLabsDevContext context, ISRFTPAccess sRFTP)
        {
            this._context = context;
            this._sRFTP = sRFTP;
        }
        [HttpPost("PostSRFTPAccess")]
        public async Task<CommonRsult> PostFTPAccess(SRFTPAccess sRFTPAccess)
        {
            var data = await _sRFTP.PostFTPAccess(sRFTPAccess);
            return data;
        }

        [HttpGet("GetFTPAccess")]
        public async Task<CommonRsult> GetFTPAccess(int srid)
        {
            return await _sRFTP.GetFTPAccess(srid);
        }

    }
}
