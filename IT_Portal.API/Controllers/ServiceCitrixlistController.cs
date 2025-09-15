using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features.ServiceCitrix;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCitrixlistController : ControllerBase
    {
        private readonly IServiceCitrixList _citriccontext;

        public ServiceCitrixlistController(IServiceCitrixList citriccontext)
        {
            this._citriccontext = citriccontext;
        }

        [HttpPost("ServiceCitrix")]
        public async Task<IActionResult> InsertServiceCitrix(SPServiceCitrix obj)
        {
            var spObj = await _citriccontext.PostServiceCitrix(obj);
            return Ok(spObj);
        }

        [HttpPost("ServiceCitrixApp")]
        public async Task<IActionResult> InsertServiceCitrixApp(SPServiceCitrixApp obj)
        {
            var spObj = await _citriccontext.PostServiceCitrixApp(obj);
            return Ok(spObj);
        }
    }
}
