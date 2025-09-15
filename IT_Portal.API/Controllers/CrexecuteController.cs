using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrexecuteController : ControllerBase
    {
        private readonly ICRexecutive _executecontext;
        private readonly MicroLabsDevContext _context;

        public CrexecuteController(ICRexecutive executecontext, MicroLabsDevContext context)
        {
            this._executecontext = executecontext;
            this._context = context;
        }

        [HttpPost("executeplan")]
        public async Task<IActionResult> Crexecute(SPCrexecute obj)
        {
            var spObj = await _executecontext.CRexecutive(obj);
            return Ok(spObj);
        }

        [HttpGet("GetExecute")]
        public async Task<IActionResult> GetExecute()
        {
            var data = await _context.VwExecPlans.ToListAsync();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCrexecutionPlan(int id)
        {
            var crexecutionPlan = await _context.CrexecutionPlans.FindAsync(id);
            if (crexecutionPlan == null)
            {
                return NotFound();
            }

            _context.CrexecutionPlans.Remove(crexecutionPlan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
