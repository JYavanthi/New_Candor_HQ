using IT_Portal.Application.Contracts;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class SoftwareVersionRepository : ISoftwareVersion
    {
        private readonly MicroLabsDevContext _context;

        public SoftwareVersionRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> PostSoftwareVersion(SoftwareVerison software)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SoftwareVersion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", software.Flag);
                    cmd.Parameters.AddWithValue("@SoftVersionID ", software.SoftVersionID);
                    cmd.Parameters.AddWithValue("@SoftwareLibraryID", software.SoftwareLibraryID);
                    cmd.Parameters.AddWithValue("@SoftVersionName", software.SoftVersionName);
                    cmd.Parameters.AddWithValue("@IsActive", software.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", software.CreatedBy);

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

