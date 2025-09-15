using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRWIFIAccessRespository : ISRWIFIAccess
    {
        private readonly MicroLabsDevContext _context;

        public SRWIFIAccessRespository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetWIFIAccess(int srid)
        {
            var result = new CommonRsult();
            try
            {
                var totalcount = await _context.Srftpaccesses.CountAsync();
                var srFTPvalue = _context.Srwifiaccesses.Where(m => m.Srid == srid);
                var a = from m in srFTPvalue
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid

                        select new
                        {

                            SRWIFIID = m.Srwifiid,
                            RequestType = m.RequestType,
                            SpecifyPlant = m.SpecifyPlant,
                            Location = m.Location,
                            SpecifyOffice = m.SpecifyOffice,
                            FromDate = m.FromDate,
                            ToDate = m.ToDate,
                            Attachment = m.Attachment,
                            Justification = m.Justification,
                            Description = m.Description,

                            /*SR*/
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
                            guestReportingManagerName = sr.GuestReportingManagerName,
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

        public async Task<CommonRsult> PostWIFIAccess(SRWIFIAccess sRWIFI)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRWIFIAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sRWIFI.Flag ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRID", sRWIFI.SRID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRWIFIID", sRWIFI.SRWIFIID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SupportID", sRWIFI.SupportID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@RequestType", sRWIFI.RequestType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SpecifyPlant", sRWIFI.SpecifyPlant ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Location", sRWIFI.Location ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SpecifyOffice", sRWIFI.SpecifyOffice ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@FromDate", sRWIFI.FromDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ToDate", sRWIFI.ToDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Justification", sRWIFI.Justification ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Description", sRWIFI.Description ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", sRWIFI.IsActive ?? (object)DBNull.Value);

                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", sRWIFI.SRVariable.SRCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", sRWIFI.SRVariable.SRRaisedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRDate", sRWIFI.SRVariable.SRDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRShotDesc", sRWIFI.SRVariable.SRShotDesc ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRDesc", sRWIFI.SRVariable.SRDesc ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", sRWIFI.SRVariable.SRRaiseFor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", sRWIFI.SRVariable.SRSelectedfor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", sRWIFI.SRVariable.GuestEmployeeId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestName", sRWIFI.SRVariable.GuestName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestEmail", sRWIFI.SRVariable.GuestEmail ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestContactNo", sRWIFI.SRVariable.GuestContactNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", sRWIFI.SRVariable.GRManagerEmpId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", sRWIFI.SRVariable.Type ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestCompany", sRWIFI.SRVariable.GuestCompany ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PlantID", sRWIFI.SRVariable.PlantID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssetID", sRWIFI.SRVariable.AssetID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", sRWIFI.SRVariable.CategoryID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryTypID", sRWIFI.SRVariable.CategoryTypID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", sRWIFI.SRVariable.Priority ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Source", sRWIFI.SRVariable.Source ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Attachment", sRWIFI.SRVariable.Attachment ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", sRWIFI.SRVariable.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedTo", sRWIFI.SRVariable.AssignedTo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedBy", sRWIFI.SRVariable.AssignedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedOn", sRWIFI.SRVariable.AssignedOn ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Remarks", sRWIFI.SRVariable.Remarks ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", sRWIFI.SRVariable.ProposedResolutionOn ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", sRWIFI.SRVariable.CreatedBy ?? (object)DBNull.Value);



                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";


                        var sridNew = 0;
                        if (sRWIFI.Flag == "I")
                        {
                            sridNew = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);

                            foreach (var item in sRWIFI.AttachmentIds)
                            {
                                var attchObj = _context.Srattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.Srid = sridNew;

                                result.Data = new { srId = sridNew };
                                _context.SaveChanges();
                            }
                        }
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
