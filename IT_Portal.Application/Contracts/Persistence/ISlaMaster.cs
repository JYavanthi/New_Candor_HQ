using IT_Portal.Application.Features;

namespace IT_Portal.Application.Contracts.Persistence
{
    public interface ISlaMaster
    {
        Task<CommonRsult> postslamaster(SPSlaMaster slaMaster);
        //here is the code
        Task<List<Esla>> GetSLAlist(int id);
        EworkingDayCalRes getWorkingDays(EworkingDayCalReq EworkingDayCalObj);
        Task<List<Esla>> getSlaByCatId(ErequestPRdate req);
        bool deleteSlaByCatId(int id);
    }
}