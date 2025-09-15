using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Text.Json;

namespace IT_Portal.Persistence.Repositories
{
    public class IssueResolutionRepository : IissueResolution
    {
        private readonly MicroLabsDevContext _context;

        public IssueResolutionRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> PostIssueRosulation(SPIssueResolution issueResolution)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_IssueResolution", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", issueResolution.Flag);
                    cmd.Parameters.AddWithValue("@IssueID", issueResolution.IssueId);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", issueResolution.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@ResolutionDt", issueResolution.ResolutionDt);
                    cmd.Parameters.AddWithValue("@ResolutionRemarks", issueResolution.ResolutionRemarks);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";

                    }


                }

            }
            catch (Exception)
            {
                result.Type = "E";
                result.Message = "Insert failed";
            }
            return result;
        }

        public async Task<CommonRsult> updateStatus(ErequestStatus issueResolution)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var issueObj = _context.IssueLists.Where(m => m.IssueId == issueResolution.IssueId).FirstOrDefault();
                if (issueObj != null)
                {
                    if (issueResolution.ChatsBox != null)
                    {
                        postChat(issueResolution.ChatsBox);
                    }

                    var con = (SqlConnection)_context.Database.GetDbConnection();
                    using (var cmd = new SqlCommand("IT.sp_UpdateIssueStatus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IssueId", issueResolution.IssueId);
                        cmd.Parameters.AddWithValue("@Status", issueResolution.Status);
                        cmd.Parameters.AddWithValue("@ModifiedBy", issueResolution.ModifiedBy);
                        cmd.Parameters.AddWithValue("@ResolutionRemarks", issueResolution.ResolutionRemarks);
                        cmd.Parameters.AddWithValue("@AssignedTo", issueResolution.assignTo);
                        cmd.Parameters.AddWithValue("@ReasonId", issueResolution.reasonID);
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        await cmd.ExecuteNonQueryAsync();

                        result.Type = "S";
                        result.Message = "Issue updated successfully";
                    }
                }
            }
            catch (Exception e)
            {
                result.Type = "E";
                Console.WriteLine(e);

                result.Message = e.Message;
            }
            return result;
        }

        public async Task<CommonRsult> updateStatusBulk(EbulkIssueStatusChange request)
        {
            CommonRsult result = new CommonRsult();
            var connection = (SqlConnection)_context.Database.GetDbConnection();
            try
            {
                await updateCommentBoxBulk(request);
                /*request.issueId.ForEach(a =>
                {
                    var issueObj = _context.IssueLists.Where(m => m.IssueId == a).FirstOrDefault();
                    if (issueObj != null)
                    {
                        issueObj.Status = request.status;
                    }
                });
                await _context.SaveChangesAsync();*/



                using (var cmd = new SqlCommand("IT.sp_UpdateIssueStatus", connection))
                {
                    foreach (var issueResolution in request.issueId)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IssueId", issueResolution);
                        cmd.Parameters.AddWithValue("@Status", request.status);
                        cmd.Parameters.AddWithValue("@ModifiedBy", request.ModifiedBy);
                        cmd.Parameters.AddWithValue("@ResolutionRemarks", request.Message);
                        cmd.Parameters.AddWithValue("@AssignedTo", request.assignTo);
                        cmd.Parameters.AddWithValue("@ReasonId", request.reasonID);

                        if (connection.State != ConnectionState.Open)
                        {
                            await connection.OpenAsync();
                        }

                        try
                        {
                            await cmd.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            result.Type = "E";
                            result.Message = $"An error occurred: {ex.Message}";
                            return result;  // Optional: return early if you want to stop on the first error
                        }
                    }
                }
                result.Type = "S";
                result.Message = "Status Updated Successfully.";
            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }

        public async Task<CommonRsult> updateCommentBoxBulk(EbulkIssueStatusChange request)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                request.issueId.ForEach(a =>
                {
                    var issueObj = _context.IssueCommentsBoxes.Where(m => m.IssueId == a).FirstOrDefault();
                    if (issueObj != null)
                    {
                        List<EcommentBoxMessage> messages = JsonSerializer.Deserialize<List<EcommentBoxMessage>>(issueObj.TextChat);
                        var newMessage = new EcommentBoxMessage
                        {
                            userRole = "Support Engineer",
                            text = request.Message,
                            timestamp = DateTime.UtcNow
                        };
                        messages.Add(newMessage);
                        string updatedJsonString = JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true });
                        issueObj.TextChat = updatedJsonString;
                    }
                    else
                    {
                        List<EcommentBoxMessage> messages = new List<EcommentBoxMessage>();
                        var newMessage = new EcommentBoxMessage
                        {
                            userRole = "Support Engineer",
                            text = request.Message,
                            timestamp = DateTime.UtcNow
                        };

                        messages.Add(newMessage);
                        string updatedJsonString = JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true });

                        var chatInstance = new IssueCommentsBox
                        {
                            IssueId = a,
                            TextChat = updatedJsonString
                        };

                        _context.IssueCommentsBoxes.Add(chatInstance);

                        _context.SaveChanges();
                    }
                });
                await _context.SaveChangesAsync();
                result.Type = "S";
                result.Message = "Status Updated Successfully.";
            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }
        bool postChat(EchatBox issueChat)
        {
            try
            {
                var result = _context.IssueCommentsBoxes
                    .Where(m => m.IssueId == issueChat.IssueId)
                    .FirstOrDefault();
                if (result == null)
                {
                    var chatInstance = new IssueCommentsBox
                    {
                        IssueId = issueChat.IssueId,
                        TextChat = issueChat.TextChat
                    };

                    _context.IssueCommentsBoxes.Add(chatInstance);

                    _context.SaveChanges();
                }
                else
                {
                    result.TextChat = issueChat.TextChat;

                }

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
