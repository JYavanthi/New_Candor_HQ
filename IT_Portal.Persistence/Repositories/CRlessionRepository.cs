using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CRlessionRepository : ICRlession
    {
        private readonly MicroLabsDevContext _context;

        public CRlessionRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRlession(SPCrlession crlession)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRlesson", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", crlession.Flag);
                    cmd.Parameters.AddWithValue("@CRLessonID", crlession.CRLessonID);
                    cmd.Parameters.AddWithValue("@ITCRID", crlession.ITCRID);
                    cmd.Parameters.AddWithValue("@Lessons", crlession.Lessons);
                    cmd.Parameters.AddWithValue("@Attachment", crlession.Attachment);
                    cmd.Parameters.AddWithValue("@LessonDt", crlession.LessonDt);
                    cmd.Parameters.AddWithValue("@CreatedBy", crlession.CreatedBy);

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
