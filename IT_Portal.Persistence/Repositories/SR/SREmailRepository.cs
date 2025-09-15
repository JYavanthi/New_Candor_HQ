using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SREmailRepository : ISREmail
    {
        private readonly MicroLabsDevContext _context;

        public SREmailRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetEmailvalue(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.Sremails.Where(m => m.Srid == srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()
                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid
                        select new
                        {
                            SREmailID = m.SremailId,
                            Requesttype = m.Requesttype,
                            EmpID = m.EmpId,
                            EmpCategory = m.EmpCategory,
                            EmpName = m.EmpName,
                            Designation = m.Designation,
                            Department = m.Department,
                            Location = m.Location,
                            Intercom = m.Intercom,
                            MoblieNo = m.MoblieNo,
                            ReportManager = m.ReportManager,
                            HOD = m.Hod,
                            CommonEmailID = m.CommonEmailId,
                            PreEmailID = m.PreEmailId,
                            guestReportingManagerName = sr.GuestReportingManagerName,
                            OutsideComm = m.OutsideComm,
                            MailGroup = m.MailGroup,
                            EmailID = m.EmailId,
                            MailAccess = m.MailAccess,
                            Justification = m.Justification,
                            Description = m.Description,
                            EmpType = m.EmpType,
                            GB = m.Gb,
                            MemberAdded = m.MemberAdded,
                            GroupName = m.GroupName

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
                            rpmEmpNo = sr.RpmEmpNo,
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

        public async Task<CommonRsult> PostEmailReq(SREmailRequest sREmail)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SREmail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sREmail.Flag);
                    cmd.Parameters.AddWithValue("@SREmailID", sREmail.SREmailID);
                    cmd.Parameters.AddWithValue("@SRID", sREmail.SRID);
                    cmd.Parameters.AddWithValue("@SupportID", sREmail.SupportID);
                    cmd.Parameters.AddWithValue("@Requesttype", sREmail.Requesttype);
                    cmd.Parameters.AddWithValue("@EmpID", sREmail.EmpID);
                    cmd.Parameters.AddWithValue("@EmpCategory", sREmail.EmpCategory);
                    cmd.Parameters.AddWithValue("@EmpName", sREmail.EmpName);
                    cmd.Parameters.AddWithValue("@Designation", sREmail.Designation);
                    cmd.Parameters.AddWithValue("@Department", sREmail.Department);
                    cmd.Parameters.AddWithValue("@Location", sREmail.Location);
                    cmd.Parameters.AddWithValue("@Intercom", sREmail.Intercom);
                    cmd.Parameters.AddWithValue("@MoblieNo", sREmail.MoblieNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReportManager", sREmail.ReportManager);
                    cmd.Parameters.AddWithValue("@HOD", sREmail.HOD);
                    cmd.Parameters.AddWithValue("@CommonEmailID", sREmail.CommonEmailID);
                    cmd.Parameters.AddWithValue("@PreEmailID", sREmail.PreEmailID);
                    cmd.Parameters.AddWithValue("@OutsideComm", sREmail.OutsideComm);
                    cmd.Parameters.AddWithValue("@EmailID", sREmail.EmailID);
                    cmd.Parameters.AddWithValue("@MailGroup", sREmail.MailGroup);
                    cmd.Parameters.AddWithValue("@MailAccess", sREmail.MailAccess);
                    cmd.Parameters.AddWithValue("@Justification", sREmail.Justification);
                    cmd.Parameters.AddWithValue("@Description", sREmail.Description);
                    cmd.Parameters.AddWithValue("@EmpType", sREmail.EmpType);
                    cmd.Parameters.AddWithValue("@GB", sREmail.GB);
                    cmd.Parameters.AddWithValue("@GroupName", sREmail.GroupName);
                    cmd.Parameters.AddWithValue("@MemberAdded", sREmail.empNo);
                    cmd.Parameters.AddWithValue("@IsActive", sREmail.IsActive);

                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", sREmail.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", sREmail.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", sREmail.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", sREmail.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", sREmail.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", sREmail.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", sREmail.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", sREmail.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", sREmail.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", sREmail.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", sREmail.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", sREmail.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", sREmail.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", sREmail.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", sREmail.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", sREmail.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", sREmail.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", sREmail.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", sREmail.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", sREmail.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", sREmail.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", sREmail.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", sREmail.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", sREmail.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", sREmail.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", sREmail.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", sREmail.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", sREmail.SRVariable.CreatedBy);
                    var srId = 0;
                    var b = 0;
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        srId = 0;
                        srId = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);

                        result.Data = new { srId = srId };

                        if (sREmail.SupportID == 41 && sREmail.SupportID == 42)
                        {
                            if (sREmail.SupportID == 41)
                            {
                                var data = await _context.EmailGroups.OrderByDescending(m => m.EmailGroupId).FirstOrDefaultAsync();
                                b = sREmail.emailGroupId;
                            }
                            else
                            {
                                b = 0;
                            }
                            var newArray = sREmail.empNo.Split(',');

                            foreach (var a in newArray)
                            {
                                var grpMember = new EmailGroupMember
                                {
                                    EmailGroupId = 0,
                                    EmpNo = int.Parse(a),
                                    CreatedBy = sREmail.SRVariable.CreatedBy,
                                    CreatedDt = DateTime.Now,
                                    ModifiedBy = sREmail.SRVariable.CreatedBy,
                                    MidifiedDt = DateTime.Now
                                };

                                _context.EmailGroupMembers.Add(grpMember);
                                await _context.SaveChangesAsync();
                            }
                        }
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


        public async Task<CommonRsult> GetSREmailGroups()
        {
            var result = new CommonRsult();
            try
            {
                var data = await _context.EmailGroups.ToListAsync();
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
                result.Type = ex.Message;
                return result;
            }
        }
    }
}
