using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ProjectLessonsRepository : IProjectLessons
    {
        private readonly MicroLabsDevContext _context;

        public ProjectLessonsRepository(MicroLabsDevContext context)
        {
            _context = context;
        }

        public async Task<CommonRsult> saveProjectLessons(SPProjectLessons lessons)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_PRLesson", con))
                {
                    if (lessons.Flag == 'U')
                    {
                        var leessonData = _context.Prlessons.FirstOrDefault(m => m.PrlessonsId == lessons.PRLessonsID);

                        if (leessonData.TemplateId != lessons.TemplateID)
                        {
                            var responseData = _context.PrtemplateResponses.Where(m => m.LessonLearnedId == lessons.PRLessonsID);

                            _context.RemoveRange(responseData);
                            _context.SaveChanges();
                        }
                    }
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", (object)lessons.Flag ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PRLessonsID", (object)lessons.PRLessonsID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectID", (object)lessons.ProjectID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TemplateID", (object)lessons.TemplateID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@TaskID", (object)lessons.TaskID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MilestoneID", (object)lessons.MilestoneID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Category", (object)lessons.Category ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Lessons_Type", (object)lessons.Lessons_Type ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Description", (object)lessons.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Impact", (object)lessons.Impact ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Recommendation", (object)lessons.Recommendation ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProjCloserAccept", (object)lessons.ProjCloserAccept ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", (object)lessons.CreatedBy ?? DBNull.Value);

                    using (var da = new SqlDataAdapter(command))
                    {
                        foreach (var item in lessons.ProjectTemplateResponseList)
                        {
                            await saveTemplateResponse(item);
                        }
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

        public async Task<CommonRsult> saveTemplateDetails(templateDetails templateObj)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_PRTemplatesDtls", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", templateObj.Flag ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Task", templateObj.Task ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PRTemplateDetailsID", templateObj.PRTemplateDtlsID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PRTemplateID", templateObj.PRTemplateID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", templateObj.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@LessonType", templateObj.LessonType ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Description", templateObj.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Impact", templateObj.Impact ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Recommendation", templateObj.Recommendation ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TaskID", templateObj.TaskID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MilestoneID", templateObj.MilestoneID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Question", templateObj.Question ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Type", templateObj.Type ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Value", templateObj.Value ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Mandatory", templateObj.Mandatory ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", templateObj.CreatedBy);

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


        public async Task<CommonRsult> saveTemplateResponse(ProjectTemplateResponse prTemplateResponse)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_PRTemplateResponse", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Flag", SqlDbType.Char) { Value = prTemplateResponse.flag });
                    command.Parameters.Add(new SqlParameter("@TemplateDtlsID", SqlDbType.Int) { Value = prTemplateResponse.TemplateDtlsID ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@PrID", SqlDbType.Int) { Value = prTemplateResponse.PrID ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@Response", SqlDbType.NVarChar) { Value = prTemplateResponse.Response ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@TemplateID", SqlDbType.NVarChar) { Value = prTemplateResponse.TemplateID ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@CreatedBy", SqlDbType.Int) { Value = prTemplateResponse.CreatedBy ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@TRID", SqlDbType.Int) { Value = prTemplateResponse.TRID ?? (object)DBNull.Value });
                    command.Parameters.Add(new SqlParameter("@lessonLearnedId", SqlDbType.Int) { Value = prTemplateResponse.lessonLearnedId ?? (object)DBNull.Value });

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

        public async Task<CommonRsult> saveTemplate(proSpTemplate templateObj)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_PRTemplate", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", templateObj.Flag ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PRTemplateID", templateObj.PRTemplateID);
                    command.Parameters.AddWithValue("@TemplateName", templateObj.TemplateName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", templateObj.IsActive ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", templateObj.CreatedBy);

                    using (var da = new SqlDataAdapter(command))
                    {
                        var pridNew = (_context.Prtemplates.OrderByDescending(m => m.PrtemplateId).FirstOrDefault()?.PrtemplateId) ?? 0;

                        ++pridNew;

                        foreach (var item in templateObj.templateDetailsList)
                        {
                            item.PRTemplateID = templateObj.Flag == "I" ? pridNew : templateObj.PRTemplateID;
                            await saveTemplateDetails(item);
                        }
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

        public async Task<CommonRsult> getProjectLessonsByProjectId(int proId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwPrlessons.Where(m => m.ProjectId == proId).ToListAsync();
                var data1 = await _context.PrtemplateResponses.Where(m => m.PrId == proId).ToListAsync();
                result.Data = new { lessonData = data, templateData = data1 };
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> getProjectLessonByLessonId(int lessonId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwPrlessons.Where(m => m.PrlessonsId == lessonId).ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = (ex.Message);
            }
            return result;
        }

        public async Task<CommonRsult> DeleteProjectTemplate(int TemplateID)
        {
            var result = new CommonRsult();
            try
            {
                var entity = _context.Prtemplates.FirstOrDefault(m => m.PrtemplateId == TemplateID);
                if (entity != null)
                {
                    var details = _context.PrtemplateDtls.Where(m => m.PrtemplateId == TemplateID).ToList();
                    _context.PrtemplateDtls.RemoveRange(details);
                    _context.Prtemplates.Remove(entity);
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


        public async Task<CommonRsult> DeleteProjectLeson(int LesonId)
        {
            var result = new CommonRsult();
            try
            {
                var entity = _context.Prlessons.FirstOrDefault(m => m.PrlessonsId == LesonId);
                if (entity != null)
                {
                    _context.Prlessons.Remove(entity);
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
        public async Task<CommonRsult> DeleteTemplateDtls(int TemplatedtlID)
        {
            var result = new CommonRsult();
            try
            {
                var entity = _context.PrtemplateDtls.FirstOrDefault(m => m.PrtemplateDtlsId == TemplatedtlID);
                if (entity != null)
                {
                    _context.PrtemplateDtls.Remove(entity);
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
    }
}
