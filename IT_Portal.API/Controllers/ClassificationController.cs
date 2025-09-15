using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : ControllerBase
    {
        private readonly IClasifications _clcontext;
        private readonly MicroLabsDevContext _context;

        public ClassificationController(IClasifications clcontext, MicroLabsDevContext context)
        {
            this._clcontext = clcontext;
            this._context = context;
        }

        [HttpPost("PostCategorytyp")]
        public async Task<IActionResult> PostClassification(SPClassifications obj)
        {
            var spObj = await _clcontext.postClassification(obj);
            return Ok(spObj);
        }

        [HttpGet]
        public async Task<IActionResult> GetClassification()
        {
            var data = await _context.Classifications.ToListAsync();
            return Ok(data);
        }


        [HttpGet("deleteHoldOnReasonById")]
        public async Task<IActionResult> deleteHoldOnReasonById(int id)
        {
            try
            {
                var existingReason = await _context.IssueOnholdCats.FindAsync(id);
                if (existingReason == null)
                {
                    return NotFound("Item not found.");
                }
                existingReason.IsActive = false;

                await _context.SaveChangesAsync();
                return Ok("Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet("getHoldOnReasonById")]
        public async Task<IActionResult> getHoldOnReasonById(int id)
        {
            try
            {
                var data = from ioh in _context.IssueOnholdCats
                           join c in _context.Categories on ioh.CategoryId equals c.ItcategoryId
                           join ct in _context.CategoryTyps on ioh.CategoryTypeId equals ct.CategoryTypeId
                           join s in _context.Supports on ioh.SupportId equals s.SupportId
                           where ioh.IsActive == true
                           select new
                           {
                               ioh.IssueOnholdCatId,
                               ioh.CategoryId,
                               CategoryName = c.CategoryName,
                               ioh.CategoryTypeId,
                               TypeName = ct.CategoryType,
                               ioh.OnholdReason,
                               ioh.CreatedBy,
                               ioh.CreatedDate,
                               ioh.ModifiedBy,
                               ioh.ModifiedDate,
                               ioh.SupportId,
                               s.SupportName
                           };
                if (id != 0)
                {
                    return Ok(data.Where(m => m.IssueOnholdCatId == id));
                }
                else
                {
                    return Ok("Hold Reason Id is required.");
                }
                /*                var data = await _context.IssueOnholdCats.ToListAsync();
                */
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpGet("getHoldOnReason")]
        public async Task<IActionResult> getHoldOnReason(int supportId, int SubCategory, int Category)
        {
            try
            {
                var data = from ioh in _context.IssueOnholdCats
                           join c in _context.Categories on ioh.CategoryId equals c.ItcategoryId into categoryJoin
                           from c in categoryJoin.DefaultIfEmpty()
                           join ct in _context.CategoryTyps on ioh.CategoryTypeId equals ct.CategoryTypeId into categoryTypeJoin
                           from ct in categoryTypeJoin.DefaultIfEmpty()
                           join s in _context.Supports on ioh.SupportId equals s.SupportId into supportJoin
                           from s in supportJoin.DefaultIfEmpty()
                           where ioh.IsActive == true
                           select new
                           {
                               ioh.IssueOnholdCatId,
                               ioh.CategoryId,
                               CategoryName = c.CategoryName,
                               ioh.CategoryTypeId,
                               TypeName = ct.CategoryType,
                               ioh.OnholdReason,
                               ioh.CreatedBy,
                               ioh.CreatedDate,
                               ioh.ModifiedBy,
                               ioh.ModifiedDate,
                               ioh.SupportId,
                               s.SupportName
                           };
                if (supportId == 0)
                {
                    return Ok(data);
                }
                else
                {
                    return Ok(data.Where(m => m.SupportId == supportId));
                }
                /*                var data = await _context.IssueOnholdCats.ToListAsync();
                */
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost("saveHoldOnReason")]
        public async Task<IActionResult> saveHoldOnReason([FromBody] IssueOnholdCat reason)
        {
            try
            {
                if (reason.IssueOnholdCatId == 0)
                {
                    await _context.IssueOnholdCats.AddAsync(reason);
                }
                else
                {
                    var existingReason = await _context.IssueOnholdCats.FindAsync(reason.IssueOnholdCatId);
                    if (existingReason == null)
                    {
                        return NotFound("Item not found.");
                    }
                    existingReason.SupportId = reason.SupportId;
                    existingReason.CategoryId = reason.CategoryId;
                    existingReason.CategoryTypeId = reason.CategoryTypeId;
                    existingReason.OnholdReason = reason.OnholdReason;
                    existingReason.IsActive = reason.IsActive;
                    existingReason.ModifiedBy = reason.ModifiedBy;
                    existingReason.ModifiedDate = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
                return Ok(reason);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


    }
}
