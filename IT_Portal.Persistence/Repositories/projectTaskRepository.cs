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
    public class projectTaskRepository : IprojectTask
    {
        private readonly MicroLabsDevContext _context;

        public projectTaskRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> saveProjectTask(SPProjecttask projectTask)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_ProjectTask", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Flag", projectTask.Flag);
                    command.Parameters.AddWithValue("@TaskID", projectTask.TaskID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MilestoneID", projectTask.MilestoneID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectID", projectTask.ProjectID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Owner", projectTask.Owner ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@EmpID", projectTask.EmpID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@assignTo", projectTask.AssignTo ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Duration", projectTask.Duration ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Responsible", projectTask.Responsible ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Accountable", projectTask.Accountable ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Consulted", projectTask.Consulted ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Informed", projectTask.Informed ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TaskTitle", projectTask.TaskTitle ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Dependency", projectTask.Dependency ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TaskDesc", projectTask.TaskDesc ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsSubtask", projectTask.IsSubtask ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Priority", projectTask.Priority ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@WorkHours", projectTask.WorkHours ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Status", projectTask.Status ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Projectphase", projectTask.Projectphase ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CompletionDate", projectTask.CompletionDate ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@StartDt", projectTask.StartDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@EndDt", projectTask.EndDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ActualStartDt", projectTask.ActualStartDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ActualEndDt", projectTask.ActualEndDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ActualCost", projectTask.ActualCost ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PlannedCost", projectTask.PlannedCost ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", projectTask.IsActive ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", projectTask.CreatedBy ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ModifiedBy", projectTask.ModifiedBy ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@parentTaskId", projectTask.parentTaskId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@AdditionalNotes", projectTask.addditionalNotes ?? (object)DBNull.Value);


                    SqlParameter outputError = new SqlParameter("@Error", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputError);

                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                    }

                    // ✅ Read the output value after execution
                    string errorMsg = outputError.Value?.ToString();

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        result.Type = "E";
                        result.Message = errorMsg;
                    }
                    else
                    {
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                        if (projectTask.Flag == 'I')
                        {
                            var pridNew = (int)(_context.ProjectTasks.OrderByDescending(m => m.TaskId).FirstOrDefault()?.TaskId);

                            foreach (var item in projectTask.AttachmentIds)
                            {
                                var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.PrtaskId = pridNew;
                                attchObj.Prid = projectTask.ProjectID;

                                _context.SaveChanges();
                            }
                        }
                    }

                    return result;
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> getTask(int projectId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectTasks.Where(m => m.ProjectId == projectId).OrderByDescending(m => m.CreatedDt).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }
        public async Task<CommonRsult> getTaskById(int taskId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectTasks.FirstOrDefaultAsync(m => m.TaskId == taskId);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }
        public async Task<CommonRsult> deleteTaskById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                using (var context = _context)
                {
                    var entity = context.ProjectTasks.FirstOrDefault(x => x.TaskId == id);
                    if (entity != null)
                    {
                        context.ProjectTasks.Remove(entity);
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

