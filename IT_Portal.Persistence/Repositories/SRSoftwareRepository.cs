using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.SR.Software;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class SRSoftwareRepository : ISoftware
    {
        private readonly MicroLabsDevContext _context;

        public SRSoftwareRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> PostSoftware(SPSoftware sPSoftware)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_SRSoftware", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", sPSoftware.Flag);
                    cmd.Parameters.AddWithValue("@SRID", sPSoftware.SRID);
                    cmd.Parameters.AddWithValue("@SWID", sPSoftware.SWID);
                    cmd.Parameters.AddWithValue("@SupportID", sPSoftware.SupportID);
                    cmd.Parameters.AddWithValue("@SoftwareType", sPSoftware.SoftwareType);
                    cmd.Parameters.AddWithValue("@SoftwareName", sPSoftware.SoftwareName);
                    cmd.Parameters.AddWithValue("@SoftwareVersionName", sPSoftware.SoftwareVersionName);
                    cmd.Parameters.AddWithValue("@VendorName", sPSoftware.VendorName);
                    cmd.Parameters.AddWithValue("@InstType", sPSoftware.InstType);
                    cmd.Parameters.AddWithValue("@LicenceType", sPSoftware.LicenceType);
                    cmd.Parameters.AddWithValue("@Location", sPSoftware.Location);
                    cmd.Parameters.AddWithValue("@Department", sPSoftware.Department);
                    cmd.Parameters.AddWithValue("@NoOfUers", sPSoftware.NoOfUers);
                    cmd.Parameters.AddWithValue("@NoOfLicence", sPSoftware.NoOfLicence);
                    cmd.Parameters.AddWithValue("@CostPerLicence", sPSoftware.CostPerLicence);
                    cmd.Parameters.AddWithValue("@TotalCost", sPSoftware.TotalCost);
                    cmd.Parameters.AddWithValue("@AMCAppilcable", sPSoftware.AMCAppilcable);
                    cmd.Parameters.AddWithValue("@CostForAMC", sPSoftware.CostForAMC);
                    cmd.Parameters.AddWithValue("@ScopeOfAMC", sPSoftware.ScopeOfAMC);
                    cmd.Parameters.AddWithValue("@IsInstReq", sPSoftware.IsInstReq);
                    cmd.Parameters.AddWithValue("@InstCharge", sPSoftware.InstCharge);
                    cmd.Parameters.AddWithValue("@DtlsOfInst", sPSoftware.DtlsOfInst);
                    cmd.Parameters.AddWithValue("@DtlsOfinstDt", sPSoftware.DtlsOfinstDt);
                    cmd.Parameters.AddWithValue("@TypeOfDev", sPSoftware.TypeOfDev);
                    cmd.Parameters.AddWithValue("@DtlsOfDev", sPSoftware.DtlsOfDev);
                    cmd.Parameters.AddWithValue("@IsInterfaceReq", sPSoftware.IsInterfaceReq);
                    cmd.Parameters.AddWithValue("@InterfaceReq", sPSoftware.InterfaceReq);
                    cmd.Parameters.AddWithValue("@InterfaceWith", sPSoftware.InterfaceWith);
                    cmd.Parameters.AddWithValue("@IsGxpApp", sPSoftware.IsGxpApp);
                    cmd.Parameters.AddWithValue("@NonFunReq", sPSoftware.NonFunReq);
                    cmd.Parameters.AddWithValue("@DtlsOfReq", sPSoftware.DtlsOfReq);
                    cmd.Parameters.AddWithValue("@WhereHosted", sPSoftware.WhereHosted);
                    cmd.Parameters.AddWithValue("@TypeOfWeb", sPSoftware.TypeOfWeb);
                    cmd.Parameters.AddWithValue("@UsageBY", sPSoftware.UsageBY);
                    cmd.Parameters.AddWithValue("@UserAccessFrom", sPSoftware.UserAccessFrom);
                    cmd.Parameters.AddWithValue("@CurrVersion", sPSoftware.CurrVersion);
                    cmd.Parameters.AddWithValue("@TareVersion", sPSoftware.TareVersion);
                    cmd.Parameters.AddWithValue("@Brds", sPSoftware.Brds);
                    cmd.Parameters.AddWithValue("@BusJustification", sPSoftware.BusJustification);
                    cmd.Parameters.AddWithValue("@Justification", sPSoftware.Justification);
                    cmd.Parameters.AddWithValue("@NoofUseruse", sPSoftware.NoofUseruse);

                    cmd.Parameters.AddWithValue("@SRCode", sPSoftware.SRVariable.SRCode);
                    cmd.Parameters.AddWithValue("@SRRaisedBy", sPSoftware.SRVariable.SRRaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", sPSoftware.SRVariable.SRDate);
                    cmd.Parameters.AddWithValue("@SRShotDesc", sPSoftware.SRVariable.SRShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", sPSoftware.SRVariable.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", sPSoftware.SRVariable.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@SRSelectedfor", sPSoftware.SRVariable.SRSelectedfor);
                    cmd.Parameters.AddWithValue("@GuestEmployeeId", sPSoftware.SRVariable.GuestEmployeeId);
                    cmd.Parameters.AddWithValue("@GuestName", sPSoftware.SRVariable.GuestName);
                    cmd.Parameters.AddWithValue("@GuestEmail", sPSoftware.SRVariable.GuestEmail);
                    cmd.Parameters.AddWithValue("@GuestContactNo", sPSoftware.SRVariable.GuestContactNo);
                    cmd.Parameters.AddWithValue("@GRManagerEmpId", sPSoftware.SRVariable.GRManagerEmpId);
                    cmd.Parameters.AddWithValue("@Type", sPSoftware.SRVariable.Type);
                    cmd.Parameters.AddWithValue("@GuestCompany", sPSoftware.SRVariable.GuestCompany);
                    cmd.Parameters.AddWithValue("@PlantID", sPSoftware.SRVariable.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", sPSoftware.SRVariable.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", sPSoftware.SRVariable.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", sPSoftware.SRVariable.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", sPSoftware.SRVariable.Priority);
                    cmd.Parameters.AddWithValue("@Source", sPSoftware.SRVariable.Source);
                    cmd.Parameters.AddWithValue("@Attachment", sPSoftware.SRVariable.Attachment);
                    cmd.Parameters.AddWithValue("@Status", sPSoftware.SRVariable.Status);
                    cmd.Parameters.AddWithValue("@AssignedTo", sPSoftware.SRVariable.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedBy", sPSoftware.SRVariable.AssignedBy);
                    cmd.Parameters.AddWithValue("@AssignedOn", sPSoftware.SRVariable.AssignedOn);
                    cmd.Parameters.AddWithValue("@Remarks", sPSoftware.SRVariable.Remarks);
                    cmd.Parameters.AddWithValue("@ProposedResolutionOn", sPSoftware.SRVariable.ProposedResolutionOn);
                    cmd.Parameters.AddWithValue("@CreatedBy", sPSoftware.SRVariable.CreatedBy);
                    cmd.Parameters.AddWithValue("@IsActive", sPSoftware.IsActive);


                    using (var da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                        result.Type = "S";
                        result.Message = "Insert Successfully";


                        var cridNew = 0;
                        if (sPSoftware.Flag == "I")
                        {
                            cridNew = (int)(_context.ServiceRequests.OrderByDescending(m => m.Srid).FirstOrDefault()?.Srid);

                            foreach (var item in sPSoftware.AttachmentIds)
                            {
                                var attchObj = _context.Srattachments.Where(m => m.AttachId == item).FirstOrDefault();
                                attchObj.Srid = cridNew;

                                _context.SaveChanges();
                            }
                        }
                        result.Data = new { srId = cridNew };
                    }
                }
            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }
    }
}
