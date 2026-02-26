
using IT_Portal.Persistence.IT_Models;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IchatBox
    {
        Task<IssueCommentsBox> getChat(int issueId);
        bool postChat(IssueCommentsBox issueChat);
    }
}
