using IT_Portal.Application.Contracts.Persistence.SR;
using IT_Portal.Application.Features;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.SR
{
    public class SRRemoteRepository : ISRRemoteAccess
    {
        private readonly MicroLabsDevContext _context;

        public SRRemoteRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetSRRemoteAccess()
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.Sraccesses;
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid
                        select new
                        {
                            SRAccessID = m.SraccessId,
                            RequestType = m.RequestType,
                            SoftName = m.SoftName,
                            SoftVersion = m.SoftVersion,
                            ReferDocument = m.ReferDocument,
                            DORemovalAccess = m.DoremovalAccess,
                            SWRemoved = m.Swremoved,
                            ServerAccess = m.ServerAccess,
                            KindAccess = m.KindAccess,
                            DowntimeRequired = m.DowntimeRequired,
                            TypeServerAccess = m.TypeServerAccess,
                            IPDetails = m.Ipdetails,
                            VenderName = m.VenderName,
                            VenderFocalName = m.VenderFocalName,
                            VenderFocalEmailID = m.VenderFocalEmailId,
                            AccessStartTime = m.AccessStartTime,
                            AccessEndTime = m.AccessEndTime,
                            Justification = m.Justification,
                            ReferenceDocument = m.ReferenceDocument,
                            DORemoteAccess = m.DoremovalAccess,
                            Attachment = m.Attachment
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

        public async Task<CommonRsult> GetSRRemoteAccessById(int Srid)
        {
            var result = new CommonRsult();
            try
            {
                var value = _context.Sraccesses.Where(m => m.Srid == Srid);
                var a = from m in value
                        join employee in _context.Employees on m.CreatedBy.ToString() equals employee.EmployeeNo into emp
                        from employee in emp.DefaultIfEmpty()

                        join sr in _context.VwServiceRequests on m.Srid equals sr.Srid
                        join s in _context.Supports on m.SupportId equals s.SupportId
                        select new
                        {
                            SRAccessID = m.SraccessId,
                            RequestType = m.RequestType,
                            SoftName = m.SoftName,
                            SoftVersion = m.SoftVersion,
                            ReferDocument = m.ReferDocument,
                            DORemovalAccess = m.DoremovalAccess,
                            SWRemoved = m.Swremoved,
                            ServerAccess = m.ServerAccess,
                            KindAccess = m.KindAccess,
                            DowntimeRequired = m.DowntimeRequired,
                            TypeServerAccess = m.TypeServerAccess,
                            IPDetails = m.Ipdetails,
                            VenderName = m.VenderName,
                            VenderFocalName = m.VenderFocalName,
                            VenderFocalEmailID = m.VenderFocalEmailId,
                            AccessStartTime = m.AccessStartTime,
                            AccessEndTime = m.AccessEndTime,
                            Justification = m.Justification,
                            ReferenceDocument = m.ReferenceDocument,
                            DORemoteAccess = m.DoremoteAccess,
                            Attachment = m.Attachment
                                    //SR
                                    ,
                            srid = sr.Srid
                                    ,
                            guestReportingManagerName = sr.GuestReportingManagerName,
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

        public async Task<CommonRsult> PostSRRemoteAccess(SRRemoteAccess access)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRAccess", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", access.Flag ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRID", access.SRID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRAccessID", access.SRAccessID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@RequestType", access.RequestType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SupportID", access.SupportID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoftName", access.SoftName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoftVersion", access.SoftVersion ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReferDocument", access.ReferDocument ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DORemovalAccess", access.DORemovalAccess ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SWRemoved", access.SWRemoved ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ServerAccess", access.ServerAccess ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@KindAccess", access.KindAccess ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DowntimeRequired", access.DowntimeRequired ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TypeServerAccess", access.TypeServerAccess ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IPDetails", access.IPDetails ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenderName", access.VenderName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenderFocalName", access.VenderFocalName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@VenderFocalEmailID", access.VenderFocalEmailID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccessStartTime", access.AccessStartTime ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AccessEndTime", access.AccessEndTime ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Justification", access.Justification ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReferenceDocument", access.ReferenceDocument ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DORemoteAccess", access.DORemoteAccess ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", access.IsActive ?? (object)DBNull.Value);
                    //SR
                    cmd.Parameters.AddWithValue("@SRCode", access.SRVariable.SRCode ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", access.SRVariable.SRRaisedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRDate", access.SRVariable.SRDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRShotDesc", access.SRVariable.SRShotDesc ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRDesc", access.SRVariable.SRDesc ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", access.SRVariable.SRRaiseFor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", access.SRVariable.SRSelectedfor ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", access.SRVariable.GuestEmployeeId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestName", access.SRVariable.GuestName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestEmail", access.SRVariable.GuestEmail ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestContactNo", access.SRVariable.GuestContactNo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", access.SRVariable.GRManagerEmpId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Type", access.SRVariable.Type ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@GuestCompany", access.SRVariable.GuestCompany ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PlantID", access.SRVariable.PlantID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssetID", access.SRVariable.AssetID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryID", access.SRVariable.CategoryID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryTypID", access.SRVariable.CategoryTypID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Priority", access.SRVariable.Priority ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Source", access.SRVariable.Source ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Attachment", access.SRVariable.Attachment ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Status", access.SRVariable.Status ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedTo", access.SRVariable.AssignedTo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedBy", access.SRVariable.AssignedBy ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@AssignedOn", access.SRVariable.AssignedOn ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Remarks", access.SRVariable.Remarks ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", access.SRVariable.ProposedResolutionOn ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CreatedBy", access.SRVariable.CreatedBy ?? (object)DBNull.Value);

                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";


                        if (access.Flag == "I")
                        {
                            var srId = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);

                            result.Data = new { srId = srId };

                            foreach (var item in access.AttachmentIds)
                            {
                                var attchObj = _context.Srattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.Srid = srId;
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
