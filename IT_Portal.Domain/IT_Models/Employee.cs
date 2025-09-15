namespace IT_Portal.Domain.IT_Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeNo { get; set; } = null!;

    public DateTime? EmpNoGeneratedDate { get; set; }

    public string Status { get; set; } = null!;

    public string EmploymentType { get; set; } = null!;

    public int? AppointmentId { get; set; }

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public string? Initial { get; set; }

    public int PlantId { get; set; }

    public int PaygroupId { get; set; }

    public int EmployeeCategoryid { get; set; }

    public int CountryId { get; set; }

    public int StateId { get; set; }

    public int LocationId { get; set; }

    public int DesignationId { get; set; }

    public int RoleId { get; set; }

    public int DepartmentId { get; set; }

    public int? SubDepartmentId { get; set; }

    public int? ReportingGroupId { get; set; }

    public int ReportingManagerId { get; set; }

    public int ApprovingManagerId { get; set; }

    public bool IsMetroCity { get; set; }

    public int CorrespondingAddressTypeId { get; set; }

    public DateTime DateOfJoining { get; set; }

    public int ProbationPeriod { get; set; }

    public DateTime DateOfConfirmation { get; set; }

    public int NoticePeriod { get; set; }

    public string? OfficialEmailId { get; set; }

    public string? IsSharedEmailId { get; set; }

    public string? RoomOrBlock { get; set; }

    public string? Floor { get; set; }

    public string? Building { get; set; }

    public string? TelephoneNo { get; set; }

    public string? Extension { get; set; }

    public int CreatedById { get; set; }

    public DateTime CreatedDate { get; set; }

    public int ModifiedById { get; set; }

    public DateTime ModifiedDate { get; set; }

    public string? MobileNo { get; set; }

    public decimal? CurrentCtc { get; set; }

    public string? PersonalEmailId { get; set; }

    public bool Active { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? CurrentResponsibilities { get; set; }

    public DateTime? DateOfLeaving { get; set; }

    public string? LeavingType { get; set; }

    public string? CurrentYearKra { get; set; }

    public DateTime? DateOfResignation { get; set; }

    public bool? BulkUpdateDataPushToSap { get; set; }

    public bool? ProfileUpdateDataPushToSap { get; set; }

    public DateTime? ApprenticeCompletionDate { get; set; }

    public int? JobProfileId { get; set; }

    public int? LeavingTypeId { get; set; }

    public int? ContractorId { get; set; }

    //public bool? BulkUpdateDataPushToSap { get; set; }

    //public bool? ProfileUpdateDataPushToSap { get; set; }

    //public DateTime? ApprenticeCompletionDate { get; set; }

    //public int? JobProfileId { get; set; }

    //public int? LeavingTypeId { get; set; }

    //public int? ContractorId { get; set; }

    public virtual AppointmentPersonalDetail? Appointment { get; set; }

    public virtual ICollection<AppointmentAddressDetail> AppointmentAddressDetails { get; set; } = new List<AppointmentAddressDetail>();

    public virtual ICollection<AppointmentAssetDetail> AppointmentAssetDetails { get; set; } = new List<AppointmentAssetDetail>();

    public virtual ICollection<AppointmentAttachmentDetail> AppointmentAttachmentDetails { get; set; } = new List<AppointmentAttachmentDetail>();

    public virtual ICollection<AppointmentEducationDetail> AppointmentEducationDetails { get; set; } = new List<AppointmentEducationDetail>();

    public virtual ICollection<AppointmentFamilyDetail> AppointmentFamilyDetails { get; set; } = new List<AppointmentFamilyDetail>();

    public virtual ICollection<AppointmentLanguageDetail> AppointmentLanguageDetails { get; set; } = new List<AppointmentLanguageDetail>();

    public virtual ICollection<AppointmentNominationDetail> AppointmentNominationDetails { get; set; } = new List<AppointmentNominationDetail>();

    public virtual ICollection<AppointmentPersonalDetail> AppointmentPersonalDetails { get; set; } = new List<AppointmentPersonalDetail>();

    public virtual ICollection<AppointmentStatutoryDetail> AppointmentStatutoryDetails { get; set; } = new List<AppointmentStatutoryDetail>();

    public virtual ICollection<AppointmentWorkExperienceDetail> AppointmentWorkExperienceDetails { get; set; } = new List<AppointmentWorkExperienceDetail>();

    public virtual EmployeeMaster ApprovingManager { get; set; } = null!;

    public virtual AddrTypM CorrespondingAddressType { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual EmployeeMaster CreatedBy { get; set; } = null!;

    public virtual DepartmentMaster Department { get; set; } = null!;

    public virtual DesignationMaster Designation { get; set; } = null!;

    public virtual ICollection<EmployeeAppraisal> EmployeeAppraisals { get; set; } = new List<EmployeeAppraisal>();

    public virtual ICollection<EmployeeAttachment> EmployeeAttachments { get; set; } = new List<EmployeeAttachment>();

    public virtual EmpCategoryMaster EmployeeCategory { get; set; } = null!;

    public virtual ICollection<EmployeeConfirmation> EmployeeConfirmations { get; set; } = new List<EmployeeConfirmation>();

    public virtual ICollection<EmployeeDocument> EmployeeDocuments { get; set; } = new List<EmployeeDocument>();

    public virtual ICollection<EmployeeResignationDetail> EmployeeResignationDetails { get; set; } = new List<EmployeeResignationDetail>();

    public virtual ICollection<EmployeeRetirementDetail> EmployeeRetirementDetails { get; set; } = new List<EmployeeRetirementDetail>();

    public virtual ICollection<EmployeeSalaryDetail> EmployeeSalaryDetails { get; set; } = new List<EmployeeSalaryDetail>();

    public virtual ICollection<EmployeeSalaryHeadDetail> EmployeeSalaryHeadDetails { get; set; } = new List<EmployeeSalaryHeadDetail>();

    public virtual ICollection<EmployeeSalaryHeadPayableDetail> EmployeeSalaryHeadPayableDetails { get; set; } = new List<EmployeeSalaryHeadPayableDetail>();

    public virtual ICollection<EmployeeSalaryHistory> EmployeeSalaryHistories { get; set; } = new List<EmployeeSalaryHistory>();

    public virtual ICollection<EmployeeTerminationDetail> EmployeeTerminationDetails { get; set; } = new List<EmployeeTerminationDetail>();

    public virtual LocationMaster Location { get; set; } = null!;

    public virtual EmployeeMaster ModifiedBy { get; set; } = null!;

    public virtual PaygroupMaster Paygroup { get; set; } = null!;

    public virtual PlantMaster Plant { get; set; } = null!;

    public virtual ReportingGroupM? ReportingGroup { get; set; }

    public virtual EmployeeMaster ReportingManager { get; set; } = null!;

    public virtual RoleMaster Role { get; set; } = null!;

    public virtual State State { get; set; } = null!;

    public virtual SubDeptMaster? SubDepartment { get; set; }
}
