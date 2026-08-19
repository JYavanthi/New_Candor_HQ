using IT_Portal.Application.Contracts.Persistence.Assets;
using IT_Portal.Application.Features;
using IT_Portal.Application.Features.Asset;
using IT_Portal.Persistence.DatabaseContext;
using Microsoft.AspNetCore.Mvc;

namespace IT_Portal.API.Controllers.Asset
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetRequestController : ControllerBase
    {
        private readonly MicroLabsDevContext _context;
        private readonly IAssetRequest _asset;

        public AssetRequestController(MicroLabsDevContext context, IAssetRequest asset)
        {
            this._context = context;
            this._asset = asset;
        }
        [HttpPost("SaveITAssets")]
        public async Task<CommonRsult> PostAssets(ITAssetsRequest assets)
        {
            var data = await _asset.PostAssets(assets);
            return data;
        }
        [HttpGet("GetAssets")]
        public async Task<CommonRsult> GetAssets()
        {
            return await _asset.GetAssets();
        }
        [HttpGet("AssetbyID")]
        public async Task<CommonRsult> AssetbyId(int ID)
        {
            return await _asset.AssetbyId(ID);
        }

        [HttpGet("deleteAssetbyID")]
        public async Task<CommonRsult> delteAssetByID(int ID)
        {
            return await _asset.delteAssetByID(ID);
        }
        [HttpPost("SaveApprover")]
        public async Task<CommonRsult> PostAssets(ITAssetApprover assetApprover)
        {
            var data = await _asset.PostAssetApprover(assetApprover);
            return data;
        }
        [HttpPost("SaveResolution")]
        public async Task<CommonRsult> PostResolApprover(ITAssetResolution resol)
        {
            var data = await _asset.PostResolApprover(resol);
            return data;
        }
        [HttpGet("GetAssetHistory")]
        public async Task<CommonRsult> GetAssetsHistory()
        {
            return await _asset.GetAssetsHistory();
        }
        [HttpGet("GetAssetHistoryBYID")]
        public async Task<CommonRsult> GetAssetsHistoryBYID(int ID)
        {
            return await _asset.GetAssetsHistoryBYID(ID);
        }
    }
}
