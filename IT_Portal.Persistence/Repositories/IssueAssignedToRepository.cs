using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class IssueAssignedToRepository : IIssueAssignedTo
    {
        private readonly MicroLabsDevContext _context;

        public IssueAssignedToRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> PostIssueAssignedTo(SPIssueAssignedTo issueassignedto)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_IssueAssigned", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", issueassignedto.Flag);
                    cmd.Parameters.AddWithValue("@IssueID", issueassignedto.IssueId);
                    cmd.Parameters.AddWithValue("@AssignedTo", issueassignedto.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", issueassignedto.AssignedBy);
                    cmd.Parameters.AddWithValue("@Status", issueassignedto.Status);

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

        public async Task<CommonRsult> issueForwardTo(EForwardToRequest issueassignedto)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_IssueForwardTo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", issueassignedto.Flag);
                    cmd.Parameters.AddWithValue("@IssueID", issueassignedto.IssueId);
                    cmd.Parameters.AddWithValue("@AssignedTo", issueassignedto.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", issueassignedto.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", issueassignedto.AssignedOn);
                    cmd.Parameters.AddWithValue("@Status", issueassignedto.Status);
                    cmd.Parameters.AddWithValue("@ResolutionRemarks", issueassignedto.resolutionReamrk);

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
