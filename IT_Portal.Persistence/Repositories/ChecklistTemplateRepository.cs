using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ChecklistTemplateRepository : IChecklistTemplate
    {
        private readonly MicroLabsDevContext _context;

        public ChecklistTemplateRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetChecklistTemplate()
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwChecklistTemplates.OrderByDescending(m => m.CreatedDt).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<CommonRsult> GetCheckList()
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwProjectCheckLists.ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<CommonRsult> deleteChecklistTemplate(int id)
        {
            CommonRsult result = new CommonRsult();

            try
            {
                var entity = _context.ChecklistTemplates.FirstOrDefault(m => m.ChecklisttemplateId == id);
                if (entity != null)
                {
                    _context.ChecklistTemplates.Remove(entity);
                    await _context.SaveChangesAsync();
                }
                result.Type = "S";
                result.Message = "Successfully Deleted.";
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<CommonRsult> PostChecklistTemplate(SPChecklistTemplate sPProject)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ChecklistTemplate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sPProject.Flag);
                    cmd.Parameters.AddWithValue("@ChecklisttemplateId", sPProject.ChecklisttemplateId);
                    cmd.Parameters.AddWithValue("@ChecklistIDs", sPProject.ChecklistIDs);
                    cmd.Parameters.AddWithValue("@TemplateName", sPProject.TemplateName);
                    cmd.Parameters.AddWithValue("@CreatedBy", sPProject.CreatedBy);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
