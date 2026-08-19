using IT_Portal.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantidController : ControllerBase
    {
        private readonly IPlantID _plantcontext;

        public PlantidController(IPlantID plantcontext)
        {
            this._plantcontext = plantcontext;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlantid()
        {
            var data = await _plantcontext.GetPlantID();
            return Ok(data);
        }
    }
}
