namespace IT_Portal.Application.Features.RptIssue
{
    public class GetIssueReport
    {
        public int? IssueTicketNo { get; set; }
        public string? Descriptions { get; set; }
        public string? Priority { get; set; }
        public DateTime? ReportedDate { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string? Status { get; set; }
        public string? InitialCategory { get; set; }
        public string? InitialCategoryType { get; set; }
        public string? UserEmpNo { get; set; }
        public string? UserName { get; set; }
        public string? PlantCode { get; set; }
        public string? PlantName { get; set; }
        public string? Paygroup { get; set; }
        public string? EmpoyeeCategory { get; set; }
        public string? AssignedTo { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public string? LastUpdateID { get; set; }
        public string? Resolvedby { get; set; }
        public DateTime? ResolutionDate { get; set; }
        public string? ResolutionRemarks { get; set; }
        public DateTime? ClosureDate { get; set; }
        public string? ClosureBy { get; set; }
        public string? ClosureRemarks { get; set; }
        public DateTime? ResponseSLADate { get; set; }
        public string? ResponseSLAUpdateEngineer { get; set; }
        public string? ResponseSLABreachedReason { get; set; }
        public string? ResponseSLADelayedby { get; set; }
    }
}
