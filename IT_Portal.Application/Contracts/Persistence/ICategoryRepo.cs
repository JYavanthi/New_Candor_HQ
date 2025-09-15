using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICategoryRepo
    {
        Task<CommonRsult> CRcategor(SPCategory crcategory);
    }
}
