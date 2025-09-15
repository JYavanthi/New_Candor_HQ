using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class SoftwareLibraryRepositories : ISoftwareLibrary
    {
        private readonly MicroLabsDevContext _context;

        public SoftwareLibraryRepositories(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> PostSoftwareLibrary(Application.Features.SoftwareLibrary library)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SoftwareLibrary", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", library.Flag);//(object)lessons.ProjectID ?? DBNull.Value
                    cmd.Parameters.AddWithValue("@SoftwareLibraryID", (object)library.SoftwareLibraryID ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoftwareName", (object)library.SoftwareName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", library.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", library.CreatedBy);

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
