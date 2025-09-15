using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareLibraryController : ControllerBase
    {
        private readonly ISoftwareLibrary _library;
        private readonly MicroLabsDevContext _context;

        public SoftwareLibraryController(ISoftwareLibrary library, MicroLabsDevContext context)
        {
            this._library = library;
            this._context = context;
        }
        [HttpPost("PostSoftwareValue")]
        public async Task<CommonRsult> PostSoftwareLibrary(SoftwareLibrary library)
        {
            var spObj = await _library.PostSoftwareLibrary(library);
            return spObj;
        }
        [HttpGet("GetSoftwarevalue")]
        public async Task<IActionResult> GetSoftwarelibraryValue()
        {
            var data = await _context.VwSoftwareLibraries.ToListAsync();
            return Ok(data);
        }


        [HttpGet("GetSoftwareVersionBySoftId")]
        public async Task<IActionResult> GetSoftwareVersionBySoftId()
        {
            var data = await _context.VwSoftwareVersions.ToListAsync();
            return Ok(data);
        }
    }
}
