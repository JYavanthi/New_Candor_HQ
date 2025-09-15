using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR.Domain;
using IT_Portal.Application.Features.SR.Email;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class serviceMaster : IserviceMaster
    {
        private readonly MicroLabsDevContext _context;
        public serviceMaster(MicroLabsDevContext context)
        {
            this._context = context;
        }


        public async Task<CommonRsult> getServiceSoft(ESRfilterRequest request)
        {

            CommonRsult result = new CommonRsult();
            try
            {
                if (request.srId != 0)
                {
                    var data = new VwSrsoftware();
                    data = await _context.VwSrsoftwares.Where(m => request.srId == m.Srid).FirstOrDefaultAsync();

                    result.Data = data;
                }
                else
                {
                    var data = new List<VwSrsosftware>();
                    data = await _context.VwSrsosftwares.ToListAsync();

                    result.Data = data;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }

        public async Task<CommonRsult> getDomain(ESRfilterRequest request)
        {

            CommonRsult result = new CommonRsult();
            try
            {
                if (request.srId != 0)
                {
                    var data = new VwSrdomain();
                    data = await _context.VwSrdomains.Where(m => request.srId == m.Srid).FirstOrDefaultAsync();

                    result.Data = data;
                }
                else
                {
                    var data = new List<VwSrdomain>();
                    data = await _context.VwSrdomains.ToListAsync();

                    result.Data = data;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
        /*        public async Task<CommonRsult> getApprover(int suppId)
                {
                    CommonRsult result = new CommonRsult();
                    try
                    {
        *//*                var data = new List<Support>();
        *//*               var data =
                            await (from support in _context.Supports
                                   *//*join rpm in _context.Employees on support.Rpm.ToString() equals rpm.EmployeeNo into rpmGroup
                                   from rpm in rpmGroup.DefaultIfEmpty()
                                   join hod in _context.Employees on support.Hod.ToString() equals hod.EmployeeNo into hodGroup
                                   from hod in hodGroup.DefaultIfEmpty()*//*
                                   where support.SupportId == suppId
                                  *//* select new
                                   {
                                       support.Rpm,
                                       RpmName = rpm.FirstName + ' ' +rpm.LastName,
                                       support.Hod,
                                       HodName = hod.FirstName + ' ' +hod.LastName,
                                       support.CreatedBy,
                                       support.CreatedDate,
                                   }).ToListAsync();*//*
                        result.Data = data;
                        return result;
                    }
                    catch (Exception ex)
                    {
                        result.Message = ex.Message;
                        return result;
                    }
                }
        */
        public async Task<CommonRsult> getService(ESRfilterRequest filterRquest)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                var data = await _context.VwServiceRequests.OrderByDescending(m => m.Srid).ToListAsync();

                result.Data = data;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }

        public async Task<CommonRsult> DeleteSRById(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                using (var context = _context)
                {
                    var entity = context.ServiceRequests.FirstOrDefault(x => x.Srid == id);
                    if (entity != null)
                    {
                        context.ServiceRequests.Remove(entity);
                        context.SaveChanges();
                    }

                    result.Message = "Successfully Deleted.";
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
        public async Task<CommonRsult> postService(serviceRequestSoft request)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Flag", 'I');
                    command.Parameters.AddWithValue("@SupportID", request.SupportID);
                    command.Parameters.AddWithValue("@SRSelectedfor", request.SRSelectedfor);
                    command.Parameters.AddWithValue("@SRRaisedBy", request.SRRaisedBy);
                    command.Parameters.AddWithValue("@SRDate", request.SRDate);
                    command.Parameters.AddWithValue("@SRShotDesc", request.SRShotDesc);
                    command.Parameters.AddWithValue("@SRDesc", request.SRDesc);
                    command.Parameters.AddWithValue("@SRRaiseFor", request.SRRaiseFor);
                    command.Parameters.AddWithValue("@GuestEmployeeId", request.GuestEmployeeId);
                    command.Parameters.AddWithValue("@GuestName", request.GuestName);
                    command.Parameters.AddWithValue("@GuestEmail", request.GuestEmail);
                    command.Parameters.AddWithValue("@GuestContactNo", request.GuestContactNo);
                    command.Parameters.AddWithValue("@GuestReportingManagerEmployeeId", request.GuestReportingManagerEmployeeId);
                    command.Parameters.AddWithValue("@Type", request.Type);
                    command.Parameters.AddWithValue("@GuestCompany", request.GuestCompany);
                    command.Parameters.AddWithValue("@PlantID", request.PlantID);
                    command.Parameters.AddWithValue("@AssetID", request.AssetID);
                    command.Parameters.AddWithValue("@CategoryID", request.CategoryID);
                    command.Parameters.AddWithValue("@CategoryTypID", request.CategoryTypID);
                    command.Parameters.AddWithValue("@Priority", request.Priority);
                    command.Parameters.AddWithValue("@Source", request.Source);
                    command.Parameters.AddWithValue("@Attachment", request.Attachment);
                    command.Parameters.AddWithValue("@Status", request.Status);
                    command.Parameters.AddWithValue("@AssignedTo", request.AssignedTo);
                    command.Parameters.AddWithValue("@AssignedBy", request.AssignedBy);
                    command.Parameters.AddWithValue("@AssignedOn", request.AssignedOn);
                    command.Parameters.AddWithValue("@Remarks", request.Remarks);
                    command.Parameters.AddWithValue("@ProposedResolutionOn", request.ProposedResolutionOn);
                    command.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);
                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";

                    }
                }
            }
            catch (Exception)
            {
                result.Type = "E";
                result.Message = "Insert failed";
            }
            return result;
        }


        public async Task<CommonRsult> assignTo(ESRAssignTo request)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.SRassignTo", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SRID", request.SRID);
                    command.Parameters.AddWithValue("@Status", request.Status);
                    command.Parameters.AddWithValue("@AssignedBy", request.AssignedBy);
                    command.Parameters.AddWithValue("@AssignedTo", request.AssignedTo);
                    command.Parameters.AddWithValue("@ModifiedBy", request.ModifiedBy);
                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
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
        public async Task<CommonRsult> saveEmailService(EemailRequest request)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();

                using (var command = new SqlCommand("IT.sp_SREmail", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Flag", request.Flag);
                    command.Parameters.AddWithValue("@SupportID", request.SupportID);
                    command.Parameters.AddWithValue("@SRSelectedfor", request.SRSelectedfor);
                    command.Parameters.AddWithValue("@SRRaisedBy", request.SRRaisedBy);
                    command.Parameters.AddWithValue("@SRDate", request.SRDate);
                    command.Parameters.AddWithValue("@SRShotDesc", request.SRShotDesc);
                    command.Parameters.AddWithValue("@SRDesc", request.SRDesc);
                    command.Parameters.AddWithValue("@SRRaiseFor", request.SRRaiseFor);
                    command.Parameters.AddWithValue("@GuestEmployeeId", request.GuestEmployeeId);
                    command.Parameters.AddWithValue("@GuestName", request.GuestName);
                    command.Parameters.AddWithValue("@GuestEmail", request.GuestEmail);
                    command.Parameters.AddWithValue("@GuestContactNo", request.GuestContactNo);
                    command.Parameters.AddWithValue("@GuestReportingManagerEmployeeId", request.GuestReportingManagerEmployeeId);
                    command.Parameters.AddWithValue("@Type", request.Type);
                    command.Parameters.AddWithValue("@GuestCompany", request.GuestCompany);
                    command.Parameters.AddWithValue("@PlantID", request.PlantID);
                    command.Parameters.AddWithValue("@AssetID", request.AssetID);
                    command.Parameters.AddWithValue("@CategoryID", request.CategoryID);
                    command.Parameters.AddWithValue("@CategoryTypID", request.CategoryTypID);
                    command.Parameters.AddWithValue("@Priority", request.Priority);
                    command.Parameters.AddWithValue("@Source", request.Source);
                    command.Parameters.AddWithValue("@Attachment", request.Attachment);
                    command.Parameters.AddWithValue("@Status", request.Status);
                    command.Parameters.AddWithValue("@AssignedTo", request.AssignedTo);
                    command.Parameters.AddWithValue("@AssignedBy", request.AssignedBy);
                    command.Parameters.AddWithValue("@AssignedOn", request.AssignedOn);
                    command.Parameters.AddWithValue("@Remarks", request.Remarks);
                    command.Parameters.AddWithValue("@ProposedResolutionOn", request.ProposedResolutionOn);
                    command.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);

                    using (var da = new SqlDataAdapter(command))
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
            catch (Exception)
            {
                result.Type = "E";
                result.Message = "Insert failed";
            }
            return result;
        }
        public async Task<CommonRsult> saveDomain(EdomainRequest request)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_SRDomain", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Flag", request.Flag);
                    command.Parameters.AddWithValue("@SRDomainID", request.SRDomainID);
                    command.Parameters.AddWithValue("@SRID", request.SRID);
                    command.Parameters.AddWithValue("@SupportID", request.SupportID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DomainName", request.DomainName ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@usePlant", request.UsePlant ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UseDepart", request.UseDepart ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NoofUser", request.NoofUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PurpDomain", request.PurpDomain ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DueDt", request.DueDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@TypeofSSL", request.TypeofSSL ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@RenewalPeriod", request.RenewalPeriod ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Justification", request.Justification ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DiscontinationDt", request.DiscontinationDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsActive", request.IsActive ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ReqDomainName", request.ReqDomainName);
                    //SR
                    command.Parameters.AddWithValue("@SRCode", request.SRVariable.SRCode);
                    command.Parameters.AddWithValue("@SRRaisedBy", request.SRVariable.SRRaisedBy);
                    command.Parameters.AddWithValue("@SRDate", request.SRVariable.SRDate);
                    command.Parameters.AddWithValue("@SRShotDesc", request.SRVariable.SRShotDesc);
                    command.Parameters.AddWithValue("@SRDesc", request.SRVariable.SRDesc);
                    command.Parameters.AddWithValue("@SRRaiseFor", request.SRVariable.SRRaiseFor);
                    command.Parameters.AddWithValue("@GuestEmployeeId", request.SRVariable.GuestEmployeeId);
                    command.Parameters.AddWithValue("@GuestName", request.SRVariable.GuestName);
                    command.Parameters.AddWithValue("@GuestEmail", request.SRVariable.GuestEmail);
                    command.Parameters.AddWithValue("@GuestContactNo", request.SRVariable.GuestContactNo);
                    command.Parameters.AddWithValue("@GRManagerEmpId", request.SRVariable.GRManagerEmpId);
                    command.Parameters.AddWithValue("@Type", request.SRVariable.Type);
                    command.Parameters.AddWithValue("@GuestCompany", request.SRVariable.GuestCompany);
                    command.Parameters.AddWithValue("@PlantID", request.SRVariable.PlantID);
                    command.Parameters.AddWithValue("@AssetID", request.SRVariable.AssetID);
                    command.Parameters.AddWithValue("@CategoryID", request.SRVariable.CategoryID);
                    command.Parameters.AddWithValue("@CategoryTypID", request.SRVariable.CategoryTypID);
                    command.Parameters.AddWithValue("@Priority", request.SRVariable.Priority);
                    command.Parameters.AddWithValue("@Source", request.SRVariable.Source);
                    command.Parameters.AddWithValue("@Attachment", request.SRVariable.Attachment);
                    command.Parameters.AddWithValue("@Status", request.SRVariable.Status);
                    command.Parameters.AddWithValue("@AssignedTo", request.SRVariable.AssignedTo);
                    command.Parameters.AddWithValue("@SRSelectedfor", request.SRVariable.SRSelectedfor);
                    command.Parameters.AddWithValue("@AssignedBy", request.SRVariable.AssignedBy);
                    command.Parameters.AddWithValue("@AssignedOn", request.SRVariable.AssignedOn);
                    command.Parameters.AddWithValue("@Remarks", request.SRVariable.Remarks);
                    command.Parameters.AddWithValue("@ProposedResolutionOn", request.SRVariable.ProposedResolutionOn);
                    command.Parameters.AddWithValue("@CreatedBy", request.SRVariable.CreatedBy);

                    using (var da = new SqlDataAdapter(command))
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
        public async Task<CommonRsult> submitResolution(ESrSoftwareResolution model)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_SRResolution", con))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Flag", model.Flag);
                    command.Parameters.AddWithValue("@SRResolID", (object)model.SRResolID ?? DBNull.Value);
                    command.Parameters.AddWithValue("@SRID", model.SRID);
                    command.Parameters.AddWithValue("@ResolRemarks", (object)model.ResolRemarks ?? DBNull.Value);
                    command.Parameters.AddWithValue("@UserRemarks", (object)model.UserRemarks ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ProposedResolDt", (object)model.ProposedResolDt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@ResolDt", (object)model.ResolDt ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Description", (object)model.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@OnHoldReason", model.OnHoldReason);
                    command.Parameters.AddWithValue("@status", (object)model.Status ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", (object)model.CreatedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue("@SupportID", (object)model.supportId ?? DBNull.Value);

                    using (var da = new SqlDataAdapter(command))
                    {
                        await Task.Run(() => da.Fill(dt));
                        var data = await _context.EmailGroups.OrderByDescending(m => m.EmailGroupId).FirstOrDefaultAsync();
                        if (!model.empNo.IsNullOrEmpty())
                        {
                            var newArray = model.empNo.Split(',');

                            if (model.supportId == 42)
                            {

                                foreach (var a in newArray)
                                {
                                    var grpMember = new EmailGroupMember
                                    {
                                        EmailGroupId = data.EmailGroupId,
                                        EmpNo = int.Parse(a),
                                        CreatedBy = model.CreatedBy,
                                        CreatedDt = DateTime.Now,
                                        ModifiedBy = model.CreatedBy,
                                        MidifiedDt = DateTime.Now
                                    };

                                    _context.EmailGroupMembers.Add(grpMember);
                                    await _context.SaveChangesAsync();
                                }
                            }
                        }
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


        public async Task<CommonRsult> getResolution(ESRfilterRequest filterRquest)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                if (filterRquest.srId != 0)
                {
                    var data = _context.VwSrresolutions.Where(m => filterRquest.srId == m.Srid).OrderByDescending(a => a.SrresolId).ToList();

                    result.Data = data;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }

        /*public async Task<CommonRsult> getHodBy(int mId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                if (mId != 0)
                {
                    var result1 = from support in _context.Supports
                                            join rpm in _context.Employees on support.Rpm.ToString() equals rpm.EmployeeNo into rpmGroup
                                            from rpm in rpmGroup.DefaultIfEmpty()
                                            join hod in _context.Employees on support.Hod.ToString() equals hod.EmployeeNo into hodGroup
                                            from hod in hodGroup.DefaultIfEmpty()
                                            where support.SupportId == mId
                                            select new
                                            {
                                                SupportId = support.SupportId,
                                                SupportName = support.SupportName,
                                                ParentId = support.ParentId,
                                                IsActive = support.IsActive,
                                                IsVisible = support.IsVisible,
                                                RpmId = support.Rpm,
                                                RpmName = rpm != null ? rpm.FirstName : null,
                                                HodId = support.Hod,
                                                HodName = hod != null ? hod.FirstName : null,  
                                            };
                    var data = result1.FirstOrDefault();
                    result.Data = data;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }
*/
        public async Task<CommonRsult> getHistory(ESRfilterRequest filterRquest)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                if (filterRquest.srId != 0)
                {
                    var data = _context.VwSrcommonHistories.Where(m => filterRquest.srId == m.Srid).OrderByDescending(m => m.ModifiedDt).ToList();

                    result.Data = data;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }

        public async Task<CommonRsult> getResolutionHistory(ESRfilterRequest filterRquest)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                if (filterRquest.srId != 0)
                {
                    var data = _context.SrresolutionHistories.Where(m => filterRquest.srId == m.Srid).ToListAsync();

                    result.Data = data;
                }
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;

        }


        public async Task<CommonRsult> getApprover(string empId)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwGetSrapprovers.Where(m => m.EmployeeNo == empId).ToListAsync();
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> getSRApproved(int id)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var data = await _context.VwSrapprovedDats.Where(m => m.Srid == id).ToListAsync();
                result.Data = data;
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