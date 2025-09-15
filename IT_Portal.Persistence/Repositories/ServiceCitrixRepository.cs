using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.ServiceCitrix;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IT_Portal.Persistence.Repositories
{
    public class ServiceCitrixRepository : IServiceCitrixList
    {
        private readonly MicroLabsDevContext _context;

        public ServiceCitrixRepository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> PostServiceCitrix(SPServiceCitrix serviceCitrix)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ServiceCitrix", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", serviceCitrix.Flag);
                    cmd.Parameters.AddWithValue("@ServiceCitrixID", serviceCitrix.ServiceCitrixID);
                    cmd.Parameters.AddWithValue("@RaisedBy", serviceCitrix.RaisedBy);
                    cmd.Parameters.AddWithValue("@SRDate", serviceCitrix.SRDate);
                    cmd.Parameters.AddWithValue("@ShotDesc", serviceCitrix.ShotDesc);
                    cmd.Parameters.AddWithValue("@SRDesc", serviceCitrix.SRDesc);
                    cmd.Parameters.AddWithValue("@SRRaiseFor", serviceCitrix.SRRaiseFor);
                    cmd.Parameters.AddWithValue("@PlantID", serviceCitrix.PlantID);
                    cmd.Parameters.AddWithValue("@AssetID", serviceCitrix.AssetID);
                    cmd.Parameters.AddWithValue("@CategoryID", serviceCitrix.CategoryID);
                    cmd.Parameters.AddWithValue("@CategoryTypID", serviceCitrix.CategoryTypID);
                    cmd.Parameters.AddWithValue("@Priority", serviceCitrix.Priority);
                    cmd.Parameters.AddWithValue("@Source", serviceCitrix.Source);
                    cmd.Parameters.AddWithValue("@Service", serviceCitrix.Service);
                    cmd.Parameters.AddWithValue("@Attachment", serviceCitrix.Attachment);
                    cmd.Parameters.AddWithValue("@Status", serviceCitrix.Status);
                    cmd.Parameters.AddWithValue("@CreatedBy", serviceCitrix.CreatedBy);

                    using (var da = new SqlDataAdapter(cmd))
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

        public async Task<CommonRsult> PostServiceCitrixApp(SPServiceCitrixApp serviceCitrixApp)
        {
            CommonRsult result = new CommonRsult();
            try
            {

                DataTable dt = new DataTable();
                var con = (SqlConnection)_context.Database.GetDbConnection();
                using (var cmd = new SqlCommand("IT.sp_ServiceCitrixApp", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Flag", serviceCitrixApp.Flag);
                    cmd.Parameters.AddWithValue("@ServiceCitrixID", serviceCitrixApp.ServiceCitrixID);
                    cmd.Parameters.AddWithValue("@ApprovedLevel1", serviceCitrixApp.ApprovedLevel1);
                    cmd.Parameters.AddWithValue("@ApprovedLevel1By", serviceCitrixApp.ApprovedLevel1By);
                    cmd.Parameters.AddWithValue("@ApprovedLevel1On", serviceCitrixApp.ApprovedLevel1On);
                    cmd.Parameters.AddWithValue("@ApprovedLevel2", serviceCitrixApp.ApprovedLevel2);
                    cmd.Parameters.AddWithValue("@ApprovedLevel2By", serviceCitrixApp.ApprovedLevel2By);
                    cmd.Parameters.AddWithValue("@ApprovedLevel2On", serviceCitrixApp.ApprovedLevel2On);
                    cmd.Parameters.AddWithValue("@ApprovedLevel3", serviceCitrixApp.ApprovedLevel3);
                    cmd.Parameters.AddWithValue("@ApprovedLevel3By", serviceCitrixApp.ApprovedLevel3By);
                    cmd.Parameters.AddWithValue("@ApprovedLevel3On", serviceCitrixApp.ApprovedLevel3By);
                    cmd.Parameters.AddWithValue("@AssignedTo", serviceCitrixApp.AssignedTo);
                    cmd.Parameters.AddWithValue("@AssignedOn", serviceCitrixApp.AssignedBy);
                    cmd.Parameters.AddWithValue("@Remarks", serviceCitrixApp.Remarks);
                    cmd.Parameters.AddWithValue("@ModifiedBy", serviceCitrixApp.ModifiedBy);

                    using (var da = new SqlDataAdapter(cmd))
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
    }
}