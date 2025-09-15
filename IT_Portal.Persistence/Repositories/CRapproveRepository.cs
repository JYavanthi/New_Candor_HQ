using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CRapproveRepository : ICRapproval
    {
        private readonly MicroLabsDevContext _context;

        public CRapproveRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRapprove(SPCrapprove crapprove)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRApprover", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", crapprove.Flag);
                    cmd.Parameters.AddWithValue("@CRApproverID", crapprove.CRApproverID);
                    cmd.Parameters.AddWithValue("@ApproverLevel", crapprove.ApproverLevel);
                    cmd.Parameters.AddWithValue("@PlantID", crapprove.PlantID);
                    cmd.Parameters.AddWithValue("@SupportID", crapprove.SupportID);
                    cmd.Parameters.AddWithValue("@CRID", crapprove.CRID);
                    cmd.Parameters.AddWithValue("@Stage", crapprove.Stage);
                    cmd.Parameters.AddWithValue("@ApproverID", crapprove.ApproverID);
                    cmd.Parameters.AddWithValue("@ApprovedDt", crapprove.ApprovedDt);
                    cmd.Parameters.AddWithValue("@Remarks", crapprove.Remarks);
                    cmd.Parameters.AddWithValue("@Comments", crapprove.Comments);
                    cmd.Parameters.AddWithValue("@Status", crapprove.Status);
                    cmd.Parameters.AddWithValue("@Attachment", crapprove.Attachment);
                    cmd.Parameters.AddWithValue("@CreatedBy", crapprove.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDt", crapprove.CreatedDt);
                    cmd.Parameters.AddWithValue("@ModifiedBy", crapprove.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDt", crapprove.ModifiedDt);

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
