using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRUSBAccess
    {
        public string Flag { get; set; }
        public int SRID { get; set; }
        public int SRUSBAID { get; set; }
        public int SupportID { get; set; }
        public string? RequestType { get; set; }
        public string? ADID { get; set; }
        public string? AssestDetails { get; set; }
        public string? Hostname { get; set; }
        public string? DeviceType { get; set; }
        public DateTime? DurationFrom { get; set; }
        public DateTime? DurationTo { get; set; }
        public string? AccessType { get; set; }
        public string? IPAddress { get; set; }
        public string? EmpType { get; set; }
        public string? Justification { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }
        public SRVariable SRVariable { get; set; }
    }
}
