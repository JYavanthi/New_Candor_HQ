namespace IT_Portal.Domain.IT_Models;

public partial class OfferDetail
{
    public int OfferId { get; set; }

    public string? Title { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Initial { get; set; }

    public string? Gender { get; set; }

    public string PersonalEmailId { get; set; } = null!;

    public string? MobileNo { get; set; }

    public int Age { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string? AddressLine3 { get; set; }

    public string City { get; set; } = null!;

    public int StateId { get; set; }

    public string? PinCode { get; set; }

    public int? PlantId { get; set; }

    public int? PaygroupId { get; set; }

    public int? EmployeeCategoryid { get; set; }

    public int? LocationId { get; set; }

    public int? DesignationId { get; set; }

    public int? RoleId { get; set; }

    public string? InterviewedBy { get; set; }

    public bool AssesmentReport { get; set; }

    public bool Mattest { get; set; }

    public bool SendEmailNotification { get; set; }

    public string? OtherEmails { get; set; }

    public string PresentEmployer { get; set; } = null!;

    public decimal TotalExperience { get; set; }

    public decimal PresentCtc { get; set; }

    public decimal OfferedSalary { get; set; }

    public string? SalaryType { get; set; }

    public string? PackageType { get; set; }

    public string? ReferenceThru { get; set; }

    public string? RefEmployeeNo { get; set; }

    public string? RefDetails { get; set; }

    public string? RecruitmentType { get; set; }

    public string? ReplacingEmployeeNumber { get; set; }

    public string? AdditionalDetails { get; set; }

    public DateTime? TentativeJoiningDate { get; set; }

    public string Status { get; set; } = null!;

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string? OfferNo { get; set; }

    public DateTime? EmailSentDate { get; set; }

    public int? QualificationId { get; set; }

    public int? DepartmentId { get; set; }

    public string? Guid { get; set; }

    public DateTime? PreJoiningEmailSentDate { get; set; }

    public decimal? SalesAmount { get; set; }

    public int? ReportingManagerId { get; set; }

    public int? ApprovingManagerId { get; set; }

    public bool? IsConfidential { get; set; }

    public string? PreJoiningInitiation { get; set; }

    public string? Pfapplicable { get; set; }

    public string? Esiapplicable { get; set; }

    public string? Epsapplicable { get; set; }

    public virtual ICollection<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; } = new List<AppointmentPersonalDetail>();

    public virtual EmployeeMaster? ApprovingManager { get; set; }

    public virtual DesignationMaster? Designation { get; set; }

    public virtual EmpCategoryMaster? EmployeeCategory { get; set; }

    public virtual LocationMaster? Location { get; set; }

    public virtual ICollection<OfferAttachment> OfferAttachments { get; set; } = new List<OfferAttachment>();

    public virtual ICollection<OfferSalaryDetail> OfferSalaryDetails { get; set; } = new List<OfferSalaryDetail>();

    public virtual ICollection<OfferSalaryHeadDetail> OfferSalaryHeadDetails { get; set; } = new List<OfferSalaryHeadDetail>();

    public virtual PaygroupMaster? Paygroup { get; set; }

    public virtual PlantMaster? Plant { get; set; }

    public virtual EmployeeMaster? ReportingManager { get; set; }

    public virtual RoleMaster? Role { get; set; }

    public virtual State State { get; set; } = null!;
}
