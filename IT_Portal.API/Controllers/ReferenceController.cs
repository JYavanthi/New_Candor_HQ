using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceController : ControllerBase
    {
        private readonly IReference _referencecontext;

        public ReferenceController(IReference referencecontext)
        {
            this._referencecontext = referencecontext;
        }

        [HttpGet]
        public async Task<IActionResult> Getreferences()
        {
            var data = await _referencecontext.Getreference();
            return Ok(data);
        }

        [HttpPost("RefrencePost")]
        public async Task<IActionResult> PostRefrence(SPCRrefrence obj)
        {
            var spObj = await _referencecontext.CRRefrence(obj);
            return Ok(spObj);
        }
    }
}
