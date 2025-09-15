using IT_Portal.Application.Contracts.Persistence.Assets;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.Asset;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.Asset
{
    [Route("api/[controller]")]
    [ApiController]
    public class ITSpareRequestController : ControllerBase
    {
        private readonly IITSpareRequest _spare;

        public ITSpareRequestController(IITSpareRequest spare)
        {
            this._spare = spare;
        }
        [HttpPost("PostITSpare")]
        public async Task<CommonRsult> PostItSpare(ITSpareRequest request)
        {
            var data = await _spare.PostItSpare(request);
            return data;
        }
        [HttpGet("GetSpareById")]
        public async Task<CommonRsult> GetSpareByID(int ID)
        {
            return await _spare.GetSpareByID(ID);
        }


        [HttpGet("deleteSpareById")]
        public async Task<CommonRsult> delteSpareByID(int ID)
        {
            return await _spare.delteSpareByID(ID);
        }
        [HttpGet("GetSparevalue")]
        public async Task<CommonRsult> GetSpareValue()
        {
            return await _spare.GetSpareValue();
        }
        [HttpGet("GetSpareHistory")]
        public async Task<CommonRsult> GetSpareHistory()
        {
            return await _spare.GetSpareHistory();
        }
        [HttpGet("GetSpareHistoryBYID")]
        public async Task<CommonRsult> GetSpareHistoryBYID(int ID)
        {
            return await _spare.GetSpareHistoryBYID(ID);
        }
    }
}
