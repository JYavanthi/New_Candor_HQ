namespace IT_Portal.Domain.IT_Models;

public partial class ContractEmployeeM
{
    public int Id { get; set; }

    public string? EmployeeId { get; set; }

    public int? PayGroup { get; set; }

    public string? Location { get; set; }

    public int? StaffCat { get; set; }

    public int? ReportingGroup { get; set; }

    public int? VendorContractorId { get; set; }

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Gender { get; set; }

    public string? MaritalStatus { get; set; }

    public DateTime? Dob { get; set; }

    public string? Nationality { get; set; }

    public string? Telphone { get; set; }

    public string? Mobile { get; set; }

    public string? EmailId { get; set; }

    public string? BloodGroup { get; set; }

    public string? Pan { get; set; }

    public bool? PhysicallyChallenged { get; set; }

    public string? PhysicallyChallengedDetails { get; set; }

    public string? EmergencyContactPerson { get; set; }

    public string? EmergencyContactAddress1 { get; set; }

    public string? EmergencyContactAddress2 { get; set; }

    public string? EmergencyContactAddress3 { get; set; }

    public string? EmergencyContactTel { get; set; }

    public string? EmergencyContactMob { get; set; }

    public decimal? TotalExp { get; set; }

    public int? LocId { get; set; }

    public string? GradeId { get; set; }

    public int? Dptid { get; set; }

    public int? Dsgid { get; set; }

    public int? Sdptid { get; set; }

    public DateTime? Doj { get; set; }

    public DateTime? Dol { get; set; }

    public string? Rptmngr { get; set; }

    public string? Apprmngr { get; set; }

    public string? Block { get; set; }

    public string? Floor { get; set; }

    public string? Building { get; set; }

    public string? ShiftCode { get; set; }

    public string? RuleCode { get; set; }

    public string? SwipeCount { get; set; }

    public bool? EligibleforOt { get; set; }

    public int? RoleId { get; set; }

    public string? Bandid { get; set; }

    public DateTime? ValidThrough { get; set; }

    public decimal? SalaryAmount { get; set; }

    public string? SalaryFreq { get; set; }

    public bool? WeeklyOff { get; set; }

    public int? IsActive { get; set; }

    public DateTime? InActivatedOn { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public string? SwipeNo { get; set; }

    public int? WorkingDays { get; set; }

    public string? Salarypermonth { get; set; }

    public int? Extn { get; set; }

    public string? CalendarType { get; set; }

    public string? CalendarCode { get; set; }

    public string? CalendarName { get; set; }

    public string? LastApprover { get; set; }

    public string? PendingApprover { get; set; }

    public string? Status { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public bool? Blacklisted { get; set; }

    public virtual ICollection<AuditLogContractor> AuditLogContractors { get; set; } = new List<AuditLogContractor>();

    public virtual ICollection<ContractEmpAttachment> ContractEmpAttachments { get; set; } = new List<ContractEmpAttachment>();
}
