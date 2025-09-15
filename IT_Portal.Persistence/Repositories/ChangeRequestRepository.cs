using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.changerequest;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace IT_Portal.Persistence.Repositories
{
    public class ChangeRequestRepository : IChangeRequest
    {
        private readonly MicroLabsDevContext _context;

        public ChangeRequestRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> InsertChangeRequest(ChangeRequestSP spChangerequest)
        {

            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.Sp_ChangeRequest", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", spChangerequest.Type);
                    cmd.Parameters.AddWithValue("@ITCRID", spChangerequest.ITCRID);
                    cmd.Parameters.AddWithValue("@SupportID", spChangerequest.SupportId);
                    cmd.Parameters.AddWithValue("@ClassifcationID", spChangerequest.ClassifcationId);
                    cmd.Parameters.AddWithValue("@CategoryID", spChangerequest.CategoryId);
                    cmd.Parameters.AddWithValue("@CROwner", spChangerequest.Crowner);
                    cmd.Parameters.AddWithValue("@CRDate", spChangerequest.Crdate);
                    cmd.Parameters.AddWithValue("@CrrequestedBy", spChangerequest.CrrequestedBy);
                    cmd.Parameters.AddWithValue("@CrrequestedDt", spChangerequest.CrrequestedDt);
                    cmd.Parameters.AddWithValue("@CategoryTypeID", spChangerequest.CategoryTypeId);
                    cmd.Parameters.AddWithValue("@CRREmailNotification", spChangerequest.CRREmailNotification);
                    cmd.Parameters.AddWithValue("@CRInitiatedFor", spChangerequest.CrinitiatedFor);
                    cmd.Parameters.AddWithValue("@Status", spChangerequest.Status);
                    cmd.Parameters.AddWithValue("@ReferenceID", spChangerequest.ReferenceId);
                    cmd.Parameters.AddWithValue("@ReferenceTyp", spChangerequest.ReferenceTyp);
                    cmd.Parameters.AddWithValue("@NatureOfChange", spChangerequest.NatureOfChange);
                    cmd.Parameters.AddWithValue("@PriorityType", spChangerequest.PriorityType);
                    cmd.Parameters.AddWithValue("@PlantID", spChangerequest.PlantId);
                    cmd.Parameters.AddWithValue("@SysLandscapeID", spChangerequest.SysLandscapeID);
                    cmd.Parameters.AddWithValue("@GXPClassification", spChangerequest.Gxpclassification);
                    cmd.Parameters.AddWithValue("@GxpplantId", spChangerequest.GxpplantId);
                    cmd.Parameters.AddWithValue("@ChangeControlNo", spChangerequest.ChangeControlNo);
                    cmd.Parameters.AddWithValue("@ChangeControlDt", spChangerequest.ChangeControlDt);
                    cmd.Parameters.AddWithValue("@ChangeControlAttach", spChangerequest.ChangeControlAttach);
                    cmd.Parameters.AddWithValue("@ChangeDesc", spChangerequest.ChangeDesc);
                    cmd.Parameters.AddWithValue("@ReasonForChange", spChangerequest.ReasonForChange);
                    cmd.Parameters.AddWithValue("@AlternateConsidetation", spChangerequest.AlternateConsidetation);
                    cmd.Parameters.AddWithValue("@ImpactNotDoing", spChangerequest.ImpactNotDoing);
                    cmd.Parameters.AddWithValue("@BusinessImpact", spChangerequest.BusinessImpact);
                    cmd.Parameters.AddWithValue("@TriggeredBy", spChangerequest.TriggeredBy);
                    cmd.Parameters.AddWithValue("@Benefits", spChangerequest.Benefits);
                    cmd.Parameters.AddWithValue("@EstimatedCost", spChangerequest.EstimatedCost);
                    cmd.Parameters.AddWithValue("@EstimatedCostCurr", spChangerequest.EstimatedCostCurr);
                    cmd.Parameters.AddWithValue("@EstimatedEffort", spChangerequest.EstimatedEffort);
                    cmd.Parameters.AddWithValue("@EstimatedEffortUnit", spChangerequest.EstimatedEffortUnit);
                    cmd.Parameters.AddWithValue("@EstimatedDateCompletion", spChangerequest.EstimatedDateCompletion);
                    cmd.Parameters.AddWithValue("@RollbackPlan", spChangerequest.RollbackPlan);
                    cmd.Parameters.AddWithValue("@BackoutPlan", spChangerequest.BackoutPlan);
                    cmd.Parameters.AddWithValue("@DownTimeRequired", spChangerequest.DownTimeRequired);
                    cmd.Parameters.AddWithValue("@DownTimeFromDate", spChangerequest.DownTimeFromDate);
                    cmd.Parameters.AddWithValue("@DownTimeToDate", spChangerequest.DownTimeToDate);
                    cmd.Parameters.AddWithValue("@ImpactedLocation", spChangerequest.ImpactedLocation);
                    cmd.Parameters.AddWithValue("@ImpactedDept", spChangerequest.ImpactedDept);
                    cmd.Parameters.AddWithValue("@ImactedFunc", spChangerequest.ImactedFunc);
                    cmd.Parameters.AddWithValue("@Attachment", spChangerequest.Attachment);
                    cmd.Parameters.AddWithValue("@isSubmitted", spChangerequest.isSubmitted);
                    cmd.Parameters.AddWithValue("@isApproved", spChangerequest.isApproved);
                    cmd.Parameters.AddWithValue("@isImplemented", spChangerequest.isImplemented);
                    cmd.Parameters.AddWithValue("@isReleased", spChangerequest.isReleased);
                    cmd.Parameters.AddWithValue("@CreatedBy", spChangerequest.CreatedBy);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";
                        Console.WriteLine(da);
                        var crid = cmd.Parameters["@ITCRID"].Value;
                        var cridNew = 0;
                        if (spChangerequest.Type == "I")
                        {
                            cridNew = (int)(_context.ChangeRequests.OrderByDescending(m => m.Itcrid).FirstOrDefault()?.Itcrid);

                            foreach (var item in spChangerequest.AttachmentIds)
                            {
                                var attchObj = _context.AttachFiles.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.Itcrid = cridNew;
                                _context.SaveChanges();
                            }
                        }
                        else
                        {
                            cridNew = spChangerequest.ITCRID;
                        }
                        result.Data = new { ITCRID = cridNew };
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
