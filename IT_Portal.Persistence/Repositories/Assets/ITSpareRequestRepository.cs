using IT_Portal.Application.Contracts.Persistence.Assets;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.Asset;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories.Assets
{
    public class ITSpareRequestRepository : IITSpareRequest
    {
        private readonly MicroLabsDevContext _context;

        public ITSpareRequestRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }

        public async Task<CommonRsult> GetSpareByID(int ID)
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItspareDetails.FirstOrDefault(m => m.ItspareId == ID);
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> delteSpareByID(int ID)
        {
            var result = new CommonRsult();
            try
            {
                var entity = _context.Itspares.FirstOrDefault(m => m.ItspareId == ID);
                if (entity != null)
                {
                    _context.Itspares.Remove(entity);
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

        public async Task<CommonRsult> GetSpareHistory()
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItspareHistories;
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
        public async Task<CommonRsult> GetSpareHistoryBYID(int ID)
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItspareHistories.OrderByDescending(a => a.CreatedDt).Where(m => m.ItspareId == ID);
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<CommonRsult> GetSpareValue()
        {
            var result = new CommonRsult();
            try
            {
                var data = _context.VwItspareDetails.OrderByDescending(m => m.ItspareId);
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

        public async Task<CommonRsult> PostItSpare(ITSpareRequest request)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ITSpare", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", request.Flag);
                    cmd.Parameters.AddWithValue("@ITSpareID", request.ITSpareID);
                    cmd.Parameters.AddWithValue("@SupportID", request.SupportID);
                    cmd.Parameters.AddWithValue("@PlantID", request.PlantID);
                    cmd.Parameters.AddWithValue("@Requesttype", request.Requesttype);
                    cmd.Parameters.AddWithValue("@RequestedBY", request.RequestedBY);
                    cmd.Parameters.AddWithValue("@RequestedFor", request.RequestedFor);
                    cmd.Parameters.AddWithValue("@SelectedFor", request.SelectedFor);
                    cmd.Parameters.AddWithValue("@EmpType", request.EmpType);
                    cmd.Parameters.AddWithValue("@Guest_Id", request.Guest_Id);
                    cmd.Parameters.AddWithValue("@Guest_Name", request.Guest_Name);
                    cmd.Parameters.AddWithValue("@Guest_Email", request.Guest_Email);
                    cmd.Parameters.AddWithValue("@Guest_RManagerId", request.Guest_RManagerId);
                    cmd.Parameters.AddWithValue("@Guest_ContactNo", request.Guest_ContactNo);
                    cmd.Parameters.AddWithValue("@Emp_Id", request.Emp_Id);
                    cmd.Parameters.AddWithValue("@GxpReq", request.GxpReq);
                    cmd.Parameters.AddWithValue("@Asset_Type", request.Asset_Type);
                    cmd.Parameters.AddWithValue("@Spare_Type", request.Spare_Type);
                    cmd.Parameters.AddWithValue("@Spare_Model", request.Spare_Model);
                    cmd.Parameters.AddWithValue("@Spare_SerialNo", request.Spare_SerialNo);
                    cmd.Parameters.AddWithValue("@Specs_Requirements", request.Specs_Requirements);
                    cmd.Parameters.AddWithValue("@Specification", request.Specification);
                    cmd.Parameters.AddWithValue("@Justification", request.Justification);
                    cmd.Parameters.AddWithValue("@HOD_Approval", request.HOD_Approval);
                    cmd.Parameters.AddWithValue("@Status", request.Status);
                    cmd.Parameters.AddWithValue("@IsActive", request.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", request.CreatedBy);

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
    }
}
