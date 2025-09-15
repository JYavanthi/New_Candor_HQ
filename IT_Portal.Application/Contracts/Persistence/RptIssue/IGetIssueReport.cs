using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence.RptIssue
{
    public interface IGetIssueReport
    {
        public Task<CommonRsult> GetIssueReport(EcrFilterRequest filterRquest);
        public Task<CommonRsult> GetIssueResolutoin(EcrFilterRequest filterRquest);
    }
}
