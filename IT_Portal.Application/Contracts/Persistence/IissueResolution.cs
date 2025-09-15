using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IissueResolution
    {
        Task<CommonRsult> PostIssueRosulation(SPIssueResolution issueResolution);
        public Task<CommonRsult> updateStatus(ErequestStatus issueResolution);
        public Task<CommonRsult> updateStatusBulk(EbulkIssueStatusChange request);
    }
}
