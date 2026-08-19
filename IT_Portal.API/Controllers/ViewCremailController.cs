using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewCremailController : ControllerBase
    {
        private readonly IViewcremail _viewcremail;
        private readonly MicroLabsDevContext _context;

        public ViewCremailController(IViewcremail viewcremail, MicroLabsDevContext context)
        {
            this._viewcremail = viewcremail;
            this._context = context;
        }
        [HttpPost("PostViewCremail")]
        public async Task<IActionResult> Viewcremail(SPViewcrmail viewcremail)
        {
            var spObj = await _viewcremail.Viewcremail(viewcremail);
            return Ok(spObj);
        }
        [HttpGet("GetViewCremail")]
        public async Task<IActionResult> GetRequest()
        {
            var data = await _context.VwCremails.ToListAsync();
            return Ok(data);
        }
    }
}
