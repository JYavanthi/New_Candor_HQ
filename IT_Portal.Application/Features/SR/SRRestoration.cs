using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRRestoration
    {
        public string Flag { get; set; }
        public int? SRID { get; set; }
        public int? SRRID { get; set; }
        public int? SupportID { get; set; }
        public string? RequestType { get; set; }
        public string? OTS { get; set; }
        public string? Descriptions { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ProvideDescription { get; set; }
        public DateTime? Restoration { get; set; }
        public string? TransferingData { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable SRVariable { get; set; }
    }
}
