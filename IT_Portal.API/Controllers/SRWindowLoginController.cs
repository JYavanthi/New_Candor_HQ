using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRWindowLoginController : ControllerBase
    {
        private readonly ISRWindowsLogin _sRWindows;

        public SRWindowLoginController(ISRWindowsLogin sRWindows)
        {
            this._sRWindows = sRWindows;
        }
        [HttpPost("PostWindowLogin")]
        public async Task<CommonRsult> PostSRWindowLogin(SRWindowslogin SRWL)
        {
            return await _sRWindows.PostSRWindowLogin(SRWL);
        }
        [HttpGet("GetWindowLogin")]
        public async Task<CommonRsult> GetSRWindowLogin()
        {
            return await _sRWindows.GetSRWindowLogin();
        }
        [HttpGet("GetWindowValue")]
        public async Task<CommonRsult> GetSRWindowValue(int srId)
        {
            return await _sRWindows.GetSRWindowValue(srId);
        }
    }
}
