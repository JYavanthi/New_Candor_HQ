using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IIssueList
    {
        Task<CommonRsult> PostIssueList(SPIssueList issuelist);
    }
}
