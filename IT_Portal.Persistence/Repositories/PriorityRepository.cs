using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class PriorityRepository : Ipriority
    {
        private readonly MicroLabsDevContext _context;

        public PriorityRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRPriority(SPPriority prioritytyp)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_Priority", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", prioritytyp.Flag);
                    cmd.Parameters.AddWithValue("@PriorityID", prioritytyp.PriorityID);
                    cmd.Parameters.AddWithValue("@PriorityName", prioritytyp.PriorityName);
                    cmd.Parameters.AddWithValue("@IsActive", prioritytyp.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", prioritytyp.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", prioritytyp.CreatedDate);
                    cmd.Parameters.AddWithValue("@UpdatedBy", prioritytyp.UpdatedBy);
                    cmd.Parameters.AddWithValue("@UpdatedDate", prioritytyp.UpdatedDate);

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

        public async Task<List<Priority>> Getpriority()
        {
            var data = await _context.Priorities.ToListAsync();
            return data;
        }
    }
}
