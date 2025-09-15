using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRExternalDriveRespository : ISRExternalDrive
    {
        private readonly MicroLabsDevContext _context;

        public SRExternalDriveRespository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetExternalDrive(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.SrexternalDrives.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SREDID = m.Sredid,
                            RequestType = m.ReqType,
                            ForSelf = m.ForSelf,
                            Name = m.Name,
                            Designation = m.Designation,
                            EmpCategory = m.EmpCategory,
                            Role = m.Role,
                            Department = m.Department,
                            SubDepartment = m.SubDepartment,
                            ReportingManager = m.ReportingManager,
                            HOD = m.Hod,
                            AccessPath = m.AccessPath,
                            AccessType = m.AccessType,
                            AccessRequired = m.AccessRequired,
                            OnwerEmail = m.OnwerEmail,
                            OnwerPlant = m.OnwerPlant,
                            EmpType = m.EmpType,
                            Justification = m.Justification,
                            Description = m.Description,

                            //SR

                            srid = sr.Srid
                            ,
                            srcode = sr.Srcode
                            ,
                            guestReportingManagerName = sr.GuestReportingManagerName,
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

        public async Task<CommonRsult> PostExternalDrive(SRExternalDrive SRED)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRExternalDrive", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", SRED.Flag);
                    cmd.Parameters.AddWithValue("@SRID", SRED.SRID);
                    cmd.Parameters.AddWithValue("@SREDID", SRED.SREDID);
                    cmd.Parameters.AddWithValue("@SupportID", SRED.SupportID);
                    cmd.Parameters.AddWithValue("@ReqType", SRED.ReqType);
                    cmd.Parameters.AddWithValue("@ForSelf", SRED.ForSelf);
                    cmd.Parameters.AddWithValue("@Name", SRED.Name);
                    cmd.Parameters.AddWithValue("@Designation", SRED.Designation);
                    cmd.Parameters.AddWithValue("@EmpCategory", SRED.EmpCategory);
                    cmd.Parameters.AddWithValue("@Role", SRED.Role);
                    cmd.Parameters.AddWithValue("@Department", SRED.Department);
                    cmd.Parameters.AddWithValue("@SubDepartment", SRED.SubDepartment);
                    cmd.Parameters.AddWithValue("@ReportingManager", SRED.ReportingManager);
                    cmd.Parameters.AddWithValue("@HOD", SRED.HOD);
                    cmd.Parameters.AddWithValue("@AccessPath", SRED.AccessPath);
                    cmd.Parameters.AddWithValue("@AccessType", SRED.AccessType);
                    cmd.Parameters.AddWithValue("@AccessRequired", SRED.AccessRequired);
                    cmd.Parameters.AddWithValue("@OnwerEmail", SRED.OnwerEmail);
                    cmd.Parameters.AddWithValue("@OnwerPlant", SRED.OnwerPlant);
                    cmd.Parameters.AddWithValue("@EmpType", SRED.EmpType);
                    cmd.Parameters.AddWithValue("@Justification", SRED.Justification);
                    cmd.Parameters.AddWithValue("@Description", SRED.Description);
                    cmd.Parameters.AddWithValue("@IsActive", SRED.IsActive);

                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", SRED.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", SRED.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", SRED.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", SRED.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", SRED.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", SRED.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", SRED.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", SRED.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", SRED.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", SRED.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", SRED.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", SRED.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", SRED.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", SRED.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", SRED.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", SRED.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", SRED.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", SRED.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", SRED.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", SRED.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", SRED.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", SRED.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", SRED.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", SRED.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", SRED.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", SRED.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", SRED.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", SRED.SRVariable.CreatedBy);

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
