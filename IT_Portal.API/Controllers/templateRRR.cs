using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class templateRRR : ControllerBase
    {

        private readonly MicroLabsDevContext _context;
        templateRRR(MicroLabsDevContext context)
        {
            this._context = context;
        }
    }
}
