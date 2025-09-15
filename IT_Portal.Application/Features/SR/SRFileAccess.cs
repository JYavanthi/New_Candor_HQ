using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRFileAccess
    {
        public string? Flag { get; set; }
        public int? SRID { get; set; }
        public int? SRServerID { get; set; }
        public int? SupportID { get; set; }
        public string? RequestType { get; set; }
        public string? HostName { get; set; }
        public string? IPAddress { get; set; }
        public string? FileServerName { get; set; }
        public string? FolderPath { get; set; }
        public string? Justification { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable SRVariable { get; set; }
    }
}
