using AutoMapper;
using IT_Portal.Application.Features.GetHistoryData;
using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.MappingProfile
{
    public class ViewHistoryProfile : Profile
    {
        public ViewHistoryProfile()
        {
            CreateMap<ChangeRequestHistory, ChangeRequestHistoryResultDto>();
            CreateMap<CrapproverHistory, CrapproverHistoryResultDto>();
            CreateMap<CrexecutionPlanHistory, CrexecutionPlanHistoryResultDto>();
        }
    }
}
