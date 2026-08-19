using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HREmployee : ControllerBase
    {
        private readonly MicroLabsDevContext _context;

        public HREmployee(MicroLabsDevContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHREmployee()
        {
            var employeedata = await _context.VwEmployeeDetails.ToListAsync();
            return Ok(employeedata);
        }
    }
}
