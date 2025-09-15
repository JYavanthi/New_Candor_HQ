using IT_Portal.Application.Contracts.Persistence.Assets;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.Asset;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.Assets
{
    public class AssetRepository : IAssetRequest
    {
        private readonly MicroLabsDevContext _context;

        public AssetRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> AssetbyId(int ID)
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItassetsDetails.FirstOrDefault(m => m.ItassetId == ID);
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> GetAssets()
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItassetsDetails.OrderByDescending(m => m.ItassetId);
                result.Data = data;
                result.Count = data.Count();
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }

        }



        public async Task<CommonRsult> delteAssetByID(int ID)
        {
            var result = new CommonRsult();
            try
            {
                var entity = _context.ItassetDetails.FirstOrDefault(m => m.ItassetId == ID);
                if (entity != null)
                {
                    _context.ItassetDetails.Remove(entity);
                    _context.SaveChanges();
                }

                result.Message = "Successfully Deleted.";
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<CommonRsult> PostAssets(ITAssetsRequest assets)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ITAssets", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", assets.Flag);
                    cmd.Parameters.AddWithValue("@ITAssetID", assets.ITAssetID);
                    cmd.Parameters.AddWithValue("@Requesttype", assets.Requesttype);
                    cmd.Parameters.AddWithValue("@RequestedBY", assets.RequestedBY);
                    cmd.Parameters.AddWithValue("@RequestedFor", assets.RequestedFor);
                    cmd.Parameters.AddWithValue("@SelectedFor", assets.SelectedFor);
                    cmd.Parameters.AddWithValue("@PlantID", assets.PlantID);
                    cmd.Parameters.AddWithValue("@SupportID", assets.SupportID);
                    cmd.Parameters.AddWithValue("@EmpType", assets.EmpType);
                    cmd.Parameters.AddWithValue("@Guest_Id", assets.Guest_Id);
                    cmd.Parameters.AddWithValue("@Guest_Name", assets.Guest_Name);
                    cmd.Parameters.AddWithValue("@Guest_Email", assets.Guest_Email);
                    cmd.Parameters.AddWithValue("@Guest_RManagerId", assets.Guest_RManagerId);
                    cmd.Parameters.AddWithValue("@Guest_ContactNo", assets.Guest_ContactNo);
                    cmd.Parameters.AddWithValue("@Assettype", assets.Assettype);
                    cmd.Parameters.AddWithValue("@Emp_Id", assets.Emp_Id);
                    cmd.Parameters.AddWithValue("@GxpReq", assets.GxpReq);
                    cmd.Parameters.AddWithValue("@ExistingAsset", assets.ExistingAsset);
                    cmd.Parameters.AddWithValue("@AssetModel", assets.AssetModel);
                    cmd.Parameters.AddWithValue("@AssetSerialNo", assets.AssetSerialNo);
                    cmd.Parameters.AddWithValue("@AssetsWarranty_EndDt", assets.AssetsWarranty_EndDt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@SuggModel", assets.SuggModel);
                    cmd.Parameters.AddWithValue("@Specs_Requirements", assets.Specs_Requirements);
                    cmd.Parameters.AddWithValue("@ApproximateINR", assets.ApproximateINR);
                    cmd.Parameters.AddWithValue("@Justification", assets.Justification);
                    cmd.Parameters.AddWithValue("@HOD_Approval", assets.HOD_Approval);
                    cmd.Parameters.AddWithValue("@IsActive", assets.IsActive);
                    cmd.Parameters.AddWithValue("@Status", assets.Status);
                    cmd.Parameters.AddWithValue("@CreatedBy", assets.CreatedBy);


                    using (var da = new SqlDataAdapter(cmd))
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

        public async Task<CommonRsult> PostAssetApprover(ITAssetApprover assets)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_ASApprover", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", assets.Flag);
                    command.Parameters.AddWithValue("@ITAssetID", assets.ITAssetID);
                    command.Parameters.AddWithValue("@ITSpareID", assets.ITSpareID);
                    command.Parameters.AddWithValue("@ISHOD", assets.ISHOD);
                    command.Parameters.AddWithValue("@ISRPM", assets.ISRPM ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@HOD_ApproverID", assets.HOD_ApproverID);
                    command.Parameters.AddWithValue("@HOD_ApproverRemarks", assets.HOD_ApproverRemarks);
                    command.Parameters.AddWithValue("@RPM_ApproverID", assets.RPM_ApproverID);
                    command.Parameters.AddWithValue("@RPM_ApproverRemarks", assets.RPM_ApproverRemarks);
                    command.Parameters.AddWithValue("@Status", assets.Status ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedBy", assets.CreatedBy.HasValue ? (object)assets.CreatedBy.Value : DBNull.Value);

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

        public async Task<CommonRsult> PostResolApprover(ITAssetResolution resol)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var command = new SqlCommand("IT.sp_ASResolution", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Flag", resol.Flag);
                    command.Parameters.AddWithValue("@ITAssetID", resol.ITAssetID);
                    command.Parameters.AddWithValue("@ITSpareID", resol.ITSpareID);
                    command.Parameters.AddWithValue("@UserRemarks", resol.UserRemarks);
                    command.Parameters.AddWithValue("@ProposedResolDt", resol.ProposedResolDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@ResolDt", resol.ResolDt ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Description", resol.Description);
                    command.Parameters.AddWithValue("@OnHoldReason", resol.OnHoldReason);
                    command.Parameters.AddWithValue("@AssignedTo", resol.AssignedTo);
                    command.Parameters.AddWithValue("@AssignedBy", resol.AssignedBy);
                    command.Parameters.AddWithValue("@Remarks", resol.Remarks);
                    command.Parameters.AddWithValue("@Status", resol.Status);
                    command.Parameters.AddWithValue("@CreatedBy", resol.CreatedBy);
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

        public async Task<CommonRsult> GetAssetsHistory()
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItassetsHistories;
                result.Data = data;
                result.Count = data.Count();
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
        public async Task<CommonRsult> GetAssetsHistoryBYID(int ID)
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItassetsHistories.OrderByDescending(m => m.ItahistoryId).Where(m => m.ItassetId == ID);
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
