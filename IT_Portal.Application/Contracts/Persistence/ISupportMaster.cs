using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISupportMaster
    {
        Task<CommonRsult> PostSupport(SupportMaster supp);
        Task<CommonRsult> UpdateSupport(SupportMaster supp);
        Task<CommonRsult> DeleteSupport(int SupportID);
        Task<CommonRsult> GetSupport();

        Task<CommonRsult> GetSupportById(int id);
    }
}
