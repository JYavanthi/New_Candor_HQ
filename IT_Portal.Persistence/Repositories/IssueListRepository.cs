using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class IssueListRepository : IIssueList
    {
        private readonly MicroLabsDevContext _context;

        public IssueListRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> PostIssueList(SPIssueList issuelist)
        {
            CommonRsult result = new CommonRsult();
            try

            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_IssueList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", issuelist.Flag);
                    cmd.Parameters.AddWithValue("@IssueID", issuelist.IssueId);
                    cmd.Parameters.AddWithValue("@IssueSelectedfor", issuelist.IssueSelectedfor);
                    cmd.Parameters.AddWithValue("@IssueRaisedBy", issuelist.IssueRaisedBy);
                    cmd.Parameters.AddWithValue("@IssueDate", issuelist.IssueDate);
                    cmd.Parameters.AddWithValue("@IssueShotDesc", issuelist.IssueShotDesc);
                    cmd.Parameters.AddWithValue("@IssueDesc", issuelist.IssueDesc);
                    cmd.Parameters.AddWithValue("@IssueRaiseFor", issuelist.IssueRaiseFor);
                    cmd.Parameters.AddWithValue("@IssueForGuest", issuelist.IssueForGuest);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", issuelist.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", issuelist.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", issuelist.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", issuelist.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GuestReportingManagerEmployeeId", issuelist.GuestReportingManagerEmployeeId);
                    cmd.Parameters.AddWithValue("@Type", issuelist.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", issuelist.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", issuelist.PlantId);
                    cmd.Parameters.AddWithValue("@AssetID", issuelist.AssetId);
                    cmd.Parameters.AddWithValue("@CategoryID", issuelist.CategoryId);
                    cmd.Parameters.AddWithValue("@CategoryTypID", issuelist.CategoryTypId);
                    cmd.Parameters.AddWithValue("@Priority", issuelist.Priority);
                    cmd.Parameters.AddWithValue("@Source", issuelist.Source);
                    cmd.Parameters.AddWithValue("@Attachment", issuelist.Attachment);
                    cmd.Parameters.AddWithValue("@Status", issuelist.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", issuelist.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", issuelist.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", issuelist.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", issuelist.Remarks);
                    cmd.Parameters.AddWithValue("@CreatedBy", issuelist.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDt", issuelist.CreatedDt);
                    cmd.Parameters.AddWithValue("@ModifiedBy", issuelist.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDt", issuelist.ModifiedDt);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", issuelist.ModifiedDt);
                    cmd.Parameters.AddWithValue("@ResolutionDt", issuelist.ResolutionDt);
                    cmd.Parameters.AddWithValue("@ReasonID", issuelist.reasonID);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                        var issueId = cmd.Parameters["@IssueID"].Value;
                        var issueIdNew = 0;
                        /*result.Data = issueNew;*/

                        if (issuelist.Flag == "I")
                        {
                            issueIdNew = (int)(_context.IssueLists.OrderByDescending(m => m.IssueId).FirstOrDefault()?.IssueId);
                            foreach (var item in issuelist.AttachmentIds)
                            {
                                var attchObj = _context.Isattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.Isid = issueIdNew;
                                _context.SaveChanges();
                            }

                        }
                        else
                        {
                            issueIdNew = issuelist.IssueId;
                        }
                        result.Data = new { issueID = issueIdNew };
                        /*if (file != null && file.Length > 0)
                        {
                            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "issues", issueIdNew.ToString());
                            if (!Directory.Exists(uploadsFolder))
                            {
                                Directory.CreateDirectory(uploadsFolder);
                            }

                            var fileName = Path.GetFileName(file.FileName); // Use the original file name provided by the user
                            var filePath = Path.Combine(uploadsFolder, fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            result.Message += $" File '{fileName}' uploaded successfully.";
                        }
                        else
                        {
                            result.Message += " No file uploaded.";
                        }*/
                    }
                }

            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }

    }
}
