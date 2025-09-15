using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRRestorationRespository : ISRRestoration
    {
        private readonly MicroLabsDevContext _context;

        public SRRestorationRespository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetSRRestoration(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrrestorationAccesses.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRRID = m.Srrid,
                            RequestType = m.RequestType,
                            OTS = m.Ots,
                            StartDate = m.StartDate,
                            EndDate = m.EndDate,
                            Date = m.Date,
                            ProvideDescription = m.ProvideDescription,
                            Restoration = m.Restoration,
                            Attachment = m.Attachment,
                            TransferingData = m.TransferingData
                            //SR
                            ,
                            srid = sr.Srid
                            ,
                            srcode = sr.Srcode
                            ,
                            supportId = sr.SupportId
                            ,
                            SupportName = sr.SupportName
                            ,
                            srraiseBy = sr.SrraiseBy
                            ,
                            srdate = sr.Srdate
                            ,
                            srshotDesc = sr.SrshotDesc
                            ,
                            srdesc = sr.Srdesc
                            ,
                            srraiseFor = sr.SrraiseFor
                            ,
                            srselectedfor = sr.Srselectedfor
                            ,
                            guestEmployeeId = sr.GuestEmployeeId
                            ,
                            guestName = sr.GuestName
                            ,
                            guestEmail = sr.GuestEmail
                            ,
                            guestContactNo = sr.GuestContactNo
                            ,
                            guestReportingManagerEmployeeId = sr.GuestReportingManagerEmployeeId
                            ,
                            type = sr.Type
                            ,
                            guestCompany = sr.GuestCompany
                            ,
                            plantId = sr.PlantId
                            ,
                            assetId = sr.AssetId
                            ,
                            categoryId = sr.CategoryId
                            ,
                            categoryTypId = sr.CategoryTypId
                            ,
                            priority = sr.Priority
                            ,
                            srforGuest = sr.SrforGuest
                            ,
                            source = sr.Source
                            ,
                            status = sr.Status
                            ,
                            assignedTo = sr.AssignedTo
                            ,
                            assignedBy = sr.AssignedBy
                            ,
                            assignedOn = sr.AssignedOn
                            ,
                            proposedResolutionOn = sr.ProposedResolutionOn
                            ,
                            remarks = sr.Remarks
                            ,
                            stage = sr.Stage
                            ,
                            isApproved = sr.IsApproved
                            ,
                            approverstage = sr.Approverstage
                            ,
                            approvedBy = sr.ApprovedBy
                            ,
                            approvedDt = sr.ApprovedDt
                            ,
                            parentId = sr.ParentId
                            ,
                            supportIsActive = sr.SupportIsActive
                            ,
                            isVisible = sr.IsVisible
                            ,
                            image = sr.Image
                            ,
                            url = sr.Url
                            ,
                            isHodreq = sr.IsHodreq
                            ,
                            guestReportingManagerName = sr.GuestReportingManagerName,
                            isRpmreq = sr.IsRpmreq
                            ,
                            supportCreatedBy = sr.SupportCreatedBy
                            ,
                            supportCreatedDate = sr.SupportCreatedDate
                            ,
                            supportUpdatedBy = sr.SupportUpdatedBy
                            ,
                            supportUpdatedDate = sr.SupportUpdatedDate
                            ,
                            parentSupportName = sr.ParentSupportName
                            ,
                            IsActive = m.IsActive
                            ,
                            CreateBy = employee.FirstName + " " + employee.LastName + " " + "(" + m.CreatedBy + ")"
                            ,
                            CreatedDt = m.CreatedDt,
                            rpmEmail = sr.RpmEmail,
                            hodEmail = sr.HodEmail,
                            hodToName = sr.HodToName,
                            rpmToName = sr.RpmToName,
                            hodEmpNo = sr.HodEmpNo,
                            rpmEmpNo = sr.RpmEmpNo
                        };
                result.Data = a.FirstOrDefault();
                result.Count = a.Count();
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

        }

        public async Task<CommonRsult> PostSRRestoration(SRRestoration restoration)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRRestorationAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", restoration.Flag);
                    cmd.Parameters.AddWithValue("@SRID", restoration.SRID);
                    cmd.Parameters.AddWithValue("@SRRID", restoration.SRRID);
                    cmd.Parameters.AddWithValue("@SupportID", restoration.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", restoration.RequestType);
                    cmd.Parameters.AddWithValue("@OTS", restoration.OTS);
                    cmd.Parameters.AddWithValue("@Descriptions", restoration.Descriptions);
                    cmd.Parameters.AddWithValue("@Date", restoration.Date ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@StartDate", restoration.StartDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EndDate", restoration.EndDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProvideDescription", restoration.ProvideDescription);
                    cmd.Parameters.AddWithValue("@Restoration", restoration.Restoration ?? (object)DBNull.Value);

                    cmd.Parameters.AddWithValue("@TransferingData", restoration.TransferingData);
                    cmd.Parameters.AddWithValue("@IsActive", restoration.IsActive);

                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", restoration.SRVariable.SRCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", restoration.SRVariable.SRRaisedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRDate", restoration.SRVariable.SRDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRShotDesc", restoration.SRVariable.SRShotDesc ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRDesc", restoration.SRVariable.SRDesc ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", restoration.SRVariable.SRRaiseFor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", restoration.SRVariable.SRSelectedfor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", restoration.SRVariable.GuestEmployeeId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestName", restoration.SRVariable.GuestName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestEmail", restoration.SRVariable.GuestEmail ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestContactNo", restoration.SRVariable.GuestContactNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", restoration.SRVariable.GRManagerEmpId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", restoration.SRVariable.Type ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestCompany", restoration.SRVariable.GuestCompany ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PlantID", restoration.SRVariable.PlantID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssetID", restoration.SRVariable.AssetID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", restoration.SRVariable.CategoryID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryTypID", restoration.SRVariable.CategoryTypID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", restoration.SRVariable.Priority ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Source", restoration.SRVariable.Source ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Attachment", restoration.SRVariable.Attachment ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", restoration.SRVariable.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedTo", restoration.SRVariable.AssignedTo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedBy", restoration.SRVariable.AssignedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedOn", restoration.SRVariable.AssignedOn ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Remarks", restoration.SRVariable.Remarks ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", restoration.SRVariable.ProposedResolutionOn ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", restoration.SRVariable.CreatedBy ?? (object)DBNull.Value);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        var srId = 0;
                        srId = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);

                        result.Data = new { srId = srId };
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
