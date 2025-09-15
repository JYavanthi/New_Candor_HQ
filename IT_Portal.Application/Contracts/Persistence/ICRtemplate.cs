using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ICRtemplate
    {
        Task<CommonRsult> CRTemplate(SPCRtemplate crtemplate);
    }
}
