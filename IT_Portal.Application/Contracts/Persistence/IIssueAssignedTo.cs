using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IIssueAssignedTo
    {
        Task<CommonRsult> PostIssueAssignedTo(SPIssueAssignedTo issueassignedto);
        Task<CommonRsult> issueForwardTo(EForwardToRequest issueassignedto);
    }
}