using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMastersController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;

        public EmployeeMastersController(MicroLabsDevContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            var employeedata = await _context.VwEmployeeDetails.ToListAsync();
            return Ok(employeedata);
        }

    }
}
