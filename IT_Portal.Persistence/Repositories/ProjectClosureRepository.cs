using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    class ProjectClosureRepository : IProjectClosure
    {
        private readonly MicroLabsDevContext _context;

        public ProjectClosureRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> PostProjclosure(Application.Features.ProjectClosure projectClosure)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ProjectClosure", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", projectClosure.Flag);
                    cmd.Parameters.AddWithValue("@ClosureID", projectClosure.ClosureID);
                    cmd.Parameters.AddWithValue("@ProjectID", projectClosure.ProjectID);
                    cmd.Parameters.AddWithValue("@Status ", projectClosure.Status);
                    cmd.Parameters.AddWithValue("@Remarks", projectClosure.Remarks);
                    cmd.Parameters.AddWithValue("@Attachment", projectClosure.Attachment);
                    cmd.Parameters.AddWithValue("@LessonsLearnt", projectClosure.LessonsLearnt);
                    cmd.Parameters.AddWithValue("@Task ", projectClosure.Task);
                    cmd.Parameters.AddWithValue("@Category", projectClosure.Category);
                    cmd.Parameters.AddWithValue("@ProblemsStatement", projectClosure.ProblemsStatement);
                    cmd.Parameters.AddWithValue("@Impact", projectClosure.Impact);
                    cmd.Parameters.AddWithValue("@Recommendation", projectClosure.Recommendation);
                    cmd.Parameters.AddWithValue("@Feedback ", projectClosure.Feedback);
                    cmd.Parameters.AddWithValue("@IsSponsor", projectClosure.IsSponsor);
                    cmd.Parameters.AddWithValue("@CreatedBy", projectClosure.CreatedBy);

                    foreach (var item in projectClosure.AttachmentIds)
                    {
                        var attchObj = _context.Prattachments.Where(m => m.AttachId == item).FirstOrDefault();
                        attchObj.IsActive = true;
                        _context.SaveChanges();
                    }

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
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

        public async Task<CommonRsult> getClosureByProjectId(int prjectId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectClosures.Where(m => m.ProjectId == prjectId).ToListAsync();
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
