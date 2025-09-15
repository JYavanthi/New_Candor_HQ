using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CategoryRepository : ICategoryRepo
    {
        private readonly MicroLabsDevContext _context;

        public CategoryRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRcategor(SPCategory crcategory)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_Category", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", crcategory.Flag);
                    cmd.Parameters.AddWithValue("@ITCategoryID", crcategory.ITCategoryID);
                    cmd.Parameters.AddWithValue("@SupportID", crcategory.SupportID);
                    cmd.Parameters.AddWithValue("@CategoryName", crcategory.CategoryName);
                    cmd.Parameters.AddWithValue("@IsActive", crcategory.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", crcategory.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDt", crcategory.CreatedDt);
                    cmd.Parameters.AddWithValue("@ModifiedBy", crcategory.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDt", crcategory.ModifiedDt);

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
