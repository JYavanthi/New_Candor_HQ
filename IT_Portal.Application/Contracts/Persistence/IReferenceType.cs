using IT_Portal.Application.Features;
using IT_Portal.Persistence.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IReferenceType
    {
        Task<List<ReferenceTyp>> GetReferenceType();

        Task<CommonRsult> CRRefrencetyp(SPRefernceTyp refrencetyp);
    }
}
