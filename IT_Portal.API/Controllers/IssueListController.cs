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
    public class IssueListController : ControllerBase
    {
        private readonly IIssueList _issuecontext;
        private readonly MicroLabsDevContext _context;

        public IssueListController(IIssueList issuecontext, MicroLabsDevContext context)
        {
            this._issuecontext = issuecontext;
            this._context = context;
        }

        [HttpPost("SaveIssue")]
        public async Task<IActionResult> InsertIssueList(SPIssueList issuelist)
        {
            var sbObj = await _issuecontext.PostIssueList(issuelist);
            return Ok(sbObj);
        }

        [HttpGet("Getissuelist")]
        public async Task<IActionResult> GetIssueList()
        {
            var data = await _context.VwIssueLists.OrderByDescending(m => m.IssueId)
                .ToListAsync();
            return Ok(data);
        }

        [HttpGet("GetissuelistById")]
        public async Task<IActionResult> GetIssueListById(int id)
        {
            var data = await _context.VwIssueLists.Where(m => m.IssueId == id).FirstOrDefaultAsync();

            return Ok(data);
        }

        [HttpGet("GetIssuelistHistory")]
        public async Task<IActionResult> GetIssuelistHistory()
        {
            var data = await _context.VwIssueListHistories.OrderBy(m => m.ModifiedDt).ToListAsync();
            return Ok(data);
        }

        [HttpPost("addFile")]
        public async Task<IActionResult> UploadFile([FromForm] srFileRquest FileRequest)
        {
            try
            {
                if (FileRequest.file == null || FileRequest.file.Length == 0)
                {
                    return BadRequest("No file selected for upload.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "issueAttchment", "Uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var attachFile = new Isattachment
                {
                    FileName = FileRequest.file.FileName,
                    IsActive = true,
                    Stage = "CR",
                    CreatedBy = FileRequest.CreatedBy,
                    CreatedDt = DateTime.Now,
                    ModifiedBy = FileRequest.CreatedBy,
                    ModifiedDt = DateTime.Now
                };

                if (!(FileRequest.srId == 0))
                {
                    attachFile.Isid = FileRequest.srId;
                }
                _context.Isattachments.Add(attachFile);
                await _context.SaveChangesAsync();

                var attachId = attachFile.AttachId;

                var fileName = $"{attachId}_{FileRequest.file.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await FileRequest.file.CopyToAsync(stream);
                }

                return Ok(new { attachId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetFileData")]
        public IActionResult GetFileData(string srId)
        {
            try
            {
                if (string.IsNullOrEmpty(srId))
                {
                    return BadRequest("Service ID and fileName are required");
                }

                var attachmentDataList = _context.Isattachments.Where(m => (bool)m.IsActive && m.Isid.ToString() == srId);
                return Ok(attachmentDataList);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
        }

        [HttpDelete("Delete/{attachId}")]
        public async Task<IActionResult> DeleteFile(int attachId)
        {
            try
            {
                var attachFile = await _context.Isattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "issueAttchment", "Uploads");
                var fileName = $"{attachId}_{attachFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _context.Isattachments.Remove(attachFile);
                await _context.SaveChangesAsync();

                return Ok(new { message = "File deleted successfully." });
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpGet("Download/{attachId}")]
        public async Task<IActionResult> DownloadFile(int attachId)
        {
            try
            {
                var attachFile = await _context.Isattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "issueAttchment", "Uploads");
                var fileName = $"{attachId}_{attachFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found on the server.");
                }

                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(fileBytes, "application/octet-stream", attachFile.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("View/{attachId}")]
        public async Task<IActionResult> viewFile(int attachId)
        {
            try
            {
                var attachFile = await _context.Isattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "issueAttchment", "Uploads");
                var fileName = $"{attachId}_{attachFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found on the server.");
                }

                var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);

                var contentType = GetContentType(filePath);

                return File(fileBytes, contentType, attachFile.FileName);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        private string GetContentType(string filePath)
        {
            var ext = Path.GetExtension(filePath).ToLowerInvariant();

            switch (ext)
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                case ".pdf":
                    return "application/pdf";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
