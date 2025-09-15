using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ITSupportRepository : ISupportID
    {
        private readonly MicroLabsDevContext _context;

        public ITSupportRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<Support>> GetSuppotID()
        {
            var data = await _context.Supports.ToListAsync();
            return data;
        }

        /*public async Task<CommonRsult> GetSuppotID()
        {
            CommonRsult result = new CommonRsult();
            try
            { 
                var data = await _context.Supports.ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }*/
        public async Task<CommonRsult> Modulename(SPModule suportmodule)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_Module", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", suportmodule.Flag);
                    cmd.Parameters.AddWithValue("@SupportID", suportmodule.SupportID);
                    cmd.Parameters.AddWithValue("@SupportName", suportmodule.SupportName);
                    cmd.Parameters.AddWithValue("@ParentID", suportmodule.ParentID);
                    cmd.Parameters.AddWithValue("@IsActive", suportmodule.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", suportmodule.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", suportmodule.CreatedDate);
                    cmd.Parameters.AddWithValue("@UpdatedBy", suportmodule.UpdatedBy);
                    cmd.Parameters.AddWithValue("@UpdatedDate", suportmodule.UpdatedDate);

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
