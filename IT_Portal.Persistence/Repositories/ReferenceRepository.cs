using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ReferenceRepository : IReference
    {
        private readonly MicroLabsDevContext _context;

        public ReferenceRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRRefrence(SPCRrefrence refrence)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRRefrence", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", refrence.Flag);
                    cmd.Parameters.AddWithValue("@ReferenceID", refrence.ReferenceID);
                    cmd.Parameters.AddWithValue("@ReferenceName", refrence.ReferenceName);
                    cmd.Parameters.AddWithValue("@IsActive", refrence.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", refrence.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", refrence.CreatedDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", refrence.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDate", refrence.ModifiedDate);

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

        public async Task<List<Reference>> Getreference()
        {
            var data = await _context.References.ToListAsync();
            return data;
        }
    }
}
