using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class Virtual
    {
        public string? Flag { get; set; }
        public int? SRID { get; set; }
        public int? SRVMID { get; set; }
        public int? SupportID { get; set; }
        public string? RequestType { get; set; }
        public string? EmailID { get; set; }
        public string? NoParticipants { get; set; }
        public DateTime? StartDt { get; set; }
        public DateTime? EndDt { get; set; }
        public int? Location { get; set; }
        public string? Department { get; set; }
        public string? Justification { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable? SRVariable { get; set; }

    }
}
