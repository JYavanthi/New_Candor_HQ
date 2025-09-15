using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRWIFIAccess
    {
        public string? Flag { get; set; }
        public int? SRID { get; set; }
        public int? SRWIFIID { get; set; }
        public int? SupportID { get; set; }
        public string? RequestType { get; set; }
        public string? SpecifyPlant { get; set; }
        public string? Location { get; set; }
        public string? SpecifyOffice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? Justification { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public SRVariable SRVariable { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();

    }
}
