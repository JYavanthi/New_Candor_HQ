namespace IT_Portal.Domain.IT_Models;

public partial class ProdHrOfferDetail
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

    public int QualificationId { get; set; }

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

    public DateTime? DateOfBirth { get; set; }

    public string? PresentDesignation { get; set; }

    public int? ReplacingEmployeeId { get; set; }

    public string? PreviousExperiences { get; set; }

    public string? JobDescriptions { get; set; }

    public string? InterviewerDetails { get; set; }

    public string? InterviewerRemarks { get; set; }

    public string? FinalRemarks { get; set; }

    public DateTime? ExceptionApprovedDate { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public DateOnly? AcceptedDoj { get; set; }

    public string? District { get; set; }

    public int? SecondSignatoryId { get; set; }

    public string? NotAcceptedReason { get; set; }

    public int? SubDepartmentId { get; set; }

    public DateTime? ApprenticeCompletionDate { get; set; }

    public int? JobProfileId { get; set; }

    public int? RequisitionId { get; set; }

    public int? CandidateId { get; set; }

    public string? EmploymentType { get; set; }
}
