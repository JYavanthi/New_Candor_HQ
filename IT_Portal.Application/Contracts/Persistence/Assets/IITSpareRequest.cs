using IT_Portal.Application.Features;
using IT_Portal.Application.Features.Asset;

namespace IT_Portal.Application.Contracts.Persistence.Assets
{
    public interface IITSpareRequest
    {
        public Task<CommonRsult> PostItSpare(ITSpareRequest request);
        public Task<CommonRsult> GetSpareByID(int ID);
        public Task<CommonRsult> delteSpareByID(int ID);
        public Task<CommonRsult> GetSpareValue();
        public Task<CommonRsult> GetSpareHistory();
        public Task<CommonRsult> GetSpareHistoryBYID(int ID);
    }
}
