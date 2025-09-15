using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SREmailRequest
    {
        public string? Flag { get; set; }
        public int? SREmailID { get; set; }
        public int? SRID { get; set; }
        public int? SupportID { get; set; }
        public string? Requesttype { get; set; }
        public int? EmpID { get; set; }
        public string? EmpCategory { get; set; }
        public string? EmpName { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public int? Location { get; set; }
        public string? Intercom { get; set; }
        public string? MoblieNo { get; set; }
        public string? ReportManager { get; set; }
        public string? HOD { get; set; }
        public string? CommonEmailID { get; set; }
        public string? PreEmailID { get; set; }
        public string? OutsideComm { get; set; }
        public string? EmailID { get; set; }
        public string? MailGroup { get; set; }
        public string? MailAccess { get; set; }
        public string? Justification { get; set; }
        public string? Description { get; set; }
        public string? EmpType { get; set; }
        public string? GB { get; set; }
        public string? MemberAdded { get; set; }
        public string? empNo { get; set; }
        public string? GroupName { get; set; }
        public bool? IsActive { get; set; }
        public int emailGroupId { get; set; }

        public SRVariable SRVariable { get; set; }
    }

}
