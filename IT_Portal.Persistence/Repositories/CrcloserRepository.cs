using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CrcloserRepository : Icrcloser
    {
        private readonly MicroLabsDevContext _context;

        public CrcloserRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRcloser(Crcloser crcloser)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRClosure", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ITCRID", crcloser.itcrid);
                    cmd.Parameters.AddWithValue("@ClosureRemarks", crcloser.ClosureRemarks);
                    cmd.Parameters.AddWithValue("@ClosedBy", crcloser.ClosedBy);
                    cmd.Parameters.AddWithValue("@ClosedDt", crcloser.ClosedDt);
                    cmd.Parameters.AddWithValue("@Feedback", crcloser.Feedback);
                    cmd.Parameters.AddWithValue("@CreatedBy", crcloser.CreatedBy);
                    cmd.Parameters.AddWithValue("@ClosedStatus", crcloser.ClosedStatus);

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
