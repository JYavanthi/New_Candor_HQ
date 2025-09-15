namespace IT_Portal.Domain.IT_Models;

public partial class Sremail
{
    public int SremailId { get; set; }

    public int SupportId { get; set; }

    public int Srid { get; set; }

    public string? Requesttype { get; set; }

    public int? EmpId { get; set; }

    public string? EmpCategory { get; set; }

    public string? EmpName { get; set; }

    public string? Designation { get; set; }

    public string? Department { get; set; }

    public int? Location { get; set; }

    public string? Intercom { get; set; }

    public string? MoblieNo { get; set; }

    public string? ReportManager { get; set; }

    public string? Hod { get; set; }

    public string? CommonEmailId { get; set; }

    public string? PreEmailId { get; set; }

    public string? OutsideComm { get; set; }

    public string? EmailId { get; set; }

    public string? MailAccess { get; set; }

    public string? MailGroup { get; set; }

    public string? Justification { get; set; }

    public string? Attachment { get; set; }

    public string? Description { get; set; }

    public string? EmpType { get; set; }

    public string? Gb { get; set; }

    public string? MemberAdded { get; set; }

    public string? GroupName { get; set; }

    public bool? IsActive { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDt { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? ModifiedDt { get; set; }
}
