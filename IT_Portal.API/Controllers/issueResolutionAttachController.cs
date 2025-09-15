using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class issueResolutionAttachController : ControllerBase
    {

        private readonly MicroLabsDevContext _context;
        public issueResolutionAttachController(MicroLabsDevContext context)
        {
            this._context = context;
        }

        [HttpPost("saveDocument")]
        public async Task<IActionResult> UploadFile([FromForm] string issueId, [FromForm] IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("File is not selected or empty");
                }

                if (string.IsNullOrEmpty(issueId))
                {
                    return BadRequest("IssueId is required");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "issuesDoc", issueId);
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
                return Ok(StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}"));
            }
        }


        [HttpGet("GetFile")]
        public IActionResult GetFile(string issueId, string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(issueId) || string.IsNullOrEmpty(fileName))
                {
                    return BadRequest("issueId and fileName are required");
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "issuesDoc", issueId, fileName);
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found");
                }

                var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                var fileType = "application/octet-stream"; // You can determine the file type based on the file extension
                return File(fileStream, fileType, fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
