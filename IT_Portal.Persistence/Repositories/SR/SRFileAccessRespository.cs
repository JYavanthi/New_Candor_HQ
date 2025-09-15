using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRFileAccessRespository : ISRFileAccess
    {
        private readonly MicroLabsDevContext _context;

        public SRFileAccessRespository(MicroLabsDevContext context)
        {
            _context = context;
        }

        public async Task<CommonRsult> GetSRFileAccess()
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrserverAccesses;
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRServerID = m.SrserverId,
                            RequestType = m.RequestType,
                            HostName = m.HostName,
                            IPAddress = m.Ipaddress,
                            FileServerName = m.FileServerName,
                            FolderPath = m.FolderPath,
                            Justification = m.Justification,
                            Description = m.Description,
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
                            srdate = sr.Srdate,
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

        public async Task<CommonRsult> GetSRFileAccessValue(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrserverAccesses.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRServerID = m.SrserverId,
                            RequestType = m.RequestType,
                            HostName = m.HostName,
                            IPAddress = m.Ipaddress,
                            FileServerName = m.FileServerName,
                            FolderPath = m.FolderPath,
                            Justification = m.Justification,
                            Description = m.Description,
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

        public async Task<CommonRsult> PostSRFileAccess(SRFileAccess fileAccess)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRServerAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", fileAccess.Flag);
                    cmd.Parameters.AddWithValue("@SRID", fileAccess.SRID);
                    cmd.Parameters.AddWithValue("@SRServerID", fileAccess.SRServerID);
                    cmd.Parameters.AddWithValue("@SupportID", fileAccess.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", fileAccess.RequestType);
                    cmd.Parameters.AddWithValue("@HostName", fileAccess.HostName);
                    cmd.Parameters.AddWithValue("@IPAddress", fileAccess.IPAddress);
                    cmd.Parameters.AddWithValue("@FileServerName", fileAccess.FileServerName);
                    cmd.Parameters.AddWithValue("@FolderPath", fileAccess.FolderPath);
                    cmd.Parameters.AddWithValue("@Justification", fileAccess.Justification);
                    cmd.Parameters.AddWithValue("@Description", fileAccess.Description);
                    cmd.Parameters.AddWithValue("@IsActive", fileAccess.IsActive);

                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", fileAccess.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", fileAccess.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", fileAccess.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", fileAccess.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", fileAccess.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", fileAccess.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", fileAccess.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", fileAccess.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", fileAccess.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", fileAccess.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", fileAccess.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", fileAccess.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", fileAccess.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", fileAccess.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", fileAccess.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", fileAccess.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", fileAccess.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", fileAccess.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", fileAccess.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", fileAccess.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", fileAccess.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", fileAccess.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", fileAccess.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", fileAccess.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", fileAccess.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", fileAccess.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", fileAccess.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", fileAccess.SRVariable.CreatedBy);
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
