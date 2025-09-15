using IT_Portal.Application.Features;
using IT_Portal.Application.Features.GetApprover;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IGetApproverEmail
    {
        Task<List<GetApproverEmailResult>> GetApproverEmail(SPGetApproverEmail getApproveemail);

    }
}
