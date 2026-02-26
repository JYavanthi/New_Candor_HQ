using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR.Domain;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class serviceMaster : ControllerBase
    {
        private readonly IserviceMaster _serviceRepo;
        private readonly MicroLabsDevContext _context;

        public serviceMaster(IserviceMaster serviceMaster, MicroLabsDevContext context)
        {
            this._serviceRepo = serviceMaster;
            this._context = context;
        }

        [HttpPost("saveSoftware")]
        public async Task<IActionResult> InsertServiceMaster(serviceRequestSoft request)
        {
            var spObj = await _serviceRepo.postService(request);
            return Ok(spObj);
        }

        [HttpPost("saveDomain")]
        public async Task<IActionResult> saveDomain(EdomainRequest request)
        {
            var spObj = await _serviceRepo.saveDomain(request);
            return Ok(spObj);
        }

        [HttpGet("getDomain")]
        public async Task<IActionResult> getDomain([FromQuery] ESRfilterRequest request)
        {
            var spObj = await _serviceRepo.getDomain(request);
            return Ok(spObj);
        }

        [HttpGet("getService")]
        public async Task<IActionResult> getService([FromQuery] ESRfilterRequest request)
        {
            var spObj = await _serviceRepo.getService(request);
            return Ok(spObj);
        }


        [HttpGet("DeleteSRById")]
        public async Task<IActionResult> DeleteSRById(int srId)
        {
            var spObj = await _serviceRepo.DeleteSRById(srId);
            return Ok(spObj);
        }

        [HttpGet("getSoftware")]
        public async Task<IActionResult> getSoftService([FromQuery] ESRfilterRequest request)
        {
            var spObj = await _serviceRepo.getServiceSoft(request);
            return Ok(spObj);
        }

        [HttpPost("submitResolution")]
        public async Task<IActionResult> saveResolution(ESrSoftwareResolution request)
        {
            var spObj = await _serviceRepo.submitResolution(request);
            return Ok(spObj);
        }


        [HttpPost("srAssignTo")]
        public async Task<IActionResult> assignTo(ESRAssignTo request)
        {
            var spObj = await _serviceRepo.assignTo(request);
            return Ok(spObj);
        }

        [HttpGet("getSrApprover")]
        public async Task<IActionResult> getSrApprover(string id)
        {
            var spObj = await _serviceRepo.getApprover(id);
            return Ok(spObj);
        }

        [HttpGet("getSRResolution")]
        public async Task<IActionResult> saveResolution([FromQuery] ESRfilterRequest request)
        {
            var spObj = await _serviceRepo.getResolution(request);
            return Ok(spObj);
        }


        [HttpGet("getSRResolutionHistory")]
        public async Task<IActionResult> getResolutionHistory([FromQuery] ESRfilterRequest request)
        {
            var spObj = await _serviceRepo.getResolutionHistory(request);
            return Ok(spObj);
        }

        [HttpGet("getSRHistory")]
        public async Task<IActionResult> getSRHistory([FromQuery] ESRfilterRequest request)
        {
            var spObj = await _serviceRepo.getHistory(request);
            return Ok(spObj);
        }

        [HttpGet("getSRApproved")]
        public async Task<IActionResult> getSRApproved(int srId)
        {
            var spObj = await _serviceRepo.getSRApproved(srId);
            return Ok(spObj);
        }

        [HttpPost("addFile")]
        public async Task<IActionResult> UploadFile([FromForm] srFileRquest crFileRequest)
        {
            try
            {
                if (crFileRequest.file == null || crFileRequest.file.Length == 0)
                {
                    return BadRequest("No file selected for upload.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "srAttchment", "Uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var attachFile = new Srattachment
                {
                    FileName = crFileRequest.file.FileName,
                    IsActive = true,
                    Stage = "CR",
                    CreatedBy = crFileRequest.CreatedBy,
                    CreatedDt = DateTime.Now,
                    ModifiedBy = crFileRequest.CreatedBy,
                    ModifiedDt = DateTime.Now
                };

                if (!(crFileRequest.srId == 0))
                {
                    attachFile.Srid = crFileRequest.srId;
                }
                _context.Srattachments.Add(attachFile);
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

        [HttpGet("GetFileData")]
        public IActionResult GetFileData(string srId)
        {
            try
            {
                if (string.IsNullOrEmpty(srId))
                {
                    return BadRequest("srId and fileName are required");
                }

                var attachmentDataList = _context.Srattachments.Where(m => (bool)m.IsActive && m.Srid.ToString() == srId);
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
                var attachFile = await _context.Srattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "srAttchment", "Uploads");
                var fileName = $"{attachId}_{attachFile.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                _context.Srattachments.Remove(attachFile);
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
                var attachFile = await _context.Srattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "srAttchment", "Uploads");
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
                var attachFile = await _context.Srattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "srAttchment", "Uploads");
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

        /*
                [HttpGet("getHODByModuleId")]
                public async Task<IActionResult> getHod(int modulID)
                {
                    var spObj = await _serviceRepo.getHodBy(modulID);
                    return Ok(spObj);
                }*/
        /*
                [HttpPost("saveDomain")]
                public async Task<IActionResult> InsertDomainMaster(serviceRequestSoft request)
                {
                    var spObj = await _servic eRepo.saveDomain(request);
                    return Ok(spObj);
                }*/
    }
}
