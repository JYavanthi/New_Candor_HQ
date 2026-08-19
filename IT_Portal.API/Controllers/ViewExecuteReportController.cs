using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViewExecuteReportController : ControllerBase
    {
        private readonly IVWcrexecute _vwexecutecontext;
        private readonly MicroLabsDevContext _context;

        public ViewExecuteReportController(IVWcrexecute vwexecutecontext, MicroLabsDevContext context)
        {
            this._vwexecutecontext = vwexecutecontext;
            this._context = context;
        }

        [HttpGet("GetAllcrexecute")]
        public async Task<IActionResult> GetViewExecute()
        {

            var data = await _context.VwRptcrexecPlans.ToListAsync();
            return Ok(data);
        }
    }
}
