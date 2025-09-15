using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IClasifications
    {
        Task<CommonRsult> postClassification(SPClassifications classifications);
    }
}
