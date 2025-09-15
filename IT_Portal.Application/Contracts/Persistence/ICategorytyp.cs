using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICategorytyp
    {
        Task<CommonRsult> CRcategortyp(SPCategorytyp categorytyp);
    }
}
