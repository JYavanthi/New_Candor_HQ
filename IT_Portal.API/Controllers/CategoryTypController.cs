using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryTypController : ControllerBase
    {
        private readonly ICategorytyp _categorytypcontext;
        private readonly MicroLabsDevContext _context;

        public CategoryTypController(ICategorytyp categorytypcontext, MicroLabsDevContext context)
        {
            this._categorytypcontext = categorytypcontext;
            this._context = context;
        }

        [HttpPost("PostCategorytyp")]
        public async Task<IActionResult> PostCategorytyp(SPCategorytyp obj)
        {
            var spObj = await _categorytypcontext.CRcategortyp(obj);
            return Ok(spObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriestyp()
        {
            var data = await _context.CategoryTyps.ToListAsync();
            return Ok(data);
        }

        [HttpGet("viewcattyp")]
        public async Task<IActionResult> ViewCategoriestyp()
        {
            var data = await _context.VwCategorytypes.ToListAsync();
            return Ok(data);
        }
    }
}
