using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentMasterController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;

        public DepartmentMasterController(MicroLabsDevContext context)
        {
            this._context = context;
        }

        [HttpGet("GetDepartment")]
        public async Task<IActionResult> GetDepartmentMaster()
        {
            var data = await _context.VwDepartmentMasters.ToListAsync();
            return Ok(data);
        }
    }
}
