using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class SystemLandscapeSpRepository : ISystemlandscapeSp
    {
        private readonly MicroLabsDevContext _context;

        public SystemLandscapeSpRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> InsertSystemlandscape(SystemlandscapeSP systemlandscape)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SysLandscape", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", systemlandscape.Flag);
                    cmd.Parameters.AddWithValue("@SysLandscapeID", systemlandscape.SysLandscapeId);
                    cmd.Parameters.AddWithValue("@SupportID", systemlandscape.SupportId);
                    cmd.Parameters.AddWithValue("@CategoryID", systemlandscape.CategoryId);
                    cmd.Parameters.AddWithValue("@ClassificationID", systemlandscape.ClassificationId);
                    cmd.Parameters.AddWithValue("@SysLandscape", systemlandscape.SysLandscape1);
                    cmd.Parameters.AddWithValue("@PriorityNum", systemlandscape.PriorityNum);
                    cmd.Parameters.AddWithValue("@IsActive", systemlandscape.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", systemlandscape.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDt", systemlandscape.CreatedDt);
                    cmd.Parameters.AddWithValue("@ModifiedBy", systemlandscape.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDt", systemlandscape.ModifiedDt);

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
    }
}
