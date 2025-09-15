using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace IT_Portal.Persistence.Repositories
{
    public class projectIssueRepository : IprojectIssue
    {
        private readonly MicroLabsDevContext _context;

        public projectIssueRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> saveProjectIssue(SPprojectIssue model)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_ProjectIssue", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", model.Flag);
                    command.Parameters.AddWithValue("@issueId", (object)model.IssueId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TaskId", (object)model.TaskId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectMgmtID", (object)model.ProjectMgmtID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@SubTaskId", (object)model.SubTaskId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MileStoneId", (object)model.MileStoneId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectLevel", (object)model.ProjectLevel ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Description", (object)model.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Priority", (object)model.Priority ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Impact", (object)model.Impact ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DateOpened", (object)model.DateOpened ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CompletionDate", (object)model.CompletionDate ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DateClosed", (object)model.DateClosed ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IssueOwner", (object)model.IssueOwner ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Department", (object)model.Department ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Status", (object)model.Status ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Notes", (object)model.Notes ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AssignedTo", (object)model.AssignedTo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AssignedBy", (object)model.AssignedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AssignedOn", (object)model.AssignedOn ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", (object)model.CreatedBy ?? DBNull.Value);


                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                        if (model.Flag == "I")
                        {
                            var pridNew = (int)(_context.ProjectIssues.OrderByDescending(m => m.IssueId).FirstOrDefault()?.IssueId);

                            foreach (var item in model.AttachmentIds)
                            {
                                var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.PrissueId = pridNew;

                                _context.SaveChanges();
                            }
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> getProIssueById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectIssues.FirstOrDefaultAsync(m => m.IssueId == id);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }
        public async Task<CommonRsult> getProIssueProById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectIssues.Where(m => m.ProjectMgmtId == id).OrderByDescending(a => a.CreatedDt).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> deleteProjectIssueById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                using (var context = _context)
                {
                    var entity = context.ProjectIssues.FirstOrDefault(x => x.IssueId == id);
                    if (entity != null)
                    {
                        context.ProjectIssues.Remove(entity);
                        context.SaveChanges();
                    }

                    result.Message = "Successfully Deleted.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }


    }
}

