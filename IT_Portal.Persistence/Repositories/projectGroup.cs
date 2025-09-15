using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class projectGroup : IprojectGroup
    {
        private readonly IserviceMaster _serviceRepo;
        private readonly MicroLabsDevContext _context;

        public projectGroup(IserviceMaster serviceMaster, MicroLabsDevContext context)
        {
            this._serviceRepo = serviceMaster;
            this._context = context;
        }


        public async Task<CommonRsult> getProjectGroupById(int id)
        {

            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.ViewProjectGroups.Where(m => m.ProjectGroupId == id).FirstOrDefaultAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<CommonRsult> getProjectGroup()
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.ViewProjectGroups.ToListAsync();
                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<CommonRsult> PostProjectGroup(SPprojectGroup request)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.SP_ProjectGroup", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Flag", request.Flag);
                    command.Parameters.AddWithValue("@ProjectGroupID", (object)request.ProjectGroupID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectGroupName", (object)request.ProjectGroupName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", (object)request.IsActive ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", (object)request.CreatedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ModifiedBy", (object)request.ModifiedBy ?? DBNull.Value);


                    // ✅ Define and add the output parameter
                    SqlParameter outputError = new SqlParameter("@Error", SqlDbType.NVarChar, 50)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(outputError);

                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                    }

                    // ✅ Read the output value after execution
                    string errorMsg = outputError.Value?.ToString();

                    if (!string.IsNullOrEmpty(errorMsg))
                    {
                        result.Type = "E";
                        result.Message = errorMsg;
                    }
                    else
                    {
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                    }

                    return result;
                }
            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }
    }

    /*
        public async Task<CommonRsult> PostProjectApprover(SPprojectGroup request)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.SP_ProjectGroup", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Flag", request.Flag);
                    command.Parameters.AddWithValue("@ProjectGroupID", (object)request.ProjectGroupID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProjectGroupName", (object)request.ProjectGroupName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", (object)request.IsActive ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", (object)request.CreatedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ModifiedBy", (object)request.ModifiedBy ?? DBNull.Value);


                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                    }
                }
            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }*/
}
