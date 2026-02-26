using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ReferenceTypeRepository : IReferenceType
    {
        private readonly MicroLabsDevContext _context;

        public ReferenceTypeRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRRefrencetyp(SPRefernceTyp refrencetyp)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRRefrenceType", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", refrencetyp.Flag);
                    cmd.Parameters.AddWithValue("@ReferenceTypeID", refrencetyp.ReferenceTypeID);
                    cmd.Parameters.AddWithValue("@ReferenceType", refrencetyp.ReferenceType);
                    cmd.Parameters.AddWithValue("@IsActive", refrencetyp.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", refrencetyp.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", refrencetyp.CreatedDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", refrencetyp.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDate", refrencetyp.ModifiedDate);

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

        public async Task<List<ReferenceTyp>> GetReferenceType()
        {
            var data = await _context.ReferenceTyps.ToListAsync();
            return data;
        }
    }
}
