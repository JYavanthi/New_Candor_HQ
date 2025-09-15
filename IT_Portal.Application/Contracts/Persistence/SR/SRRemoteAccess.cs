using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Contracts.Persistence.SR
{
    public class SRRemoteAccess
    {
        public string? Flag { get; set; }
        public int? SRID { get; set; }
        public int? SRAccessID { get; set; }
        public string? RequestType { get; set; }
        public int? SupportID { get; set; }
        public string? SoftName { get; set; }
        public string? SoftVersion { get; set; }
        public string? ReferDocument { get; set; }
        public DateTime? DORemovalAccess { get; set; }
        public bool? SWRemoved { get; set; }
        public bool? ServerAccess { get; set; }
        public string KindAccess { get; set; }
        public string? DowntimeRequired { get; set; }
        public string? TypeServerAccess { get; set; }
        public string? IPDetails { get; set; }
        public string? VenderName { get; set; }
        public string? VenderFocalName { get; set; }
        public string? VenderFocalEmailID { get; set; }
        public DateTime? AccessStartTime { get; set; }
        public DateTime? AccessEndTime { get; set; }
        public string? Justification { get; set; }
        public string? ReferenceDocument { get; set; }
        public DateTime? DORemoteAccess { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable SRVariable { get; set; }
        public List<int> AttachmentIds { get; set; } = new List<int>();
    }
}
