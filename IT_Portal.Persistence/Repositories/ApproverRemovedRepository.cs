using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetApprover;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ApproverRemovedRepository : IApproverRemoved
    {
        private readonly MicroLabsDevContext _context;

        public ApproverRemovedRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> postApprover(IApproverRemoved approverRemoved)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ApproverRemoved", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SupportTeamID", approverRemoved.SupportTeamID);
                    cmd.Parameters.AddWithValue("@PlantID", approverRemoved.PlantID);
                    cmd.Parameters.AddWithValue("@SupportID", approverRemoved.SupportID);
                    cmd.Parameters.AddWithValue("@CategoryID", approverRemoved.CategoryID);
                    cmd.Parameters.AddWithValue("@ClassificationID", approverRemoved.ClassificationID);
                    cmd.Parameters.AddWithValue("@Approverstage ", approverRemoved.Approverstage);
                    cmd.Parameters.AddWithValue("@Level", approverRemoved.Level);
                    cmd.Parameters.AddWithValue("@CreatedBy ", approverRemoved.CreatedBy);
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                    }
                    return result;
                }
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
