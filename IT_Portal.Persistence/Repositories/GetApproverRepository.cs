using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetApprover;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class GetApproverRepository : IgetApprover
    {
        private readonly MicroLabsDevContext _context;

        public GetApproverRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<GetApproverResultSP>> GetApprover(SPgetApprove getApprove)
        {
            List<GetApproverResultSP> result = new List<GetApproverResultSP>();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_GetApprover", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Level", getApprove.level);
                    cmd.Parameters.AddWithValue("@stage", getApprove.stage);
                    cmd.Parameters.AddWithValue("@plantid", getApprove.plantid);
                    cmd.Parameters.AddWithValue("@categoryid", getApprove.CategoryId);
                    cmd.Parameters.AddWithValue("@classificationid", getApprove.ClassificationId);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));

                    }
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            GetApproverResultSP spObj = new GetApproverResultSP();
                            if (row.Table.Columns.Contains("ITApproverID"))
                            {
                                spObj.ITApproverID = row["ITApproverID"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver1"))
                            {
                                spObj.Approver1 = row["Approver1"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver1Name"))
                            {
                                spObj.Approver1Name = row["Approver1Name"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver2"))
                            {
                                spObj.Approver2 = row["Approver2"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver2Name"))
                            {
                                spObj.Approver2Name = row["Approver2Name"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver3"))
                            {
                                spObj.Approver3 = row["Approver3"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver3Name"))
                            {
                                spObj.Approver3Name = row["Approver3Name"].ToString();
                            }
                            if (row.Table.Columns.Contains("ApproverCount"))
                            {
                                spObj.ApproverCount = row["ApproverCount"].ToString();
                            }
                            result.Add(spObj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }


}
