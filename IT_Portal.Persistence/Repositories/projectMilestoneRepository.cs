using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace IT_Portal.Persistence.Repositories
{
    public class projectMilestoneRepository : IprojectMilestone
    {
        private readonly MicroLabsDevContext _context;
        public projectMilestoneRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> saveProjectMilestone(SPProjectMilestone spProjectMilestone)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();

                using (var cmd = new SqlCommand("IT.sp_PMilestone", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add input parameters
                    cmd.Parameters.AddWithValue("@Flag", spProjectMilestone.Flag);
                    cmd.Parameters.AddWithValue("@ProjMilestoneID", spProjectMilestone.ProjMilestoneID);
                    cmd.Parameters.AddWithValue("@ProjectID", spProjectMilestone.ProjectID);
                    cmd.Parameters.AddWithValue("@MilestoneTitle", spProjectMilestone.MilestoneTitle);
                    cmd.Parameters.AddWithValue("@MilestoneDesc", spProjectMilestone.MilestoneDesc);
                    cmd.Parameters.AddWithValue("@MilestoneStatus", spProjectMilestone.MilestoneStatus);
                    cmd.Parameters.AddWithValue("@Owner", spProjectMilestone.Owner);
                    cmd.Parameters.AddWithValue("@Priority", spProjectMilestone.Priority);
                    cmd.Parameters.AddWithValue("@StartDt", spProjectMilestone.StartDt);
                    cmd.Parameters.AddWithValue("@EndDt", spProjectMilestone.EndDt);
                    cmd.Parameters.AddWithValue("@ActualStartDt", spProjectMilestone.ActualStartDt);
                    cmd.Parameters.AddWithValue("@ActualEndDt", spProjectMilestone.ActualEndDt);
                    cmd.Parameters.AddWithValue("@FinishStartDt", spProjectMilestone.FinishStartDt);
                    cmd.Parameters.AddWithValue("@FinishEndDt", spProjectMilestone.FinishEndDt);
                    cmd.Parameters.AddWithValue("@ActualFinishStartDt", spProjectMilestone.ActualFinishStartDt);
                    cmd.Parameters.AddWithValue("@ActualFinishEndDt", spProjectMilestone.ActualFinishEndDt);
                    cmd.Parameters.AddWithValue("@IsActive", spProjectMilestone.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", spProjectMilestone.CreatedBy);
                    cmd.Parameters.AddWithValue("@ModifiedBy", spProjectMilestone.ModifiedBy);


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
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
                return result;
            }
        }
        public async Task<CommonRsult> getProjectMilestone()
        {
            CommonRsult result = new CommonRsult();
            try
            {
                /*var data = _context.ProjMilestones.ToListAsync();
                result.Data = data;*/
                result.Message = "vijay";
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getMilestoneByProjectId(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMilestones.Where(m => m.ProjectId == id).OrderByDescending(m => m.CreatedDt).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getMilestoneByMilestoneId(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectMilestones.FirstOrDefaultAsync(m => m.ProjMilestoneId == id);
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }
        public async Task<CommonRsult> DeleteMilestoneById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                using (var context = _context)
                {
                    var entity = context.ProjectMilestones.FirstOrDefault(x => x.ProjMilestoneId == id);
                    if (entity != null)
                    {
                        context.ProjectMilestones.Remove(entity);
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

