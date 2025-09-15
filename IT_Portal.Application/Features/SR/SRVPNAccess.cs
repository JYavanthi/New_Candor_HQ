using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRVPNAccess
    {
        public string? Flag { get; set; }
        public int? SRID { get; set; }
        public int? SRVPNID { get; set; }
        public int? SupportID { get; set; }
        public string? RequestType { get; set; }
        public string? EmpPlant { get; set; }
        public string? AccessPermission { get; set; }
        public string? AccessList { get; set; }
        public string? AccessType { get; set; }
        public DateTime? AccessFromDt { get; set; }
        public DateTime? AccessToDt { get; set; }
        public string? EmpType { get; set; }
        public string? Justification { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public bool? IsActive { get; set; }
        public SRVariable SRVariable { get; set; }

    }
}
