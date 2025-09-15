using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class NatureofChangeRepository : INatureofChange
    {
        private readonly MicroLabsDevContext _context;

        public NatureofChangeRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> PostNatureofchange(SPNatureofchange natureofchange)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_NatureofChange", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", natureofchange.Flag);
                    cmd.Parameters.AddWithValue("@NatureofChangeID", natureofchange.NatureofChangeID);
                    cmd.Parameters.AddWithValue("@CategoryID", natureofchange.CategoryID);
                    cmd.Parameters.AddWithValue("@NatureofChange", natureofchange.NatureofChange);
                    cmd.Parameters.AddWithValue("@IsActive", natureofchange.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", natureofchange.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", natureofchange.CreatedDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", natureofchange.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDate", natureofchange.ModifiedDate);

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
