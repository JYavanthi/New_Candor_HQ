using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRapproveController : ControllerBase
    {
        private readonly ICRapproval _approvecontext;
        private readonly MicroLabsDevContext _context;

        public CRapproveController(ICRapproval approvecontext, MicroLabsDevContext context)
        {
            this._approvecontext = approvecontext;
            this._context = context;
        }

        [HttpPost("Approve")]
        public async Task<IActionResult> CRapprove(SPCrapprove obj)
        {
            var spObj = await _approvecontext.CRapprove(obj);
            return Ok(spObj);
        }

        [HttpGet("Getapprove")]
        public async Task<IActionResult> Getapprove()
        {
            var data = await _context.Crapprovers.ToListAsync();
            return Ok(data);
        }
    }
}
