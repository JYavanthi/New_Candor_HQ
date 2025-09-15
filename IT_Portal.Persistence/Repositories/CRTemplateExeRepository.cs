using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CRTemplateExeRepository : ICRTemplateExe
    {
        private readonly MicroLabsDevContext _context;

        public CRTemplateExeRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRTemplateexe(CRTemplateExe crtemplateexe)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRTemplateExecPlan", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", crtemplateexe.Flag);
                    cmd.Parameters.AddWithValue("@CRTemplateID", crtemplateexe.CRTemplateID);
                    cmd.Parameters.AddWithValue("@CRID", crtemplateexe.CRID);
                    cmd.Parameters.AddWithValue("@CreatedBy", crtemplateexe.CreatedBy);

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