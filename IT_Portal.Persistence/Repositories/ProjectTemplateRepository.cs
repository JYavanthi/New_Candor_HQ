using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{

    public class ProjectTemplateRepository : IProjectTemplate
    {
        private readonly MicroLabsDevContext _context;

        public ProjectTemplateRepository(MicroLabsDevContext context)
        {
            _context = context;
        }

        public async Task<CommonRsult> saveProjectTemplate(SPProjectTemplate template)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_PRTemplate", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", template.Flag);
                    /*                    command.Parameters.AddWithValue("@PRTemplateID", SqlDbType.Int).Direction = ParameterDirection.Output;
                    */
                    command.Parameters.AddWithValue("@PRTemplateID", template.PRTemplateID);
                    command.Parameters.AddWithValue("@TemplateName", template.TemplateName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", template.IsActive);
                    command.Parameters.AddWithValue("@CreatedBy", template.CreatedBy);

                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> getProjectTemplateByTemplateId(int templateId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwPrtemplates.Where(m => m.PrtemplateId == templateId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }


        public async Task<CommonRsult> getProjectTemplateDetailsByTemplateId(int templateId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.PrtemplateDtls.Where(m => m.PrtemplateId == templateId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }


        public async Task<CommonRsult> getProjectTemplateDetailsResByTemplateId(int templateId, int lessonLearnedId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwPrtemplateDetails.Where(m => m.PrtemplateId == templateId && m.LessonLearnedId == lessonLearnedId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getProjectTemplate()
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwPrtemplates.ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }
    }
}
