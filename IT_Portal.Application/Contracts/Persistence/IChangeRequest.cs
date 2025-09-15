using IT_Portal.Application.Features;
using IT_Portal.Application.Features.changerequest;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IChangeRequest
    {
        // Task<Output> Functionname(INput)
        Task<CommonRsult> InsertChangeRequest(ChangeRequestSP changerequest);//abstarck 
    }
}