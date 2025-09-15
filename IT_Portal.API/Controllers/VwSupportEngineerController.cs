using IT_Portal.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VwSupportEngineerController : ControllerBase
    {
        private readonly IVWSupportEngineer _supengineercontext;

        public VwSupportEngineerController(IVWSupportEngineer supengineercontext)
        {
            this._supengineercontext = supengineercontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetSupportTeam()
        {
            var data = await _supengineercontext.GetSuppotrEngineer();
            return Ok(data);
        }
    }
}
