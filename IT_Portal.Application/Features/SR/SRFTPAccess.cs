using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRFTPAccess
    {
        public string Flag { get; set; }
        public int SRID { get; set; }
        public int SRFTPAID { get; set; }
        public int SupportID { get; set; }
        public string? ReqType { get; set; }
        public int? AccessRequire { get; set; }
        public string? AccessType { get; set; }
        public string? AccessPath { get; set; }
        public string? Description { get; set; }
        public string? OwnerEmail { get; set; }
        public string? OwnerPlant { get; set; }
        public string? EmpType { get; set; }
        public string? Justification { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable SRVariable { get; set; }
    }
}
