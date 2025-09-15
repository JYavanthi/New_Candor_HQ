using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportMasterController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly ISupportMaster _supp;

        public SupportMasterController(MicroLabsDevContext context, ISupportMaster supp)
        {
            this._context = context;
            this._supp = supp;
        }

        [HttpGet("GetSupportValue")]
        public async Task<CommonRsult> GetSupport()
        {
            var data = await _supp.GetSupport();
            return data;
        }

        [HttpGet("GetSupportById")]
        public async Task<CommonRsult> GetSupportById(int id)
        {
            var data = await _supp.GetSupportById(id);
            return data;
        }
        [HttpGet("GetParentValue")]
        public async Task<IActionResult> GetParentValue(int ParentId)
        {
            var data = await _context.Supports.Where(m => m.ParentId == ParentId).ToListAsync();
            return Ok(data);
        }

        [HttpPost("SaveSupport")]
        public async Task<CommonRsult> PostSupport(SupportMaster supp)
        {
            var data = await _supp.PostSupport(supp);
            return data;
        }
        [HttpPut("UpdateSupport")]
        public async Task<CommonRsult> UpdateSupport(SupportMaster supp)
        {
            var data = await _supp.UpdateSupport(supp);
            return data;
        }
        [HttpGet("DeleteSupport")]
        public async Task<CommonRsult> DeleteSupport(int SupportID)
        {
            var data = await _supp.DeleteSupport(SupportID);
            return data;
        }
    }
}
