using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CRreleaseRepository : ICrrelease
    {
        private readonly MicroLabsDevContext _context;

        public CRreleaseRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRrelease(SPCrrelease crrelease)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRRelease", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", crrelease.Flag);
                    cmd.Parameters.AddWithValue("@CRReleaseID", crrelease.CRReleaseID);
                    cmd.Parameters.AddWithValue("@ITCRID", crrelease.ITCRID);
                    cmd.Parameters.AddWithValue("@SysLandscape", crrelease.SysLandscape);
                    cmd.Parameters.AddWithValue("@ReleaseComments", crrelease.ReleaseComments);
                    cmd.Parameters.AddWithValue("@AssignedTo", crrelease.AssignedTo);
                    cmd.Parameters.AddWithValue("@ReleaseDt", crrelease.ReleaseDt);
                    cmd.Parameters.AddWithValue("@Attachments", crrelease.Attachments);
                    cmd.Parameters.AddWithValue("@Status", crrelease.Status);
                    cmd.Parameters.AddWithValue("@ApprovedBy", crrelease.ApprovedBy);
                    cmd.Parameters.AddWithValue("@ApprovedDt", crrelease.ApprovedDt);
                    cmd.Parameters.AddWithValue("@CreatedBy", crrelease.CreatedBy);

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
