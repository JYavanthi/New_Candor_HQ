using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CategoryTypRepository : ICategorytyp
    {
        private readonly MicroLabsDevContext _context;

        public CategoryTypRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRcategortyp(SPCategorytyp categorytyp)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_Categorytyp", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", categorytyp.Flag);
                    cmd.Parameters.AddWithValue("@CategoryTypeID", categorytyp.CategoryTypeID);
                    cmd.Parameters.AddWithValue("@CategoryID", categorytyp.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryType", categorytyp.CategoryType);
                    cmd.Parameters.AddWithValue("@IsActive", categorytyp.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", categorytyp.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", categorytyp.CreatedDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", categorytyp.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDate", categorytyp.ModifiedDate);

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
