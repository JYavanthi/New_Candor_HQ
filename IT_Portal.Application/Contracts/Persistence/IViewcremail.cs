using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface IViewcremail
    {
        Task<CommonRsult> Viewcremail(SPViewcrmail viewcremail);
    }
}
