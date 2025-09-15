using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CRTemplateRepository : ICRtemplate
    {
        private readonly MicroLabsDevContext _context;

        public CRTemplateRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRTemplate(SPCRtemplate crtemplate)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRTemplate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", crtemplate.Flag);
                    cmd.Parameters.AddWithValue("@CRTemplateID", crtemplate.CRTemplateID);
                    cmd.Parameters.AddWithValue("@TemplateName", crtemplate.TemplateName);
                    cmd.Parameters.AddWithValue("@CRID", crtemplate.CRID);
                    cmd.Parameters.AddWithValue("@CRTemplateDtlsID", crtemplate.CRTemplateDtlsID);
                    cmd.Parameters.AddWithValue("@SupportID", crtemplate.SupportID);
                    cmd.Parameters.AddWithValue("@SysLandscapeID", crtemplate.SysLandscapeID);
                    cmd.Parameters.AddWithValue("@ClassificationID", crtemplate.ClassificationID);
                    cmd.Parameters.AddWithValue("@CategoryID", crtemplate.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", crtemplate.CategoryTypID);
                    cmd.Parameters.AddWithValue("@TaskName", crtemplate.TaskName);
                    cmd.Parameters.AddWithValue("@TaskDesc", crtemplate.TaskDesc);
                    cmd.Parameters.AddWithValue("@Priority", crtemplate.Priority);
                    cmd.Parameters.AddWithValue("@IsActive", crtemplate.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", crtemplate.CreatedBy);

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