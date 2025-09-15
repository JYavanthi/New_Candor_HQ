using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceTypeController : ControllerBase
    {
        private readonly IReferenceType _referencetypecontext;

        public ReferenceTypeController(IReferenceType referencetypecontext)
        {
            this._referencetypecontext = referencetypecontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetreferenceType()
        {
            var data = await _referencetypecontext.GetReferenceType();
            return Ok(data);
        }

        [HttpPost("RefrencetypPost")]
        public async Task<IActionResult> PostRefrencetyp(SPRefernceTyp obj)
        {
            var spObj = await _referencetypecontext.CRRefrencetyp(obj);
            return Ok(spObj);
        }
    }
}
