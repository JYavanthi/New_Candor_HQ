using IT_Portal.Application.Features;
using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IReference
    {
        Task<List<Reference>> Getreference();

        Task<CommonRsult> CRRefrence(SPCRrefrence refrence);
    }
}
