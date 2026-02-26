using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;

namespace IT_Portal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class projectManagement : ControllerBase
    {
        private readonly IProjectManagement _projectManagmentRepoObj;
        private readonly MicroLabsDevContext _context;
        public projectManagement(IProjectManagement projectManagmentRepoObj, MicroLabsDevContext context)
        {
            this._projectManagmentRepoObj = projectManagmentRepoObj;
            this._context = context;
        }

        [HttpPost("saveProjectMaster")]
        public async Task<IActionResult> saveProjectMaster(SPProjectMaster spProjectMasterObj)
        {
            var spObj = await _projectManagmentRepoObj.saveProject(spProjectMasterObj);
            return Ok(spObj);
        }

        [HttpGet("getProject")]
        public async Task<CommonRsult> getProject()
        {
            return await _projectManagmentRepoObj.getProject();
        }

        [HttpGet("getTask")]
        public async Task<CommonRsult> getTask(int proId)
        {
            return await _projectManagmentRepoObj.getTask(proId);
        }

        //[HttpGet("getTaskByTaskId")]
        //public async Task<CommonRsult> getTaskById(int taskId)
        //{
        //    return await _projectManagmentRepoObj.getTaskById(taskId);
        //}

        //[HttpGet("deleteTaskById")]
        //public async Task<IActionResult> deleteTaskById(int taskId)
        //{
        //    var spObj = await _projectManagmentRepoObj.deleteTaskById(taskId);
        //    return Ok(spObj);
        //}

        [HttpGet("getProjectById")]
        public async Task<CommonRsult> getProjectById([FromQuery]int id)
        {
            return await _projectManagmentRepoObj.getProjectById(id);
        }


        //[HttpGet("getProIssueById")]
        //public async Task<CommonRsult> getProIssueById(int id)
        //{
        //    return await _projectManagmentRepoObj.getProIssueById(id);
        //}



        [HttpGet("getProIssueByProId")]
        public async Task<CommonRsult> getProIssueProIdById(int id)
        {
            return await _projectManagmentRepoObj.getProIssueProById(id);
        }

        [HttpGet("getProIssue")]
        public async Task<CommonRsult> getIssue()
        {
            return await _projectManagmentRepoObj.getIssue();
        }
        //[HttpGet("getProIssueByProId")]
        //public async Task<CommonRsult> getProIssueProIdById(int id)
        //{
        //    return await _projectManagmentRepoObj.getProIssueProById(id);
        //}


        [HttpGet("deleteProjectIssueById")]
        public async Task<IActionResult> deleteProjectIssueById(int issueId)
        {
            var spObj = await _projectManagmentRepoObj.deleteProjectIssueById(issueId);
            return Ok(spObj);
        }
        //[HttpGet("deleteProjectIssueById")]
        //public async Task<IActionResult> deleteProjectIssueById(int issueId)
        //{
        //    var spObj = await _projectManagmentRepoObj.deleteProjectIssueById(issueId);
        //    return Ok(spObj);
        //}


        /*[HttpPost("saveProjectMilestone")]
        public async Task<IActionResult> saveProjectMilestone(SPProjectMilestone spProjectMilestone)
        {
            var spObj = await _projectManagmentRepoObj.saveProjectMilestone(spProjectMilestone);
            return Ok(spObj);
        }*/

        /*
                [HttpPost("saveProjectIssue")]
                public async Task<IActionResult> saveProjectPRoIssue(SPprojectIssue obj)
                {
                    var spObj = await _projectManagmentRepoObj.saveProjectIssue(obj);
                    return Ok(spObj);
                }*/

        //[HttpGet("getProjectMilestone")]
        //public async Task<CommonRsult> getProjectMilestone()
        //{
        //    return await _projectManagmentRepoObj.getProjectMilestone();
        //}


        /* [HttpPost("saveProjectask")]
                public async Task<IActionResult> saveProjectask(SP_Projecttask projectTask)
                {
                    var spObj = await _projectManagmentRepoObj.saveProjectTask(projectTask);
                    return Ok(spObj);
                }*/


        //[HttpGet("getMilestoneByProjectId")]
        //public async Task<CommonRsult> getMilestoneByProjectId(int id)
        //{
        //    return await _projectManagmentRepoObj.getMilestoneByProjectId(id);
        //}

        //[HttpGet("getMilestoneByMilestoneId")]
        //public async Task<CommonRsult> getMilestoneByMilestoneId(int id)
        //{
        //    return await _projectManagmentRepoObj.getMilestoneByMilestoneId(id);
        //}

        //[HttpGet("DeleteMilestoneById")]
        //public async Task<IActionResult> DeleteMilestoneById(int milestoneId)
        //{
        //    var spObj = await _projectManagmentRepoObj.DeleteMilestoneById(milestoneId);
        //    return Ok(spObj);
        //}


        [HttpGet("getMemberByMemberId")]
        public async Task<CommonRsult> getMemberByMemberId(int id)
        {
            return await _projectManagmentRepoObj.getMemberByMemberId(id);
        }


        [HttpGet("getMemberByProId")]
        public async Task<CommonRsult> getMemberByProId(int projectid)
        {
            return await _projectManagmentRepoObj.getMemberByProId(projectid);
        }


        [HttpPost("saveProjectMember")]
        public async Task<IActionResult> saveProjectMember(SPMemebers spProjectMember)
        {
            var spObj = await _projectManagmentRepoObj.saveProjectMember(spProjectMember);
            return Ok(spObj);
        }

        [HttpPost("saveProjectChecklist")]
        public async Task<IActionResult> saveProjectChecklist(SPProjectChecklist sPProjectChecklist)
        {
            var spObj = await _projectManagmentRepoObj.saveProjectCheckList(sPProjectChecklist);
            return Ok(spObj);
        }

        [HttpGet("getCheckiListByProId")]
        public async Task<CommonRsult> getCheckiListByProId(int projectid)
        {
            return await _projectManagmentRepoObj.getCheckiListByProId(projectid);
        }

        [HttpGet("getCheckListByCheckListId")]
        public async Task<CommonRsult> getCheckListByCheckListId(int id)
        {
            return await _projectManagmentRepoObj.getCheckListByCheckListId(id);
        }

        [HttpGet("DeleteChecklistById")]
        public async Task<IActionResult> DeleteChecklistById(int checklistId)
        {
            var spObj = await _projectManagmentRepoObj.DeleteChecklistById(checklistId);
            return Ok(spObj);
        }

        [HttpGet("DeleteMembersById")]
        public async Task<IActionResult> DeleteMembersById(int memberId)
        {
            var spObj = await _projectManagmentRepoObj.DeleteMembersById(memberId);
            return Ok(spObj);
        }
        [HttpGet("getPrHistory")]
        public async Task<CommonRsult> PrHistory(int projectid)
        {
            return await _projectManagmentRepoObj.PrHistory(projectid);
        }
        [HttpPost("addFile")]
        public async Task<IActionResult> UploadFile([FromForm] prFileRquest prFileRequest)
        {
            try
            {
                if (prFileRequest.file == null || prFileRequest.file.Length == 0)
                {
                    return BadRequest("No file selected for upload.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "prAttchment", "Uploads");

                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                var attachFile = new Prattachment
                {
                    FileName = prFileRequest.file.FileName,
                    Stage = prFileRequest.prTypeFlag,
                    CreatedBy = prFileRequest.CreatedBy,
                    CreatedDt = DateTime.Now,
                    ModifiedBy = prFileRequest.CreatedBy,
                    ModifiedDt = DateTime.Now
                };
                if (prFileRequest.prId != 0)
                {
                    attachFile.Prid = prFileRequest.prId;
                }
                if (prFileRequest.prTypeFlag == "T" && prFileRequest.prId != 0)
                {
                    attachFile.Prid = prFileRequest.prId;
                }
                if (prFileRequest.prTypeFlag == "C" && prFileRequest.prCheckListId != 0)
                {
                    attachFile.PrcheckListId = prFileRequest.prCheckListId;
                }
                if (prFileRequest.prTypeFlag == "I" && prFileRequest.prIssueId != 0)
                {
                    attachFile.PrissueId = prFileRequest.prIssueId;
                }
                if (prFileRequest.prTypeFlag == "Cr")
                {
                    attachFile.IsActive = false;
                }
                _context.Prattachments.Add(attachFile);
                await _context.SaveChangesAsync();

                var attachId = attachFile.AttachId;

                var fileName = $"{attachId}_{prFileRequest.prTypeFlag}_{prFileRequest.file.FileName}";
                var filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await prFileRequest.file.CopyToAsync(stream);
                }

                return Ok(new { attachId });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetFileData")]
        public IActionResult GetFileData(int prId, string prTypeFlag, int taskId,
            int prIssueId, int prCheckListId)
        {

            CommonRsult result = new CommonRsult();
            try
            {
                if (prTypeFlag == "P")
                {
                    if (prId == 0)
                    {
                        return BadRequest("prId and fileName are required.");
                    }

                    var attachmentDataList = _context.VwPrattachments.Where(m => (bool)m.IsActive && m.Prid == prId && m.Stage == prTypeFlag);
                    result.Data = attachmentDataList;
                }

                if (prTypeFlag == "I")
                {
                    if (prIssueId == 0)
                    {
                        return BadRequest("ChecklistId are required.");
                    }

                    var attachmentDataList = _context.VwPrattachments.Where(m => (bool)m.IsActive && m.PrissueId == prIssueId);
                    result.Data = attachmentDataList;
                }

                if (prTypeFlag == "C")
                {
                    if (prCheckListId == 0)
                    {
                        return BadRequest("ChecklistId are required.");
                    }

                    var attachmentDataList = _context.VwPrattachments.Where(m => (bool)m.IsActive && m.PrcheckListId == prCheckListId);
                    result.Data = attachmentDataList;
                }

                if (prTypeFlag == "T")
                {
                    if (taskId == 0)
                    {
                        return BadRequest("taskId are required.");
                    }

                    var attachmentDataList = _context.VwPrattachments.Where(m => (bool)m.IsActive && m.PrtaskId == taskId);
                    result.Data = attachmentDataList;
                }


                if (prTypeFlag == "Cr")
                {
                    var attachmentDataList = _context.VwPrattachments.Where(m => (bool)m.IsActive && m.Prid == prId && m.Stage == prTypeFlag);
                    result.Data = attachmentDataList;
                }
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
            return Ok(result);
        }


        [HttpGet("GetDocumetList")]
        public IActionResult GetDocumetList(int prId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                if (prId == 0)
                {
                    return BadRequest("prId and fileName are required.");
                }

                var attachmentDataList = _context.VwPrattachments.Where(m => m.Prid == prId);
                result.Data = attachmentDataList;
            }
            catch (Exception e)
            {
                return Ok(e.Message);
            }
            return Ok(result);
        }

        [HttpDelete("Delete/{attachId}")]
        public async Task<IActionResult> DeleteFile(int attachId)
        {
            try
            {
                var attachFile = await _context.Prattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                _context.Prattachments.Remove(attachFile);
                await _context.SaveChangesAsync();

                return Ok(new { message = "File deleted successfully." });
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpGet("Download/{attachId}")]
        public async Task<IActionResult> DownloadFile(int attachId, string prTypeFlag)
        {
            try
            {
                var attachFile = await _context.Prattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "prAttchment", "Uploads");
                var fileName = $"{attachId}_{prTypeFlag}_{attachFile.FileName}";
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
        public async Task<IActionResult> viewFile(int attachId, string prTypeFlag)
        {
            try
            {
                var attachFile = await _context.Prattachments.FindAsync(attachId);
                if (attachFile == null)
                {
                    return NotFound("File not found.");
                }

                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "prAttchment", "Uploads");
                var fileName = $"{attachId}_{prTypeFlag}_{attachFile.FileName}";
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

