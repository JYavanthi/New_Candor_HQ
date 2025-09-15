using IT_Portal.Application.Features.SR.SRCommon;

namespace IT_Portal.Application.Features.SR
{
    public class SRWindowslogin
    {
        public string? Flag { get; set; }
        public int? SRID { get; set; }
        public int? SRWLID { get; set; }
        public int? SupportID { get; set; }
        public string? RequestType { get; set; }
        public int? EmpID { get; set; }
        public DateTime Date { get; set; }
        public string? Initials { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Designation { get; set; }
        public int? Plant { get; set; }
        public string? PayGroup { get; set; }
        public string? StaffCategory { get; set; }
        public string? Department { get; set; }
        public string? ReportingTO { get; set; }
        public string? HOD { get; set; }
        public string? Role { get; set; }
        public string? UserType { get; set; }
        public string? ChangeOUPath { get; set; }
        public string? Justification { get; set; }
        public DateTime? EIDIndividual { get; set; }
        public string? UserID { get; set; }
        public string? EmpType { get; set; }
        public string? Description { get; set; }
        public bool? IsActive { get; set; }

        public SRVariable SRVariable { get; set; }
    }
}
