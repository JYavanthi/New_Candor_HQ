using IT_Portal.Domain.IT_Models;

namespace IT_Portal.Application.Features.GetHistoryData
{
    public class ChangeRequestHistoryResultDto : ChangeRequestHistory
    {
        public string? CrOwnerName { get; set; }
        public string? CreatedName { get; set; }
        public string? ModifiedName { get; set; }
    }
}
