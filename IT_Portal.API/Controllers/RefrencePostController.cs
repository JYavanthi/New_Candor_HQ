using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefrencePostController : ControllerBase
    {
        private readonly IRefrencePost _refcontext;

        public RefrencePostController(IRefrencePost refcontext)
        {
            this._refcontext = refcontext;
        }

        [HttpPost("RefrencePost")]
        public async Task<IActionResult> PostCategory(SPCRrefrence obj)
        {
            var spObj = await _refcontext.CRRefrence(obj);
            return Ok(spObj);
        }
    }
}
