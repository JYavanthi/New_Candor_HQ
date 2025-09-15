using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts
{
    public interface ISoftwareVersion
    {
        Task<CommonRsult> PostSoftwareVersion(SoftwareVerison software);
        /*Task<CommonRsult> GetSoftwareVersion();*/
    }

}
