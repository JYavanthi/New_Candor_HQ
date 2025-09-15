using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.changerequest;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using IT_Portal.API.Controllers;
using IT_Portal.Domain.IT_Models;
using Microsoft.EntityFrameworkCore;


namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeRequestController : ControllerBase
    {
        private readonly IChangeRequest _changeRequest;
        private readonly MicroLabsDevContext _context;

        public ChangeRequestController(IChangeRequest changeRequest, MicroLabsDevContext context)
        {
            this._changeRequest = changeRequest;
            this._context = context;
        }

        [HttpPost("InsertChangeRequest")]
        public async Task<IActionResult> InsertChangeRequest(ChangeRequestSP obj)
        {
            var spObj = await _changeRequest.InsertChangeRequest(obj);
            return Ok(spObj);
        }

        [HttpGet("Getrequest")]
        public async Task<IActionResult> GetRequest()
        {
            var data = await _context.ChangeRequests.ToListAsync();
            return Ok(data);
        }

        [HttpPost("addFile")]
        public async Task<IActionResult> UploadFile([FromForm] crFileRquest crFileRequest)
        {
            try
            {
                if (crFileRequest.file == null || crFileRequest.file.Length == 0)
                {
                    return BadRequest("No file selected for upload.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "ChangeRequestRaise", "Uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var attachFile = new AttachFile
                {
                    FileName = crFileRequest.file.FileName,
                    IsActive = true,
                    Stage = crFileRequest.Stage,
                    CreatedBy = crFileRequest.CreatedBy,
                    CreatedDt = DateTime.Now,
                    ModifiedBy = crFileRequest.CreatedBy,
                    ModifiedDt = DateTime.Now
                };

                if (!(crFileRequest.Itcrid == 0))
                {
                    attachFile.Itcrid = crFileRequest.Itcrid;
                }
                _context.AttachFiles.Add(attachFile);
                await _context.SaveChangesAsync();

                var attachId = attachFile.AttachId;

                var fileName = $"{attachId}_{crFileRequest.file.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await crFileRequest.file.CopyToAsync(stream);
                }

                return Ok(new { attachId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("Delete/{attachId}")]
        public async Task<IActionResult> DeleteFile(int attachId)
        {
            try
            {
                var attachFile = await _context.AttachFiles.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "ChangeRequestRaise", "Uploads");
                var fileName = $"{attachId}_{attachFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _context.AttachFiles.Remove(attachFile);
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
                var attachFile = await _context.AttachFiles.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "ChangeRequestRaise", "Uploads");
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
                var attachFile = await _context.AttachFiles.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "ChangeRequestRaise", "Uploads");
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



        [HttpGet("GetFileData")]
        public IActionResult GetFileData(string itcrid)
        {
            try
            {
                if (string.IsNullOrEmpty(itcrid))
                {
                    return BadRequest("ITCRID and fileName are required");
                }

                var attachmentDataList = _context.AttachFiles.Where(m => (bool)m.IsActive && m.Itcrid.ToString() == itcrid);
                return Ok(attachmentDataList);
            }
            catch (Exception e)
            {
                return Ok(e.Message);
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