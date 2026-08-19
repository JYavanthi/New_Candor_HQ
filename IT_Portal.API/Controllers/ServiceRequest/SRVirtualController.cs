using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.ServiceRequest
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRVirtualController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly IVirtual _value;

        public SRVirtualController(MicroLabsDevContext context, IVirtual value)
        {
            this._context = context;
            this._value = value;
        }


        [HttpPost("PostVirtual")]
        public async Task<CommonRsult> PostVirtual(Virtual virt)
        {
            var data = await _value.PostVirtual(virt);
            return data;
        }
        [HttpGet("GetVirtual")]
        public async Task<CommonRsult> GetVirtual(int srid)
        {
            var data = await _value.GetVirtual(srid);
            return data;
        }
    }
}
