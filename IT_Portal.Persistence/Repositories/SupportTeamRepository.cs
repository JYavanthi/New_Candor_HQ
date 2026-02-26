using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class SupportTeamRepository : ISupportTeam
    {
        private readonly MicroLabsDevContext _context;

        public SupportTeamRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<VwSupportTeamDtl>> GetSuppotr()
        {
            var data = await _context.VwSupportTeamDtls.ToListAsync();
            return data;
        }

        public async Task<List<VwSupportTeamAll>> GetSuppotAll(int supportId)
        {

            if (supportId != 0)
            {
                var data = await _context.VwSupportTeamAlls.Where(m => supportId == m.SupportTeamAssgnId).ToListAsync();
                return data;
            }
            else
            {
                var data = await _context.VwSupportTeamAlls.ToListAsync();
                return data;
            }
        }

        public async Task<CommonRsult> getSupportTeamData(int supportTeamId)
        {

            CommonRsult result = new CommonRsult();
            try
            {

                var data = await _context.VwSupportTeamAlls.Where(m => supportTeamId == m.SupportTeamId).ToListAsync();
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
        public async Task<CommonRsult> InsertSupportTeam(supportTeamCopy request)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CloneSupportTeamAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpID", request.empId);
                    cmd.Parameters.AddWithValue("@CopyEmpID", request.existingEmpId);
                    cmd.Parameters.AddWithValue("@CreatedBy", request.createdBy);

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
        public async Task<CommonRsult> InsertSupportTeam(SPSupportTeamTable supportteam)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();

                /*if (supportteam.supportIds != null)
                {
                    foreach (int supportId in supportteam.supportIds)
                    {
                        using (var cmd = new SqlCommand("IT.sp_SupportTeam", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Flag", supportteam.Flag);
                            cmd.Parameters.AddWithValue("@SupportTeamID", supportId);
                            cmd.Parameters.AddWithValue("@SupportTeamAssgnID", supportteam.SupportTeamAssgnID);
                            cmd.Parameters.AddWithValue("@Email", supportteam.Email);
                            cmd.Parameters.AddWithValue("@First_Name", supportteam.FirstName);
                            cmd.Parameters.AddWithValue("@Middle_Name", supportteam.MiddleName);
                            cmd.Parameters.AddWithValue("@Last_Name", supportteam.LastName);
                            cmd.Parameters.AddWithValue("@Img_Url", supportteam.ImgUrl);
                            cmd.Parameters.AddWithValue("@Designation", supportteam.Designation);
                            cmd.Parameters.AddWithValue("@Role", supportteam.Role);
                            cmd.Parameters.AddWithValue("@EmpID", supportteam.EmpId);
                            cmd.Parameters.AddWithValue("@IsActive", supportteam.IsActive);

                            cmd.Parameters.AddWithValue("@DOL", supportteam.Dol);
                            cmd.Parameters.AddWithValue("@DOB", supportteam.Dob.HasValue ? (object)supportteam.Dob.Value : DBNull.Value);

                            cmd.Parameters.AddWithValue("@IsAdmin", supportteam.IsAdmin);
                            cmd.Parameters.AddWithValue("@isSuperAdmin", supportteam.isSuperAdmin);
                            cmd.Parameters.AddWithValue("@IsApprover", supportteam.IsApprover);
                            cmd.Parameters.AddWithValue("@IsChangeAnalyst", supportteam.IsChangeAnalyst);
                            cmd.Parameters.AddWithValue("@IsSupportEngineer", supportteam.IsSupportEngineer);
                            cmd.Parameters.AddWithValue("@PlantID", supportteam.PlantId);
                            cmd.Parameters.AddWithValue("@SupportID", supportteam.SupportId);
                            cmd.Parameters.AddWithValue("@CategoryID", supportteam.CategoryId);
                            cmd.Parameters.AddWithValue("@CategoryTypID", supportteam.CategoryTypID);
                            cmd.Parameters.AddWithValue("@ClassificationID", supportteam.ClassificationId);
                            cmd.Parameters.AddWithValue("@ApproverstageCR", supportteam.ApproverstageCR);
                            cmd.Parameters.AddWithValue("@ApproverstageR", supportteam.ApproverstageR);
                            cmd.Parameters.AddWithValue("@ApproverstageC", supportteam.ApproverstageC);
                            cmd.Parameters.AddWithValue("@Level", supportteam.Level);
                            cmd.Parameters.AddWithValue("@Approverstage2CR", supportteam.Approverstage2CR);
                            cmd.Parameters.AddWithValue("@Approverstage2R", supportteam.Approverstage2R);
                            cmd.Parameters.AddWithValue("@Approverstage2C", supportteam.Approverstage2C);
                            cmd.Parameters.AddWithValue("@Level2", supportteam.Level2);
                            cmd.Parameters.AddWithValue("@Approverstage3CR", supportteam.Approverstage3CR);
                            cmd.Parameters.AddWithValue("@Approverstage3R", supportteam.Approverstage3R);
                            cmd.Parameters.AddWithValue("@Approverstage3C", supportteam.Approverstage3C);
                            cmd.Parameters.AddWithValue("@Level3", supportteam.Level3);
                            cmd.Parameters.AddWithValue("@CreatedBy", supportteam.CreatedBy);


                            using (var da = new SqlDataAdapter(cmd))
                            {

                                await Task.Run(() => da.Fill(dt));

                            }
                        }

                    }
                }
                else
                {
*/
                using (var cmd = new SqlCommand("IT.sp_SupportTeam", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Flag", supportteam.Flag);
                    cmd.Parameters.AddWithValue("@SupportTeamID", supportteam.SupportTeamId);
                    cmd.Parameters.AddWithValue("@SupportTeamAssgnID", supportteam.SupportTeamAssgnID);
                    cmd.Parameters.AddWithValue("@Email", supportteam.Email);
                    cmd.Parameters.AddWithValue("@First_Name", supportteam.FirstName);
                    cmd.Parameters.AddWithValue("@Middle_Name", supportteam.MiddleName);
                    cmd.Parameters.AddWithValue("@Last_Name", supportteam.LastName);
                    cmd.Parameters.AddWithValue("@Img_Url", supportteam.ImgUrl);
                    cmd.Parameters.AddWithValue("@Designation", supportteam.Designation);
                    cmd.Parameters.AddWithValue("@Role", supportteam.Role);
                    cmd.Parameters.AddWithValue("@EmpID", supportteam.EmpId);
                    cmd.Parameters.AddWithValue("@IsActive", supportteam.IsActive);
                    // cmd.Parameters.AddWithValue("@GroupId", supportteam.GroupId);
                    // cmd.Parameters.AddWithValue("@MaxAllowed", 5);

                    cmd.Parameters.AddWithValue("@DOL", supportteam.Dol.HasValue ? (object)supportteam.Dol.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOB", supportteam.Dob.HasValue ? (object)supportteam.Dob.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@IsAdmin", supportteam.IsAdmin);
                    cmd.Parameters.AddWithValue("@isSuperAdmin", supportteam.isSuperAdmin);
                    cmd.Parameters.AddWithValue("@IsApprover", supportteam.IsApprover);
                    cmd.Parameters.AddWithValue("@IsChangeAnalyst", supportteam.IsChangeAnalyst);
                    cmd.Parameters.AddWithValue("@IsSupportEngineer", supportteam.IsSupportEngineer);
                    cmd.Parameters.AddWithValue("@PlantID", supportteam.PlantId);
                    cmd.Parameters.AddWithValue("@SupportID", supportteam.SupportId);
                    cmd.Parameters.AddWithValue("@CategoryID", supportteam.CategoryId);
                    cmd.Parameters.AddWithValue("@CategoryTypID", supportteam.CategoryTypID);
                    cmd.Parameters.AddWithValue("@ClassificationID", supportteam.ClassificationId);
                    cmd.Parameters.AddWithValue("@ApproverstageCR", supportteam.ApproverstageCR);
                    cmd.Parameters.AddWithValue("@ApproverstageR", supportteam.ApproverstageR);
                    cmd.Parameters.AddWithValue("@ApproverstageC", supportteam.ApproverstageC);
                    cmd.Parameters.AddWithValue("@Level", supportteam.Level);
                    cmd.Parameters.AddWithValue("@Approverstage2CR", supportteam.Approverstage2CR);
                    cmd.Parameters.AddWithValue("@Approverstage2R", supportteam.Approverstage2R);
                    cmd.Parameters.AddWithValue("@Approverstage2C", supportteam.Approverstage2C);
                    cmd.Parameters.AddWithValue("@Level2", supportteam.Level2);
                    cmd.Parameters.AddWithValue("@Approverstage3CR", supportteam.Approverstage3CR);
                    cmd.Parameters.AddWithValue("@Approverstage3R", supportteam.Approverstage3R);
                    cmd.Parameters.AddWithValue("@Approverstage3C", supportteam.Approverstage3C);
                    cmd.Parameters.AddWithValue("@Level3", supportteam.Level3);
                    cmd.Parameters.AddWithValue("@CreatedBy", supportteam.CreatedBy);


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
