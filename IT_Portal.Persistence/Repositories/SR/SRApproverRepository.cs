using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{

    public class SRApproverRepository : ISRApprover
    {
        private readonly MicroLabsDevContext _context;

        public SRApproverRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> getApprover(int srId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.Srapprovers.Where(m => m.Srid == srId)
                    .ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<CommonRsult> PostApprover(SRApprover sRApprover)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRApprover", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sRApprover.Flag);
                    cmd.Parameters.AddWithValue("@SRApproverID", sRApprover.SRApproverID);
                    cmd.Parameters.AddWithValue("@PlantID", sRApprover.PlantID);
                    cmd.Parameters.AddWithValue("@SupportID", sRApprover.SupportID);
                    cmd.Parameters.AddWithValue("@SRID", sRApprover.SRID);
                    cmd.Parameters.AddWithValue("@ApproverLevel", sRApprover.ApproverLevel);
                    cmd.Parameters.AddWithValue("@Stage", sRApprover.Stage);
                    cmd.Parameters.AddWithValue("@ApproverID", sRApprover.ApproverID);
                    cmd.Parameters.AddWithValue("@Remarks", sRApprover.Remarks);
                    cmd.Parameters.AddWithValue("@Status", sRApprover.Status);
                    cmd.Parameters.AddWithValue("@Attachment", sRApprover.Attachment);
                    cmd.Parameters.AddWithValue("@CreatedBy", sRApprover.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDt", sRApprover.CreatedDt);
                    cmd.Parameters.AddWithValue("@ModifiedBy", sRApprover.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDt", sRApprover.ModifiedDt);

                    var srId = 0;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S"; srId = 0;
                        srId = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);

                        result.Data = new { srId = srId };
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
    }
}
