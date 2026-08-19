using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userValidate : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly IvalidateUser validationUserImp;
        public userValidate(MicroLabsDevContext context, IvalidateUser software)
        {
            this._context = context;
            this.validationUserImp = software;
        }

        [HttpPost("saveValidUser")]
        public IActionResult saveValidUser(EvalidationPost obj)
        {
            var data = validationUserImp.saveValidUser(obj.empNum);
            return Ok(data);
        }

        [HttpGet("getValidateUser")]
        public IActionResult getUserValid(int empNum)
        {
            var data = validationUserImp.checkValidUser(empNum);
            return Ok(data);
        }

        [HttpGet("onLogOut")]
        public IActionResult onLogOut(int empNum)
        {
            var data = validationUserImp.onLogOut(empNum);
            return Ok(data);
        }
    }
}