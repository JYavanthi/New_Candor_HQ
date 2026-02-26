using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ProjectMasterRepository : IProjectManagement
    {

        private readonly MicroLabsDevContext _context;
        public ProjectMasterRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> saveProject(SPProjectMaster spProjectMaster)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ProjectMgmt", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", spProjectMaster.Flag);
                    cmd.Parameters.AddWithValue("@Status", spProjectMaster.Status);
                    cmd.Parameters.AddWithValue("@Approver1Remark", spProjectMaster.Approver1Remark);
                    cmd.Parameters.AddWithValue("@Approver2Remark", spProjectMaster.Approver2Remark);
                    cmd.Parameters.AddWithValue("@ProjectMgmtID", spProjectMaster.ProjectMgmtID);
                    cmd.Parameters.AddWithValue("@SupportID", spProjectMaster.SupportID);
                    cmd.Parameters.AddWithValue("@ProjectName", spProjectMaster.ProjectName);
                    cmd.Parameters.AddWithValue("@ProjectDesc", spProjectMaster.ProjectDesc);
                    cmd.Parameters.AddWithValue("@ProjectOwner", spProjectMaster.ProjectOwner);
                    cmd.Parameters.AddWithValue("@StartDt", spProjectMaster.StartDt);
                    cmd.Parameters.AddWithValue("@EndDt", spProjectMaster.EndDt);
                    cmd.Parameters.AddWithValue("@ActualStartDt", spProjectMaster.ActualStartDt);
                    cmd.Parameters.AddWithValue("@ActualEndDt", spProjectMaster.ActualEndDt);
                    cmd.Parameters.AddWithValue("@IsActive", spProjectMaster.IsActive);
                    cmd.Parameters.AddWithValue("@EstimateHrs", spProjectMaster.EstimateHrs);
                    cmd.Parameters.AddWithValue("@EstimateCost", spProjectMaster.EstimateCost);
                    cmd.Parameters.AddWithValue("@ActualHrs", spProjectMaster.ActualHrs);
                    cmd.Parameters.AddWithValue("@ActualCost", spProjectMaster.ActualCost);
                    cmd.Parameters.AddWithValue("@CreatedBy", spProjectMaster.CreatedBy);
                    cmd.Parameters.AddWithValue("@PlantID", spProjectMaster.PlantId);
                    cmd.Parameters.AddWithValue("@Sponser", spProjectMaster.Sponser);
                    cmd.Parameters.AddWithValue("@ProjectGroupId", spProjectMaster.ProjectGroupId);
                    cmd.Parameters.AddWithValue("@ProjectAccess", spProjectMaster.ProjectAccess);
                    cmd.Parameters.AddWithValue("@Deliverables", spProjectMaster.Deliverables);
                    cmd.Parameters.AddWithValue("@AdditionalNotes", spProjectMaster.AdditionalNotes);
                    SqlParameter outputError = new SqlParameter("@Error", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputError);
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                    }
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

                        if (spProjectMaster.Flag == "I")
                        {
                            var pridNew = (int)(_context.ProjectMgmts.OrderByDescending(m => m.ProjectMgmtId).FirstOrDefault()?.ProjectMgmtId);

                            foreach (var item in spProjectMaster.AttachmentIds)
                            {
                                var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.Prid = pridNew;

                                _context.SaveChanges();
                            }
                        }
                    }


                    //using (var da = new SqlDataAdapter(cmd))
                    //{
                    //    await Task.Run(() => da.Fill(dt));
                    //    result.Type = "S";


                    //    result.Message = "Insert Successfully";
                    //    if (spProjectMaster.Flag == "I")
                    //    {
                    //        var pridNew = (int)(_context.ProjectMgmts.OrderByDescending(m => m.ProjectMgmtId).FirstOrDefault()?.ProjectMgmtId);

                    //        foreach (var item in spProjectMaster.AttachmentIds)
                    //        {
                    //            var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                    //            attchObj.Prid = pridNew;

                    //            _context.SaveChanges();
                    //        }
                    //    }
                    //}
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }


        //public async Task<CommonRsult> saveProjectTask(SP_Projecttask projectTask)
        //{
        //    CommonRsult result = new CommonRsult();
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        var con = (SqlConnection)_context.Database.GetDbConnection();
        //        using (var command = new SqlCommand("IT.sp_ProjectTask", con))
        //        {
        //            command.CommandType = CommandType.StoredProcedure;

        //            command.Parameters.AddWithValue("@Flag", projectTask.Flag);
        //            command.Parameters.AddWithValue("@TaskID", projectTask.TaskID ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@MilestoneID", projectTask.MilestoneID ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@ProjectID", projectTask.ProjectID ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Owner", projectTask.Owner ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@EmpID", projectTask.EmpID ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@assignTo", projectTask.AssignTo ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Duration", projectTask.Duration ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Responsible", projectTask.Responsible ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Accountable", projectTask.Accountable ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Consulted", projectTask.Consulted ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Informed", projectTask.Informed ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@TaskTitle", projectTask.TaskTitle ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@TaskDesc", projectTask.TaskDesc ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Priority", projectTask.Priority ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@WorkHours", projectTask.WorkHours ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@Status", projectTask.Status ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@CompletionDate", projectTask.CompletionDate ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@StartDt", projectTask.StartDt ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@EndDt", projectTask.EndDt ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@IsActive", projectTask.IsActive ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@CreatedBy", projectTask.CreatedBy ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@ModifiedBy", projectTask.ModifiedBy ?? (object)DBNull.Value);
        //            command.Parameters.AddWithValue("@parentTaskId", projectTask.parentTaskId ?? (object)DBNull.Value);


        //            using (var da = new SqlDataAdapter(command))
        //            {
        //                await Task.Run(() => da.Fill(dt));
        //                result.Type = "S";
        //                result.Message = "Insert Successfully";
        //                if (projectTask.Flag == 'I')
        //                {
        //                    var pridNew = (int)(_context.ProjectTasks.OrderByDescending(m => m.TaskId).FirstOrDefault()?.TaskId);

        //                    foreach (var item in projectTask.AttachmentIds)
        //                    {
        //                        var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
        //                        attchObj.PrtaskId = pridNew;
        //                        attchObj.Prid = projectTask.ProjectID;

        //                        _context.SaveChanges();
        //                    }
        //                }

        //            }
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //        return result;
        //    }
        //}

        //public async Task<CommonRsult> saveProjectMilestone(SPProjectMilestone spProjectMilestone)
        //{
        //    CommonRsult result = new CommonRsult();
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        var con = (SqlConnection)_context.Database.GetDbConnection();
        //        using (var cmd = new SqlCommand("IT.sp_PMilestone", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Flag", spProjectMilestone.Flag);
        //            cmd.Parameters.AddWithValue("@ProjMilestoneID", spProjectMilestone.ProjMilestoneID);
        //            cmd.Parameters.AddWithValue("@ProjectID", spProjectMilestone.ProjectID);
        //            cmd.Parameters.AddWithValue("@MilestoneTitle", spProjectMilestone.MilestoneTitle);
        //            cmd.Parameters.AddWithValue("@MilestoneDesc", spProjectMilestone.MilestoneDesc);
        //            cmd.Parameters.AddWithValue("@MilestoneStatus", spProjectMilestone.MilestoneStatus);
        //            cmd.Parameters.AddWithValue("@Owner", spProjectMilestone.Owner);
        //            cmd.Parameters.AddWithValue("@Priority", spProjectMilestone.Priority);
        //            cmd.Parameters.AddWithValue("@StartDt", spProjectMilestone.StartDt);
        //            cmd.Parameters.AddWithValue("@EndDt", spProjectMilestone.EndDt);
        //            cmd.Parameters.AddWithValue("@ActualStartDt", spProjectMilestone.ActualStartDt);
        //            cmd.Parameters.AddWithValue("@ActualEndDt", spProjectMilestone.ActualEndDt);
        //            cmd.Parameters.AddWithValue("@FinishStartDt", spProjectMilestone.FinishStartDt);
        //            cmd.Parameters.AddWithValue("@FinishEndDt", spProjectMilestone.FinishEndDt);
        //            cmd.Parameters.AddWithValue("@ActualFinishStartDt", spProjectMilestone.ActualFinishStartDt);
        //            cmd.Parameters.AddWithValue("@ActualFinishEndDt", spProjectMilestone.ActualFinishEndDt);
        //            cmd.Parameters.AddWithValue("@IsActive", spProjectMilestone.IsActive);
        //            cmd.Parameters.AddWithValue("@CreatedBy", spProjectMilestone.CreatedBy);
        //            cmd.Parameters.AddWithValue("@ModifiedBy", spProjectMilestone.ModifiedBy);



        //            using (var da = new SqlDataAdapter(cmd))
        //            {
        //                await Task.Run(() => da.Fill(dt));
        //                result.Type = "S";
        //                result.Message = "Insert Successfully";

        //            }
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //        return result;
        //    }
        //}


        //public async Task<CommonRsult> saveProjectMember(SPMemebers spProjectMember)
        //{
        //    CommonRsult result = new CommonRsult();
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        var con = (SqlConnection)_context.Database.GetDbConnection();
        //        using (var cmd = new SqlCommand("IT.sp_ManageProjectMembers", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@Flag", spProjectMember.Flag);
        //            cmd.Parameters.AddWithValue("@PrMemberId", spProjectMember.PrMemberId ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@ProjectMgmtID", spProjectMember.ProjectMgmtID ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@EmpID", spProjectMember.EmpID ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@Role", spProjectMember.Role ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@Type", spProjectMember.Type ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@isResponsible", spProjectMember.Responsible ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@isAccountable", spProjectMember.Accountable ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@isConsulted", spProjectMember.Consulted ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@isInformed", spProjectMember.Informed ?? (object)DBNull.Value);
        //            cmd.Parameters.AddWithValue("@CreatedBy", spProjectMember.CreatedBy ?? (object)DBNull.Value);

        //            using (var da = new SqlDataAdapter(cmd))
        //            {
        //                await Task.Run(() => da.Fill(dt));
        //                result.Type = "S";
        //                result.Message = "Insert Successfully";

        //            }
        //        }

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //        return result;
        //    }
        //}

        public async Task<CommonRsult> saveProjectMember(SPMemebers spProjectMember)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();

                using (var cmd = new SqlCommand("IT.sp_ManageProjectMembers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Input parameters
                    cmd.Parameters.AddWithValue("@Flag", spProjectMember.Flag);
                    cmd.Parameters.AddWithValue("@PrMemberId", spProjectMember.PrMemberId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProjectMgmtID", spProjectMember.ProjectMgmtID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmpID", spProjectMember.EmpID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", spProjectMember.Role ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", spProjectMember.Type ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@isResponsible", spProjectMember.Responsible ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@isAccountable", spProjectMember.Accountable ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@isConsulted", spProjectMember.Consulted ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@isInformed", spProjectMember.Informed ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", spProjectMember.CreatedBy ?? (object)DBNull.Value);


                    SqlParameter errorParam = new SqlParameter("@errorMsg", SqlDbType.NVarChar, 500);
                    errorParam.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(errorParam);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                    }


                    string errorMsg = errorParam.Value?.ToString();

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        result.Type = "E";
                        result.Message = errorMsg;
                    }
                    else
                    {
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
                return result;
            }
        }


        public async Task<CommonRsult> saveProjectCheckList(SPProjectChecklist checklist)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_ManageProjectChecklist", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", checklist.Flag);
                    command.Parameters.AddWithValue("@checkListId", checklist.checkListId);
                    command.Parameters.AddWithValue("@checkListTital", checklist.checkListTital ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TaskId", checklist.TaskId);
                    command.Parameters.AddWithValue("@ProjectMgmtID", checklist.ProjectMgmtID);
                    command.Parameters.AddWithValue("@SubTaskId", checklist.SubTaskId);
                    command.Parameters.AddWithValue("@MileStoneId", checklist.MileStoneId);
                    command.Parameters.AddWithValue("@ProjectLevel", checklist.ProjectLevel ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Description", checklist.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", checklist.CreatedBy);
                    command.Parameters.AddWithValue("@CreatedDt", checklist.CreatedDt);
                    command.Parameters.AddWithValue("@ModifiedBy", checklist.ModifiedBy);
                    command.Parameters.AddWithValue("@ModifiedDt", checklist.ModifiedDt);
                    /*command.Parameters.AddWithValue("@ProjectLevel", checklist.ProjectLevel ?? (object)DBNull.Value);*/

                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                        var newCheckListId = (int)(_context.ProjectCheckLists.OrderByDescending(m => m.CheckListId).FirstOrDefault()?.CheckListId);

                        foreach (var item in checklist.AttachmentIds)
                        {
                            var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                            attchObj.PrcheckListId = newCheckListId;

                            _context.SaveChanges();
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

        public async Task<CommonRsult> saveProject(SPprojectIssue model)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_ProjectMgmt", con))
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
                    command.Parameters.AddWithValue("@DateClosed", (object)model.DateClosed ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IssueOwner", (object)model.IssueOwner ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Department", (object)model.Department ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Status", (object)model.Status ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Notes", (object)model.Notes ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AssignedTo", (object)model.AssignedTo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AssignedBy", (object)model.AssignedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue("@AssignedOn", (object)model.AssignedOn ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", (object)model.CreatedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ModifiedBy", (object)model.ModifiedBy ?? DBNull.Value);


                    using (var da = new SqlDataAdapter(command))
                    {
                        var newCheckListId = (int)(_context.ProjectIssues.OrderByDescending(m => m.IssueId).FirstOrDefault()?.IssueId);

                        foreach (var item in model.AttachmentIds)
                        {
                            var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                            attchObj.Prid = newCheckListId;

                            _context.SaveChanges();
                        }
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
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

        public async Task<CommonRsult> getCheckiListByProId(int proId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectCheckLists.Where(m => m.ProjectMgmtId == proId).OrderByDescending(a => a.CheckListId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getCheckListByCheckListId(int CheckListId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectCheckLists.FirstOrDefaultAsync(m => m.CheckListId == CheckListId);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> DeleteChecklistById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                using (var context = _context)
                {
                    var entity = context.ProjectCheckLists.FirstOrDefault(x => x.CheckListId == id);
                    if (entity != null)
                    {
                        context.ProjectCheckLists.Remove(entity);
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

        public async Task<CommonRsult> saveProjectIssue(SPprojectIssue spProjectIssue)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ManageProjectIssue", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", spProjectIssue.Flag);

                    cmd.Parameters.AddWithValue("@issueId", spProjectIssue.IssueId);
                    cmd.Parameters.AddWithValue("@TaskId", spProjectIssue.TaskId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProjectMgmtID", spProjectIssue.ProjectMgmtID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SubTaskId", spProjectIssue.SubTaskId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MileStoneId", spProjectIssue.MileStoneId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProjectLevel", spProjectIssue.ProjectLevel ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", spProjectIssue.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", spProjectIssue.Priority ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Impact", spProjectIssue.Impact ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOpened", spProjectIssue.DateOpened ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateClosed", spProjectIssue.DateClosed ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IssueOwner", spProjectIssue.IssueOwner ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Department", spProjectIssue.Department ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", spProjectIssue.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Notes", spProjectIssue.Notes ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedTo", spProjectIssue.AssignedTo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedBy", spProjectIssue.AssignedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedOn", spProjectIssue.AssignedOn ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", spProjectIssue.CreatedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ModifiedBy", spProjectIssue.ModifiedBy ?? (object)DBNull.Value);



                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";

                        if (spProjectIssue.Flag == "I")
                        {
                            var pridNew = (int)(_context.ProjectIssues.OrderByDescending(m => m.IssueId).FirstOrDefault()?.IssueId);

                            foreach (var item in spProjectIssue.AttachmentIds)
                            {
                                var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.PrissueId = pridNew;
                                attchObj.Prid = spProjectIssue.ProjectMgmtID;

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

        public async Task<CommonRsult> getProject()
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMgmts.OrderByDescending(m => m.ProjectMgmtId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getMemberByProId(int proId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMembers.Where(m => m.ProjectMgmtId == proId).OrderByDescending(m => m.PrMemberId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getMemberByMemberId(int memberId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMembers.FirstOrDefaultAsync(m => m.PrMemberId == memberId);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> DeleteMembersById(int id)
        {
            CommonRsult result = new CommonRsult();

            try
            {
                var con = (SqlConnection)_context.Database.GetDbConnection();

                using (var cmd = new SqlCommand("IT.sp_ManageProjectMembers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Flag", "D");
                    cmd.Parameters.AddWithValue("@PrMemberId", id);
                    cmd.Parameters.AddWithValue("@ProjectMgmtID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmpID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Role", DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", DBNull.Value);
                    cmd.Parameters.AddWithValue("@isResponsible", DBNull.Value);
                    cmd.Parameters.AddWithValue("@isAccountable", DBNull.Value);
                    cmd.Parameters.AddWithValue("@isConsulted", DBNull.Value);
                    cmd.Parameters.AddWithValue("@isInformed", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", DBNull.Value);

                    SqlParameter errorParam = new SqlParameter("@errorMsg", SqlDbType.NVarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(errorParam);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    await con.CloseAsync();

                    string errorMsg = errorParam.Value?.ToString();

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        result.Type = "E";
                        result.Message = errorMsg;
                    }
                    else
                    {
                        result.Type = "S";
                        result.Message = "Successfully Deleted.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
            }

            return result;
        }


        public async Task<CommonRsult> getTask(int projectId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectTasks.Where(m => m.ProjectId == projectId).OrderByDescending(a => a.TaskId).ToListAsync();
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

        public async Task<CommonRsult> getProjectById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMgmts.FirstOrDefaultAsync(m => m.ProjectMgmtId == id);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getIssue()
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectIssues.ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
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
                var data = await _context.VwProjectIssues.Where(m => m.ProjectMgmtId == id).OrderByDescending(a => a.IssueId).ToListAsync();
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

        //public async Task<CommonRsult> getProjectMilestone()
        //{
        //    CommonRsult result = new CommonRsult();
        //    try
        //    {
        //        /*var data = _context.ProjMilestones.ToListAsync();
        //        result.Data = data;*/
        //        result.Message = "vijay";
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = (ex.Message);
        //    }
        //    return result;
        //}

        public async Task<CommonRsult> getMilestoneByProjectId(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMilestones.Where(m => m.ProjectId == id).OrderByDescending(a => a.ProjMilestoneId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        //public async Task<CommonRsult> getMilestoneByMilestoneId(int id)
        //{
        //    CommonRsult result = new CommonRsult();
        //    try
        //    {
        //        var data = await _context.ProjectMilestones.FirstOrDefaultAsync(m => m.ProjMilestoneId == id);
        //        result.Data = data;
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = (ex.Message);
        //    }
        //    return result;
        //}

        //public async Task<CommonRsult> DeleteMilestoneById(int id)
        //{
        //    CommonRsult result = new CommonRsult();
        //    try
        //    {
        //        using (var context = _context)
        //        {
        //            var entity = context.ProjectMilestones.FirstOrDefault(x => x.ProjMilestoneId == id);
        //            if (entity != null)
        //            {
        //                context.ProjectMilestones.Remove(entity);
        //                context.SaveChanges();
        //            }

        //            result.Message = "Successfully Deleted.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result.Message = ex.Message;
        //    }

        //    return result;
        //}

        public async Task<CommonRsult> getIssueByProId(int proId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectIssues.Where(m => m.ProjectMgmtId == proId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getIssueByIssueId(int proIssueId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectIssues.FirstOrDefaultAsync(m => m.IssueId == proIssueId);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }
        public async Task<CommonRsult> PrHistory(int projectid)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMgmtHistories.Where(m => m.ProjectMgmtId == projectid).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }


    }

}
