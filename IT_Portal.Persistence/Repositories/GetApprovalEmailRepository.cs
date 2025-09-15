using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetApprover;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class GetApprovalEmailRepository : IGetApproverEmail
    {
        private readonly MicroLabsDevContext _context;

        public GetApprovalEmailRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<List<GetApproverEmailResult>> GetApproverEmail(SPGetApproverEmail getApproveemail)
        {
            List<GetApproverEmailResult> result = new List<GetApproverEmailResult>();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_GetApproverforEmail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@stage", getApproveemail.stage);
                    cmd.Parameters.AddWithValue("@plantid", getApproveemail.plantid);
                    cmd.Parameters.AddWithValue("@categoryid", getApproveemail.CategoryId);
                    cmd.Parameters.AddWithValue("@classificationid", getApproveemail.ClassificationId);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));

                    }
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            GetApproverEmailResult spObj = new GetApproverEmailResult();
                            if (row.Table.Columns.Contains("level"))
                            {
                                spObj.level = (int)row["level"];
                            }
                            if (row.Table.Columns.Contains("stage"))
                            {
                                spObj.stage = row["stage"].ToString();
                            }
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
                            if (row.Table.Columns.Contains("Approver1Email"))
                            {
                                spObj.Approver1Email = row["Approver1Email"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver2"))
                            {
                                spObj.Approver2 = row["Approver2"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver2Name"))
                            {
                                spObj.Approver2Name = row["Approver2Name"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver2Email"))
                            {
                                spObj.Approver2Email = row["Approver2Email"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver3"))
                            {
                                spObj.Approver3 = row["Approver3"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver3Name"))
                            {
                                spObj.Approver3Name = row["Approver3Name"].ToString();
                            }
                            if (row.Table.Columns.Contains("Approver3Email"))
                            {
                                spObj.Approver3Email = row["Approver3Email"].ToString();
                            }
                            if (row.Table.Columns.Contains("ApproverCount"))
                            {
                                spObj.ApproverCount = row["ApproverCount"].ToString();
                            }
                            if (row.Table.Columns.Contains("Empid1"))
                            {
                                spObj.Empid1 = row["Empid1"].ToString();
                            }
                            if (row.Table.Columns.Contains("Empid2"))
                            {
                                spObj.Empid2 = row["Empid2"].ToString();
                            }
                            if (row.Table.Columns.Contains("Empid3"))
                            {
                                spObj.Empid3 = row["Empid3"].ToString();
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
