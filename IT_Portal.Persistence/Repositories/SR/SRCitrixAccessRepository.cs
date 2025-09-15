using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRCitrixAccessRepository : ISRCitrixAccess
    {
        private readonly MicroLabsDevContext _context;

        public SRCitrixAccessRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetCitrixAccess()
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrcitrixAccesses;
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {

                            SRCID = m.Srcid
                            ,
                            RequestType = m.RequestType
                            ,
                            ADID = m.Adid
                            ,
                            ReplaceADID = m.ReplaceAdid
                            ,
                            AssetDetails = m.AssetDetails
                            ,
                            IPAddress = m.Ipaddress
                            ,
                            HostName = m.HostName
                            ,
                            SoftwareRequired = m.SoftwareRequired
                            ,
                            EmpType = m.EmpType
                            ,
                            Justification = m.Justification
                            ,
                            OUPath = m.Oupath

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

        public async Task<CommonRsult> GetCitrixValue(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrcitrixAccesses.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {

                            SRCID = m.Srcid
                            ,
                            RequestType = m.RequestType
                            ,
                            ADID = m.Adid
                            ,
                            ReplaceADID = m.ReplaceAdid
                            ,
                            AssetDetails = m.AssetDetails
                            ,
                            IPAddress = m.Ipaddress
                            ,
                            HostName = m.HostName
                            ,
                            SoftwareRequired = m.SoftwareRequired
                            ,
                            EmpType = m.EmpType
                            ,
                            Justification = m.Justification
                            ,
                            OUPath = m.Oupath

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
                            guestReportingManagerName = sr.GuestReportingManagerName
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

        public async Task<CommonRsult> PostCitrixAccess(SRCitrixAccess sRCitrix)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRCitrixAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sRCitrix.Flag);
                    cmd.Parameters.AddWithValue("@SRCID", sRCitrix.SRCID);
                    cmd.Parameters.AddWithValue("@SRID", sRCitrix.SRID);
                    cmd.Parameters.AddWithValue("@SupportID", sRCitrix.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", sRCitrix.RequestType);
                    cmd.Parameters.AddWithValue("@ADID", sRCitrix.ADID);
                    cmd.Parameters.AddWithValue("@ReplaceADID", sRCitrix.ReplaceADID);
                    cmd.Parameters.AddWithValue("@AssetDetails", sRCitrix.AssetDetails);
                    cmd.Parameters.AddWithValue("@IPAddress", sRCitrix.IPAddress);
                    cmd.Parameters.AddWithValue("@HostName", sRCitrix.HostName);
                    cmd.Parameters.AddWithValue("@SoftwareRequired", sRCitrix.SoftwareRequired);
                    cmd.Parameters.AddWithValue("@EmpType", sRCitrix.EmpType);
                    cmd.Parameters.AddWithValue("@Justification", sRCitrix.Justification);
                    cmd.Parameters.AddWithValue("@OUPath", sRCitrix.OUPath);
                    cmd.Parameters.AddWithValue("@IsActive", sRCitrix.IsActive);
                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", sRCitrix.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", sRCitrix.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", sRCitrix.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", sRCitrix.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", sRCitrix.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", sRCitrix.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", sRCitrix.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", sRCitrix.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", sRCitrix.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", sRCitrix.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", sRCitrix.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", sRCitrix.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", sRCitrix.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", sRCitrix.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", sRCitrix.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", sRCitrix.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", sRCitrix.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", sRCitrix.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", sRCitrix.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", sRCitrix.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", sRCitrix.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", sRCitrix.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", sRCitrix.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", sRCitrix.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", sRCitrix.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", sRCitrix.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", sRCitrix.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", sRCitrix.SRVariable.CreatedBy);

                    var srId = 0;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S"; result.Type = "S";
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
