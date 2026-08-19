using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRTemplateController : ControllerBase
    {
        private readonly ICRtemplate _crtemplatecontext;
        private readonly MicroLabsDevContext _context;

        public CRTemplateController(ICRtemplate crtemplatecontext, MicroLabsDevContext context)
        {
            this._crtemplatecontext = crtemplatecontext;
            this._context = context;
        }

        [HttpPost("PostCRTemplate")]
        public async Task<IActionResult> PostCRTemplate(SPCRtemplate obj)
        {
            var spObj = await _crtemplatecontext.CRTemplate(obj);
            return Ok(spObj);
        }

        [HttpGet("GetCRTemplate")]
        public async Task<IActionResult> GetCRTemplate()
        {
            var data = await _context.VwCrtemplates.ToListAsync();
            return Ok(data);
        }
    }
}
