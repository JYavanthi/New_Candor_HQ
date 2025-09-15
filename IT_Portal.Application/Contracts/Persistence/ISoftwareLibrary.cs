using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISoftwareLibrary
    {
        Task<CommonRsult> PostSoftwareLibrary(SoftwareLibrary library);

    }
}
