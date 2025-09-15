using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRCitrixAccess
    {
        public string? Flag { get; set; }
        public int? SRCID { get; set; }
        public int? SRID { get; set; }
        public int? SupportID { get; set; }
        public string? RequestType { get; set; }
        public string? ADID { get; set; }
        public string? ReplaceADID { get; set; }
        public string? AssetDetails { get; set; }
        public string? SoftwareRequired { get; set; }
        public string? IPAddress { get; set; }
        public string? HostName { get; set; }
        public string? EmpType { get; set; }
        public string? Justification { get; set; }
        public string? OUPath { get; set; }
        public bool? IsActive { get; set; }
        public SRVariable SRVariable { get; set; }
    }
}
