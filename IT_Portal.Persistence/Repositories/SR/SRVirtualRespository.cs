using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRVirtualRespository : IVirtual
    {
        private readonly MicroLabsDevContext _context;

        public SRVirtualRespository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> PostVirtual(Virtual virt)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRVirtual", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", virt.Flag);
                    cmd.Parameters.AddWithValue("@SRID", virt.SRID);
                    cmd.Parameters.AddWithValue("@SRVMID", virt.SRVMID);
                    cmd.Parameters.AddWithValue("@SupportID", virt.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", virt.RequestType);
                    cmd.Parameters.AddWithValue("@EmailID", virt.EmailID);
                    cmd.Parameters.AddWithValue("@NoParticipants", virt.NoParticipants);
                    cmd.Parameters.AddWithValue("@StartDt", virt.StartDt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EndDt", virt.EndDt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Location", virt.Location);
                    cmd.Parameters.AddWithValue("@Department", virt.Department);
                    cmd.Parameters.AddWithValue("@Justification", virt.Justification);
                    cmd.Parameters.AddWithValue("@Description", virt.Description);

                    cmd.Parameters.AddWithValue("@SRCode", virt.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", virt.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", virt.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", virt.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", virt.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", virt.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", virt.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", virt.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", virt.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", virt.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", virt.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", virt.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", virt.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", virt.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", virt.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", virt.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", virt.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", virt.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", virt.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", virt.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", virt.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", virt.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", virt.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", virt.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", virt.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", virt.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", virt.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", virt.SRVariable.CreatedBy);
                    cmd.Parameters.AddWithValue("@IsActive", virt.IsActive);


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
        public async Task<CommonRsult> GetVirtual(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var totalcount = await _context.Srvirtuals.CountAsync();
                var srvirtualvalue = _context.Srvirtuals.Where(m => m.Srid == srid);
                var a = from m in srvirtualvalue
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo
                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid
                        select new
                        {
                            srvmid = m.Srvmid,
                            srid = m.Srid,
                            supportId = m.SupportId,
                            requestType = m.RequestType,
                            emailId = m.EmailId,
                            noParticipants = m.NoParticipants,
                            startDt = m.StartDt,
                            endDt = m.EndDt,
                            location = m.Location,
                            department = m.Department,
                            justification = m.Justification,
                            attachment = m.Attachment,
                            description = m.Description
                            //SR
                            ,
                            srcode = sr.Srcode
                            ,
                            SupportName = sr.SupportName
                            ,
                            guestReportingManagerName = sr.GuestReportingManagerName,
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
                result.Count = totalcount;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

        }
    }
}
