using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRlessionController : ControllerBase
    {
        private readonly ICRlession _crlessioncontext;
        private readonly MicroLabsDevContext _context;

        public CRlessionController(ICRlession crlessioncontext, MicroLabsDevContext context)
        {
            this._crlessioncontext = crlessioncontext;
            this._context = context;
        }

        [HttpPost("Approve")]
        public async Task<IActionResult> CRapprove(SPCrlession obj)
        {
            var spObj = await _crlessioncontext.CRlession(obj);
            return Ok(spObj);
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] string itcrid, [FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("File is not selected or empty");
                }

                if (string.IsNullOrEmpty(itcrid))
                {
                    return BadRequest("ITCRID is required");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "ChangeRequest", itcrid);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var fileName = file.FileName; // Use the original file name provided by the user
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { fileName });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetFile")]
        public IActionResult GetFile(string itcrid, string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(itcrid) || string.IsNullOrEmpty(fileName))
                {
                    return BadRequest("ITCRID and fileName are required");
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "ChangeRequest", itcrid, fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found");
                }

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var fileType = "application/octet-stream";
                return File(fileStream, fileType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetCrLession")]
        public async Task<IActionResult> GetRequest()
        {
            var data = await _context.Crlessons.ToListAsync();
            return Ok(data);
        }
    }
}
