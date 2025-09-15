using IT_Portal.Application.Features;
using IT_Portal.Application.Features.Asset;

namespace IT_Portal.Application.Contracts.Persistence.Assets
{
    public interface IAssetRequest
    {
        Task<CommonRsult> PostAssets(ITAssetsRequest assets);
        Task<CommonRsult> GetAssets();
        Task<CommonRsult> AssetbyId(int ID);
        Task<CommonRsult> delteAssetByID(int ID);
        Task<CommonRsult> PostAssetApprover(ITAssetApprover assets);
        Task<CommonRsult> PostResolApprover(ITAssetResolution resol);
        Task<CommonRsult> GetAssetsHistory();
        Task<CommonRsult> GetAssetsHistoryBYID(int ID);
    }
}
