using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly MicroLabsDevContext _context;

        public CategoryController(ICategoryRepo categoryRepo, MicroLabsDevContext context)
        {
            this._categoryRepo = categoryRepo;
            this._context = context;
        }

        [HttpPost("PostCategorytyp")]
        public async Task<IActionResult> PostCategory(SPCategory obj)
        {
            var spObj = await _categoryRepo.CRcategor(obj);
            return Ok(spObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var data = await _context.Categories.ToListAsync();
            return Ok(data);
        }
    }
}
