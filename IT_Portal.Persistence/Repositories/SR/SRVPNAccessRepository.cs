using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRVPNAccessRepository : ISRVPNAccess
    {
        private readonly MicroLabsDevContext _context;

        public SRVPNAccessRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetVPNAccess()
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.Srvpnaccesses;
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRVPNID = m.Srvpnid
                            ,
                            RequestType = m.RequestType
                            ,
                            EmpPlant = m.EmpPlant
                            ,
                            AccessPermission = m.AccessPermission
                            ,
                            AccessList = m.AccessList
                            ,
                            AccessType = m.AccessType
                            ,
                            AccessFromDt = m.AccessFromDt
                            ,
                            AccessToDt = m.AccessToDt
                            ,
                            EmpType = m.EmpType
                            ,
                            Justification = m.Justification
                            ,
                            Description = m.Description
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
                            guestReportingManagerName = sr.GuestReportingManagerName,
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
                            hodEmpNo = sr.HodEmpNo
                            ,
                            rpmEmpNo = sr.RpmEmpNo
                            ,
                            IsActive = m.IsActive
                            ,
                            CreateBy = employee.FirstName + " " + employee.LastName + " " + "(" + m.CreatedBy + ")"
                            ,
                            CreatedDt = m.CreatedDt
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

        public async Task<CommonRsult> GetVPNAccessValue(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.Srvpnaccesses.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRVPNID = m.Srvpnid
                            ,
                            RequestType = m.RequestType
                            ,
                            EmpPlant = m.EmpPlant
                            ,
                            AccessPermission = m.AccessPermission
                            ,
                            AccessList = m.AccessList
                            ,
                            AccessType = m.AccessType
                            ,
                            AccessFromDt = m.AccessFromDt
                            ,
                            AccessToDt = m.AccessToDt
                            ,
                            EmpType = m.EmpType
                            ,
                            Justification = m.Justification
                            ,
                            Description = m.Description
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
                            guestReportingManagerName = sr.GuestReportingManagerName
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
                            rpmEmpNo = sr.RpmEmpNo,
                            location = m.Location
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

        public async Task<CommonRsult> PostVPNAccess(SRVPNAccess sRVPN)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRVPNAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sRVPN.Flag);
                    cmd.Parameters.AddWithValue("@SRID", sRVPN.SRID);
                    cmd.Parameters.AddWithValue("@SRVPNID", sRVPN.SRVPNID);
                    cmd.Parameters.AddWithValue("@SupportID", sRVPN.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", sRVPN.RequestType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmpPlant", sRVPN.EmpPlant ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccessPermission", sRVPN.AccessPermission ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccessList", sRVPN.AccessList ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccessType", sRVPN.AccessType);
                    cmd.Parameters.AddWithValue("@AccessFromDt", sRVPN.AccessFromDt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccessToDt", sRVPN.AccessToDt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmpType", sRVPN.EmpType);
                    cmd.Parameters.AddWithValue("@Justification", sRVPN.Justification);
                    cmd.Parameters.AddWithValue("@Description", sRVPN.Description);
                    cmd.Parameters.AddWithValue("@IsActive", sRVPN.IsActive);
                    cmd.Parameters.AddWithValue("@Location", sRVPN.Location);

                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", sRVPN.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", sRVPN.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", sRVPN.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", sRVPN.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", sRVPN.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", sRVPN.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", sRVPN.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", sRVPN.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", sRVPN.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", sRVPN.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", sRVPN.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", sRVPN.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", sRVPN.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", sRVPN.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", sRVPN.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", sRVPN.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", sRVPN.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", sRVPN.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", sRVPN.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", sRVPN.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", sRVPN.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", sRVPN.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", sRVPN.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", sRVPN.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", sRVPN.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", sRVPN.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", sRVPN.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", sRVPN.SRVariable.CreatedBy);
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
