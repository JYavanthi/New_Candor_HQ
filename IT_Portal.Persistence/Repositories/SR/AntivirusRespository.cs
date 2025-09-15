using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
//using IT_Portal.Persistence.DatabaseContext.IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class AntivirusRespository : IAntivirus
    {
        private readonly MicroLabsDevContext _context;

        public AntivirusRespository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetAntivirus(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var totalcount = await _context.Srantiviruses.CountAsync();
                var SRValue = _context.VwServiceRequests;
                var SrAntivirusvalue = _context.Srantiviruses.Where(m => m.Srid == srid);
                var a = from m in SrAntivirusvalue
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {
                            SRAVID = m.Srid,
                            RequestType = m.RequestType,
                            InstallDts = m.InstallDts,
                            UninstallDts = m.UninstallDts,
                            ExcDts = m.ExcDts,
                            IncDts = m.IncDts,
                            Attachment = m.Attachment,
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

                            guestReportingManagerName = sr.GuestReportingManagerName
                        };


                result.Data = a.FirstOrDefault();
                result.Count = totalcount;
                return result;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<CommonRsult> PostAntivirus(Antivirus antivirus)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRAntivirus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", antivirus.Flag);
                    cmd.Parameters.AddWithValue("@SRID", antivirus.SRID);
                    cmd.Parameters.AddWithValue("@SRAVID", antivirus.SRAVID);
                    cmd.Parameters.AddWithValue("@SupportID", antivirus.SupportID);
                    cmd.Parameters.AddWithValue("@RequestType", antivirus.RequestType);
                    cmd.Parameters.AddWithValue("@InstallDts", antivirus.InstallDts);
                    cmd.Parameters.AddWithValue("@UninstallDts", antivirus.UninstallDts);
                    cmd.Parameters.AddWithValue("@ExcDts", antivirus.ExcDts);
                    cmd.Parameters.AddWithValue("@IncDts", antivirus.IncDts);
                    cmd.Parameters.AddWithValue("@Description", antivirus.Description);
                    cmd.Parameters.AddWithValue("@IsActive", antivirus.IsActive);
                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", antivirus.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", antivirus.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", antivirus.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", antivirus.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", antivirus.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", antivirus.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", antivirus.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", antivirus.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", antivirus.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", antivirus.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", antivirus.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", antivirus.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", antivirus.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", antivirus.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", antivirus.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", antivirus.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", antivirus.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", antivirus.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", antivirus.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", antivirus.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", antivirus.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", antivirus.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", antivirus.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", antivirus.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", antivirus.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", antivirus.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", antivirus.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", antivirus.SRVariable.CreatedBy);


                    var srId = 0;
                    srId = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        srId = 0;
                        srId = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);

                        result.Data = new { srId = srId };
                        result.Type = "S";
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
