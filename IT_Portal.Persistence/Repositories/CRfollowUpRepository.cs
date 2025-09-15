using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CRfollowUpRepository : ICRfollowUp
    {
        private readonly MicroLabsDevContext _context;

        public CRfollowUpRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRfollowup(SPCrfollowUp crfollowUp)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRFollowup", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", crfollowUp.Flag);
                    cmd.Parameters.AddWithValue("@CRFollowupID", crfollowUp.CRFollowupID);
                    cmd.Parameters.AddWithValue("@ITCRID", crfollowUp.ITCRID);
                    cmd.Parameters.AddWithValue("@FollowupDt", crfollowUp.FollowupDt);
                    cmd.Parameters.AddWithValue("@FollowupToPerson", crfollowUp.FollowupToPerson);
                    cmd.Parameters.AddWithValue("FollowupComments", crfollowUp.FollowupComments);
                    cmd.Parameters.AddWithValue("@CreatedBy", crfollowUp.CreatedBy);


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
