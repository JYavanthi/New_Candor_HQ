using IT_Portal.Application.Contracts.Persistence;
using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace IT_Portal.Persistence.Repositories
{
    public class SupportRespository : ISupportMaster
    {
        private readonly MicroLabsDevContext _context;

        public SupportRespository(MicroLabsDevContext context)
        {
            this._context = context;
        }
        public async Task<CommonRsult> GetSupportById(int id)
        {
            var result = new CommonRsult();
            try
            {
                var data = await _context.Supports.Where(m => m.SupportId == id).FirstOrDefaultAsync();
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
                return result;
            }

        }

        public async Task<CommonRsult> GetSupport()
        {
            var result = new CommonRsult();
            try
            {
                /*var totalcount = await _context.Srvirtuals.CountAsync();*/
                var a = await _context.Supports.ToListAsync();

                result.Data = a;
                /*    result.Count = totalcount;*/
                return result;
            }
            catch (Exception ex)
            {
                result.Type = "E";
                result.Message = ex.Message;
                return result;
            }

        }
        public async Task<CommonRsult> PostSupport(SupportMaster supp)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var supportMaster = new Support
                {
                    SupportId = 0,
                    SupportName = supp.SupportName,
                    ParentId = supp.ParentId,

                    Image = supp.Image,
                    Url = supp.URL,
                    IsRpmreq = supp.RPM,
                    IsHodreq = supp.HOD,
                    IsActive = supp.IsActive,
                    IsVisible = supp.IsVisible,
                    CreatedBy = (int)supp.CreatedBy,
                    CreatedDate = global::System.DateTime.Now
                };

                _context.Supports.Add(supportMaster);

                await _context.SaveChangesAsync();
                result.Type = "S";
                result.Message = "Status Updated Successfully.";
                result.Count = supportMaster.Checklists.Count;
            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<CommonRsult> UpdateSupport(SupportMaster supp)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var updatedata = await _context.Supports.FindAsync(supp.SupportId);
                if (updatedata == null)
                {
                    return new CommonRsult
                    {
                        Type = "E",
                        Message = "Support record not found."
                    };
                }
                updatedata.SupportName = supp.SupportName;
                updatedata.ParentId = supp.ParentId;
                updatedata.IsActive = supp.IsActive;
                updatedata.IsVisible = supp.IsVisible;
                updatedata.IsRpmreq = supp.RPM;
                updatedata.IsHodreq = supp.HOD;
                updatedata.UpdatedBy = supp.CreatedBy;
                updatedata.UpdatedDate = global::System.DateTime.Now;

                await _context.SaveChangesAsync();
                result.Type = "S";
                result.Message = "Status Updated Successfully.";
            }
            catch (Exception e)
            {
                result.Type = "E";
                result.Message = e.Message;
            }
            return result;
        }
        public async Task<CommonRsult> DeleteSupport(int SupportID)
        {
            CommonRsult result = new CommonRsult();
            try
            {
                var deletedata = await _context.Supports.FindAsync(SupportID);
                if (deletedata == null)
                {
                    return new CommonRsult
                    {
                        Type = "E",
                        Message = "Support record not found."
                    };
                }

                _context.Supports.Remove(deletedata);
                await _context.SaveChangesAsync();
                result.Type = "S";
                result.Message = "Support record deleted Successfully.";
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
