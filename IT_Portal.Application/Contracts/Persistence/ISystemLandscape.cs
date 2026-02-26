using IT_Portal.Application.Features.SystemLandscapeData;
using IT_Portal.Persistence.IT_Models;


namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISystemLandscape
    {
        Task<List<SysLandscape>> GetLandscapes(CommonCR getObj);
    }
}
