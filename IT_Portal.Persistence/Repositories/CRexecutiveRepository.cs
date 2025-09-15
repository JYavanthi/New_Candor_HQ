using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class CRexecutiveRepository : ICRexecutive
    {
        private readonly MicroLabsDevContext _context;

        public CRexecutiveRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> CRexecutive(SPCrexecute crexecute)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_CRExecutionPlan", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Set parameters, handling null values explicitly
                    cmd.Parameters.AddWithValue("@Flag", crexecute.Flag != null ? crexecute.Flag : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ITCRExecID", crexecute.ITCRExecID);
                    cmd.Parameters.AddWithValue("@ITCRID", crexecute.ITCRID);
                    cmd.Parameters.AddWithValue("@SysLandscape", crexecute.SysLandscape);
                    cmd.Parameters.AddWithValue("@ExecutionStepName", crexecute.ExecutionStepName);
                    cmd.Parameters.AddWithValue("@ExecutionStepDesc", crexecute.ExecutionStepDesc);
                    cmd.Parameters.AddWithValue("@AssignedTo", crexecute.AssignedTo != null ? crexecute.AssignedTo : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@StartDt", crexecute.StartDt != null ? crexecute.StartDt : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EndDT", crexecute.EndDT != null ? crexecute.EndDT : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Attachments", crexecute.Attachments != null ? crexecute.Attachments : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", crexecute.Status != null ? crexecute.Status : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ForwardStatus", crexecute.ForwardStatus != null ? crexecute.ForwardStatus : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ForwardedTo", crexecute.ForwardedTo != null ? crexecute.ForwardedTo : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ForwardedDt", crexecute.ForwardedDt != null ? crexecute.ForwardedDt : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReasonForwarded", crexecute.ReasonForwarded != null ? crexecute.ReasonForwarded : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Remarks", crexecute.Remarks != null ? crexecute.Remarks : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PickedStatus", crexecute.PickedStatus != null ? crexecute.PickedStatus : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PickedDt", crexecute.PickedDt != null ? crexecute.PickedDt : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ActualStartDt", crexecute.ActualStartDt != null ? crexecute.ActualStartDt : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ActualEndDt", crexecute.ActualEndDt != null ? crexecute.ActualEndDt : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DependSysLandscape", crexecute.DependSysLandscape != null ? crexecute.DependSysLandscape : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DependTaskID", crexecute.DependTaskId != null ? crexecute.DependTaskId : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", crexecute.CreatedBy != null ? crexecute.CreatedBy : (object)DBNull.Value);

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
