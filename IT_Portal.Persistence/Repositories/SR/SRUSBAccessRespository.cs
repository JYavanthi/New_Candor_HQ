using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRUSBAccessRespository : ISRUSBAccess
    {
        private readonly MicroLabsDevContext _context;

        public SRUSBAccessRespository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> GetAssetDetails(string Empno)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.VwAssetDetails.Where(m => m.EmpNo == Empno);
                result.Data = value;
                result.Count = value.Count();
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
        public async Task<CommonRsult> GetUSBAccess()
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.Srusbaccesses;
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRUSBAID = m.Srusbaid,
                            ADID = m.Adid,
                            AssetDetails = m.AssetDetails,
                            HostName = m.HostName,
                            DeviceType = m.DeviceType,
                            DurationFrom = m.DurationFrom,
                            DurationTo = m.DurationTo,
                            AccessType = m.AccessType,
                            IPAddress = m.Ipaddress,
                            EmpType = m.EmpType,
                            Justification = m.Justification,
                            //SR
                            srid = sr.Srid
                            ,
                            srcode = sr.Srcode
                            ,
                            supportId = sr.SupportId
                            ,
                            guestReportingManagerName = sr.GuestReportingManagerName,
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

        public async Task<CommonRsult> GetUSBIdValue(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.Srusbaccesses.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRUSBAID = m.Srusbaid,
                            ADID = m.Adid,
                            AssetDetails = m.AssetDetails,
                            HostName = m.HostName,
                            DeviceType = m.DeviceType,
                            DurationFrom = m.DurationFrom,
                            DurationTo = m.DurationTo,
                            AccessType = m.AccessType,
                            IPAddress = m.Ipaddress,
                            EmpType = m.EmpType,
                            Justification = m.Justification,
                            //SR
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

        public async Task<CommonRsult> PostUSBAccess(SRUSBAccess sRURL)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRUSBAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sRURL.Flag);
                    cmd.Parameters.AddWithValue("@SRID", sRURL.SRID);
                    cmd.Parameters.AddWithValue("@SRUSBAID", sRURL.SRUSBAID);
                    cmd.Parameters.AddWithValue("@SupportID", sRURL.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", sRURL.RequestType);
                    cmd.Parameters.AddWithValue("@ADID", sRURL.ADID);
                    cmd.Parameters.AddWithValue("@AssestDetails", sRURL.AssestDetails);
                    cmd.Parameters.AddWithValue("@Hostname", sRURL.Hostname);
                    cmd.Parameters.AddWithValue("@DeviceType", sRURL.DeviceType);
                    cmd.Parameters.AddWithValue("@DurationFrom", sRURL.DurationFrom);
                    cmd.Parameters.AddWithValue("@DurationTo", sRURL.DurationTo);
                    cmd.Parameters.AddWithValue("@AccessType", sRURL.AccessType);
                    cmd.Parameters.AddWithValue("@IPAddress", sRURL.IPAddress);
                    cmd.Parameters.AddWithValue("@EmpType", sRURL.EmpType);
                    cmd.Parameters.AddWithValue("@Justification", sRURL.Justification);
                    cmd.Parameters.AddWithValue("@Description", sRURL.Description);
                    cmd.Parameters.AddWithValue("@IsActive", sRURL.IsActive);
                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", sRURL.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", sRURL.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", sRURL.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", sRURL.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", sRURL.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", sRURL.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", sRURL.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", sRURL.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", sRURL.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", sRURL.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", sRURL.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", sRURL.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", sRURL.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", sRURL.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", sRURL.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", sRURL.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", sRURL.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", sRURL.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", sRURL.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", sRURL.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", sRURL.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", sRURL.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", sRURL.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", sRURL.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", sRURL.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", sRURL.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", sRURL.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", sRURL.SRVariable.CreatedBy);

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
