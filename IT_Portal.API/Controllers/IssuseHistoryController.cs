using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssuseHistoryController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;

        public IssuseHistoryController(MicroLabsDevContext context)
        {
            this._context = context;
        }
        [HttpGet("GetIssueHistory")]
        public async Task<IActionResult> GetIssueHistoryValue()
        {
            try
            {
                var data = await _context.VwIssueListHistories.ToArrayAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
