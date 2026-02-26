using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using IT_Portal.Persistence.IT_Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CheckListRepository : ICheckList
    {
        private readonly MicroLabsDevContext _context;

        public CheckListRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<VwChecklist>> Getchecklist()
        {
            var data = await _context.VwChecklists.ToListAsync();
            return data;
        }

        public async Task<CommonRsult> postchecklist(SPCheckList checklist)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CheckList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", checklist.Flag);
                    cmd.Parameters.AddWithValue("@ITChecklistID", checklist.ITChecklistID);
                    cmd.Parameters.AddWithValue("@PlantID", checklist.PlantID);
                    cmd.Parameters.AddWithValue("@status", checklist.Status);
                    cmd.Parameters.AddWithValue("@SupportID", checklist.SupportID);
                    cmd.Parameters.AddWithValue("@CategoryID", checklist.CategoryID);
                    cmd.Parameters.AddWithValue("@ClassificationID", checklist.ClassificationID);
                    cmd.Parameters.AddWithValue("@ChecklistTitle", checklist.ChecklistTitle);
                    cmd.Parameters.AddWithValue("@ChecklistDesc", checklist.ChecklistDesc);
                    cmd.Parameters.AddWithValue("@MandatoryFlag", checklist.MandatoryFlag);
                    cmd.Parameters.AddWithValue("@CreatedBy", checklist.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDt", checklist.CreatedDt);
                    cmd.Parameters.AddWithValue("@ModifiedBy", checklist.ModifiedBy);
                    cmd.Parameters.AddWithValue("@ModifiedDt", checklist.ModifiedDt);

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