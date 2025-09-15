using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRWindowsLoginRepository : ISRWindowsLogin
    {
        private readonly MicroLabsDevContext _context;

        public SRWindowsLoginRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetSRWindowLogin()
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrwindowLogins;
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRWLID = m.Srwlid
                            ,
                            RequestType = m.RequestType
                            ,
                            EmpID = m.EmpId
                            ,
                            Date = m.Date
                            ,
                            Initials = m.Initials
                            ,
                            FirstName = m.FirstName
                            ,
                            LastName = m.LastName
                            ,
                            Designation = m.Designation
                            ,
                            PayGroup = m.PayGroup
                            ,
                            StaffCategory = m.StaffCategory
                            ,
                            Department = m.Department
                            ,
                            ReportingTO = m.ReportingTo
                            ,
                            HOD = m.Hod
                            ,
                            Role = m.Role
                            ,
                            UserType = m.UserType
                            ,
                            ChangeOUPath = m.ChangeOupath
                            ,
                            Justification = m.Justification
                            ,
                            EIDIndividual = m.Eidindividual
                            ,
                            UserID = m.UserId
                            ,
                            EmpType = m.EmpType
                            ,
                            Attachment = m.Attachment
                            ,
                            Description = m.Description
                            //SR
                             ,
                            SRID = sr.Srid
                            ,
                            SRCode = sr.Srcode
                            ,
                            SupportID = sr.SupportId
                            ,
                            SupportName = sr.SupportName
                            //,SRRaisedBy = sr.SrraiseBy
                            ,
                            SRDate = sr.Srdate
                            ,
                            guestReportingManagerName = sr.GuestReportingManagerName,
                            SRShotDesc = sr.SrshotDesc
                            ,
                            SRDesc = sr.Srdesc
                            ,
                            SRRaiseFor = sr.SrraiseFor
                            ,
                            GuestEmployeeId = sr.GuestEmployeeId
                            ,
                            GuestName = sr.GuestName
                            ,
                            GuestEmail = sr.GuestEmail
                            ,
                            GuestContactNo = sr.GuestContactNo
                            ,
                            GuestReportingManagerEmployeeId = sr.GuestReportingManagerEmployeeId
                            ,
                            Type = sr.Type
                            ,
                            GuestCompany = sr.GuestCompany
                            ,
                            PlantID = sr.PlantId
                            ,
                            AssetID = sr.AssetId
                            ,
                            CategoryID = sr.CategoryId
                            ,
                            CategoryTypID = sr.CategoryTypId
                            ,
                            Priority = sr.Priority
                            ,
                            SRForGuest = sr.SrforGuest
                            ,
                            Source = sr.Source
                            ,
                            Status = sr.Status
                            ,
                            AssignedTo = sr.AssignedTo
                            ,
                            AssignedBy = sr.AssignedBy
                            ,
                            AssignedOn = sr.AssignedOn
                            ,
                            ProposedResolutionOn = sr.ProposedResolutionOn
                            ,
                            Remarks = sr.Remarks
                            ,
                            Stage = sr.Stage
                            ,
                            isApproved = sr.IsApproved
                            ,
                            Approverstage = sr.Approverstage
                            ,
                            ApprovedBy = sr.ApprovedBy
                            ,
                            ApprovedDt = sr.ApprovedDt
                            ,
                            IsActive = m.IsActive
                            ,
                            CreateBy = employee.FirstName + " " + employee.LastName + " " + "(" + m.CreatedBy + ")"
                        };
                result.Data = a;
                result.Count = a.Count();
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> GetSRWindowValue(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrwindowLogins.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRWLID = m.Srwlid
                            ,
                            RequestType = m.RequestType
                            ,
                            EmpID = m.EmpId
                            ,
                            Date = m.Date
                            ,
                            Initials = m.Initials
                            ,
                            FirstName = m.FirstName
                            ,
                            LastName = m.LastName
                            ,
                            Designation = m.Designation
                            ,
                            PayGroup = m.PayGroup
                            ,
                            StaffCategory = m.StaffCategory
                            ,
                            Department = m.Department
                            ,
                            ReportingTO = m.ReportingTo
                            ,
                            HOD = m.Hod
                            ,
                            Role = m.Role
                            ,
                            UserType = m.UserType
                            ,
                            ChangeOUPath = m.ChangeOupath
                            ,
                            Justification = m.Justification
                            ,
                            EIDIndividual = m.Eidindividual
                            ,
                            UserID = m.UserId
                            ,
                            EmpType = m.EmpType
                            ,
                            Attachment = m.Attachment
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
                            CreatedDt = m.CreatedOn,
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

        public async Task<CommonRsult> PostSRWindowLogin(SRWindowslogin SRWL)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRWindowLogin", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", SRWL.Flag);
                    cmd.Parameters.AddWithValue("@SRID", SRWL.SRID);
                    cmd.Parameters.AddWithValue("@SRWLID", SRWL.SRWLID);
                    cmd.Parameters.AddWithValue("@SupportID", SRWL.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", SRWL.RequestType);
                    cmd.Parameters.AddWithValue("@EmpID", SRWL.EmpID);
                    cmd.Parameters.AddWithValue("@Date", SRWL.Date);
                    cmd.Parameters.AddWithValue("@Initials", SRWL.Initials);
                    cmd.Parameters.AddWithValue("@FirstName", SRWL.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", SRWL.LastName);
                    cmd.Parameters.AddWithValue("@Designation", SRWL.Designation);
                    cmd.Parameters.AddWithValue("@Plant", SRWL.Plant);
                    cmd.Parameters.AddWithValue("@PayGroup", SRWL.PayGroup);
                    cmd.Parameters.AddWithValue("@StaffCategory", SRWL.StaffCategory);
                    cmd.Parameters.AddWithValue("@Department", SRWL.Department);
                    cmd.Parameters.AddWithValue("@ReportingTO", SRWL.ReportingTO);
                    cmd.Parameters.AddWithValue("@HOD", SRWL.HOD);
                    cmd.Parameters.AddWithValue("@Role", SRWL.Role);
                    cmd.Parameters.AddWithValue("@UserType", SRWL.UserType);
                    cmd.Parameters.AddWithValue("@ChangeOUPath", SRWL.ChangeOUPath);
                    cmd.Parameters.AddWithValue("@Justification", SRWL.Justification);
                    cmd.Parameters.AddWithValue("@EIDIndividual", SRWL.EIDIndividual);
                    cmd.Parameters.AddWithValue("@UserID", SRWL.UserID);
                    cmd.Parameters.AddWithValue("@EmpType", SRWL.EmpType);
                    cmd.Parameters.AddWithValue("@Description", SRWL.Description);
                    cmd.Parameters.AddWithValue("@IsActive", SRWL.IsActive);
                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", SRWL.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", SRWL.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", SRWL.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", SRWL.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", SRWL.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", SRWL.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", SRWL.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", SRWL.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", SRWL.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", SRWL.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", SRWL.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", SRWL.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", SRWL.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", SRWL.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", SRWL.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", SRWL.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", SRWL.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", SRWL.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", SRWL.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", SRWL.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", SRWL.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", SRWL.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", SRWL.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", SRWL.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", SRWL.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", SRWL.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", SRWL.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", SRWL.SRVariable.CreatedBy);
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