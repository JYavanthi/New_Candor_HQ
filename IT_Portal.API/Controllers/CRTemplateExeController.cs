using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRTemplateExeController : ControllerBase
    {
        private readonly ICRTemplateExe _templateexecontext;

        public CRTemplateExeController(ICRTemplateExe templateexecontext)
        {
            this._templateexecontext = templateexecontext;
        }

        [HttpPost("PostCRTemplateExe")]
        public async Task<IActionResult> PostCRTemplate(CRTemplateExe obj)
        {
            var spObj = await _templateexecontext.CRTemplateexe(obj);
            return Ok(spObj);
        }
    }
}
