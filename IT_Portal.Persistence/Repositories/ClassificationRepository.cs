using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ClassificationRepository : IClasifications
    {
        private readonly MicroLabsDevContext _context;

        public ClassificationRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> postClassification(SPClassifications classifications)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_Classification", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", classifications.Flag);
                    cmd.Parameters.AddWithValue("@ITClassificationID", classifications.ITClassificationID);
                    cmd.Parameters.AddWithValue("@ClassificationName", classifications.ClassificationName);
                    cmd.Parameters.AddWithValue("@CreatedBy", classifications.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDt", classifications.CreatedDt);
                    cmd.Parameters.AddWithValue("@ModifiedBy", classifications.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDt", classifications.ModifiedDt);

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
