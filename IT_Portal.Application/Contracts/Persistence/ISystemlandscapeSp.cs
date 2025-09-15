using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISystemlandscapeSp
    {
        Task<CommonRsult> InsertSystemlandscape(SystemlandscapeSP systemlandscape);
    }
}
